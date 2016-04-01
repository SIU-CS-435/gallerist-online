using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TeamJAMiN.DataContexts;
using TeamJAMiN.Controllers.GameControllerHelpers;
using TeamJAMiN.GalleristComponentEntities;
using TeamJAMiN.Models;
using TeamJAMiN.GalleristComponentEntities.Dtos;
using TeamJAMiN.GalleristComponentEntities.Managers;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TeamJAMiN.Controllers.Hubs;
using TeamJAMiN.Controllers.Hubs.HubHelpers;

namespace TeamJAMiN.Controllers
{
    //todo move out into a different place
    public class AuthorizePlayerOfCurrentGame : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authorized = base.AuthorizeCore(httpContext);
            if (!authorized)
            {
                // The user is not authenticated
                return false;
            }

            var user = httpContext.User;

            var rd = httpContext.Request.RequestContext.RouteData;
            var gameIdString = rd.Values["id"].ToString();
            if (String.IsNullOrWhiteSpace(gameIdString)) return false;
            int gameId = -1;
            int.TryParse(gameIdString, out gameId);
            if (gameId < 1)
            {
                return false;
            }

            return IsPlayerInGame(user.Identity.Name, gameId);
        }

        private bool IsPlayerInGame(string username, int gameId)
        {
            var isPlayerInGame = false;

            using (var galleristContext = new GalleristComponentsDbContext())
            {
                var game = galleristContext.Games.SingleOrDefault(m => m.Id == gameId);
                if (game == null) return false;

                using (var identityContext = new ApplicationDbContext())
                {
                    var currentUser = identityContext.Users.FirstOrDefault(m => m.UserName == username); //todo: make sure usernames are unique
                    if (currentUser == null) return false;

                    foreach (var player in game.Players)
                    {
                        if (currentUser.Id == player.UserId)
                        {
                            isPlayerInGame = true;
                        }
                    }
                }
            }
            return isPlayerInGame;
        }
    }

    public class AuthorizeHostOfCurrentGame : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authorized = base.AuthorizeCore(httpContext);
            if (!authorized) return false;            

            var user = httpContext.User;

            var rd = httpContext.Request.RequestContext.RouteData;
            var gameIdString = rd.Values["id"].ToString();
            if (String.IsNullOrWhiteSpace(gameIdString)) return false;
            int gameId = -1;
            int.TryParse(gameIdString, out gameId);

            if (gameId < 1)
            {
                return false;
            }

            return IsPlayerHostOfGame(user.Identity.Name, gameId);
        }

        private bool IsPlayerHostOfGame(string username, int gameId)
        {
            var isPlayerHost = false;

            using (var galleristContext = new GalleristComponentsDbContext())
            {
                var game = galleristContext.Games.SingleOrDefault(m => m.Id == gameId);
                if (game == null) return false;

                using (var identityContext = new ApplicationDbContext())
                {
                    var currentUser = identityContext.Users.FirstOrDefault(m => m.UserName == username); //todo: make sure usernames are unique
                    if (currentUser == null) return false;

                    foreach (var player in game.Players)
                    {
                        if (currentUser.Id == player.UserId && player.IsHost)
                        {
                            isPlayerHost = true;
                            break;
                        }
                    }
                }
            }
            return isPlayerHost;
        }
    }

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
                    var allGames = galleristContext.Games.Where(m => !m.IsCompleted);
                    var myGames = allGames.Where(m => m.Players.Any(n => n.UserId == userId));

                    var allGamesList = allGames.Select(m => new GameDto
                    {
                        Id = m.Id,
                        Url = "/Game/Play/" + m.Id,
                        Name = m.Name,
                        CurrentNumberOfPlayers = m.Players.Count,
                        MaxNumberOfPlayers = m.MaxNumberOfPlayers,
                        RemainingSlots = m.MaxNumberOfPlayers - m.Players.Count,
                        MaxTurnLength = m.TurnLength,
                        MaxTurnLengthString = m.TurnLength + " Minutes Per Turn",
                        PlayersString = m.Players.Count + " of " + m.MaxNumberOfPlayers + " players",
                        isJoinable = !m.Players.Any(p => p.UserId == userId) && m.Players.Count < m.MaxNumberOfPlayers && !m.IsStarted,
                    }).ToList();

                    var myGamesList = myGames.Select(m => new GameDto
                    {
                        Id = m.Id,
                        Url = "/Game/Play/" + m.Id,
                        Name = m.Name,
                        CurrentNumberOfPlayers = m.Players.Count,
                        MaxNumberOfPlayers = m.MaxNumberOfPlayers,
                        RemainingSlots = m.MaxNumberOfPlayers - m.Players.Count,
                        MaxTurnLength = m.TurnLength,
                        MaxTurnLengthString = m.TurnLength + " Minutes Per Turn",
                        PlayersString = m.Players.Count + " of " + m.MaxNumberOfPlayers + " players",
                        isStartable = m.Players.Any(p => p.UserId == userId && p.IsHost) && !m.IsStarted,
                        isStarted = m.IsStarted
                    }).ToList();

                    ViewBag.allGames = allGamesList;
                    ViewBag.myGames = myGamesList;
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
            if (ModelState.IsValid)
            {
                using (var galleristContext = new GalleristComponentsDbContext())
                {
                    newGame.CreatedTime = DateTime.Now;
                    galleristContext.Games.Add(newGame);
                    using (var identityContext = new ApplicationDbContext())
                    {
                        //add me to the game
                        newGame.Players.Add(new Player
                        {
                            UserId = identityContext.Users.First(m => m.UserName == User.Identity.Name).Id,
                            IsHost = true
                        });
                    }
                    galleristContext.SaveChanges();
                    return Redirect("/Game/List"); //redirect to actual game might be better for demo purposes
                }
            }
            else
            {
                return View(newGame);
            }
        }

        /// <summary>
        /// Takes you to an existing view for a game for which you are a member
        /// </summary>
        /// <returns>Game View</returns>
        [Authorize]
        public ActionResult Play(int id = 0)
        {
            using (var galleristContext = new GalleristComponentsDbContext())
            {
                using (var identityContext = new ApplicationDbContext())
                {

                    UserManager<ApplicationUser> uManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(identityContext));

                    var gameResponse = GameManager.GetGame(id, User.Identity.Name, galleristContext, identityContext);

                    if (gameResponse.Success && gameResponse.Game.IsStarted)
                    {
                        ViewBag.userName = User.Identity.Name;
                        var user = uManager.FindByName(User.Identity.Name);
                        ViewBag.userId = user.Id;
                        return View(gameResponse.Game);
                    }
                    else
                    {
                        ViewBag.Message = gameResponse.Message;
                        ViewBag.Title = gameResponse.Title;
                        return View("GameError");
                    }
                }
            }
        }

        /// <summary>
        /// Joins an existing game and takes you to the view for that game.
        /// </summary>
        /// <returns>Existing game view or appropriate error</returns>
        [Authorize]
        [HttpPost]
        public ActionResult Join(int id = 0)
        {
            using (var galleristContext = new GalleristComponentsDbContext())
            {
                using (var identityContext = new ApplicationDbContext())
                {
                    var gameResponse = GameManager.GetGame(id, User.Identity.Name, galleristContext, identityContext);

                    if (gameResponse.Success)
                    {
                        gameResponse.Game.Players.Add(new Player { UserId = identityContext.Users.First(m => m.UserName == User.Identity.Name).Id });
                        ViewBag.userName = User.Identity.Name;
                        galleristContext.SaveChanges();
                        return Redirect("/Game/List");
                    }
                    else
                    {
                        ViewBag.Message = gameResponse.Message;
                        ViewBag.Title = gameResponse.Title;
                        return View("GameError");
                    }
                }
            }
        }

        /// <summary>
        /// Starts a game and emails all of the players that their game has started.
        /// </summary>
        /// <param name="id">The id of the game to start</param>
        /// <returns>Existing game view or appropriate error</returns>
        [AuthorizeHostOfCurrentGame]
        [HttpPost]
        public ActionResult Start(int id = 0)
        {
            using (var galleristContext = new GalleristComponentsDbContext())
            {
                using (var identityContext = new ApplicationDbContext())
                {
                    //todo: set start time of game to datetime.now
                    var gameResponse = GameManager.GetGame(id, User.Identity.Name, galleristContext, identityContext);
                    var game = gameResponse.Game;
                    game.StartTime = DateTime.Now;

                    if (game.IsStarted)
                    {
                        return Redirect("~/Game/Play/" + gameResponse.Game.Id);
                    }

                    if (gameResponse.Success)
                    {
                        game.CreateRandomSetup();
                        game.StartGame();
                        galleristContext.SaveChanges();

                        //todo make a helper in email manager for this
                        //todo also use the user and url params for signalr ajax update of game list
                        var gameUrl = Request.Url.GetLeftPart(UriPartial.Authority) + "/Game/Play/" + game.Id;
                        foreach (var player in game.Players)
                        {
                            var user = identityContext.Users.Single(m => m.Id == player.UserId);
                            if (string.IsNullOrWhiteSpace(user.Email)) //todo check email prefs
                                continue;
                                                       
                            var emailTitle = user.UserName + ", your game has started!"; //todo: get full name of player. We don't have names in the system yet
                            var emailBody = "A game that you are a member of has started. You can play it by visiting The Gallerist Online" +
                                " and viewing your active games or by clicking the following link: <a href='" + gameUrl + "'></a>";

                            EmailManager.SendEmail(emailTitle, emailBody, new List<string> { user.Email });
                        }
                        //todo expand module to use signalr for all game list actions
                        PushHelper.UpdateMyGamesList(game.Players.Where(p => p.UserId != User.Identity.GetUserId()).Select(p => p.UserId).ToList(), gameUrl, game.Id);
                        return Redirect("~/Game/Play/" + gameResponse.Game.Id);
                    }
                    else
                    {
                        ViewBag.Message = gameResponse.Message;
                        ViewBag.Title = gameResponse.Title;
                        return View("GameError");
                    }
                }
            }
        }

        /// <summary>
        /// Skeleton method for taking an action/turn in the game
        /// </summary>
        /// <param name="id">The id of the game to take an action in</param>
        /// <param name="gameAction">The type of action to take along with appropriate values of money/influence spent etc</param>
        /// <returns>Existing game view or appropriate error</returns>
        [ValidateAntiForgeryToken]
        [AuthorizePlayerOfCurrentGame]
        [HttpPost]
        public ActionResult TakeGameAction(int id, PlayerLocation gameAction)
        {
            using (var galleristContext = new GalleristComponentsDbContext())
            {
                using (var identityContext = new ApplicationDbContext()) //may not need this anymore after adding the authorize helper
                {
                    var gameResponse = GameManager.GetGame(id, User.Identity.Name, galleristContext, identityContext);
                    var game = gameResponse.Game;
                    
                    //todo todo todo
                    //make sure the player taking an action is the current player
                    //compare current action to game state to make sure a valid action was taken (e.g. player can't move to board spot A from board spot A) [states..]
		            //todo make getting user by username a method (is it one already?)
		            var currentUser = identityContext.Users.FirstOrDefault(m => m.UserName == User.Identity.Name);

		            //todo refactor some of this into a game logic module
		            var player = game.Players.FirstOrDefault(p => p.UserId == currentUser.Id);
		            if (player == null)
		            {
		    	        return View("GameError");
		            }
		            if (player.Id != game.CurrentPlayerId )
		            {
		    	        return View("GameError");
		            }
		            if(player.GalleristLocation == gameAction)
		            {
			        //todo disallow player to take the same action twice
			        return Redirect("~/Game/Play/" + id);
		            }
		            var kickedPlayer = game.Players.FirstOrDefault(p => p.GalleristLocation == gameAction);
		            if(kickedPlayer != null)
		            {
			        game.KickedOutPlayerId = kickedPlayer.Id;
		            }
		            player.GalleristLocation = gameAction;
                    //check if it is one of the special cases where the action must be confirmed before allowing the next step to proceed (e.g. player must draw cards)
                    //if yes take an intermediate step, still remains current player's turn
                    //if no, continue doing logic things  //determine order of bumped player's actions, can these happen at the end of current player's turn?
                    //check player locations for action taken by current player to see if any players need to be "bumped" to another spot
                    //somewhere in here we need to inject bumped player into turn order, we also need a way to specify that the current "turn" for a bumped player is not a full turn [bumped turn flag or something]
                    //let said player take bumped turn if necessary
                    //again do the updatey
                    //need some signalr stuff so we can show the action to everyone when it is done (intermediate step or not) as well as update money, influence, board, etc.
                    //update money, influence, board, etc.

                    game.UpdatePlayerOrder();
                    galleristContext.SaveChanges();
                    return Redirect("~/Game/Play/" + id);
                    //send email to next player in turn order
                    //EmailManager.SendEmail("Player X, it is your turn to play!", "It's your turn to play at: LINK", "Mr Guy Who Gets Email.com");

                    //ViewBag.Message = "Not Yet Implemented";
                    //ViewBag.Title = "Not Yet Implemented";
                    //return View("GameError");
                }
            }
        }
    }
}
