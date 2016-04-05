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
            var action = (GameActionState)Enum.Parse(typeof(GameActionState), location.ToString());
            var manager = new ActionManager(game);
            return manager.IsValidAction(action);
        }

        public static string Highlight(this Game game, GameActionState state)
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            var highlight = "";
            if (game.CurrentActionState == state && game.CurrentPlayer.UserId == userId)
            {
                highlight = "highlight";
            }
            return highlight;
        }
    }
}