using System.Web.Mvc;

namespace TG.Web.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Index()
        {
            return View("Index", GameState.Instance);
        }
    }
}