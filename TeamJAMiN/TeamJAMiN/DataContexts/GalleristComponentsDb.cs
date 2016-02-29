using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TeamJAMiN.GalleristComponentEntities;

namespace TeamJAMiN.DataContexts
{
    public class GalleristComponentsDb : DbContext
    {
        public DbSet<TemplateArt> TemplateArt { get; set; }
        public DbSet<TemplateArtist> TemplateArtists { get; set; }

        public DbSet<GameArt> Art { get; set; }
        public DbSet<GameArtist> Artists { get; set; }

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ReputationTile> ReputationTiles { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }

        public GalleristComponentsDb()
            : base("DefaultConnection")
        {
        }
    }
}