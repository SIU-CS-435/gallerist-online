namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayerCOlor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "Color", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "Color");
        }
    }
}
