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

        //protected override void Seed(TeamJAMiN.DataContexts.GalleristComponentsDb context)
        //{
        //    context.Art.AddOrUpdate(
        //        a => a.slug,
        //        new Art
        //        {
        //            slug = "digital-0",
        //            fame = 0,
        //            numTickets = 1,
        //            type = ArtType.digital,
        //            firstTicket = new VisitorTicketType[] { VisitorTicketType.vip, VisitorTicketType.investor, VisitorTicketType.collector },
        //            secondTicket = new VisitorTicketType[] { }
        //        },
        //        new Art
        //        {
        //            slug = "digital-1",
        //            fame = 0,
        //            numTickets = 1,
        //            type = ArtType.digital,
        //            firstTicket = new VisitorTicketType[] { VisitorTicketType.investor },
        //            secondTicket = new VisitorTicketType[] { }
        //        },
        //        new Art
        //        {
        //            slug = "digital-2",
        //            fame = 2,
        //            numTickets = 2,
        //            type = ArtType.digital,
        //            firstTicket = new VisitorTicketType[] { VisitorTicketType.vip, VisitorTicketType.investor, VisitorTicketType.collector },
        //            secondTicket = new VisitorTicketType[] { VisitorTicketType.vip, VisitorTicketType.investor, VisitorTicketType.collector },
        //        },
        //        new Art
        //        {
        //            slug = "digital-3",
        //            fame = 0,
        //            numTickets = 1,
        //            type = ArtType.digital,
        //            firstTicket = new VisitorTicketType[] { VisitorTicketType.vip },
        //            secondTicket = new VisitorTicketType[] { }
        //        },
        //        new Art
        //        {
        //            slug = "digital-4",
        //            fame = 1,
        //            numTickets = 2,
        //            type = ArtType.digital,
        //            firstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor },
        //            secondTicket = new VisitorTicketType[] { VisitorTicketType.vip }
        //        },
        //        new Art
        //        {
        //            slug = "digital-5",
        //            fame = 0,
        //            numTickets = 1,
        //            type = ArtType.digital,
        //            firstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip },
        //            secondTicket = new VisitorTicketType[] { }
        //        },
        //        new Art
        //        {
        //            slug = "digital-6",
        //            fame = 1,
        //            numTickets = 2,
        //            type = ArtType.digital,
        //            firstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip },
        //            secondTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip }
        //        },
        //        new Art
        //        {
        //            slug = "digital-7",
        //            fame = 1,
        //            numTickets = 2,
        //            type = ArtType.digital,
        //            firstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.vip },
        //            secondTicket = new VisitorTicketType[] { VisitorTicketType.investor }
        //        },
        //        new Art
        //        {
        //            slug = "photo-0",
        //            fame = 0,
        //            numTickets = 1,
        //            type = ArtType.photo,
        //            firstTicket = new VisitorTicketType[] { VisitorTicketType.investor },
        //            secondTicket = new VisitorTicketType[] { }
        //        },
        //        new Art
        //        {
        //            slug = "photo-1",
        //            fame = 1,
        //            numTickets = 2,
        //            type = ArtType.photo,
        //            firstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip },
        //            secondTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip }
        //        },
        //        new Art
        //        {
        //            slug = "photo-2",
        //            fame = 0,
        //            numTickets = 1,
        //            type = ArtType.photo,
        //            firstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip },
        //            secondTicket = new VisitorTicketType[] { }
        //        },
        //        new Art
        //        {
        //            slug = "photo-3",
        //            fame = 1,
        //            numTickets = 2,
        //            type = ArtType.photo,
        //            firstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.vip },
        //            secondTicket = new VisitorTicketType[] { VisitorTicketType.investor }
        //        },
        //        new Art
        //        {
        //            slug = "photo-4",
        //            fame = 2,
        //            numTickets = 2,
        //            type = ArtType.photo,
        //            firstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip },
        //            secondTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip }
        //        },
        //        new Art
        //        {
        //            slug = "photo-5",
        //            fame = 1,
        //            numTickets = 2,
        //            type = ArtType.photo,
        //            firstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor },
        //            secondTicket = new VisitorTicketType[] { VisitorTicketType.vip }
        //        },
        //        new Art
        //        {
        //            slug = "photo-6",
        //            fame = 0,
        //            numTickets = 1,
        //            type = ArtType.photo,
        //            firstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip },
        //            secondTicket = new VisitorTicketType[] { }
        //        },
        //        new Art
        //        {
        //            slug = "photo-7",
        //            fame = 0,
        //            numTickets = 1,
        //            type = ArtType.photo,
        //            firstTicket = new VisitorTicketType[] { VisitorTicketType.vip },
        //            secondTicket = new VisitorTicketType[] { }
        //        },
        //        new Art
        //        {
        //            slug = "sculpture-0",
        //            fame = 0,
        //            numTickets = 1,
        //            type = ArtType.sculpture,
        //            firstTicket = new VisitorTicketType[] { VisitorTicketType.investor },
        //            secondTicket = new VisitorTicketType[] { }
        //        },
        //        new Art
        //        {
        //            slug = "sculpture-1",
        //            fame = 1,
        //            numTickets = 2,
        //            type = ArtType.sculpture,
        //            firstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip },
        //            secondTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip }
        //        },
        //        new Art
        //        {
        //            slug = "sculpture-2",
        //            fame = 0,
        //            numTickets = 1,
        //            type = ArtType.sculpture,
        //            firstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip },
        //            secondTicket = new VisitorTicketType[] { }
        //        },
        //        new Art
        //        {
        //            slug = "sculpture-3",
        //            fame = 1,
        //            numTickets = 2,
        //            type = ArtType.sculpture,
        //            firstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.vip },
        //            secondTicket = new VisitorTicketType[] { VisitorTicketType.investor }
        //        },
        //        new Art
        //        {
        //            slug = "sculpture-4",
        //            fame = 2,
        //            numTickets = 2,
        //            type = ArtType.sculpture,
        //            firstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip },
        //            secondTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip }
        //        },
        //        new Art
        //        {
        //            slug = "sculpture-5",
        //            fame = 1,
        //            numTickets = 2,
        //            type = ArtType.sculpture,
        //            firstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor },
        //            secondTicket = new VisitorTicketType[] { VisitorTicketType.vip }
        //        },
        //        new Art
        //        {
        //            slug = "sculpture-6",
        //            fame = 0,
        //            numTickets = 1,
        //            type = ArtType.sculpture,
        //            firstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip },
        //            secondTicket = new VisitorTicketType[] { }
        //        },
        //        new Art
        //        {
        //            slug = "sculpture-7",
        //            fame = 0,
        //            numTickets = 1,
        //            type = ArtType.sculpture,
        //            firstTicket = new VisitorTicketType[] { VisitorTicketType.vip },
        //            secondTicket = new VisitorTicketType[] { }
        //        },
        //        new Art
        //        {
        //            slug = "painting-0",
        //            fame = 0,
        //            numTickets = 1,
        //            type = ArtType.painting,
        //            firstTicket = new VisitorTicketType[] { VisitorTicketType.investor },
        //            secondTicket = new VisitorTicketType[] { }
        //        },
        //        new Art
        //        {
        //            slug = "painting-1",
        //            fame = 1,
        //            numTickets = 2,
        //            type = ArtType.painting,
        //            firstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip },
        //            secondTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip }
        //        },
        //        new Art
        //        {
        //            slug = "painting-2",
        //            fame = 0,
        //            numTickets = 1,
        //            type = ArtType.painting,
        //            firstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip },
        //            secondTicket = new VisitorTicketType[] { }
        //        },
        //        new Art
        //        {
        //            slug = "painting-3",
        //            fame = 1,
        //            numTickets = 2,
        //            type = ArtType.painting,
        //            firstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.vip },
        //            secondTicket = new VisitorTicketType[] { VisitorTicketType.investor }
        //        },
        //        new Art
        //        {
        //            slug = "painting-4",
        //            fame = 2,
        //            numTickets = 2,
        //            type = ArtType.painting,
        //            firstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip },
        //            secondTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip }
        //        },
        //        new Art
        //        {
        //            slug = "painting-5",
        //            fame = 1,
        //            numTickets = 2,
        //            type = ArtType.painting,
        //            firstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor },
        //            secondTicket = new VisitorTicketType[] { VisitorTicketType.vip }
        //        },
        //        new Art
        //        {
        //            slug = "painting-6",
        //            fame = 0,
        //            numTickets = 1,
        //            type = ArtType.painting,
        //            firstTicket = new VisitorTicketType[] { VisitorTicketType.collector, VisitorTicketType.investor, VisitorTicketType.vip },
        //            secondTicket = new VisitorTicketType[] { }
        //        },
        //        new Art
        //        {
        //            slug = "painting-7",
        //            fame = 0,
        //            numTickets = 1,
        //            type = ArtType.painting,
        //            firstTicket = new VisitorTicketType[] { VisitorTicketType.vip },
        //            secondTicket = new VisitorTicketType[] { }
        //        }
        //    );
        //    context.Artists.AddOrUpdate(
        //    a => a.slug,
        //    new Artist
        //    {
        //        slug = "photo-0",
        //        fame = 5,
        //        promotion = 2,
        //        starLevels = new int[] { 2, 6, 9, 12, 15, 19 },
        //        artType = ArtType.photo,
        //        category = ArtistCategory.red
        //    },
        //    new Artist
        //    {
        //        slug = "photo-1",
        //        fame = 1,
        //        promotion = 0,
        //        starLevels = new int[] { 2, 5, 8, 11, 15, 19 },
        //        artType = ArtType.photo,
        //        category = ArtistCategory.blue
        //    },
        //    new Artist
        //    {
        //        slug = "photo-2",
        //        fame = 4,
        //        promotion = 1,
        //        starLevels = new int[] { 2, 6, 9, 12, 15, 19 },
        //        artType = ArtType.photo,
        //        category = ArtistCategory.blue
        //    },
        //    new Artist
        //    {
        //        slug = "photo-3",
        //        fame = 8,
        //        promotion = 3,
        //        starLevels = new int[] { 2, 6, 9, 12, 15, 19 },
        //        artType = ArtType.photo,
        //        category = ArtistCategory.red
        //    },
        //    new Artist
        //    {
        //        slug = "digital-0",
        //        fame = 5,
        //        promotion = 2,
        //        starLevels = new int[] { 2, 6, 9, 12, 15, 19 },
        //        artType = ArtType.digital,
        //        category = ArtistCategory.red
        //    },
        //    new Artist
        //    {
        //        slug = "digital-1",
        //        fame = 1,
        //        promotion = 0,
        //        starLevels = new int[] { 2, 5, 8, 11, 15, 19 },
        //        artType = ArtType.digital,
        //        category = ArtistCategory.blue
        //    },
        //    new Artist
        //    {
        //        slug = "digital-2",
        //        fame = 4,
        //        promotion = 1,
        //        starLevels = new int[] { 2, 6, 9, 12, 15, 19 },
        //        artType = ArtType.digital,
        //        category = ArtistCategory.blue
        //    },
        //    new Artist
        //    {
        //        slug = "digital-3",
        //        fame = 8,
        //        promotion = 3,
        //        starLevels = new int[] { 2, 6, 9, 12, 15, 19 },
        //        artType = ArtType.digital,
        //        category = ArtistCategory.red
        //    },
        //    new Artist
        //    {
        //        slug = "sculpture-0",
        //        fame = 5,
        //        promotion = 1,
        //        starLevels = new int[] { 2, 6, 9, 12, 15, 19 },
        //        artType = ArtType.sculpture,
        //        category = ArtistCategory.blue
        //    },
        //    new Artist
        //    {
        //        slug = "sculpture-1",
        //        fame = 3,
        //        promotion = 0,
        //        starLevels = new int[] { 2, 5, 8, 11, 15, 19 },
        //        artType = ArtType.sculpture,
        //        category = ArtistCategory.blue
        //    },
        //    new Artist
        //    {
        //        slug = "sculpture-2",
        //        fame = 7,
        //        promotion = 2,
        //        starLevels = new int[] { 2, 6, 9, 12, 15, 19 },
        //        artType = ArtType.sculpture,
        //        category = ArtistCategory.red
        //    },
        //    new Artist
        //    {
        //        slug = "sculpture-3",
        //        fame = 10,
        //        promotion = 3,
        //        starLevels = new int[] { 2, 6, 9, 12, 15, 19 },
        //        artType = ArtType.sculpture,
        //        category = ArtistCategory.red
        //    },
        //     new Artist
        //     {
        //         slug = "painting-0",
        //         fame = 5,
        //         promotion = 1,
        //         starLevels = new int[] { 2, 6, 9, 12, 15, 19 },
        //         artType = ArtType.painting,
        //         category = ArtistCategory.blue
        //     },
        //    new Artist
        //    {
        //        slug = "painting-1",
        //        fame = 3,
        //        promotion = 0,
        //        starLevels = new int[] { 2, 5, 8, 11, 15, 19 },
        //        artType = ArtType.painting,
        //        category = ArtistCategory.blue
        //    },
        //    new Artist
        //    {
        //        slug = "painting-2",
        //        fame = 7,
        //        promotion = 2,
        //        starLevels = new int[] { 2, 6, 9, 12, 15, 19 },
        //        artType = ArtType.painting,
        //        category = ArtistCategory.red
        //    },
        //    new Artist
        //    {
        //        slug = "painting-3",
        //        fame = 10,
        //        promotion = 3,
        //        starLevels = new int[] { 2, 6, 9, 12, 15, 19 },
        //        artType = ArtType.painting,
        //        category = ArtistCategory.red
        //    }
        //    );
        //    context.Contracts.AddOrUpdate(
        //    c => new { c.art, c.bonus },
        //    new Contract
        //    {
        //        art = ArtType.painting,
        //        bonus = BonusType.assistant
        //    },
        //    new Contract
        //    {
        //        art = ArtType.painting,
        //        bonus = BonusType.bagVisitor
        //    },
        //    new Contract
        //    {
        //        art = ArtType.painting,
        //        bonus = BonusType.plazaVipInvestor
        //    },
        //    new Contract
        //    {
        //        art = ArtType.painting,
        //        bonus = BonusType.money
        //    },
        //    new Contract
        //    {
        //        art = ArtType.painting,
        //        bonus = BonusType.contract
        //    },
        //    new Contract
        //    {
        //        art = ArtType.photo,
        //        bonus = BonusType.assistant
        //    },
        //    new Contract
        //    {
        //        art = ArtType.photo,
        //        bonus = BonusType.bagVisitor
        //    },
        //    new Contract
        //    {
        //        art = ArtType.photo,
        //        bonus = BonusType.plazaVipInvestor
        //    },
        //    new Contract
        //    {
        //        art = ArtType.photo,
        //        bonus = BonusType.money
        //    },
        //    new Contract
        //    {
        //        art = ArtType.photo,
        //        bonus = BonusType.contract
        //    },
        //    new Contract
        //    {
        //        art = ArtType.sculpture,
        //        bonus = BonusType.assistant
        //    },
        //    new Contract
        //    {
        //        art = ArtType.sculpture,
        //        bonus = BonusType.bagVisitor
        //    },
        //    new Contract
        //    {
        //        art = ArtType.sculpture,
        //        bonus = BonusType.plazaVipInvestor
        //    },
        //    new Contract
        //    {
        //        art = ArtType.sculpture,
        //        bonus = BonusType.influence
        //    },
        //    new Contract
        //    {
        //        art = ArtType.sculpture,
        //        bonus = BonusType.contract
        //    },
        //    new Contract
        //    {
        //        art = ArtType.digital,
        //        bonus = BonusType.assistant
        //    },
        //    new Contract
        //    {
        //        art = ArtType.digital,
        //        bonus = BonusType.bagVisitor
        //    },
        //    new Contract
        //    {
        //        art = ArtType.digital,
        //        bonus = BonusType.plazaVipInvestor
        //    },
        //    new Contract
        //    {
        //        art = ArtType.digital,
        //        bonus = BonusType.influence
        //    },
        //    new Contract
        //    {
        //        art = ArtType.digital,
        //        bonus = BonusType.contract
        //    }
        //    );
        //    context.ReputationTiles.AddOrUpdate(
        //    r => r.scoring,
        //    new ReputationTile
        //    {
        //        money = 1,
        //        influence = 0,
        //        scoring = ReputationTileScoring.threeInflunce
        //    },
        //    new ReputationTile
        //    {
        //        money = 3,
        //        influence = 1,
        //        scoring = ReputationTileScoring.collector
        //    },
        //    new ReputationTile
        //    {
        //        money = 2,
        //        influence = 1,
        //        scoring = ReputationTileScoring.vip
        //    },
        //    new ReputationTile
        //    {
        //        money = 2,
        //        influence = 1,
        //        scoring = ReputationTileScoring.investor
        //    },
        //    new ReputationTile
        //    {
        //        money = 1,
        //        influence = 0,
        //        scoring = ReputationTileScoring.visitor
        //    },
        //    new ReputationTile
        //    {
        //        money = 4,
        //        influence = 0,
        //        scoring = ReputationTileScoring.visitorSet
        //    },
        //    new ReputationTile
        //    {
        //        money = 1,
        //        influence = 2,
        //        scoring = ReputationTileScoring.reputationTile
        //    },
        //    new ReputationTile
        //    {
        //        money = 3,
        //        influence = 1,
        //        scoring = ReputationTileScoring.auction
        //    },
        //    new ReputationTile
        //    {
        //        money = 1,
        //        influence = 1,
        //        scoring = ReputationTileScoring.assistant
        //    },
        //    new ReputationTile
        //    {
        //        money = 2,
        //        influence = 0,
        //        scoring = ReputationTileScoring.promotion
        //    },
        //    new ReputationTile
        //    {
        //        money = 2,
        //        influence = 0,
        //        scoring = ReputationTileScoring.aquired
        //    },
        //    new ReputationTile
        //    {
        //        money = 3,
        //        influence = 1,
        //        scoring = ReputationTileScoring.sold
        //    },
        //    new ReputationTile
        //    {
        //        money = 3,
        //        influence = 1,
        //        scoring = ReputationTileScoring.exhibiting
        //    },
        //    new ReputationTile
        //    {
        //        money = 2,
        //        influence = 1,
        //        scoring = ReputationTileScoring.artType
        //    },
        //    new ReputationTile
        //    {
        //        money = 3,
        //        influence = 1,
        //        scoring = ReputationTileScoring.photo
        //    },
        //    new ReputationTile
        //    {
        //        money = 3,
        //        influence = 1,
        //        scoring = ReputationTileScoring.painting
        //    },
        //    new ReputationTile
        //    {
        //        money = 3,
        //        influence = 1,
        //        scoring = ReputationTileScoring.digital
        //    },
        //    new ReputationTile
        //    {
        //        money = 3,
        //        influence = 1,
        //        scoring = ReputationTileScoring.sculpture
        //    },
        //    new ReputationTile
        //    {
        //        money = 2,
        //        influence = 1,
        //        scoring = ReputationTileScoring.fame
        //    },
        //    new ReputationTile
        //    {
        //        money = 4,
        //        influence = 2,
        //        scoring = ReputationTileScoring.masterpiece,
        //    }
        //    );
        //    //  This method will be called after migrating to the latest version.

        //    //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
        //    //  to avoid creating duplicate seed data. E.g.
        //    //
        //    //    context.People.AddOrUpdate(
        //    //      p => p.FullName,
        //    //      new Person { FullName = "Andrew Peters" },
        //    //      new Person { FullName = "Brice Lambson" },
        //    //      new Person { FullName = "Rowan Miller" }
        //    //    );
        //    //
        //}
    }
}
