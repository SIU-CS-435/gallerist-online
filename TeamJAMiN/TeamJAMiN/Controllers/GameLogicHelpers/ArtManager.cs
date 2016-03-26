using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.GalleristComponentEntities;

namespace TeamJAMiN.Controllers.GameLogicHelpers
{
    public static class ArtManager
    {
        public static void SetupNextArt(this Game game, ArtType type)
        {
            var art = game.Art.Where(a => a.Type == type).OrderBy(a => a.Order).FirstOrDefault();
            if(art != null)
            {
                game.VisitorToArtStack(art.Type, art.NumTickets);
            }
        }
    }
}