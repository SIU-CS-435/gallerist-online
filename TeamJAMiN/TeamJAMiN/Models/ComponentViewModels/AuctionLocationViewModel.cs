using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.Controllers.GameLogicHelpers;
using TeamJAMiN.GalleristComponentEntities;
using TeamJAMiN.Models.GameViewHelpers;

namespace TeamJAMiN.Models.ComponentViewModels
{
    public class AuctionLocationViewModel
    {
        public AuctionLocationViewModel(string userName, Game game, string column, string row)
        {
            IsActivePlayer = FormHelper.IsActivePlayer(userName, game);
            IsValidActionState = game.CurrentTurn.CurrentAction.State == GameActionState.InternationalMarket;

            Game = game;
            Column = column;
            Row = row;
            SetActionLocation(row, column);
            SetAuctionClass(ActionLocation);
        }

        public Game Game { get; private set; }

        public string ActionLocation { get; private set; }
        public GameActionState State = GameActionState.Auction;

        public bool IsActivePlayer { get; private set; }
        public bool IsValidActionState { get; private set; }

        private string Column { get; set; }
        private string Row { get; set; }

        public string AuctionClass { get; private set; }

        private void SetActionLocation(string row, string col)
        {
            ActionLocation = row + ':' + col;
        }

        private void SetAuctionClass(string actionLocation)
        {
            var bonus = AuctionManager.GetBonusByAuctionLocationString(actionLocation);
            AuctionClass = IconCss.BonusClass[bonus];
        }
    }
}