﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.GalleristComponentEntities;

namespace TeamJAMiN.Models.ComponentViewModels
{
    public class PlayerBoardViewModel
    {
        public PlayerBoardViewModel(string userName, Player player)
        {
            Player = player;
            ComissionDisplayString = player.Commission != null ? 
                player.Commission.ArtType.ToString() + " " + player.Commission.Category.ToString() : "No Commissioned Art";

            SetUnemplayedAssitants(userName, player);
            SetExhibitingArt(player);
            SetReputationLocations(userName, player);
            ContractView = new PlayerContractsViewModel(userName, player);
        }

        private List<GameReputationTileLocation> TopRowLocations = new List<GameReputationTileLocation>
            { GameReputationTileLocation.Influence, GameReputationTileLocation.Money, GameReputationTileLocation.Fame };
        private List<GameReputationTileLocation> BottomRowLocations = new List<GameReputationTileLocation>
            { GameReputationTileLocation.Visitor, GameReputationTileLocation.Tickets, GameReputationTileLocation.Assistant };

        private void SetReputationLocations(string userName, Player player)
        {
            var result = new List<ReputationTileLocationViewModel>();
            foreach(GameReputationTileLocation location in TopRowLocations)
            {
                result.Add(new ReputationTileLocationViewModel(userName, player, location));
            }
            TopRowTileLocationModels = result;
            result = new List<ReputationTileLocationViewModel>();
            foreach (GameReputationTileLocation location in BottomRowLocations)
            {
                result.Add(new ReputationTileLocationViewModel(userName, player, location));
            }
            BottomRowTileLocationModels = result;
        }

        private void SetExhibitingArt(Player player)
        {
            var result = new List<PlayerArtViewModel>();
            var artList = player.Art.Where(a => a.IsSold == false);
            foreach(GameArt art in artList)
            {
                result.Add(new PlayerArtViewModel(art));
            }
            ExhibitingArt = result;
        }

        private void SetUnemplayedAssitants(string userName, Player player)
        {
            var result = new List<UnemployedAssistantViewModel>();
            for(int i = 0; i < 8; i++)
            {
                result.Add(new UnemployedAssistantViewModel(userName, player, i));
            }
            UnemployedAssistants = result;
        }

        public Player Player { get; private set; }
        public string ComissionDisplayString { get; private set; }
        public List<UnemployedAssistantViewModel> UnemployedAssistants { get; private set; }
        public List<PlayerArtViewModel> ExhibitingArt { get; private set; }
        public List<ReputationTileLocationViewModel> TopRowTileLocationModels { get; private set; }
        public List<ReputationTileLocationViewModel> BottomRowTileLocationModels { get; private set; }
        public PlayerContractsViewModel ContractView { get; private set; }
    }
}