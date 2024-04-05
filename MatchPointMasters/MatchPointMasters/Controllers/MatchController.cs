using Microsoft.AspNetCore.Mvc;

namespace MatchPointMasters.Controllers
{
    public class MatchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
