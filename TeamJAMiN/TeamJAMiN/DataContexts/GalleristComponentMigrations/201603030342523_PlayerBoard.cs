namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayerBoard : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Players", name: "comission_Id", newName: "Commission_Id");
            RenameIndex(table: "dbo.Players", name: "IX_comission_Id", newName: "IX_Commission_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Players", name: "IX_Commission_Id", newName: "IX_comission_Id");
            RenameColumn(table: "dbo.Players", name: "Commission_Id", newName: "comission_Id");
        }
    }
}
