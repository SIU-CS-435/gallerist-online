namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class executiveactions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameArts", "IsSold", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameArts", "IsSold");
        }
    }
}
