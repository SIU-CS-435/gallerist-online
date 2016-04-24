using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.GalleristComponentEntities;

namespace TeamJAMiN.Models.GameViewHelpers
{
    public static class FormHelper
    {
        public static bool IsActivePlayer(string userName, Game game)
        {
            return game.CurrentPlayer.UserName == userName;
        }
    }
}