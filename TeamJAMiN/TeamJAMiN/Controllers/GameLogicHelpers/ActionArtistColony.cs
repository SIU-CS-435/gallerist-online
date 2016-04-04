using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.GalleristComponentEntities;

namespace TeamJAMiN.Controllers.GameLogicHelpers
{
    public class ArtistColonyContext : ActionContext
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
    }

    public class ArtistColony : ActionState
    {
        public PlayerLocation location = PlayerLocation.ArtistColony;
        public ArtistColony()
        {
            Name = GameActionState.ArtistColony;
            TransitionTo = new HashSet<GameActionState> { GameActionState.ArtistDiscover, GameActionState.ArtBuy };
        }

        public override void DoAction<ArtistColonyContext>(ArtistColonyContext context)
        {
            var game = context.Game;
            game.CurrentActionState = Name;
            var kickedPlayer = game.Players.FirstOrDefault(p => p.GalleristLocation == location);
            if (kickedPlayer != null)
            {
                game.KickedOutPlayerId = kickedPlayer.Id;
            }
            game.CurrentPlayer.GalleristLocation = location;
        }
        public override bool CanTransitionTo<ActionContext>(GameActionState action, ActionContext context)
        {
            if (TransitionTo.Contains(action))
            {
                return true;
            }

            return false;
        }
    }

    public class ArtBuy : ActionState
    {
        public ArtBuy()
        {
            Name = GameActionState.ArtBuy;
            TransitionTo = new HashSet<GameActionState> {  GameActionState.Pass };
        }

        public override void DoAction<ArtistColonyContext>(ArtistColonyContext context)
        {
            //todo move setting current action state to wrapper method
            var game = context.Game;
            game.CurrentActionState = Name;
            var artist = context.Game.GetArtistByLocationString(context.Game.CurrentActionLocation);
            var type = artist.ArtType;
            var art = context.Game.GetArtFromStack(type);
            art.Artist = artist;
            context.Game.MoveFromArtStackToPlaza(art.Type);
            //todo let player pay with influence
            context.Game.CurrentPlayer.Money -= artist.Fame;
            artist.Fame += art.Fame;
            //todo add number of collectors in gallery to artist fame
            //todo let player increase fame using influence
            //todo check if player has commission for artist
            context.Game.CurrentPlayer.Art.Add(art);
            //todo give player tickets
            //todo see if player should gain reputation tile
            //todo replace below with a pass button or something.
            context.Game.SetupNextArt(type);
            context.DoAction(GameActionState.Pass);
        }
        //todo validate location string
        //todo check if artist is discovered
        //todo check if artist has available art
        //todo check if player has room to exhibit art
        public override bool CanTransitionTo<ActionContext>(GameActionState action, ActionContext context)
        {
            if (TransitionTo.Contains(action))
            {
                return true;
            }

            return false;
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
            //todo move setting current action state to wrapper method
            var game = context.Game;
            game.CurrentActionState = Name;
            var artist = context.Game.GetArtistByLocationString(context.Game.CurrentActionLocation);
            artist.IsDiscovered = true;
            context.Game.CurrentPlayer.Commission = artist;
            //todo give player artist bonus
            //todo replace below with a pass button or something.
            context.DoAction(GameActionState.Pass);
        }
        //todo validate location string
        //todo check is artist is already discovered
        //todo check if player already has commission
        public override bool CanTransitionTo<ActionContext>(GameActionState action, ActionContext context)
        {
            if (TransitionTo.Contains(action))
            {
                return true;
            }

            return false;
        }
    }
}