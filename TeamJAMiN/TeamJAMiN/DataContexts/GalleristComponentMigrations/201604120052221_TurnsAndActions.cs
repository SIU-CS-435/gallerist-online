namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TurnsAndActions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameTurns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TurnNumber = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        CompletedActionData = c.String(),
                        PendingActionData = c.String(),
                        CurrentPlayer_Id = c.Int(),
                        Game_Id = c.Int(),
                        KickedOutPlayer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.CurrentPlayer_Id)
                .ForeignKey("dbo.Games", t => t.Game_Id)
                .ForeignKey("dbo.Players", t => t.KickedOutPlayer_Id)
                .Index(t => t.CurrentPlayer_Id)
                .Index(t => t.Game_Id)
                .Index(t => t.KickedOutPlayer_Id);
            
            AddColumn("dbo.GameArtists", "AvailableArt", c => c.Int(nullable: false));
            AddColumn("dbo.Players", "IsStartPlayer", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameTurns", "KickedOutPlayer_Id", "dbo.Players");
            DropForeignKey("dbo.GameTurns", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.GameTurns", "CurrentPlayer_Id", "dbo.Players");
            DropIndex("dbo.GameTurns", new[] { "KickedOutPlayer_Id" });
            DropIndex("dbo.GameTurns", new[] { "Game_Id" });
            DropIndex("dbo.GameTurns", new[] { "CurrentPlayer_Id" });
            DropColumn("dbo.Players", "IsStartPlayer");
            DropColumn("dbo.GameArtists", "AvailableArt");
            DropTable("dbo.GameTurns");
        }
    }
}
