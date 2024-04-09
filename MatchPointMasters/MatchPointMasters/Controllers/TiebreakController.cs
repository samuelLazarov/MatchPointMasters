using MatchPointMasters.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MatchPointMasters.Controllers
{
    public class TiebreakController : BaseController
    {
        private readonly ITiebreakService tiebreakService;

        public TiebreakController(ITiebreakService _tiebreakService)
        {
            tiebreakService = _tiebreakService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
