using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.GalleristComponentEntities;

namespace TeamJAMiN.Models.GameViewHelpers
{
    public static class IconCss
    {
        public static Dictionary<BonusType, string> BonusClass = new Dictionary<BonusType, string>
        {
            { BonusType.plazaVisitor, "bonus-visitor-any" },
            { BonusType.money, "bonus-money" },
            { BonusType.influence, "bonus-influence" },
            { BonusType.fame, "bonus-fame" },
            { BonusType.twoTickets, "bonus-ticket-two" },
            { BonusType.assistant, "bonus-assistant" },
            { BonusType.bagVisitor, "bonus-visitor-bag" },
            { BonusType.plazaVipInvestor, "bonus-visitor-plaza-investor-vip" },
            { BonusType.ticket, "ticket-any" },
            { BonusType.contract, "bonus-contract" }
        };
    }
}