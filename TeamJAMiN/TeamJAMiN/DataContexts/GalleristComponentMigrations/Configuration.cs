namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using GalleristComponentEntities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TeamJAMiN.DataContexts.GalleristComponentsDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContexts\GalleristComponentMigrations";
        }

        protected override void Seed(TeamJAMiN.DataContexts.GalleristComponentsDb context)
        {
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
            context.Contracts.AddOrUpdate(
            c => new { c.art, c.bonus },
            new Contract
            {
                art = ArtType.painting,
                bonus = BonusType.assistant
            },
            new Contract
            {
                art = ArtType.painting,
                bonus = BonusType.bagVisitor
            },
            new Contract
            {
                art = ArtType.painting,
                bonus = BonusType.plazaVipInvestor
            },
            new Contract
            {
                art = ArtType.painting,
                bonus = BonusType.money
            },
            new Contract
            {
                art = ArtType.painting,
                bonus = BonusType.contract
            },
            new Contract
            {
                art = ArtType.photo,
                bonus = BonusType.assistant
            },
            new Contract
            {
                art = ArtType.photo,
                bonus = BonusType.bagVisitor
            },
            new Contract
            {
                art = ArtType.photo,
                bonus = BonusType.plazaVipInvestor
            },
            new Contract
            {
                art = ArtType.photo,
                bonus = BonusType.money
            },
            new Contract
            {
                art = ArtType.photo,
                bonus = BonusType.contract
            },
            new Contract
            {
                art = ArtType.sculpture,
                bonus = BonusType.assistant
            },
            new Contract
            {
                art = ArtType.sculpture,
                bonus = BonusType.bagVisitor
            },
            new Contract
            {
                art = ArtType.sculpture,
                bonus = BonusType.plazaVipInvestor
            },
            new Contract
            {
                art = ArtType.sculpture,
                bonus = BonusType.influence
            },
            new Contract
            {
                art = ArtType.sculpture,
                bonus = BonusType.contract
            },
            new Contract
            {
                art = ArtType.digital,
                bonus = BonusType.assistant
            },
            new Contract
            {
                art = ArtType.digital,
                bonus = BonusType.bagVisitor
            },
            new Contract
            {
                art = ArtType.digital,
                bonus = BonusType.plazaVipInvestor
            },
            new Contract
            {
                art = ArtType.digital,
                bonus = BonusType.influence
            },
            new Contract
            {
                art = ArtType.digital,
                bonus = BonusType.contract
            }
            );
            context.ReputationTiles.AddOrUpdate(
            r => r.scoring,
            new ReputationTile
            {
                money = 1,
                influence = 0,
                scoring = ReputationTileScoring.threeInflunce
            },
            new ReputationTile
            {
                money = 3,
                influence = 1,
                scoring = ReputationTileScoring.collector
            },
            new ReputationTile
            {
                money = 2,
                influence = 1,
                scoring = ReputationTileScoring.vip
            },
            new ReputationTile
            {
                money = 2,
                influence = 1,
                scoring = ReputationTileScoring.investor
            },
            new ReputationTile
            {
                money = 1,
                influence = 0,
                scoring = ReputationTileScoring.visitor
            },
            new ReputationTile
            {
                money = 4,
                influence = 0,
                scoring = ReputationTileScoring.visitorSet
            },
            new ReputationTile
            {
                money = 1,
                influence = 2,
                scoring = ReputationTileScoring.reputationTile
            },
            new ReputationTile
            {
                money = 3,
                influence = 1,
                scoring = ReputationTileScoring.auction
            },
            new ReputationTile
            {
                money = 1,
                influence = 1,
                scoring = ReputationTileScoring.assistant
            },
            new ReputationTile
            {
                money = 2,
                influence = 0,
                scoring = ReputationTileScoring.promotion
            },
            new ReputationTile
            {
                money = 2,
                influence = 0,
                scoring = ReputationTileScoring.aquired
            },
            new ReputationTile
            {
                money = 3,
                influence = 1,
                scoring = ReputationTileScoring.sold
            },
            new ReputationTile
            {
                money = 3,
                influence = 1,
                scoring = ReputationTileScoring.exhibiting
            },
            new ReputationTile
            {
                money = 2,
                influence = 1,
                scoring = ReputationTileScoring.artType
            },
            new ReputationTile
            {
                money = 3,
                influence = 1,
                scoring = ReputationTileScoring.photo
            },
            new ReputationTile
            {
                money = 3,
                influence = 1,
                scoring = ReputationTileScoring.painting
            },
            new ReputationTile
            {
                money = 3,
                influence = 1,
                scoring = ReputationTileScoring.digital
            },
            new ReputationTile
            {
                money = 3,
                influence = 1,
                scoring = ReputationTileScoring.sculpture
            },
            new ReputationTile
            {
                money = 2,
                influence = 1,
                scoring = ReputationTileScoring.fame
            },
            new ReputationTile
            {
                money = 4,
                influence = 2,
                scoring = ReputationTileScoring.masterpiece,
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
