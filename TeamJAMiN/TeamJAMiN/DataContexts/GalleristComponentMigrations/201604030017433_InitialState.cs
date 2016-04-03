namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialState : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "CurrentActionState", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "CurrentActionState");
        }
    }
}
