using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TG.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index", GameState.PlayerNames);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Chat()

        {

            ViewBag.Message = "Your chat page";



            return View();

        }

        [HttpPost]
        public ActionResult UpdatePoints()
        {
            //ViewBag.points = _Repository.Points;
            return PartialView("UpdatePoints");
        }

        public ActionResult Refresh()
        {
            return View("Index", GameState.PlayerNames);
        }

        public void AddPlayer(string playerName)
        {
            GameState.PlayerNames.Add(playerName);
        }
    }
}