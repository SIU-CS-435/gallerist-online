namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VisitorsTicketsContracts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PlayerAssistants", "Location_Id", "dbo.TemplateLocations");
            DropForeignKey("dbo.GameVisitors", "Location_Id", "dbo.TemplateLocations");
            DropIndex("dbo.PlayerAssistants", new[] { "Location_Id" });
            DropIndex("dbo.GameVisitors", new[] { "Location_Id" });
            AddColumn("dbo.GameContracts", "Order", c => c.Int(nullable: false));
            AddColumn("dbo.GameContracts", "Location", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "AvailableVipTickets", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "AvailableInvestorTickets", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "AvailableCollectorTickets", c => c.Int(nullable: false));
            AddColumn("dbo.Players", "VipTickets", c => c.Int(nullable: false));
            AddColumn("dbo.Players", "InvestorTickets", c => c.Int(nullable: false));
            AddColumn("dbo.Players", "CollectorTickets", c => c.Int(nullable: false));
            AddColumn("dbo.PlayerAssistants", "Location", c => c.Int(nullable: false));
            AddColumn("dbo.GameReputationTiles", "Column", c => c.Int(nullable: false));
            AddColumn("dbo.GameReputationTiles", "Row", c => c.Int(nullable: false));
            AddColumn("dbo.GameVisitors", "Location", c => c.Int(nullable: false));
            AddColumn("dbo.GameVisitors", "PlayerGallery", c => c.Int(nullable: false));
            AddColumn("dbo.GameVisitors", "Order", c => c.Int(nullable: false));
            DropColumn("dbo.PlayerAssistants", "Location_Id");
            DropColumn("dbo.GameVisitors", "Location_Id");
            DropTable("dbo.TemplateLocations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TemplateLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.GameVisitors", "Location_Id", c => c.Int());
            AddColumn("dbo.PlayerAssistants", "Location_Id", c => c.Int());
            DropColumn("dbo.GameVisitors", "Order");
            DropColumn("dbo.GameVisitors", "PlayerGallery");
            DropColumn("dbo.GameVisitors", "Location");
            DropColumn("dbo.GameReputationTiles", "Row");
            DropColumn("dbo.GameReputationTiles", "Column");
            DropColumn("dbo.PlayerAssistants", "Location");
            DropColumn("dbo.Players", "CollectorTickets");
            DropColumn("dbo.Players", "InvestorTickets");
            DropColumn("dbo.Players", "VipTickets");
            DropColumn("dbo.Games", "AvailableCollectorTickets");
            DropColumn("dbo.Games", "AvailableInvestorTickets");
            DropColumn("dbo.Games", "AvailableVipTickets");
            DropColumn("dbo.GameContracts", "Location");
            DropColumn("dbo.GameContracts", "Order");
            CreateIndex("dbo.GameVisitors", "Location_Id");
            CreateIndex("dbo.PlayerAssistants", "Location_Id");
            AddForeignKey("dbo.GameVisitors", "Location_Id", "dbo.TemplateLocations", "Id");
            AddForeignKey("dbo.PlayerAssistants", "Location_Id", "dbo.TemplateLocations", "Id");
        }
    }
}
