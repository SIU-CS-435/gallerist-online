using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.Controllers.GameControllerHelpers;
using TeamJAMiN.GalleristComponentEntities;

namespace TeamJAMiN.Controllers.GameLogicHelpers
{
    public class ActionContextInvoker
    {
        ActionContext _context;
        public Game Game { get; set; }


        public ActionContextInvoker(Game game)
        {
            Game = game;
            _context = ActionContextFactory.GetContext(game.CurrentTurn.CurrentAction.State, game);
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
                _context = ActionContextFactory.GetContext(newAction.State, Game);
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
            var context = ActionContextFactory.GetContext(action.State, Game);
            return context.IsValidGameState(action);
        }

    }
}