using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamJAMiN.DataContexts;

namespace TeamJAMiN.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var galleristContext = new GalleristComponentsDbContext()) {
                ViewBag.NumberOfPlayers = galleristContext.Players.Count();
                ViewBag.NumberOfGames = galleristContext.Games.Count();
                ViewBag.RandomNumber = new Random().Next(100);
                return View();
            }
        }

        public ActionResult GameList()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}