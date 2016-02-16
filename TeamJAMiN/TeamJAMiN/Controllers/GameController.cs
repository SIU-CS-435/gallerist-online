using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeamJAMiN.Controllers
{
    public class GameController : Controller
    {
        // GET: Game List
        public ActionResult List()
        {
            var rand = new Random();
            var randInt = rand.Next(10);

            var games = new List<string>();

            for (int i = 0; i < randInt; ++i)
            {
                games.Add("Game " + (i + 1));
            }

            ViewBag.games = games;
            return View();
        }
        public ActionResult Play()
        {
            return View();
        }
    }
}
