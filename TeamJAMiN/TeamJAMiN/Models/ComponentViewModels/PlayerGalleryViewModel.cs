using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.GalleristComponentEntities;
using TeamJAMiN.Models.GameViewHelpers;

namespace TeamJAMiN.Models.ComponentViewModels
{
    public class PlayerGalleryViewModel
    {
        public PlayerGalleryViewModel(Game game, PlayerColor color)
        {
            Game = game;
            Color = color;

            HasPlayer = game.Players.Any(p => p.Color == color);
            EmptyGalleryCssClass = HasPlayer ? "" : "unused-gallery-region";
            IsGalleryFirst = color == PlayerColor.yellow || color == PlayerColor.purple;

            GalleryVisitors = game.VisitorByPlayerAndLocation(color, GameVisitorLocation.Gallery);
            GalleryInvestorCount = GalleryVisitors.Where(v => v.Type == VisitorTicketType.investor).Count();
            GalleryCollectorCount = GalleryVisitors.Where(v => v.Type == VisitorTicketType.collector).Count();
            GalleryVipCount = GalleryVisitors.Where(v => v.Type == VisitorTicketType.vip).Count();
            GalleryVisitorCounts = new List<int> { GalleryInvestorCount, GalleryCollectorCount, GalleryVipCount };

            LobbyVisitors = game.VisitorByPlayerAndLocation(color, GameVisitorLocation.Lobby);
            LobbyInvestorCount = LobbyVisitors.Where(v => v.Type == VisitorTicketType.investor).Count();
            LobbyCollectorCount = LobbyVisitors.Where(v => v.Type == VisitorTicketType.collector).Count();
            LobbyVipCount = LobbyVisitors.Where(v => v.Type == VisitorTicketType.vip).Count();
            LobbyVisitorCounts = new List<int> { LobbyInvestorCount, LobbyCollectorCount, LobbyVipCount };

        }

        public Game Game { get; private set; }
        public PlayerColor Color { get; private set; }

        public bool HasPlayer { get; private set; }
        public string EmptyGalleryCssClass { get; private set; }
        public bool IsGalleryFirst { get; private set; }

        public List<GameVisitor> GalleryVisitors { get; private set; }
        public List<int> GalleryVisitorCounts { get; private set; }
        public int GalleryInvestorCount { get; private set; }
        public int GalleryCollectorCount { get; private set; }
        public int GalleryVipCount { get; private set; }

        public List<GameVisitor> LobbyVisitors { get; private set; }
        public List<int> LobbyVisitorCounts { get; private set; }
        public int LobbyInvestorCount { get; private set; }
        public int LobbyCollectorCount { get; private set; }
        public int LobbyVipCount { get; private set; }

    }
}