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
        public static string[] ArtFameClass = { "gain-fame-0", "gain-fame-1", "gain-fame-2" };

        public static string ArtTicketToClass(VisitorTicketType[] ticketList)
        {
            if (ticketList.Count() == 3)
            {
                return "ticket-any";
            }
            string[] stringArray = { "", "", "" };
            foreach (VisitorTicketType ticket in ticketList)
            {
                if (ticket == VisitorTicketType.investor)
                {
                    stringArray[0] = "investor";
                }
                if (ticket == VisitorTicketType.collector)
                {
                    stringArray[1] = "collector";
                }
                if (ticket == VisitorTicketType.vip)
                {
                    stringArray[2] = "vip";
                }
            }
            var result = "ticket";
            foreach (string s in stringArray)
            {
                if (s != "")
                    result += "-" + s;
            }
            return result;    
        }
    }
}