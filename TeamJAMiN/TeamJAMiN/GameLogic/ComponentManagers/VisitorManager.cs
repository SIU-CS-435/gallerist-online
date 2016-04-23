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
        public static void UpdateVisitorLocation(this GameVisitor visitor, GameVisitorLocation location, PlayerColor color)
        {
            visitor.Location = location;
            visitor.PlayerGallery = color;
        }

        public static int GetGalleryVisitorCountByType(this Player player, VisitorTicketType type)
        {
            return player.Game.Visitors.Where(v => v.PlayerGallery == player.Color && v.Location == GameVisitorLocation.Gallery && v.Type == type).Count();
        }

        public static int GetPlazaVisitorCountByType(this Game game, VisitorTicketType type)
        {
            return game.Visitors.Where(v => v.Type == type && v.Location == GameVisitorLocation.Plaza).Count();
        }

        public static void MoveVisitorPlazaToGallery(this Player player, VisitorTicketType type)
        {
            var visitor = player.Game.Visitors.FirstOrDefault(v => v.Type == type && v.Location == GameVisitorLocation.Plaza);
            if(visitor != null)
            {
                visitor.UpdateVisitorLocation(GameVisitorLocation.Gallery, player.Color);
            }
        }
        public static int GetBagVisitorCountByType(this Game game, VisitorTicketType type)
        {
            return game.Visitors.Where(v => v.Type == type && v.Location == GameVisitorLocation.Bag).Count();
        }

        public static void MoveVisitorBagToGallery(this Player player, VisitorTicketType type)
        {
            var visitor = player.Game.Visitors.FirstOrDefault(v => v.Type == type && v.Location == GameVisitorLocation.Bag);
            if (visitor != null)
            {
                visitor.UpdateVisitorLocation(GameVisitorLocation.Gallery, player.Color);
            }
        }
        public static bool ValidateVisitorLocationString(string location)
        {
            var locationParams = location.Split(':');
            if (locationParams.Count() != 2)
            {
                return false;
            }
            if (!Enum.IsDefined(typeof(ArtType), locationParams[0]))
            {
                return false;
            }
            if (!Enum.IsDefined(typeof(GameVisitorLocation), locationParams[1]))
            {
                return false;
            }
            return true;
        }
        public static VisitorTicketType GetVisitorTypeFromLocationString(string location)
        {
            var locationParams = location.Split(':');
            return (VisitorTicketType)Enum.Parse(typeof(VisitorTicketType), locationParams[0]);
        }
        public static GameVisitorLocation GetVisitorLocationFromLocationString(string location)
        {
            var locationParams = location.Split(':');
            return (GameVisitorLocation)Enum.Parse(typeof(GameVisitorLocation), locationParams[1]);
        }
        public static PlayerColor GetPlayerColorFromVisitorLocationString(string location)
        {
            var locationParams = location.Split(':');
            return (PlayerColor)Enum.Parse(typeof(PlayerColor), locationParams[3]);
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