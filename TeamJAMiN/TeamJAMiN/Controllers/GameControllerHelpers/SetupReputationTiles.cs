using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.GalleristComponentEntities;

namespace TeamJAMiN.Controllers.GameControllerHelpers
{
    public static class ReputationTileSetup
    {
        public static List<TemplateReputationTile> chooseReputationTiles(this List<TemplateReputationTile> reputationTileList, int playerCount = 4)
        {
            reputationTileList = reputationTileList.Shuffle().Take(16).ToList();
            return reputationTileList;
        }

        public static void assignReputationTiles(this Game newGame)
        {
            int row = 0, column = 0, count = 3;
            if (newGame.Players.Count() < 3)
            {
                count = 2;
                newGame.ReputationTiles = new HashSet<GameReputationTile>(newGame.ReputationTiles.Shuffle().Take(12));
            }
            var tileList = newGame.ReputationTiles.ToList();
            foreach (ArtType type in Enum.GetValues(typeof(ArtType)))
            {
                foreach (GameReputationTile tile in tileList.Skip(count*row).Take(count))
                {
                    tile.Row = type;
                    if (column < count)
                    {
                        if (column == 0)
                            tile.Column = GameReputationTileLocation.ThreeInfluence;
                        else if (column == 1)
                            tile.Column = GameReputationTileLocation.OneInfluence;
                        else
                            tile.Column = GameReputationTileLocation.TwoInfluence;
                        column++;
                    }                    
                }
                column = 0;
                row++;
            }
            var startTiles = tileList.Skip(4 * count).Take(4).ToList(); ;
            for (int j = 0; j < 4; j++)
            {
                if (j == 0)
                    startTiles[j].Column = GameReputationTileLocation.ArtistColony;
                else if (j == 1)
                    startTiles[j].Column = GameReputationTileLocation.MediaCenter;
                else if (j == 2)
                    startTiles[j].Column = GameReputationTileLocation.InternationalMarket;
                else
                    startTiles[j].Column = GameReputationTileLocation.SalesOffice;
            }
        }
    }
}