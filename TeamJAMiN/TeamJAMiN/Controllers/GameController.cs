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
                    var allGames = galleristContext.Games.Where(m => !m.IsCompleted)
                        .Select(m => new GameDto
                        {
                            Url = "/Game/Play/" + m.Id,
                            Name = m.Name,
                            CurrentNumberOfPlayers = m.Players.Count,
                            MaxNumberOfPlayers = m.MaxNumberOfPlayers,
                            RemainingSlots = m.MaxNumberOfPlayers - m.Players.Count,
                            MaxTurnLength = m.TurnLength,
                            MaxTurnLengthString = m.TurnLength + " Minutes Per Turn",
                            PlayersString = m.Players.Count + " of " + m.MaxNumberOfPlayers + " players"
                        }).ToList();

                    var myGames =
                        galleristContext.Games.Where(m => m.Players.Any(n => n.UserId == userId) && !m.IsCompleted)
                        .Select(m => new GameDto
                        {
                            Url = "/Game/Play/" + m.Id,
                            Name = m.Name,
                            CurrentNumberOfPlayers = m.Players.Count,
                            MaxNumberOfPlayers = m.MaxNumberOfPlayers,
                            RemainingSlots = m.MaxNumberOfPlayers - m.Players.Count,
                            MaxTurnLength = m.TurnLength,
                            MaxTurnLengthString = m.TurnLength + " Minutes Per Turn",
                            PlayersString = m.Players.Count + " of " + m.MaxNumberOfPlayers + " players"
                        }).ToList();

                    ViewBag.allGames = allGames;
                    ViewBag.myGames = myGames;
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
        /// Takes you to an existing view for a game
        /// </summary>
        /// <returns>Game View</returns>
        [Authorize]
        public ActionResult Play(int id = 0)
        {
            using (var galleristContext = new GalleristComponentsDbContext())
            {
                var game = galleristContext.Games.Include("Art").Include("Artists").Include("ReputationTiles").Include("Contracts").Include("Visitors").Include("Players").FirstOrDefault(m => m.Id == id);

                if (game == null)
                {
                    return View("NotFound");
                }

                using (var identityContext = new ApplicationDbContext())
                {
                    //add me to the game
                    ViewBag.userName = User.Identity.Name;
                }
                return View(game);
            }
        }
    }
}
