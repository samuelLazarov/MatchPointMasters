using Microsoft.AspNetCore.Mvc;

namespace MatchPointMasters.Controllers
{
    public class TournamentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
