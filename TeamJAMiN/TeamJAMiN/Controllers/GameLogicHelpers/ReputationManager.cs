using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.GalleristComponentEntities;

namespace TeamJAMiN.Controllers.GameLogicHelpers
{
    public static class ReputationManager
    {
        public static Dictionary<GameReputationTileLocation, int> InfluenceByColumn = new Dictionary<GameReputationTileLocation, int>()
        {
            { GameReputationTileLocation.OneInfluence, 1 },
            { GameReputationTileLocation.ThreeInfluence, 3 },
            { GameReputationTileLocation.TwoInfluence, 2 }
        };

        public static GameReputationTileLocation GetReputationColumn(this Game game)
        {
            var currentLocation = game.CurrentActionLocation;
            var locationParams = currentLocation.Split(':');
            return (GameReputationTileLocation)Enum.Parse(typeof(GameReputationTileLocation),locationParams[1]);
        }

        public static ArtType GetReputationRow(this Game game)
        {
            var currentLocation = game.CurrentActionLocation;
            var locationParams = currentLocation.Split(':');
            return (ArtType)Enum.Parse(typeof(ArtType), locationParams[0]);
        }

        public static GameReputationTile GetReputationTileByLocation(this Game game, ArtType row, GameReputationTileLocation column)
        {
            return game.ReputationTiles.Where(r => r.Column == column && r.Row == row).Single();
        }

        public static int GetInfluenceByColumn(this Game game, GameReputationTileLocation column)
        {
            if(InfluenceByColumn.ContainsKey(column))
            {
                return InfluenceByColumn[column];
            }
            return 0;
        }
    }
}