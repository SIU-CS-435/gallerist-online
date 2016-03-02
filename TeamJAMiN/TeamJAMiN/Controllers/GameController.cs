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

                ViewBag.artLists = db.TemplateArt.ToList().chooseArt();
                newGame.AddArtStack(ViewBag.artLists);

                var blueArtists = db.TemplateArtists.Where(a => a.Category == ArtistCategory.red).ToList().chooseArtists();
                var redArtists = db.TemplateArtists.Where(a => a.Category == ArtistCategory.blue).ToList().chooseArtists();
                ViewBag.redArtists = redArtists;
                ViewBag.blueArtists = blueArtists;
                newGame.AddArtists(blueArtists.Values.ToList());
                newGame.AddArtists(redArtists.Values.ToList());


                ViewBag.ReputationTiles = db.TemplateReputationTiles.ToList().chooseReputationTiles();
                newGame.AddReputationTiles(ViewBag.ReputationTiles);

                ViewBag.Contracts = db.Contracts.ToList().Shuffle().ToList();
                newGame.AddContracts(ViewBag.Contracts);

                var artist = newGame.Artists.Where(a => a.ArtType == ArtType.digital && a.Category == ArtistCategory.red).FirstOrDefault();


                db.SaveChanges();
                return View(newGame);
            }
        }
    }
}
