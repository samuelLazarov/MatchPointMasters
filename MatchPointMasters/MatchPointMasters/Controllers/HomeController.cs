
namespace MatchPointMasters.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MatchPointMasters.Core.Contracts;
    using System.Security.Claims;

    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> logger;
        private readonly ITournamentService tournamentService;

        public HomeController(ILogger<HomeController> _logger, ITournamentService _tournamentService)
        {
            logger = _logger;
            tournamentService = _tournamentService;

        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            if (User.IsAdmin())
            {
                return RedirectToAction("Index", "Home", new { Area = "Admin" });
            }
            var tournamentModel = await tournamentService.LastThreeTournamentsAsync();

            return View(tournamentModel);
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
            {
                return View("Error400");
            }
            else if (statusCode == 401)
            {
                return View("Error401");
            }

            return View();
        }
    }
}