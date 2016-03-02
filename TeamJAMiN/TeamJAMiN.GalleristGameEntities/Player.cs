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
    }        
}
