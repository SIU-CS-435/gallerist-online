namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContractAction1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "CurrentActionLocation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "CurrentActionLocation");
        }
    }
}
