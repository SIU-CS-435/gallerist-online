using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.Controllers.GameControllerHelpers;
using TeamJAMiN.GalleristComponentEntities;

namespace TeamJAMiN.Controllers.GameLogicHelpers
{
    public static class TurnManager
    {
        public static void SetCurrentAction(this GameTurn turn, GameActionState state, string location)
        {
            if (turn.CurrentAction != null)
            {
                turn.AddCompletedAction(turn.CurrentAction);
            }
            turn.CurrentAction = new GameAction { State = state, Location = location, isExecutable = true };
        }

        public static void AddPendingAction(this GameTurn turn, GameAction action)
        {
            var temp = turn.PendingActions;
            temp.Add(action);
            turn.PendingActions = temp;
        }

        public static void RemovePendingAction(this GameTurn turn, GameAction action)
        {
            var temp = turn.PendingActions;
            temp.Remove(action);
            turn.PendingActions = temp;
        }

        public static void AddCompletedAction(this GameTurn turn, GameAction action)
        {
            if(action.isComplete == false)
            {
                action.isComplete = true;
                var temp = turn.CompletedActions;
                temp.Add(action);
                turn.CompletedActions = temp;
            }
        }

        public static void SetupFirstTurn(this Game newGame)
        {
            var firstTurn = new GameTurn { TurnNumber = 0, Type = GameTurnType.Setup, CurrentAction = new GameAction { State = GameActionState.GameStart } };
            newGame.Turns.Add(firstTurn);
            (new ActionManager(newGame)).DoAction(GameActionState.Pass);

        }
        public static void SetupNextTurn(this Game game)
        {
            var oldTurn = game.CurrentTurn;
            if(oldTurn.KickedOutPlayer != null)
            {
                game.SetupKickedOutTurn(oldTurn);
            }
            else
            {
                game.SetupTurn(oldTurn);
            }
        }

        public static void SetupKickedOutTurn(this Game game, GameTurn oldTurn)
        {
            //todo add turnstart action state, then add completed turn start action
            //todo add chooselocation to pending actions
            var newTurn = new GameTurn { TurnNumber = oldTurn.TurnNumber + 1, CurrentPlayer = oldTurn.KickedOutPlayer, CurrentAction = new GameAction { State = GameActionState.ChooseLocation } };
            newTurn.AddCompletedAction(newTurn.CurrentAction);
            game.CurrentPlayerId = oldTurn.KickedOutPlayer.Id;
            game.Turns.Add(newTurn);
        }

        public static void SetupTurn(this Game game, GameTurn oldTurn)
        {
            game.SetNextPlayer();
            var newTurn = new GameTurn { TurnNumber = oldTurn.TurnNumber + 1, CurrentPlayer = game.CurrentPlayer, CurrentAction = new GameAction { State = GameActionState.ChooseLocation } };
            newTurn.AddCompletedAction(newTurn.CurrentAction);
            game.Turns.Add(newTurn);
        }
    }
}