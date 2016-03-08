namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeGameArtist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameArtists", "InitialFame", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameArtists", "InitialFame");
        }
    }
}
