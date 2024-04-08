using Microsoft.AspNetCore.Mvc;

namespace MatchPointMasters.Controllers
{
    public class TournamentController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
