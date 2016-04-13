using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
            Turns = new HashSet<GameTurn>();
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

        public DateTime CreatedTime { get; set; }

        public DateTime? StartTime { get; set; }

        [DefaultValue(false)]
        public bool IsCompleted { get; set; }

        [DefaultValue(false)]
        public bool IsStarted { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public virtual HashSet<GameTurn> Turns { get; set; }
        public virtual HashSet<GameArtist> Artists { get; set; }
        public virtual HashSet<GameArt> Art { get; set; }
        public virtual HashSet<GameReputationTile> ReputationTiles { get; set; }
        public virtual HashSet<GameContract> Contracts { get; set; }
        public virtual HashSet<GameVisitor> Visitors { get; set; }
        public virtual HashSet<Player> Players { get; set; }
        public virtual HashSet<PlayerAssistant> Assistants { get; set; }
        public int AvailableVipTickets { get; set; }
        public int AvailableInvestorTickets { get; set; }
        public int AvailableCollectorTickets { get; set; }
        public string PlayerOrderData { get; set; }
        public int CurrentPlayerId { get; set; }
        public int? KickedOutPlayerId { get; set; }

        [NotMapped]
        public GameTurn CurrentTurn
        {
            get
            {
                return Turns.ToList().OrderByDescending(t => t.TurnNumber).First();
            }
        }

        [NotMapped]
        public Player CurrentPlayer
        {
            get
            {
                return this.Players.First(p => p.Id == CurrentPlayerId);
            }
        }

        [NotMapped]
        private List<Player> _playerOrder;
        [NotMapped]
        public List<Player> PlayerOrder
        {
            get
            {
                if (_playerOrder == null)
                {
                    var idArray = Array.ConvertAll(PlayerOrderData.Split(';'), p => int.Parse(p));
                    var result = new List<Player>();
                    foreach (int id in idArray)
                    {
                        result.Add(this.Players.Where(p => p.Id == id).First());
                    }
                    _playerOrder = result;
                    return result;
                }
                PlayerOrderData = String.Join(";", _playerOrder.Select(p => p.Id.ToString()).ToArray());
                return _playerOrder;
            }
            set
            {
                PlayerOrderData = String.Join(";", value.Select(p => p.Id.ToString()).ToArray());
                _playerOrder = value;
            }
        }
    }
}
