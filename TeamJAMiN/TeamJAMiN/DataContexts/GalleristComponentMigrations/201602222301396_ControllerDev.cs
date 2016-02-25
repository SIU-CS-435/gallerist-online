namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ControllerDev : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artists", "fame", c => c.Int(nullable: false));
            AddColumn("dbo.Artists", "promotion", c => c.Int(nullable: false));
            DropColumn("dbo.Artists", "startFame");
            DropColumn("dbo.Artists", "startPromotion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Artists", "startPromotion", c => c.Int(nullable: false));
            AddColumn("dbo.Artists", "startFame", c => c.Int(nullable: false));
            DropColumn("dbo.Artists", "promotion");
            DropColumn("dbo.Artists", "fame");
        }
    }
}
