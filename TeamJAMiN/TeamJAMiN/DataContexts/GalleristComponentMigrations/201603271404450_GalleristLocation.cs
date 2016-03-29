namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GalleristLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "GalleristLocation", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "GalleristLocation");
        }
    }
}
