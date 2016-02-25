namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SortArtists : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artists", "discovered", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artists", "discovered");
        }
    }
}
