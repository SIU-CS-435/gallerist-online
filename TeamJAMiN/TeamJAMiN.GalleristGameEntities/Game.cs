using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [Display(Name = "Pick a name for your game")]
        public string Name { get; set; }

        [Display(Name = "Maximum number of players")]
        [Range(1, 4, ErrorMessage ="Please enter a number between 1 and 4")]
        [DefaultValue(4)]
        public int MaxNumberOfPlayers { get; set; }

        [Display(Name = "Maximum time per turn in minutes")]
        [Range(1,1440, ErrorMessage ="Please enter a value between 1 and 1440")]
        [DefaultValue(60)]
        public int TurnLength { get; set; }

        [DefaultValue(false)]
        public bool IsCompleted { get; set; }

        [DefaultValue(false)]
        public bool IsStarted { get; set; }

        public virtual HashSet<GameArtist> Artists { get; set; }
        public virtual HashSet<GameArt> Art { get; set; }
        public virtual HashSet<GameReputationTile> ReputationTiles { get; set; }
        public virtual HashSet<GameContract> Contracts { get; set; }
        public virtual HashSet<GameVisitor> Visitors { get; set; }
        public virtual HashSet<Player> Players { get; set; }
        public int AvailableVipTickets { get; set; }
        public int AvailableInvestorTickets { get; set; }
        public int AvailableCollectorTickets { get; set; }
    }
}
