
namespace MatchPointMasters.Controllers
{
    using MatchPointMasters.Core.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MatchPointMasters.Attributes;
    using MatchPointMasters.Core.Extensions;
    using MatchPointMasters.Core.Models.Tournament;

    public class TournamentController : BaseController
    {
        private readonly ITournamentService tournamentService;
        private readonly ITournamentHostService tournamentHostService;

        public TournamentController(ITournamentService _tournamentService, ITournamentHostService _tournamentHostService)
        {
            tournamentService = _tournamentService;
            tournamentHostService = _tournamentHostService;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {


            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details()
        {

            return View();
        }

        [HttpGet]
        [MustBeATournamentHost]
        public async Task<IActionResult> Add()
        {
            
            return View();
        }


        [HttpPost]
        [MustBeATournamentHost]
        public async Task<IActionResult> Add(TournamentServiceModel tournamentServiceModel)
        {
            
            return RedirectToAction(nameof(All));
        }


        [HttpGet]
        [MustBeATournamentHost]
        public async Task<IActionResult> Edit()
        {

            return View();
        }


        [HttpPost]
        [MustBeATournamentHost]
        public async Task<IActionResult> Edit(TournamentServiceModel tournamentServiceModel)
        {

            return RedirectToAction(nameof(All));
        }

    }
}
