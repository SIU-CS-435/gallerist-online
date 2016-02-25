using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamJAMiN.GalleristComponentEntities
{
    public class Game
    {
        public int playerCount { get; set; }
        public string artistsData { get; set; }
        public Dictionary<ArtType, Artist> redArtists { get; set; }
        public Dictionary<ArtType, Artist> blueArtists { get; set; }
        public Dictionary<ArtType, List<Art>> art { get; set; }
        public List<ReputationTile> reputationTiles { get; set; }
        public List<Contract> contracts { get; set; }

    }
}
