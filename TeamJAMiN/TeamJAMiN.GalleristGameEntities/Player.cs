using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TeamJAMiN.GalleristComponentEntities
{
    public class Player
    {
        public int Id { get; set; }

        public int GameId { get; set; }

        [MaxLength(128)]
        public string UserId { get; set; }

        public Game Game { get; set; }
        public int Money { get; set; }
        public int Influence { get; set; }
        public HashSet<PlayerAssistant> Assistants { get; set; }
        public HashSet<GameReputationTile> tiles { get; set; }
        public HashSet<GameContract> Contracts { get; set; }
        public HashSet<GameArt> Art { get; set; }
        public GameArtist comission { get; set; }
    }        
}
