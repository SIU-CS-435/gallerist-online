using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamJAMiN.GalleristComponentEntities
{
    public class Contract
    {
        public int ContractId { get; set; }
        public ArtType art { get; set; }
        public BonusType bonus { get; set; }
    }
}
