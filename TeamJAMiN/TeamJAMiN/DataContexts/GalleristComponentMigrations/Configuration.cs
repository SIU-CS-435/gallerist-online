namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using TeamJAMiN.GalleristComponentEntities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    internal sealed class Configuration : DbMigrationsConfiguration<GalleristComponentsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContexts\GalleristComponentMigrations";
        }

        protected override void Seed(GalleristComponentsDbContext context)
        {
            context.TemplateGames.AddOrUpdate(
                g => g.Name,
                new TemplateGame
                {
                    Name = "GameResources",
                    Art = new HashSet<TemplateArt>(context.TemplateArt.ToList()),
                    Artists = new HashSet<TemplateArtist>(context.TemplateArtists.ToList()),
                    ReputationTiles = new HashSet<TemplateReputationTile>(context.TemplateReputationTiles.ToList()),
                    Contracts = new HashSet<TemplateContract>(context.TemplateContracts.ToList())
                }
            );
            context.TemplateArt.AddOrUpdate(
                a => a.Slug,
                new TemplateArt
                {
                    Slug = "digital-0",
                    Fame = 0,
                    NumTickets = 1,
                    Type = ArtType.digital,
                    FirstTicket = new VisitorTicketType[] { VisitorTicketType.vip, VisitorTicketType.investor, VisitorTicketType.collector },
                    SecondTicket = new VisitorTicketType[] { }
                },
                new TemplateArt
                {
                    Slug = "digital-1",
                    Fame = 0,
                    NumTickets = 1,
                    Type = ArtType.digital,
                    FirstTicket = new VisitorTicketType[] { VisitorTicketType.investor },
                    SecondTicket = new VisitorTicketType[] { }
                },
                new TemplateArt
                {
                    Slug = "digital-2",
                    Fame = 2,
                    NumTickets = 2,
                    Type = ArtType.digital,
                    FirstTicket = new VisitorTicketType[] { VisitorTicketType.vip, VisitorTicketType.investor, VisitorTicketType.collector },
                    SecondTicket = new VisitorTicketType[] { VisitorTicketType.vip, VisitorTicketType.investor, VisitorTicketType.collector },
                },
                new TemplateArt
                {
                    Slug = "digital-3",
                    Fame = 0,
                    NumTickets = 1,
                    Type = ArtType.digital,
                    FirstTicket = new VisitorTicketType[] { VisitorTicketType.vip },
                    SecondTicket = new VisitorTicketType[] { }
                },
                new TemplateArt
                {
                    Slug = "digital-4",
                    Fame = 1,
                    NumTickets = 2,
                    Type = ArtType.digital,
                    FirstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor },
                    SecondTicket = new VisitorTicketType[] { VisitorTicketType.vip }
                },
                new TemplateArt
                {
                    Slug = "digital-5",
                    Fame = 0,
                    NumTickets = 1,
                    Type = ArtType.digital,
                    FirstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip },
                    SecondTicket = new VisitorTicketType[] { }
                },
                new TemplateArt
                {
                    Slug = "digital-6",
                    Fame = 1,
                    NumTickets = 2,
                    Type = ArtType.digital,
                    FirstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip },
                    SecondTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip }
                },
                new TemplateArt
                {
                    Slug = "digital-7",
                    Fame = 1,
                    NumTickets = 2,
                    Type = ArtType.digital,
                    FirstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.vip },
                    SecondTicket = new VisitorTicketType[] { VisitorTicketType.investor }
                },
                new TemplateArt
                {
                    Slug = "photo-0",
                    Fame = 0,
                    NumTickets = 1,
                    Type = ArtType.photo,
                    FirstTicket = new VisitorTicketType[] { VisitorTicketType.investor },
                    SecondTicket = new VisitorTicketType[] { }
                },
                new TemplateArt
                {
                    Slug = "photo-1",
                    Fame = 1,
                    NumTickets = 2,
                    Type = ArtType.photo,
                    FirstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip },
                    SecondTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip }
                },
                new TemplateArt
                {
                    Slug = "photo-2",
                    Fame = 0,
                    NumTickets = 1,
                    Type = ArtType.photo,
                    FirstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip },
                    SecondTicket = new VisitorTicketType[] { }
                },
                new TemplateArt
                {
                    Slug = "photo-3",
                    Fame = 1,
                    NumTickets = 2,
                    Type = ArtType.photo,
                    FirstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.vip },
                    SecondTicket = new VisitorTicketType[] { VisitorTicketType.investor }
                },
                new TemplateArt
                {
                    Slug = "photo-4",
                    Fame = 2,
                    NumTickets = 2,
                    Type = ArtType.photo,
                    FirstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip },
                    SecondTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip }
                },
                new TemplateArt
                {
                    Slug = "photo-5",
                    Fame = 1,
                    NumTickets = 2,
                    Type = ArtType.photo,
                    FirstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor },
                    SecondTicket = new VisitorTicketType[] { VisitorTicketType.vip }
                },
                new TemplateArt
                {
                    Slug = "photo-6",
                    Fame = 0,
                    NumTickets = 1,
                    Type = ArtType.photo,
                    FirstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip },
                    SecondTicket = new VisitorTicketType[] { }
                },
                new TemplateArt
                {
                    Slug = "photo-7",
                    Fame = 0,
                    NumTickets = 1,
                    Type = ArtType.photo,
                    FirstTicket = new VisitorTicketType[] { VisitorTicketType.vip },
                    SecondTicket = new VisitorTicketType[] { }
                },
                new TemplateArt
                {
                    Slug = "sculpture-0",
                    Fame = 0,
                    NumTickets = 1,
                    Type = ArtType.sculpture,
                    FirstTicket = new VisitorTicketType[] { VisitorTicketType.investor },
                    SecondTicket = new VisitorTicketType[] { }
                },
                new TemplateArt
                {
                    Slug = "sculpture-1",
                    Fame = 1,
                    NumTickets = 2,
                    Type = ArtType.sculpture,
                    FirstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip },
                    SecondTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip }
                },
                new TemplateArt
                {
                    Slug = "sculpture-2",
                    Fame = 0,
                    NumTickets = 1,
                    Type = ArtType.sculpture,
                    FirstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip },
                    SecondTicket = new VisitorTicketType[] { }
                },
                new TemplateArt
                {
                    Slug = "sculpture-3",
                    Fame = 1,
                    NumTickets = 2,
                    Type = ArtType.sculpture,
                    FirstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.vip },
                    SecondTicket = new VisitorTicketType[] { VisitorTicketType.investor }
                },
                new TemplateArt
                {
                    Slug = "sculpture-4",
                    Fame = 2,
                    NumTickets = 2,
                    Type = ArtType.sculpture,
                    FirstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip },
                    SecondTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip }
                },
                new TemplateArt
                {
                    Slug = "sculpture-5",
                    Fame = 1,
                    NumTickets = 2,
                    Type = ArtType.sculpture,
                    FirstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor },
                    SecondTicket = new VisitorTicketType[] { VisitorTicketType.vip }
                },
                new TemplateArt
                {
                    Slug = "sculpture-6",
                    Fame = 0,
                    NumTickets = 1,
                    Type = ArtType.sculpture,
                    FirstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip },
                    SecondTicket = new VisitorTicketType[] { }
                },
                new TemplateArt
                {
                    Slug = "sculpture-7",
                    Fame = 0,
                    NumTickets = 1,
                    Type = ArtType.sculpture,
                    FirstTicket = new VisitorTicketType[] { VisitorTicketType.vip },
                    SecondTicket = new VisitorTicketType[] { }
                },
                new TemplateArt
                {
                    Slug = "painting-0",
                    Fame = 0,
                    NumTickets = 1,
                    Type = ArtType.painting,
                    FirstTicket = new VisitorTicketType[] { VisitorTicketType.investor },
                    SecondTicket = new VisitorTicketType[] { }
                },
                new TemplateArt
                {
                    Slug = "painting-1",
                    Fame = 1,
                    NumTickets = 2,
                    Type = ArtType.painting,
                    FirstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip },
                    SecondTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip }
                },
                new TemplateArt
                {
                    Slug = "painting-2",
                    Fame = 0,
                    NumTickets = 1,
                    Type = ArtType.painting,
                    FirstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip },
                    SecondTicket = new VisitorTicketType[] { }
                },
                new TemplateArt
                {
                    Slug = "painting-3",
                    Fame = 1,
                    NumTickets = 2,
                    Type = ArtType.painting,
                    FirstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.vip },
                    SecondTicket = new VisitorTicketType[] { VisitorTicketType.investor }
                },
                new TemplateArt
                {
                    Slug = "painting-4",
                    Fame = 2,
                    NumTickets = 2,
                    Type = ArtType.painting,
                    FirstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip },
                    SecondTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip }
                },
                new TemplateArt
                {
                    Slug = "painting-5",
                    Fame = 1,
                    NumTickets = 2,
                    Type = ArtType.painting,
                    FirstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor },
                    SecondTicket = new VisitorTicketType[] { VisitorTicketType.vip }
                },
                new TemplateArt
                {
                    Slug = "painting-6",
                    Fame = 0,
                    NumTickets = 1,
                    Type = ArtType.painting,
                    FirstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip },
                    SecondTicket = new VisitorTicketType[] { }
                },
                new TemplateArt
                {
                    Slug = "painting-7",
                    Fame = 0,
                    NumTickets = 1,
                    Type = ArtType.painting,
                    FirstTicket = new VisitorTicketType[] { VisitorTicketType.vip },
                    SecondTicket = new VisitorTicketType[] { }
                }
            );
            context.TemplateArtists.AddOrUpdate(
            a => a.Slug,
            new TemplateArtist
            {
                Slug = "photo-0",
                Fame = 5,
                Promotion = 2,
                StarLevels = new int[] { 2, 6, 9, 12, 15, 19 },
                ArtType = ArtType.photo,
                Category = ArtistCategory.red
            },
            new TemplateArtist
            {
                Slug = "photo-1",
                Fame = 1,
                Promotion = 0,
                StarLevels = new int[] { 2, 5, 8, 11, 15, 19 },
                ArtType = ArtType.photo,
                Category = ArtistCategory.blue
            },
            new TemplateArtist
            {
                Slug = "photo-2",
                Fame = 4,
                Promotion = 1,
                StarLevels = new int[] { 2, 6, 9, 12, 15, 19 },
                ArtType = ArtType.photo,
                Category = ArtistCategory.blue
            },
            new TemplateArtist
            {
                Slug = "photo-3",
                Fame = 8,
                Promotion = 3,
                StarLevels = new int[] { 2, 6, 9, 12, 15, 19 },
                ArtType = ArtType.photo,
                Category = ArtistCategory.red
            },
            new TemplateArtist
            {
                Slug = "digital-0",
                Fame = 5,
                Promotion = 2,
                StarLevels = new int[] { 2, 6, 9, 12, 15, 19 },
                ArtType = ArtType.digital,
                Category = ArtistCategory.red
            },
            new TemplateArtist
            {
                Slug = "digital-1",
                Fame = 1,
                Promotion = 0,
                StarLevels = new int[] { 2, 5, 8, 11, 15, 19 },
                ArtType = ArtType.digital,
                Category = ArtistCategory.blue
            },
            new TemplateArtist
            {
                Slug = "digital-2",
                Fame = 4,
                Promotion = 1,
                StarLevels = new int[] { 2, 6, 9, 12, 15, 19 },
                ArtType = ArtType.digital,
                Category = ArtistCategory.blue
            },
            new TemplateArtist
            {
                Slug = "digital-3",
                Fame = 8,
                Promotion = 3,
                StarLevels = new int[] { 2, 6, 9, 12, 15, 19 },
                ArtType = ArtType.digital,
                Category = ArtistCategory.red
            },
            new TemplateArtist
            {
                Slug = "sculpture-0",
                Fame = 5,
                Promotion = 1,
                StarLevels = new int[] { 2, 6, 9, 12, 15, 19 },
                ArtType = ArtType.sculpture,
                Category = ArtistCategory.blue
            },
            new TemplateArtist
            {
                Slug = "sculpture-1",
                Fame = 3,
                Promotion = 0,
                StarLevels = new int[] { 2, 5, 8, 11, 15, 19 },
                ArtType = ArtType.sculpture,
                Category = ArtistCategory.blue
            },
            new TemplateArtist
            {
                Slug = "sculpture-2",
                Fame = 7,
                Promotion = 2,
                StarLevels = new int[] { 2, 6, 9, 12, 15, 19 },
                ArtType = ArtType.sculpture,
                Category = ArtistCategory.red
            },
            new TemplateArtist
            {
                Slug = "sculpture-3",
                Fame = 10,
                Promotion = 3,
                StarLevels = new int[] { 2, 6, 9, 12, 15, 19 },
                ArtType = ArtType.sculpture,
                Category = ArtistCategory.red
            },
             new TemplateArtist
             {
                 Slug = "painting-0",
                 Fame = 5,
                 Promotion = 1,
                 StarLevels = new int[] { 2, 6, 9, 12, 15, 19 },
                 ArtType = ArtType.painting,
                 Category = ArtistCategory.blue
             },
            new TemplateArtist
            {
                Slug = "painting-1",
                Fame = 3,
                Promotion = 0,
                StarLevels = new int[] { 2, 5, 8, 11, 15, 19 },
                ArtType = ArtType.painting,
                Category = ArtistCategory.blue
            },
            new TemplateArtist
            {
                Slug = "painting-2",
                Fame = 7,
                Promotion = 2,
                StarLevels = new int[] { 2, 6, 9, 12, 15, 19 },
                ArtType = ArtType.painting,
                Category = ArtistCategory.red
            },
            new TemplateArtist
            {
                Slug = "painting-3",
                Fame = 10,
                Promotion = 3,
                StarLevels = new int[] { 2, 6, 9, 12, 15, 19 },
                ArtType = ArtType.painting,
                Category = ArtistCategory.red
            }
            );
            context.TemplateContracts.AddOrUpdate(
            c => new { c.Art, c.Bonus },
            new TemplateContract
            {
                Art = ArtType.painting,
                Bonus = BonusType.assistant
            },
            new TemplateContract
            {
                Art = ArtType.painting,
                Bonus = BonusType.bagVisitor
            },
            new TemplateContract
            {
                Art = ArtType.painting,
                Bonus = BonusType.plazaVipInvestor
            },
            new TemplateContract
            {
                Art = ArtType.painting,
                Bonus = BonusType.money
            },
            new TemplateContract
            {
                Art = ArtType.painting,
                Bonus = BonusType.contract
            },
            new TemplateContract
            {
                Art = ArtType.photo,
                Bonus = BonusType.assistant
            },
            new TemplateContract
            {
                Art = ArtType.photo,
                Bonus = BonusType.bagVisitor
            },
            new TemplateContract
            {
                Art = ArtType.photo,
                Bonus = BonusType.plazaVipInvestor
            },
            new TemplateContract
            {
                Art = ArtType.photo,
                Bonus = BonusType.money
            },
            new TemplateContract
            {
                Art = ArtType.photo,
                Bonus = BonusType.contract
            },
            new TemplateContract
            {
                Art = ArtType.sculpture,
                Bonus = BonusType.assistant
            },
            new TemplateContract
            {
                Art = ArtType.sculpture,
                Bonus = BonusType.bagVisitor
            },
            new TemplateContract
            {
                Art = ArtType.sculpture,
                Bonus = BonusType.plazaVipInvestor
            },
            new TemplateContract
            {
                Art = ArtType.sculpture,
                Bonus = BonusType.influence
            },
            new TemplateContract
            {
                Art = ArtType.sculpture,
                Bonus = BonusType.contract
            },
            new TemplateContract
            {
                Art = ArtType.digital,
                Bonus = BonusType.assistant
            },
            new TemplateContract
            {
                Art = ArtType.digital,
                Bonus = BonusType.bagVisitor
            },
            new TemplateContract
            {
                Art = ArtType.digital,
                Bonus = BonusType.plazaVipInvestor
            },
            new TemplateContract
            {
                Art = ArtType.digital,
                Bonus = BonusType.influence
            },
            new TemplateContract
            {
                Art = ArtType.digital,
                Bonus = BonusType.contract
            }
            );
            context.TemplateReputationTiles.AddOrUpdate(
            r => r.Scoring,
            new TemplateReputationTile
            {
                Money = 1,
                Influence = 0,
                Scoring = ReputationTileScoring.threeInflunce
            },
            new TemplateReputationTile
            {
                Money = 3,
                Influence = 1,
                Scoring = ReputationTileScoring.collector
            },
            new TemplateReputationTile
            {
                Money = 2,
                Influence = 1,
                Scoring = ReputationTileScoring.vip
            },
            new TemplateReputationTile
            {
                Money = 2,
                Influence = 1,
                Scoring = ReputationTileScoring.investor
            },
            new TemplateReputationTile
            {
                Money = 1,
                Influence = 0,
                Scoring = ReputationTileScoring.visitor
            },
            new TemplateReputationTile
            {
                Money = 4,
                Influence = 0,
                Scoring = ReputationTileScoring.visitorSet
            },
            new TemplateReputationTile
            {
                Money = 2,
                Influence = 1,
                Scoring = ReputationTileScoring.reputationTile
            },
            new TemplateReputationTile
            {
                Money = 3,
                Influence = 1,
                Scoring = ReputationTileScoring.auction
            },
            new TemplateReputationTile
            {
                Money = 1,
                Influence = 1,
                Scoring = ReputationTileScoring.assistant
            },
            new TemplateReputationTile
            {
                Money = 2,
                Influence = 0,
                Scoring = ReputationTileScoring.promotion
            },
            new TemplateReputationTile
            {
                Money = 2,
                Influence = 0,
                Scoring = ReputationTileScoring.aquired
            },
            new TemplateReputationTile
            {
                Money = 3,
                Influence = 1,
                Scoring = ReputationTileScoring.sold
            },
            new TemplateReputationTile
            {
                Money = 3,
                Influence = 1,
                Scoring = ReputationTileScoring.exhibiting
            },
            new TemplateReputationTile
            {
                Money = 2,
                Influence = 1,
                Scoring = ReputationTileScoring.artType
            },
            new TemplateReputationTile
            {
                Money = 3,
                Influence = 1,
                Scoring = ReputationTileScoring.photo
            },
            new TemplateReputationTile
            {
                Money = 3,
                Influence = 1,
                Scoring = ReputationTileScoring.painting
            },
            new TemplateReputationTile
            {
                Money = 3,
                Influence = 1,
                Scoring = ReputationTileScoring.digital
            },
            new TemplateReputationTile
            {
                Money = 3,
                Influence = 1,
                Scoring = ReputationTileScoring.sculpture
            },
            new TemplateReputationTile
            {
                Money = 2,
                Influence = 1,
                Scoring = ReputationTileScoring.fame
            },
            new TemplateReputationTile
            {
                Money = 4,
                Influence = 2,
                Scoring = ReputationTileScoring.masterpiece,
            }
            );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
