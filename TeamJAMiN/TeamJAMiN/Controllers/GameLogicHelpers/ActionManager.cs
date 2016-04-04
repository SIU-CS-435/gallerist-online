using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.Controllers.GameControllerHelpers;
using TeamJAMiN.GalleristComponentEntities;

namespace TeamJAMiN.Controllers.GameLogicHelpers
{
    public class ActionManager
    {
        ActionContext _context;
        public Game Game { get; set; }
        public Dictionary<GameActionState, Type> ActionToContextType = new Dictionary<GameActionState, Type>
            {
                { GameActionState.MediaCenter, typeof(MediaCenterContext) },
                { GameActionState.Promote, typeof(MediaCenterContext) },
                { GameActionState.Hire, typeof(MediaCenterContext) },
                { GameActionState.ArtistColony, typeof(ArtistColonyContext) },
                { GameActionState.ArtistDiscover, typeof(ArtistColonyContext) },
                { GameActionState.ArtBuy, typeof(ArtistColonyContext) },
                { GameActionState.SalesOffice, typeof(SalesOfficeContext) },
                { GameActionState.ContractDraft, typeof(SalesOfficeContext) },
                { GameActionState.ContractDraw, typeof(SalesOfficeContext) },
                { GameActionState.ContractToPlayerBoard, typeof(SalesOfficeContext) },
                { GameActionState.ChooseLocation, typeof(SetupContext) },
                { GameActionState.GameStart, typeof(SetupContext) },
                { GameActionState.Pass, typeof(SetupContext) }
            };

        public ActionManager(Game game)
        {
            Game = game;
            Type contextType = ActionToContextType[game.CurrentActionState];
            _context = (ActionContext)Activator.CreateInstance(contextType, game) ;
        }

        public bool DoAction(GameActionState action, string actionLocation = "")
        {
            if (!IsValidAction(action))
            {
                return false;
            }
            Game.CurrentActionLocation = actionLocation;
            if (!_context.NameToState.ContainsKey(action))
            {
                Type contextType = ActionToContextType[action];
                _context = (ActionContext)Activator.CreateInstance(contextType, Game);
            }
            _context.DoAction(action);
            return true;
        }

        public bool IsValidAction(GameActionState action)
        {
            return _context.IsValidTransition(action);
        }

    }

    public class ActionContext
    {
        ActionState _state;
        public Dictionary<GameActionState, Type> NameToState;
        public Game Game { get; set; }

        public GameActionState State
        {
            get
            {
                return _state.Name;
            }
            set
            {
                _state = (ActionState)Activator.CreateInstance(NameToState[value]);
            }
        }

        protected ActionContext(Game game, Dictionary<GameActionState, Type> NameToState)
        {
            Game = game;
            this.NameToState = NameToState;
            State = Game.CurrentActionState;
        }

        public bool IsValidTransition(GameActionState state)
        {
            if(!_state.CanTransitionTo(state, this))
            {
                return false;
            }
            return true;
        }

        public void DoAction(GameActionState action)
        {
            if ( IsValidTransition(action) )
            {
                State = action;
                _state.DoAction(this);
            }
        }
    }
    public class SetupContext : ActionContext
    {
        public SetupContext(Game game) 
            : base(game, new Dictionary<GameActionState, Type>
            {
                { GameActionState.ChooseLocation, typeof(ChooseLocation) },
                { GameActionState.Pass, typeof(Pass) },
                { GameActionState.GameStart, typeof(GameStart) }
            })
        { }

    }
    public abstract class ActionState
    {
        public GameActionState Name;
        public HashSet<GameActionState> TransitionTo;
        public abstract void DoAction<TContext>(TContext context)
            where TContext: ActionContext;
        public abstract bool CanTransitionTo<TContext>(GameActionState action, TContext context)
            where TContext : ActionContext;
    }
    public class GameStart : ActionState
    {
        public GameStart()
        {
            Name = GameActionState.GameStart;
            TransitionTo = new HashSet<GameActionState> { GameActionState.Pass };
        }

        public override void DoAction<ActionContext>(ActionContext context)
        {

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


    public class ChooseLocation : ActionState
    {
        public ChooseLocation()
        {
            Name = GameActionState.ChooseLocation;
            TransitionTo = new HashSet<GameActionState>
                { GameActionState.SalesOffice, GameActionState.InternationalMarket, GameActionState.MediaCenter, GameActionState.ArtistColony };
        }

        public override void DoAction<ActionContext>(ActionContext context)
        { }

        public override bool CanTransitionTo<ActionContext>(GameActionState action, ActionContext context)
        {
            if (!TransitionTo.Contains(action))
            {
                return false;
            }
            var game = context.Game;
            var currentPlayerLocation = game.Players.First(p => p.Id == context.Game.CurrentPlayerId).GalleristLocation;
            if (currentPlayerLocation == (PlayerLocation)Enum.Parse(typeof(PlayerLocation), action.ToString()))
            {
                return false;
            }
            return true;
        }
    }
    public class Pass : ActionState
    {
        public Pass()
        {
            Name = GameActionState.Pass;
            TransitionTo = new HashSet<GameActionState> { };
        }

        public override void DoAction<ActionContext>(ActionContext context)
        {
            context.Game.UpdatePlayerOrder();
            context.Game.CurrentActionState = GameActionState.ChooseLocation;
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
}