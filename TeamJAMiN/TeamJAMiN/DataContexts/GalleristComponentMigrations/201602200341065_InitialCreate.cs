namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Arts",
                c => new
                    {
                        ArtId = c.Int(nullable: false, identity: true),
                        slug = c.String(),
                        type = c.Int(nullable: false),
                        fame = c.Int(nullable: false),
                        numTickets = c.Int(nullable: false),
                        firstTicketData = c.String(),
                        secondTicketData = c.String(),
                    })
                .PrimaryKey(t => t.ArtId);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistId = c.Int(nullable: false, identity: true),
                        slug = c.String(),
                        category = c.Int(nullable: false),
                        artType = c.Int(nullable: false),
                        startFame = c.Int(nullable: false),
                        startPromotion = c.Int(nullable: false),
                        starLevelData = c.String(),
                    })
                .PrimaryKey(t => t.ArtistId);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        ContractId = c.Int(nullable: false, identity: true),
                        art = c.Int(nullable: false),
                        bonus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContractId);
            
            CreateTable(
                "dbo.ReputationTiles",
                c => new
                    {
                        ReputationTileId = c.Int(nullable: false, identity: true),
                        influence = c.Int(nullable: false),
                        money = c.Int(nullable: false),
                        scoring = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReputationTileId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ReputationTiles");
            DropTable("dbo.Contracts");
            DropTable("dbo.Artists");
            DropTable("dbo.Arts");
        }
    }
}
