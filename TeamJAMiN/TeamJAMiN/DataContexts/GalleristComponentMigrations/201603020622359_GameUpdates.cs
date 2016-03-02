namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameUpdates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "Name", c => c.String());
            AddColumn("dbo.Games", "NumberOfPlayers", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "TurnLength", c => c.Int(nullable: false));
            AlterColumn("dbo.Players", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Players", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Games", "TurnLength");
            DropColumn("dbo.Games", "NumberOfPlayers");
            DropColumn("dbo.Games", "Name");
        }
    }
}
