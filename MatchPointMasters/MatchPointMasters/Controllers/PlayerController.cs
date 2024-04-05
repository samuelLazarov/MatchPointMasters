using Microsoft.AspNetCore.Mvc;

namespace MatchPointMasters.Controllers
{
    public class PlayerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
