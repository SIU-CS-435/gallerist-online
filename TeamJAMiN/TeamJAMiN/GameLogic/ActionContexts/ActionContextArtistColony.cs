using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.GalleristComponentEntities;

namespace TeamJAMiN.Controllers.GameLogicHelpers
{
    public class ArtistColonyContext : ActionContext, IMoneyTransactionContext
    {
        public ArtistColonyContext(Game game)
            : base(game, new Dictionary<GameActionState, Type> {
                { GameActionState.ChooseLocation, typeof(ChooseLocation) },
                { GameActionState.ArtistColony, typeof(ArtistColony) },
                { GameActionState.ArtistDiscover, typeof(ArtistDiscover) },
                { GameActionState.ArtBuy, typeof(ArtBuy) },
                { GameActionState.Pass, typeof(Pass) }
            })
        { }

        public int GetCost()
        {
            if (_state is IMoneyTransactionState)
            {
                var transaction = (IMoneyTransactionState)_state;
                return transaction.GetCost(this);
            }
            else
                return -1;
        }

        public bool IsMoneyTransaction()
        {
            return _state is IMoneyTransactionState;
        }
    }

    public class ArtistColony : LocationAction
    {
        public ArtistColony()
        {
            Name = GameActionState.ArtistColony;
            location = PlayerLocation.ArtistColony;
            TransitionTo = new HashSet<GameActionState> { GameActionState.ArtistDiscover, GameActionState.ArtBuy };
        }
    }

    public class ArtBuy : ActionState, IMoneyTransactionState
    {
        public ArtBuy()
        {
            Name = GameActionState.ArtBuy;
            TransitionTo = new HashSet<GameActionState> {  GameActionState.Pass };
        }

        public int GetCost(ActionContext context)
        {
            var artist = context.Game.GetArtistByLocationString(context.Action.Location);
            if(context.Game.CurrentPlayer.Commission == artist)
            {
                return artist.InitialFame;
            }
            return artist.Fame;
        }

        public override void DoAction<ArtistColonyContext>(ArtistColonyContext context)
        {
            var game = context.Game;
            var artist = context.Game.GetArtistByLocationString(context.Action.Location);
            var type = artist.ArtType;
            var art = context.Game.GetArtFromStack(type);
            art.Artist = artist;
            context.Game.MoveFromArtStackToPlaza(art.Type);
            if (context.Game.CurrentPlayer.Commission != artist)
            {
                artist.AvailableArt -= 1;
            }
            var cost = GetCost(context);
            //todo let player pay with influence
            context.Game.CurrentPlayer.Money -= cost;
            artist.Fame += art.Fame;
            artist.Fame += context.Game.CurrentPlayer.GetGalleryVisitorCountByType(VisitorTicketType.collector);
            //todo let player increase fame using influence
            context.Game.CurrentPlayer.Art.Add(art);
            //todo give player tickets
            //todo remove comission if applicable
            //todo see if player should gain reputation tile
            context.Game.SetupNextArt(type);
            //todo replace below with a pass button or something.
            context.Game.CurrentTurn.AddCompletedAction(context.Action);
            context.DoAction(GameActionState.Pass);
        }
        //todo add action location parameter in case this is called for an action other than the current action.
        //check if artist is a celebrity
        //todo check if player has room to exhibit art
        public override bool IsValidGameState(ActionContext context)
        {
            if (!context.Action.ValidateArtistLocationString())
            {
                return false;
            }
            var artist = context.Game.GetArtistByLocationString(context.Action.Location);
            if (!artist.IsDiscovered)
            {
                return false;
            }
            if(artist.AvailableArt == 0)
            {
                return false;
            }
            return base.IsValidGameState(context);
        }
    }

    public class ArtistDiscover : ActionState
    {
        public ArtistDiscover()
        {
            Name = GameActionState.ArtistDiscover;
            TransitionTo = new HashSet<GameActionState> { GameActionState.Pass };
        }

        public override void DoAction<ArtistColonyContext>(ArtistColonyContext context)
        {
            var game = context.Game;
            var artist = context.Game.GetArtistByLocationString(context.Action.Location);
            artist.IsDiscovered = true;
            if(artist.Category == ArtistCategory.red)
            {
                var newCollector = new GameVisitor { Location = GameVisitorLocation.Plaza, Type = VisitorTicketType.collector };
                game.Visitors.Add(newCollector);
            }
            context.Game.CurrentPlayer.Commission = artist;
            artist.AvailableArt -= 1;
            //todo give player artist bonus
            //todo replace below with a pass button or something.
            context.Game.CurrentTurn.AddCompletedAction(context.Action);
            context.DoAction(GameActionState.Pass);
        }
        public override bool IsValidGameState(ActionContext context)
        {
            if (!context.Action.ValidateArtistLocationString())
            {
                return false;
            }
            var artist = context.Game.GetArtistByLocationString(context.Action.Location);
            if (artist.IsDiscovered)
            {
                return false;
            }
            if (context.Game.CurrentPlayer.Commission != null)
            {
                return false;
            }
            return base.IsValidGameState(context);
        }
    }
}