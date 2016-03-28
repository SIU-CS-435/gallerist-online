namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayerOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Players", "GameId", "dbo.Games");
            AddColumn("dbo.Games", "PlayerOrderData", c => c.String());
            AddColumn("dbo.Players", "Game_Id", c => c.Int());
            AddColumn("dbo.Players", "Game_Id1", c => c.Int());
            CreateIndex("dbo.Players", "Game_Id");
            CreateIndex("dbo.Players", "Game_Id1");
            AddForeignKey("dbo.Players", "Game_Id", "dbo.Games", "Id");
            AddForeignKey("dbo.Players", "Game_Id1", "dbo.Games", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "Game_Id1", "dbo.Games");
            DropForeignKey("dbo.Players", "Game_Id", "dbo.Games");
            DropIndex("dbo.Players", new[] { "Game_Id1" });
            DropIndex("dbo.Players", new[] { "Game_Id" });
            DropColumn("dbo.Players", "Game_Id1");
            DropColumn("dbo.Players", "Game_Id");
            DropColumn("dbo.Games", "PlayerOrderData");
            AddForeignKey("dbo.Players", "GameId", "dbo.Games", "Id", cascadeDelete: true);
        }
    }
}
