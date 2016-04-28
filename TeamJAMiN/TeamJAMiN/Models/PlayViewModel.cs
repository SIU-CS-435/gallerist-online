using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.GalleristComponentEntities;
using TeamJAMiN.Models.ComponentViewModels;

namespace TeamJAMiN.Models
{
    public class PlayViewModel
    {
        public Game Game { get; private set; }

        public SalesOfficeViewModel SalesOfficeModel { get; private set; }
        public InternationalMarketViewModel InternationalMarketModel { get; private set; }

        private List<PlayerLocation> ActionList = new List<PlayerLocation> { PlayerLocation.SalesOffice, PlayerLocation.ArtistColony, PlayerLocation.InternationalMarket, PlayerLocation.MediaCenter };
        public List<ActionSpaceViewModel> LocationViewModels { get; private set; }

        private List<PlayerColor> TopGalleryOrder = new List<PlayerColor> { PlayerColor.yellow, PlayerColor.purple };
        public List<PlayerGalleryViewModel> TopGalleryModels { get; private set; }

        private List<PlayerColor> BottomGalleryOrder = new List<PlayerColor> { PlayerColor.yellow, PlayerColor.purple };

    }

}
}