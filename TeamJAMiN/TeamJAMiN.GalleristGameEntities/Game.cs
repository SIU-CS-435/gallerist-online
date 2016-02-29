using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamJAMiN.GalleristComponentEntities
{
    public class Game
    {
        public Game()
        {
            Artists = new HashSet<GameArtist>();
            Art = new HashSet<GameArt>();
            ReputationTiles = new HashSet<ReputationTile>();
            Contracts = new HashSet<Contract>();
            Players = new HashSet<Player>();
        }

        public int Id { get; set; }
        public HashSet<GameArtist> Artists { get; set; }
        public HashSet<GameArt> Art { get; set; }
        public HashSet<ReputationTile> ReputationTiles { get; set; }
        public HashSet<Contract> Contracts { get; set; }
        public HashSet<Player> Players { get; set; }
    }
}
