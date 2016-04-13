using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.Controllers.GameLogicHelpers;
using TeamJAMiN.GalleristComponentEntities;

namespace TeamJAMiN.Models.GameViewHelpers
{
    public static class ActionHighlighter
    {
        public static bool IsValidLocation(this Game game, PlayerLocation location)
        {
            var state = (GameActionState)Enum.Parse(typeof(GameActionState), location.ToString());
            var action = new GameAction { State = state, Location = game.CurrentTurn.CurrentAction.Location };
            var manager = new ActionManager(game);
            return manager.IsValidTransition(action);
        }

        public static string Highlight(this Game game, GameActionState state)
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            var highlight = "";
            if (game.CurrentTurn.CurrentAction.State == state && game.CurrentPlayer.UserId == userId)
            {
                highlight = "highlight";
            }
            return highlight;
        }
    }
}