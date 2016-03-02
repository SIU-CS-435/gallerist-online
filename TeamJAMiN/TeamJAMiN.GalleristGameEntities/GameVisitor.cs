using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamJAMiN.GalleristComponentEntities
{
    public class GameVisitor
    {
        public int Id { get; set; }
        public VisitorTicketType Type { get; set; }
        public TemplateLocation Location { get; set; }
    }
}
