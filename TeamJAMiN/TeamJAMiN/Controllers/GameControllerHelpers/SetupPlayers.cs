using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.GalleristComponentEntities;

namespace TeamJAMiN.Controllers.GameControllerHelpers
{
    public static class SetupPlayers
    {
        public static void assignColors(this Game newGame)
        {
            var rPlayers = newGame.Players.Shuffle();
            var colorEnum = Enum.GetValues(typeof(PlayerColor)).GetEnumerator();
            foreach (Player player in rPlayers)
            {
                colorEnum.MoveNext();
                player.Color = (PlayerColor)colorEnum.Current;
            }
        }
    }
}