namespace TeamJAMiN.DataContexts.GalleristComponentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArtistBonuses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameArtists", "DiscoverBonus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameArtists", "DiscoverBonus");
        }
    }
}
