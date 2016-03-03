using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamJAMiN.GalleristComponentEntities
{
    public abstract class TemplateLocation
    {
        public int Id { get; set; }
    }

    public class ContractLocation : TemplateLocation
    {

    }
    public class ReputationTileLocation : TemplateLocation
    {

    }

    public class AssistantLocation : TemplateLocation
    {

    }
}
