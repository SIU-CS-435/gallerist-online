namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGameContracts : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Contracts", newName: "GameContracts");
            RenameTable(name: "dbo.ReputationTiles", newName: "GameReputationTiles");
            DropPrimaryKey("dbo.GameContracts");
            DropColumn("dbo.GameContracts", "ContractId");

            DropPrimaryKey("dbo.GameReputationTiles");
            DropColumn("dbo.GameReputationTiles", "ReputationTileId");

            CreateTable(
                "dbo.TemplateContracts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Art = c.Int(nullable: false),
                        Bonus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TemplateReputationTiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Influence = c.Int(nullable: false),
                        Money = c.Int(nullable: false),
                        Scoring = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.TemplateArtists", "IsDiscovered", c => c.Boolean(nullable: false));
            AddColumn("dbo.GameContracts", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.GameReputationTiles", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.GameContracts", "Id");
            AddPrimaryKey("dbo.GameReputationTiles", "Id");
            DropColumn("dbo.TemplateArtists", "Discovered");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GameReputationTiles", "ReputationTileId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.GameContracts", "ContractId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.TemplateArtists", "Discovered", c => c.Boolean(nullable: false));
            DropPrimaryKey("dbo.GameReputationTiles");
            DropPrimaryKey("dbo.GameContracts");
            DropColumn("dbo.GameReputationTiles", "Id");
            DropColumn("dbo.GameContracts", "Id");
            DropColumn("dbo.TemplateArtists", "IsDiscovered");
            DropTable("dbo.TemplateReputationTiles");
            DropTable("dbo.TemplateContracts");
            AddPrimaryKey("dbo.GameReputationTiles", "ReputationTileId");
            AddPrimaryKey("dbo.GameContracts", "ContractId");
            RenameTable(name: "dbo.GameReputationTiles", newName: "ReputationTiles");
            RenameTable(name: "dbo.GameContracts", newName: "Contracts");
        }
    }
}
