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
            { GameActionState.InternationalMarket, typeof(InternationalMarketContext) },
            { GameActionState.Reputation, typeof(InternationalMarketContext) },
            { GameActionState.Auction, typeof(InternationalMarketContext) },
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
            _context = GetContext(game.CurrentTurn.CurrentAction.State);
        }

        private ActionContext GetContext(GameActionState state)
        {
            Type contextType = ActionToContextType[state];
            return (ActionContext)Activator.CreateInstance(contextType, Game);
        }

        public bool DoAction(GameActionState state, string actionLocation = "")
        {
            var newAction = new GameAction { State = state, Location = actionLocation, isExecutable = true };

            if (!IsValidTransition(newAction))
            {
                return false;
            }

            Game.CurrentTurn.SetCurrentAction(newAction.State, newAction.Location);

            if (!_context.NameToState.ContainsKey(newAction.State))
            {
                _context = GetContext(newAction.State);
            }
            _context.DoAction(newAction);
            Game.CurrentTurn.AddCompletedAction(newAction);

            var nextAction = Game.CurrentTurn.PendingActions.FirstOrDefault(a => a.isExecutable == true);
            if (nextAction != null)
            {
                Game.CurrentTurn.RemovePendingAction(nextAction);
                this.DoAction(nextAction.State, nextAction.Location);
                Game.CurrentTurn.AddCompletedAction(nextAction);
            }
            return true;
        }

        public bool IsValidTransition(GameAction action)
        {
            if (Game.CurrentTurn.PendingActions.Any(a => a.State == action.State))
            {
                return true;
            }
            return _context.IsValidTransition(action) && IsValidGameState(action);
        }

        public bool IsValidTransition(GameActionState state)
        {
            if (Game.CurrentTurn.PendingActions.Any(a => a.State == state))
            {
                return true;
            }
            var action = new GameAction { State = state };
            return _context.IsValidTransition(action) && IsValidGameState(action);
        }

        private bool IsValidGameState(GameAction action)
        {
            var context = GetContext(action.State);
            return context.IsValidGameState(action);
        }

    }

    public class ActionContext
    {
        ActionState _state;
        public Dictionary<GameActionState, Type> NameToState;
        public Game Game { get; set; }
        public GameAction Action { get; set; }

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
            Action = game.CurrentTurn.CurrentAction;
            this.NameToState = NameToState;
            State = Game.CurrentTurn.CurrentAction.State;
        }

        public bool IsValidTransition(GameAction action)
        {
            return _state.IsValidTransition(action, this);
        }

        public bool IsValidGameState(GameAction action)
        {
            State = action.State;
            Action = action;
            return _state.IsValidGameState(this);
        }

        public void DoAction(GameActionState state)
        {
            Action = new GameAction { State = state, isExecutable = true, Location = "" };
            State = Action.State;
            _state.DoAction(this);
        }

        public void DoAction(GameAction action)
        {
            Action = action;
            State = action.State;
            _state.DoAction(this);
        }
    }
    
    public abstract class ActionState
    {
        public GameActionState Name;
        public HashSet<GameActionState> TransitionTo;
        public abstract void DoAction<TContext>(TContext context)
            where TContext: ActionContext;
        public virtual bool IsValidTransition<TContext>(GameAction action, TContext context)
            where TContext : ActionContext
        {
            if (TransitionTo.Contains(action.State))
            {

                return true;
            }

            return false;
        }
        public virtual bool IsValidGameState(ActionContext context)
        {
            return true;
        }
    }
}