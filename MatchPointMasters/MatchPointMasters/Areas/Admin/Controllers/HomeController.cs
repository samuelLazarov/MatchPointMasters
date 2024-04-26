using Microsoft.AspNetCore.Mvc;

namespace MatchPointMasters.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
