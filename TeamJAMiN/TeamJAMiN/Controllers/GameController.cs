using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TeamJAMiN.DataContexts;
using TeamJAMiN.GameControllerHelpers;
using TeamJAMiN.GalleristComponentEntities;
using TeamJAMiN.Models;
using TeamJAMiN.GalleristComponentEntities.Dtos;

namespace TeamJAMiN.Controllers
{
    public class GameController : Controller
    {
        // GET: Game List
        //[AllowAnonymous] We may want to allow anonymous to list games in the future
        [Authorize]
        public ActionResult List()
        {
            var userName = User.Identity.Name;

            using (var identityContext = new ApplicationDbContext())
            {
                var userId = identityContext.Users.First(m => m.UserName == userName).Id;
                using (var galleristContext = new GalleristComponentsDbContext())
                {
                    var games = galleristContext.Games.Where(m => m.NumberOfPlayers != m.Players.Count)
                        .Select(m => new GameDto
                        {
                            Url = "/Game/Play/" + m.Id,
                            Name = m.Name,
                            CurrentNumberOfPlayers = m.Players.Count,
                            MaxNumberOfPlayers = m.NumberOfPlayers,
                            MaxTurnLength = m.TurnLength
                        }).ToList();

                    ViewBag.games = games;
                    return View();
                }
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Game());
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Game newGame)
        {
            using (var galleristContext = new GalleristComponentsDbContext())
            {
                newGame.CreateRandomSetup();
                galleristContext.Games.Add(newGame);
                using (var identityContext = new ApplicationDbContext())
                {
                    //add me to the game
                    newGame.Players.Add(new Player { UserId = identityContext.Users.First(m => m.UserName == User.Identity.Name).Id });
                }
                galleristContext.SaveChanges();
                return Redirect("/Game/List");
            }
        }

        /// <summary>
        /// Takes you to the new game view. This also creates a game but we really need to do that in a post. We also need an additional step between clicking New Game
        /// and creating the game. For example we probably want to setup rules, setup a game name etc.
        /// </summary>
        /// <returns>Game View</returns>
        [Authorize]
        public ActionResult Play(int id = 0)
        {
            if (id == 0)
            {
                using (var galleristContext = new GalleristComponentsDbContext())
                {
                    Game newGame = new Game();
                    newGame.CreateRandomSetup();

                    //TODO: We need to allow users to input these values instead of auto generating
                    var gameNameStrings = new List<String>{
                        "The Gallerist Test Game 1",
                        "Gallerist Game A",
                        "Gallerist Game Dev",
                        "Trying the gallerist!",
                        "Let's give Gallerist a go!",
                        "Gallerist - All welcome :)",
                        "Gallerist time lets gooo...",
                        "Gallerist Private Room"
                    };

                    var rand = new Random();
                    var gameName = gameNameStrings.ElementAt(rand.Next(gameNameStrings.Count));
                    newGame.Name = gameName;
                    newGame.NumberOfPlayers = 4;
                    newGame.TurnLength = 60;

                    //need standard for adding a player to a game
                    using (var identityContext = new ApplicationDbContext())
                    {
                        //add me to the game
                        newGame.Players.Add(new Player { UserId = identityContext.Users.First(m => m.UserName == User.Identity.Name).Id });
                        galleristContext.Games.Add(newGame);
                        galleristContext.SaveChanges();
                        return View(newGame);
                    }
                }
            }
            else
            {
                //TODO: Make this less horrible. Need a new action
                using (var galleristContext = new GalleristComponentsDbContext())
                {
                    var game = galleristContext.Games.Include("Art").Include("Artists").Include("ReputationTiles").Include("Contracts").Include("Visitors").FirstOrDefault(m => m.Id == id);

                    if (game == null)
                    {
                        return View("NotFound");
                    }

                    return View(game);
                }
            }
        }

        /// <summary>
        /// Takes you to the view for an existing game
        /// </summary>
        /// <returns>Specified Game View</returns>
        //[Authorize]
        //public ActionResult Play(int id)
        //{
        //    using (var galleristContext = new GalleristComponentsDbContext())
        //    {
        //        var game = galleristContext.Games.FirstOrDefault(m => m.Id == id);

        //        if(game == null)
        //        {
        //            return View("NotFound");
        //        }

        //        return View(game);
        //    }
        //}
    }
}
