namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class playermodels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlayerAssistants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location_Id = c.Int(),
                        Player_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TemplateLocations", t => t.Location_Id)
                .ForeignKey("dbo.Players", t => t.Player_Id)
                .Index(t => t.Location_Id)
                .Index(t => t.Player_Id);
            
            CreateTable(
                "dbo.TemplateLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.GameArts", "Artist_Id", c => c.Int());
            AddColumn("dbo.GameArts", "Player_Id", c => c.Int());
            AddColumn("dbo.GameContracts", "Player_Id", c => c.Int());
            AddColumn("dbo.Players", "Money", c => c.Int(nullable: false));
            AddColumn("dbo.Players", "Influence", c => c.Int(nullable: false));
            AddColumn("dbo.Players", "comission_Id", c => c.Int());
            AddColumn("dbo.GameReputationTiles", "Player_Id", c => c.Int());
            AddColumn("dbo.GameVisitors", "Location_Id", c => c.Int());
            CreateIndex("dbo.GameArts", "Artist_Id");
            CreateIndex("dbo.GameArts", "Player_Id");
            CreateIndex("dbo.GameContracts", "Player_Id");
            CreateIndex("dbo.Players", "comission_Id");
            CreateIndex("dbo.GameReputationTiles", "Player_Id");
            CreateIndex("dbo.GameVisitors", "Location_Id");
            AddForeignKey("dbo.GameArts", "Artist_Id", "dbo.GameArtists", "Id");
            AddForeignKey("dbo.GameArts", "Player_Id", "dbo.Players", "Id");
            AddForeignKey("dbo.Players", "comission_Id", "dbo.GameArtists", "Id");
            AddForeignKey("dbo.GameContracts", "Player_Id", "dbo.Players", "Id");
            AddForeignKey("dbo.GameReputationTiles", "Player_Id", "dbo.Players", "Id");
            AddForeignKey("dbo.GameVisitors", "Location_Id", "dbo.TemplateLocations", "Id");
            DropColumn("dbo.GameVisitors", "Location_Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GameVisitors", "Location_Type", c => c.Int(nullable: false));
            DropForeignKey("dbo.GameVisitors", "Location_Id", "dbo.TemplateLocations");
            DropForeignKey("dbo.GameReputationTiles", "Player_Id", "dbo.Players");
            DropForeignKey("dbo.GameContracts", "Player_Id", "dbo.Players");
            DropForeignKey("dbo.Players", "comission_Id", "dbo.GameArtists");
            DropForeignKey("dbo.PlayerAssistants", "Player_Id", "dbo.Players");
            DropForeignKey("dbo.PlayerAssistants", "Location_Id", "dbo.TemplateLocations");
            DropForeignKey("dbo.GameArts", "Player_Id", "dbo.Players");
            DropForeignKey("dbo.GameArts", "Artist_Id", "dbo.GameArtists");
            DropIndex("dbo.GameVisitors", new[] { "Location_Id" });
            DropIndex("dbo.GameReputationTiles", new[] { "Player_Id" });
            DropIndex("dbo.PlayerAssistants", new[] { "Player_Id" });
            DropIndex("dbo.PlayerAssistants", new[] { "Location_Id" });
            DropIndex("dbo.Players", new[] { "comission_Id" });
            DropIndex("dbo.GameContracts", new[] { "Player_Id" });
            DropIndex("dbo.GameArts", new[] { "Player_Id" });
            DropIndex("dbo.GameArts", new[] { "Artist_Id" });
            DropColumn("dbo.GameVisitors", "Location_Id");
            DropColumn("dbo.GameReputationTiles", "Player_Id");
            DropColumn("dbo.Players", "comission_Id");
            DropColumn("dbo.Players", "Influence");
            DropColumn("dbo.Players", "Money");
            DropColumn("dbo.GameContracts", "Player_Id");
            DropColumn("dbo.GameArts", "Player_Id");
            DropColumn("dbo.GameArts", "Artist_Id");
            DropTable("dbo.TemplateLocations");
            DropTable("dbo.PlayerAssistants");
        }
    }
}
