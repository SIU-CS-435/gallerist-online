using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.GalleristComponentEntities;

namespace TeamJAMiN.Models.GameViewHelpers
{
    public static class IconCss
    {
        public static string[] StarClass = { "", "star-green-1", "star-green-2", "star-green-3", "star-gold-1", "star-gold-2", "star-celebrity" };
        public static Dictionary<BonusType, string> ArtistBonusClass = new Dictionary<BonusType, string>
        {
            {BonusType.plazaVisitor,"bonus-visitor-any"},
            {BonusType.money,"bonus-money"},
            {BonusType.influence,"bonus-influence"},
            {BonusType.fame,"bonus-fame"},
            {BonusType.twoTickets,"bonus-ticket-two"}
        };
    }
}