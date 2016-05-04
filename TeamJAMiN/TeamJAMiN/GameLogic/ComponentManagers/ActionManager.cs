using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.GalleristComponentEntities;

namespace TeamJAMiN.Controllers.GameLogicHelpers
{
    public enum PendingPosition
        {
            first,last
        }
    public static class ActionManager
    {
        
        public static GameAction GetTicketAction(VisitorTicketType type)
        {
            GameAction action = new GameAction();
            switch (type)
            {
                case VisitorTicketType.collector:
                    action.State = GameActionState.GetTicketCollector;
                    break;
                case VisitorTicketType.vip:
                    action.State = GameActionState.GetTicketVip;
                    break;
                case VisitorTicketType.investor:
                    action.State = GameActionState.GetTicketInvestor;
                    break;
                default:
                    action = null;
                    break;
            }
            return action;
        }

        public static bool IsValidAction(this GameAction action, Game game)
        {
            var invoker = new ActionContextInvoker(game);
            return invoker.IsValidGameState(action);
        }
    }
}