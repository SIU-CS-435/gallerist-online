namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedTime1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Games", "StartTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Games", "StartTime", c => c.DateTime(nullable: false));
        }
    }
}
