using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.GalleristComponentEntities;

namespace TeamJAMiN.GameControllerHelpers
{
    public static class ReputationTileSetup
    {
        public static List<ReputationTile> chooseReputationTiles(this List<ReputationTile> reputationTileList, int playerCount = 4)
        {
            reputationTileList = reputationTileList.Shuffle().ToList();
            return reputationTileList.Take(12).ToList();
        }
    }
}