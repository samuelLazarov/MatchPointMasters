using MatchPointMasters.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MatchPointMasters.Controllers
{
    public class MatchController : Controller
    {
        private readonly IMatchService matchService;

        public MatchController(IMatchService _matchService)
        {
            matchService = _matchService;
        }

        public async Task<IActionResult> Details(int id)
        {
            var match = await matchService.GetMatchById(id);

            if (match == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(match);
        }
    }
}
