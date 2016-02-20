using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamJAMiN.GalleristComponentEntities
{
    public class ReputationTile
    {
        public int ReputationTileId { get; set; }
        public int influence { get; set; }
        public int money { get; set; }
        public ReputationTileScoring scoring { get; set; }
    }
}
