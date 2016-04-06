namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssistantsToGames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlayerAssistants", "Game_Id", c => c.Int());
            CreateIndex("dbo.PlayerAssistants", "Game_Id");
            AddForeignKey("dbo.PlayerAssistants", "Game_Id", "dbo.Games", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayerAssistants", "Game_Id", "dbo.Games");
            DropIndex("dbo.PlayerAssistants", new[] { "Game_Id" });
            DropColumn("dbo.PlayerAssistants", "Game_Id");
        }
    }
}
