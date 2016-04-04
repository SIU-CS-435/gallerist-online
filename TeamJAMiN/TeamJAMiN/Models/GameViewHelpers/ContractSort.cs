using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.GalleristComponentEntities;

namespace TeamJAMiN.Models.GameViewHelpers
{
    public static class ContractSort
    {
        public static bool HasContractAtLocation(this Player player, GameContractLocation location)
        {
            if(player.Contracts.FirstOrDefault( c => c.Location == location ) != null)
            {
                return true;
            }
            return false;
        }

        public static GameContract GetContractAtLocation(this Player player, GameContractLocation location)
        {
            return player.Contracts.FirstOrDefault(c => c.Location == location);
        }
    }
}