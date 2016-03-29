namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameStartPlayerHost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "IsStarted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Players", "IsHost", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "IsHost");
            DropColumn("dbo.Games", "IsStarted");
        }
    }
}
