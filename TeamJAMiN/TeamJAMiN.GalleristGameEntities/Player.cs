using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamJAMiN.GalleristComponentEntities
{
    public class Player
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int UserId { get; set; }
        public Game Game { get; set; }
    }        
}
