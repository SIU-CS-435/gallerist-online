namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class currentplayer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "CurrentPlayerId", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "KickedOutPlayerId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "KickedOutPlayerId");
            DropColumn("dbo.Games", "CurrentPlayerId");
        }
    }
}
