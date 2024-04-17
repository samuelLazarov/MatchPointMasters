
namespace MatchPointMasters.Controllers
{
    using MatchPointMasters.Core.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MatchPointMasters.Attributes;
    using MatchPointMasters.Core.Extensions;
    using MatchPointMasters.Core.Models.Tournament.QueryModels;
    using MatchPointMasters.Extensions;
    using MatchPointMasters.Core.Models.Tournament.ViewModels;

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
        public async Task<IActionResult> All([FromQuery]AllTournamentsQueryModel model)
        {
            var allTournaments = await tournamentService.AllAsync(
                model.SearchTerm,
                model.Sorting,
                model.Status,
                model.CurrentPage,
                model.TournamentsPerPage);

            model.TotalTournamentsCount = allTournaments.TotalTournamentsCount;
            model.Tournaments = allTournaments.Tournaments;

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id, string information)
        {
            if (!await tournamentService.TournamentExistsByIdAsync(id))
            {
                return BadRequest();
            }

            var currentTournament = await tournamentService.DetailsAsync(id);

            if (information != currentTournament.GetInformation())
            {
                return BadRequest();
            }

            return View(currentTournament);
        }

        [HttpGet]
        [MustBeATournamentHost]
        public async Task<IActionResult> AddTournament()
        {
            if (await tournamentHostService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            var tournamentForm = new TournamentAddViewModel();

            return View(tournamentForm);
        }


        [HttpPost]
        [MustBeATournamentHost]
        public async Task<IActionResult> AddTournament(TournamentAddViewModel tournamentForm)
        {
            if (await tournamentHostService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            if (tournamentForm.StartDate >= tournamentForm.EndDate)
            {
                ModelState.AddModelError("StartDate", "Invalid timespan!");
                ModelState.AddModelError("EndDate", "Invalid timespan!");
            }

            if (!ModelState.IsValid)
            {
                return View(tournamentForm);
            }

            await tournamentService.AddTournamentAsync(tournamentForm);

            return RedirectToAction("All", "Tournament");
        }



        [HttpGet]
        [MustBeATournamentHost]
        public async Task<IActionResult> EditTournament(int id)
        {
            if (await tournamentHostService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            if (!await tournamentService.TournamentExistsByIdAsync(id))
            {
                return BadRequest();
            }

            var tournamentForm = await tournamentService.EditTournamentGetAsync(id);
            return View(tournamentForm);
        }


        [HttpPost]
        [MustBeATournamentHost]
        public async Task<IActionResult> Edit(TournamentEditViewModel tournamentForm)
        {
            if (await tournamentHostService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            if (tournamentForm == null)
            {
                return BadRequest();
            }

            if (tournamentForm.StartDate >= tournamentForm.EndDate)
            {
                ModelState.AddModelError("StartDate", "Invalid timespan!");
                ModelState.AddModelError("EndDate", "Invalid timespan!");
            }

            if (!ModelState.IsValid)
            {
                return View(tournamentForm);
            }

            int id = tournamentForm.Id;
            await tournamentService.EditTournamentPostAsync(tournamentForm);

            return RedirectToAction("Details", "Tournament", new {id, information = tournamentForm.GetInformation()});
        }

        [HttpGet]
        [MustBeATournamentHost]
        public async Task<IActionResult> DeleteTournament(int id)
        {
            if (await tournamentHostService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            if (!await tournamentService.TournamentExistsByIdAsync(id))
            {
                return BadRequest();
            }

            var searchedTournament = await tournamentService.DeleteTournamentAsync(id);

            return View(searchedTournament);

        }

        [HttpPost]
        [MustBeATournamentHost]
        public async Task<IActionResult> DeleteTournamentConfirmed(int id)
        {
            if (await tournamentHostService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            if (!await tournamentService.TournamentExistsByIdAsync(id))
            {
                return BadRequest();
            }

            await tournamentService.DeleteTournamentConfirmedAsync(id);

            return RedirectToAction("All", "Tournament");

        }

    }
}
