namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContractAction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "UserName");
        }
    }
}
