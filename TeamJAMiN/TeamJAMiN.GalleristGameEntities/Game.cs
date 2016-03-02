using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamJAMiN.GalleristComponentEntities
{
    public partial class Game
    {
        public Game()
        {
            Artists = new HashSet<GameArtist>();
            Art = new HashSet<GameArt>();
            ReputationTiles = new HashSet<GameReputationTile>();
            Contracts = new HashSet<GameContract>();
            Players = new HashSet<Player>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfPlayers { get; set; }
        public int TurnLength { get; set; }
        public HashSet<GameArtist> Artists { get; set; }
        public HashSet<GameArt> Art { get; set; }
        public HashSet<GameReputationTile> ReputationTiles { get; set; }
        public HashSet<GameContract> Contracts { get; set; }
        public HashSet<GameVisitor> Visitors { get; set; }

        public HashSet<Player> Players { get; set; }
    }
}
