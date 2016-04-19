using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.GalleristComponentEntities;

namespace TeamJAMiN.Controllers.GameLogicHelpers
{
    public static class TicketManager
    {
        public static void GetTicket(this Player player, VisitorTicketType type)
        {
            switch(type)
            {
                case VisitorTicketType.collector:
                    player.GetTicketCollector();
                    break;
                case VisitorTicketType.investor:
                    player.GetTicketInvestor();
                    break;
                case VisitorTicketType.vip:
                    player.GetTicketVip();
                    break;
                default:
                    break;

            }
        }
        public static int GetAvailableTicketsByType(this Game game, VisitorTicketType type)
        {
            switch (type)
            {
                case VisitorTicketType.collector:
                    return game.AvailableCollectorTickets;
                case VisitorTicketType.investor:
                    return game.AvailableInvestorTickets;
                case VisitorTicketType.vip:
                    return game.AvailableVipTickets;
                default:
                    return -1;
            }
        }

        public static int GetPlayerTicketCountByType(this Player player, VisitorTicketType type)
        {
            switch (type)
            {
                case VisitorTicketType.collector:
                    return player.CollectorTickets;
                case VisitorTicketType.investor:
                    return player.InvestorTickets;
                case VisitorTicketType.vip:
                    return player.VipTickets;
                default:
                    return -1;
            }
        }

        public static void RemoveTicketByType(this Game game, VisitorTicketType type)
        {
            if( game.GetAvailableTicketsByType(type) != 0 )
            {
                switch (type)
                {
                    case VisitorTicketType.collector:
                        game.AvailableCollectorTickets--;
                        break;
                    case VisitorTicketType.investor:
                        game.AvailableInvestorTickets--;
                        break;
                    case VisitorTicketType.vip:
                        game.AvailableVipTickets--;
                        break;
                    default:
                        break;
                }
            }
        }

        public static void GetTicketCollector(this Player player)
        {
            if(player.Game.AvailableCollectorTickets > 0)
                player.Game.AvailableCollectorTickets -= 1;
            player.CollectorTickets += 1;
        }
        public static void GetTicketInvestor(this Player player)
        {
            if (player.Game.AvailableInvestorTickets > 0)
                player.Game.AvailableInvestorTickets -= 1;
            player.InvestorTickets += 1;
        }
        public static void GetTicketVip(this Player player)
        {
            if (player.Game.AvailableVipTickets > 0)
                player.Game.AvailableVipTickets -= 1;
            player.VipTickets += 1;
        }
    }
}