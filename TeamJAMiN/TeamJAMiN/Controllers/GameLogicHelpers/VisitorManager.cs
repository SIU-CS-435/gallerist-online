using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.GalleristComponentEntities;

namespace TeamJAMiN.Controllers.GameLogicHelpers
{
    public static class VisitorManager
    {
        public static List<GameVisitor> DrawVisitors(this Game game, int count)
        {
            return game.Visitors.Where(v => v.Location == GameVisitorLocation.Bag).OrderBy(v => v.Order).Take(count).ToList();
        }
        public static void VisitorToArtStack(this Game game, ArtType type, int count)
        {
            game.DrawVisitors(count).UpdateVisitorLocation(TypeLocationMap.TypeToLocation[type]);            
        }
        public static void MoveFromArtStackToPlaza(this Game game, ArtType type)
        {
            game.Visitors.Where(v => v.Location == TypeLocationMap.TypeToLocation[type]).UpdateVisitorLocation(GameVisitorLocation.Plaza);
        }
        public static void UpdateVisitorLocation(this IEnumerable<GameVisitor> list, GameVisitorLocation location)
        {
            foreach (GameVisitor v in list)
            {
                v.Location = location;
            }
        }
        public static void UpdateVisitorLocation(this IEnumerable<GameVisitor> list, GameVisitorLocation location, PlayerColor color)
        {
            foreach (GameVisitor v in list)
            {
                v.Location = location;
                v.PlayerGallery = color;
            }
        }

        public static int GetGalleryVisitorCountByType(this Player player, VisitorTicketType type)
        {
            return player.Game.Visitors.Where(v => v.PlayerGallery == player.Color && v.Location == GameVisitorLocation.Gallery && v.Type == type).Count();
        }

    }
    public static class TypeLocationMap
    {
        public static Dictionary<ArtType, GameVisitorLocation> TypeToLocation = new Dictionary<ArtType, GameVisitorLocation>
        {
            { ArtType.photo, GameVisitorLocation.Photo },
            { ArtType.painting, GameVisitorLocation.Painting },
            { ArtType.digital, GameVisitorLocation.Digital },
            { ArtType.sculpture, GameVisitorLocation.Sculpture },
        };
    }
}