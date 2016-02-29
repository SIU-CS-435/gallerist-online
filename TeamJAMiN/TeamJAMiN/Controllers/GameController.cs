using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TeamJAMiN.DataContexts;
using TeamJAMiN.GameControllerHelpers;
using TeamJAMiN.GalleristComponentEntities;
using TeamJAMiN.Models;

namespace TeamJAMiN.Controllers
{
    public class GameController : Controller
    {
        //private GalleristComponentsDb db = new GalleristComponentsDb();
        // GET: Game List
        public ActionResult List()
        {
            var rand = new Random();
            var randInt = rand.Next(10);

            var games = new List<string>();

            var userName = User.Identity.Name;
            using (var identityDb = new ApplicationDbContext())
            {
                var userId = identityDb.Users.First(m => m.UserName == userName).Id;
                
                for (int i = 0; i < randInt; ++i)
                {
                    games.Add("Game " + (i + 1));
                }

                ViewBag.games = games;
                return View();
            }
        }
        public ActionResult Play()
        {
            using (var db = new GalleristComponentsDb())
            {
                Game newGame = new Game();
                Dictionary<ArtType, List<Art>> artStacks = new Dictionary<ArtType, List<Art>>();
                foreach (ArtType type in Enum.GetValues(typeof(ArtType)))
                    artStacks.Add(type, db.Art.Where(a => a.type == type).ToList());

                newGame.art = artStacks.shuffleArt();
                newGame.redArtists = db.Artists.Where(a => a.category == ArtistCategory.red).ToList().chooseArtists();
                newGame.blueArtists = db.Artists.Where(a => a.category == ArtistCategory.blue).ToList().chooseArtists();
                newGame.reputationTiles = db.ReputationTiles.ToList().chooseReputationTiles();
                newGame.contracts = db.Contracts.ToList().Shuffle().ToList();

                db.SaveChanges();
                return View(newGame);
            }
        }
    }
}
