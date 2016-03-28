namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TemplateGameResources : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TemplateGames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.TemplateArts", "TemplateGame_Id", c => c.Int());
            AddColumn("dbo.TemplateArtists", "TemplateGame_Id", c => c.Int());
            AddColumn("dbo.TemplateContracts", "TemplateGame_Id", c => c.Int());
            AddColumn("dbo.TemplateReputationTiles", "TemplateGame_Id", c => c.Int());
            CreateIndex("dbo.TemplateArts", "TemplateGame_Id");
            CreateIndex("dbo.TemplateArtists", "TemplateGame_Id");
            CreateIndex("dbo.TemplateContracts", "TemplateGame_Id");
            CreateIndex("dbo.TemplateReputationTiles", "TemplateGame_Id");
            AddForeignKey("dbo.TemplateArts", "TemplateGame_Id", "dbo.TemplateGames", "Id");
            AddForeignKey("dbo.TemplateArtists", "TemplateGame_Id", "dbo.TemplateGames", "Id");
            AddForeignKey("dbo.TemplateContracts", "TemplateGame_Id", "dbo.TemplateGames", "Id");
            AddForeignKey("dbo.TemplateReputationTiles", "TemplateGame_Id", "dbo.TemplateGames", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TemplateReputationTiles", "TemplateGame_Id", "dbo.TemplateGames");
            DropForeignKey("dbo.TemplateContracts", "TemplateGame_Id", "dbo.TemplateGames");
            DropForeignKey("dbo.TemplateArtists", "TemplateGame_Id", "dbo.TemplateGames");
            DropForeignKey("dbo.TemplateArts", "TemplateGame_Id", "dbo.TemplateGames");
            DropIndex("dbo.TemplateReputationTiles", new[] { "TemplateGame_Id" });
            DropIndex("dbo.TemplateContracts", new[] { "TemplateGame_Id" });
            DropIndex("dbo.TemplateArtists", new[] { "TemplateGame_Id" });
            DropIndex("dbo.TemplateArts", new[] { "TemplateGame_Id" });
            DropColumn("dbo.TemplateReputationTiles", "TemplateGame_Id");
            DropColumn("dbo.TemplateContracts", "TemplateGame_Id");
            DropColumn("dbo.TemplateArtists", "TemplateGame_Id");
            DropColumn("dbo.TemplateArts", "TemplateGame_Id");
            DropTable("dbo.TemplateGames");
        }
    }
}
