namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "CreatedTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Games", "StartTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "StartTime");
            DropColumn("dbo.Games", "CreatedTime");
        }
    }
}
