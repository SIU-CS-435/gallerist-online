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
        public static Dictionary<ReputationTileScoring, string> ReputationTileScoringHTML = new Dictionary<ReputationTileScoring, string>
        {
            { ReputationTileScoring.aquired, @"<div id=""aquired-scoring"" class=""row no-gutter"">
                                                    <div class=""col-xs-6"">
                                                        <div id=""aquired-scoring-sold"" class=""sell-icon aquired-scoring-icon""></div>
                                                    </div>
                                                    <div class=""col-xs-6"">
                                                        <div id=""aquired-scoring-exhibited"" class=""exhibit-icon aquired-scoring-icon""></div>
                                                    </div>
                                                </div>" },
            { ReputationTileScoring.artType, @"<div id=""art-type-scoring"" class=""row no-gutter"">
                                                    <div class=""col-xs-12"">
                                                        <div id=""art-type-scoring-sculpture"" class=""sculpture-icon art-type-scoring-art""></div>
                                                    </div>
                                                    <div class=""col-xs-6"">
                                                        <div id=""art-type-scoring-painting"" class=""painting-icon art-type-scoring-art""></div>
                                                    </div>
                                                    <div class=""col-xs-6"">
                                                        <div id=""art-type-scoring-photo"" class=""photo-icon art-type-scoring-art""></div>
                                                    </div>
                                                    <div class=""col-xs-12"">
                                                        <div id=""art-type-scoring-digital"" class=""digital-icon art-type-scoring-art""></div>
                                                    </div>
                                                </div>" },
            { ReputationTileScoring.assistant, "<div class=\"reputation-tile-scoring assistant-icon\"></div>" },
            { ReputationTileScoring.auction, "<div class=\"reputation-tile-scoring auction-icon\"></div>" },
            { ReputationTileScoring.collector, "<div class=\"reputation-tile-scoring visitor-collector\"></div>" },
            { ReputationTileScoring.digital, "<div class=\"reputation-tile-scoring digital-icon\"></div>" },
            { ReputationTileScoring.exhibiting, "<div class=\"reputation-tile-scoring exhibit-icon\"></div>" },
            { ReputationTileScoring.fame, "<div class=\"reputation-tile-scoring star-reputation-tile\"></div>" },
            { ReputationTileScoring.investor, "<div class=\"reputation-tile-scoring visitor-investor\"></div>" },
            { ReputationTileScoring.masterpiece, "<div id=\"masterpiece-scoring\" class=\"reputation-tile-scoring star-celebrity\"></div>" },
            { ReputationTileScoring.painting, "<div class=\"reputation-tile-scoring painting-icon\"></div>" },
            { ReputationTileScoring.photo, "<div class=\"reputation-tile-scoring photo-icon\"></div>" },
            { ReputationTileScoring.promotion, "<div id=\"promotion-scoring\" class=\"promotion-tile promotion-4\">4</div>" },
            { ReputationTileScoring.reputationTile, "<div class=\"reputation-tile-scoring reputation-icon\"></div>" },
            { ReputationTileScoring.sculpture, "<div class=\"reputation-tile-scoring sculpture-icon\"></div>" },
            { ReputationTileScoring.sold, "<div class=\"reputation-tile-scoring sell-icon\"></div>" },
            { ReputationTileScoring.threeInflunce, "<div class=\"reputation-tile-scoring influence-3\"></div>" },
            { ReputationTileScoring.vip, "<div class=\"reputation-tile-scoring visitor-vip\"></div>" },
            { ReputationTileScoring.visitor, "<div class=\"reputation-tile-scoring visitor-any\"></div>" },
            { ReputationTileScoring.visitorSet, @"<div id=""visitor-set-scoring"" class=""row no-gutter"">
                                                    <div class=""col-xs-12"">
                                                        <div id=""visitor-set-collector"" class=""visitor-collector visitor-set-scoring-visitor""></div>
                                                    </div>
                                                    <div class=""col-xs-6"">
                                                        <div id=""visitor-set-vip"" class=""visitor-vip visitor-set-scoring-visitor""></div>
                                                    </div>
                                                    <div class=""col-xs-6"">
                                                        <div id=""visitor-set-investor"" class=""visitor-investor visitor-set-scoring-visitor""></div>
                                                    </div>
                                                </div>" },
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