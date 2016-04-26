using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.GalleristComponentEntities;
using TeamJAMiN.Models.GameViewHelpers;

namespace TeamJAMiN.Models.ComponentViewModels
{
    public class InternationalMarketViewModel
    {
        public InternationalMarketViewModel(string userName, Game game)
        {
            IsActivePlayer = FormHelper.IsActivePlayer(userName, game);
            IsValidActionState = game.CurrentTurn.CurrentAction.State == GameActionState.InternationalMarket;

            Game = game;

            SetTiles(game);
            SetAuctionLocations(userName, game);
        }

        public bool IsActivePlayer { get; private set; }
        public bool IsValidActionState { get; private set; }

        public Game Game { get; private set; }

        public Dictionary<ArtType,List<ReputationTileViewModel>> Tiles { get; private set; }
        public Dictionary<string,List<AuctionLocationViewModel>> AuctionLocations { get; private set; }

        public List<GameReputationTileLocation> Columns = new List<GameReputationTileLocation>
            { GameReputationTileLocation.OneInfluence, GameReputationTileLocation.TwoInfluence, GameReputationTileLocation.ThreeInfluence };

        public List<ArtType> TypeOrder = new List<ArtType> { ArtType.digital, ArtType.photo, ArtType.sculpture, ArtType.painting }; //reputation tile rows
        public List<string> AuctionRows = new List<string> { "Auction1", "Auction3", "Auction6" };

        private void SetTiles(Game game)
        {
            var result = new List<List<ReputationTileViewModel>>();
            foreach ( ArtType row in TypeOrder)
            {
                var rowList = new List<ReputationTileViewModel>();
                foreach(GameReputationTileLocation column in Columns)
                {
                    var tile = game.ReputationTiles.FirstOrDefault(r => r.Row == row && r.Column == column);
                    if (tile != null)
                        rowList.Add(new ReputationTileViewModel(tile));
                    else
                        rowList.Add(null);
                }
                result.Add(rowList);
            }
            Tiles = TypeOrder.Zip(result, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);
        }
        private void SetAuctionLocations(string userName, Game game)
        {
            var rowHeader = new List<string> { "money-1", "money-2", "money-3" }; //the css class for the row header (displays the appropriate amount of money)
            var result = new List<List<AuctionLocationViewModel>>();
            foreach (string row in AuctionRows)
            {
                var rowList = new List<AuctionLocationViewModel>();
                foreach (GameReputationTileLocation column in Columns)
                {
                    rowList.Add(new AuctionLocationViewModel(userName, game, column.ToString(), row));
                }
                result.Add(rowList);
            }
            AuctionLocations = rowHeader.Zip(result, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);

        }

    }
}