using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.GalleristComponentEntities;

namespace TeamJAMiN.Controllers.GameLogicHelpers
{
    public static class AuctionManager
    {
        public static Dictionary<string, int> InfluenceByColumn = new Dictionary<string, int>()
        {
            { "OneInfluence", 1 },
            { "ThreeInfluence", 3 },
            { "TwoInfluence", 2 }
        };

        public static string GetAuctionColumn(this Game game)
        {
            var currentLocation = game.CurrentActionLocation;
            var locationParams = currentLocation.Split(':');
            return locationParams[1];
        }

        public static string GetAuctionRow(this Game game)
        {
            var currentLocation = game.CurrentActionLocation;
            var locationParams = currentLocation.Split(':');
            return locationParams[0];
        }

        public static int GetInfluenceByColumn(this Game game, string column)
        {
            if (InfluenceByColumn.ContainsKey(column))
            {
                return InfluenceByColumn[column];
            }
            return 0;
        }
    }
}