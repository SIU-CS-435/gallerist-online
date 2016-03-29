namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayerOrderSchema : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Players", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.Players", "Game_Id1", "dbo.Games");
            DropIndex("dbo.Players", new[] { "Game_Id" });
            DropIndex("dbo.Players", new[] { "Game_Id1" });
            DropColumn("dbo.Players", "Game_Id1");
            AlterColumn("dbo.Players", "GameId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Players", "GameId", "dbo.Games", "Id", cascadeDelete: true);
            DropColumn("dbo.Players", "Game_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "Game_Id", c => c.Int());
            DropForeignKey("dbo.Players", "GameId", "dbo.Games");
            AlterColumn("dbo.Players", "GameId", c => c.Int());
            AddColumn("dbo.Players", "Game_Id1", c => c.Int(nullable: false));
            CreateIndex("dbo.Players", "Game_Id1");
            CreateIndex("dbo.Players", "Game_Id");
            AddForeignKey("dbo.Players", "Game_Id1", "dbo.Games", "Id");
            AddForeignKey("dbo.Players", "Game_Id", "dbo.Games", "Id");
        }
    }
}
