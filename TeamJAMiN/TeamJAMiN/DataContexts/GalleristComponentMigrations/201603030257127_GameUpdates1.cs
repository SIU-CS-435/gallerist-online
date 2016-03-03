namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameUpdates1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "MaxNumberOfPlayers", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "IsCompleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Games", "NumberOfPlayers");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "NumberOfPlayers", c => c.Int(nullable: false));
            DropColumn("dbo.Games", "IsCompleted");
            DropColumn("dbo.Games", "MaxNumberOfPlayers");
        }
    }
}
