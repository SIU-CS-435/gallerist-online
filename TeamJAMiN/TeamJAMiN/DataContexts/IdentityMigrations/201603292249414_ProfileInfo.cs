namespace TeamJAMiN.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfileInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AllowsEmails", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsPrivate", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsPrivate");
            DropColumn("dbo.AspNetUsers", "AllowsEmails");
        }
    }
}
