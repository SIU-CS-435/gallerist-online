namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VisitorInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameVisitors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Location_Type = c.Int(nullable: false),
                        Game_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.Game_Id)
                .Index(t => t.Game_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameVisitors", "Game_Id", "dbo.Games");
            DropIndex("dbo.GameVisitors", new[] { "Game_Id" });
            DropTable("dbo.GameVisitors");
        }
    }
}
