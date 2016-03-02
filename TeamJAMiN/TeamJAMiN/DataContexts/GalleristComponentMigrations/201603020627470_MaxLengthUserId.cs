namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaxLengthUserId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Players", "UserId", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Players", "UserId", c => c.String());
        }
    }
}
