using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.GalleristComponentEntities;

namespace TeamJAMiN.Controllers.GameLogicHelpers
{
    public class ActionContext
    {
        protected ActionState _state;
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

        public bool IsValidGameState(GameAction action)
        {
            State = action.State;
            Action = action;
            return _state.IsValidGameState(this);
        }

        public void DoAction(GameActionState state)
        {
            Action = new GameAction { State = state, IsExecutable = true, Location = "" };
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
        public virtual void DoAction<TContext>(TContext context)
            where TContext : ActionContext
        {
            if(TransitionTo.Count <= 1 )
            {
                context.Game.CurrentTurn.AddPendingActions(TransitionTo.ToList(), GameActionStatus.Optional, false);
            }
            else
            {
                context.Game.CurrentTurn.AddPendingActions(TransitionTo.ToList(), context.Action, GameActionStatus.OptionalExclusive, false);
            }
        }
        public virtual bool IsValidGameState(ActionContext context)
        {
            return true;
        }
    }
}