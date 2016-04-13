namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updategameforturns : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Games", "CurrentActionState");
            DropColumn("dbo.Games", "CurrentActionLocation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "CurrentActionLocation", c => c.String());
            AddColumn("dbo.Games", "CurrentActionState", c => c.Int(nullable: false));
        }
    }
}
