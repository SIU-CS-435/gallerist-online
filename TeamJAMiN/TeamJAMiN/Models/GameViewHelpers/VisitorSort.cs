using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.GalleristComponentEntities;

namespace TeamJAMiN.Models.GameViewHelpers
{
    public static class VisitorSort
    {
        public static List<GameVisitor> VisitorByPlayer(this Game game, PlayerColor color)
        {
            return game.Visitors.Where(v => v.PlayerGallery == color).ToList();
        }
        public static List<GameVisitor> VisitorByLocation(this Game game, GameVisitorLocation location)
        {
            return game.Visitors.Where(v => v.Location == location).ToList();
        }
        public static List<GameVisitor> VisitorByPlayerAndLocation(this Game game, PlayerColor color, GameVisitorLocation location)
        {
            return game.Visitors.Where(v => v.PlayerGallery == color && v.Location == location).ToList();
        }
    }
}