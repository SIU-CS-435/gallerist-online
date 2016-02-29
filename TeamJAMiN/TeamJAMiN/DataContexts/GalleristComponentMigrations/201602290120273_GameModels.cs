namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameArts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Fame = c.Int(nullable: false),
                        NumTickets = c.Int(nullable: false),
                        FirstTicketData = c.String(),
                        Order = c.Int(nullable: false),
                        SecondTicketData = c.String(),
                        Game_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.Game_Id)
                .Index(t => t.Game_Id);
            
            CreateTable(
                "dbo.GameArtists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.Int(nullable: false),
                        ArtType = c.Int(nullable: false),
                        Fame = c.Int(nullable: false),
                        Promotion = c.Int(nullable: false),
                        StarLevelData = c.String(),
                        IsDiscovered = c.Boolean(nullable: false),
                        Game_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.Game_Id)
                .Index(t => t.Game_Id);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.TemplateArts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Slug = c.String(),
                        Type = c.Int(nullable: false),
                        Fame = c.Int(nullable: false),
                        NumTickets = c.Int(nullable: false),
                        FirstTicketData = c.String(),
                        SecondTicketData = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TemplateArtists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Slug = c.String(),
                        Category = c.Int(nullable: false),
                        ArtType = c.Int(nullable: false),
                        Fame = c.Int(nullable: false),
                        Promotion = c.Int(nullable: false),
                        StarLevelData = c.String(),
                        Discovered = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Contracts", "Game_Id", c => c.Int());
            AddColumn("dbo.ReputationTiles", "Game_Id", c => c.Int());
            CreateIndex("dbo.Contracts", "Game_Id");
            CreateIndex("dbo.ReputationTiles", "Game_Id");
            AddForeignKey("dbo.Contracts", "Game_Id", "dbo.Games", "Id");
            AddForeignKey("dbo.ReputationTiles", "Game_Id", "dbo.Games", "Id");
            DropTable("dbo.Arts");
            DropTable("dbo.Artists");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistId = c.Int(nullable: false, identity: true),
                        slug = c.String(),
                        category = c.Int(nullable: false),
                        artType = c.Int(nullable: false),
                        fame = c.Int(nullable: false),
                        promotion = c.Int(nullable: false),
                        starLevelData = c.String(),
                        discovered = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ArtistId);
            
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
            
            DropForeignKey("dbo.ReputationTiles", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.Players", "GameId", "dbo.Games");
            DropForeignKey("dbo.Contracts", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.GameArtists", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.GameArts", "Game_Id", "dbo.Games");
            DropIndex("dbo.ReputationTiles", new[] { "Game_Id" });
            DropIndex("dbo.Players", new[] { "GameId" });
            DropIndex("dbo.Contracts", new[] { "Game_Id" });
            DropIndex("dbo.GameArtists", new[] { "Game_Id" });
            DropIndex("dbo.GameArts", new[] { "Game_Id" });
            DropColumn("dbo.ReputationTiles", "Game_Id");
            DropColumn("dbo.Contracts", "Game_Id");
            DropTable("dbo.TemplateArtists");
            DropTable("dbo.TemplateArts");
            DropTable("dbo.Players");
            DropTable("dbo.Games");
            DropTable("dbo.GameArtists");
            DropTable("dbo.GameArts");
        }
    }
}
