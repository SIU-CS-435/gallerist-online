namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Assistants : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PlayerAssistants", "Player_Id", "dbo.Players");
            DropIndex("dbo.PlayerAssistants", new[] { "Player_Id" });
            RenameColumn(table: "dbo.PlayerAssistants", name: "Player_Id", newName: "PlayerId");
            AlterColumn("dbo.PlayerAssistants", "PlayerId", c => c.Int(nullable: false));
            CreateIndex("dbo.PlayerAssistants", "PlayerId");
            AddForeignKey("dbo.PlayerAssistants", "PlayerId", "dbo.Players", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayerAssistants", "PlayerId", "dbo.Players");
            DropIndex("dbo.PlayerAssistants", new[] { "PlayerId" });
            AlterColumn("dbo.PlayerAssistants", "PlayerId", c => c.Int());
            RenameColumn(table: "dbo.PlayerAssistants", name: "PlayerId", newName: "Player_Id");
            CreateIndex("dbo.PlayerAssistants", "Player_Id");
            AddForeignKey("dbo.PlayerAssistants", "Player_Id", "dbo.Players", "Id");
        }
    }
}
