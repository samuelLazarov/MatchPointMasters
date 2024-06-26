﻿
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
    using System.Security.Claims;

    public class TournamentController : BaseController
    {
        private readonly ITournamentService tournamentService;
        private readonly ITournamentHostService tournamentHostService;
        private readonly IPlayerService playerService;
        private readonly IClubService clubService;

        public TournamentController(
            ITournamentService _tournamentService,
            ITournamentHostService _tournamentHostService,
            IPlayerService _playerService,
            IClubService _clubService)
        {
            tournamentService = _tournamentService;
            tournamentHostService = _tournamentHostService;
            playerService = _playerService;
            clubService = _clubService;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllTournamentsQueryModel model)
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
        [HttpGet("Tournament/Details/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if (!await tournamentService.TournamentExistsByIdAsync(id))
            {
                return BadRequest();
            }

            var currentTournament = await tournamentService.DetailsAsync(id);

            return View(currentTournament);
        }

        [HttpGet]
        public async Task<IActionResult> Mine([FromQuery] AllTournamentsQueryModel model)
        {
            var userId = User.Id();

            if (userId == null)
            {
                return Unauthorized();
            }

            var player = await playerService.FindPlayerByUserIdAsync(userId);

            if (player == null)
            {
                return Unauthorized();
            }

            int playerId = player.Id;

            var tournamentsCollection = await tournamentService.AllTournamentsByPlayerIdAsync(
                    playerId, model.SearchTerm, model.Sorting, model.Status, model.CurrentPage, model.TournamentsPerPage);

            return View(tournamentsCollection);
        }


        [HttpGet]
        [MustBeATournamentHost]
        public async Task<IActionResult> AddTournament()
        {
            if (await tournamentHostService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            var clubs = await clubService.GetAllForTournament();
            if (clubs == null)
            {
                return BadRequest();
            }

            var tournamentForm = new TournamentAddViewModel();
            tournamentForm.Clubs = clubs;

            return View(tournamentForm);
        }


        [HttpPost]
        [MustBeATournamentHost]
        public async Task<IActionResult> AddTournament(TournamentAddViewModel tournamentForm)
        {
            var clubs = await clubService.GetAllForTournament();

            var userId = User.Id();

            var tournamentHostId
                = await tournamentHostService.GetTournamentHostIdAsync(userId);

            if (tournamentHostId == null)
            {
                return Unauthorized();
            }

            tournamentForm.TournamentHostId = (int)tournamentHostId;

            if (clubs == null)
            {
                return BadRequest();
            }

            tournamentForm.Clubs = clubs;

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
        public async Task<IActionResult> Edit(int id)
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

            var clubs = await clubService.GetAllForTournament();
            tournamentForm.Clubs = clubs;
            var userId = User.Id();

            var tournamentHostId
                = await tournamentHostService.GetTournamentHostIdAsync(userId);

            tournamentForm.TournamentHostId = (int)tournamentHostId;

            int id = tournamentForm.Id;
            await tournamentService.EditTournamentPostAsync(tournamentForm);

            return RedirectToAction("Details", "Tournament", new { id, information = tournamentForm.GetInformation() });
        }

        [HttpGet]
        [MustBeATournamentHost]
        public async Task<IActionResult> Delete(int id)
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
        public async Task<IActionResult> DeleteConfirmed(int id)
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
        [HttpPost]
        public async Task<IActionResult> RegisterInTournament(int id)
        {
            string userId = User.Id();

            var player = await playerService.FindPlayerByUserIdAsync(userId);

            if (player == null)
            {
                return RedirectToAction("Login", "Account", new {Area = "Identity"});
            }

            int playerId = player.Id;

            await playerService.AddPlayerToTournamentAsync(playerId, id);

            return RedirectToAction("Mine", "Tournament");
        }

        [HttpGet]
        public async Task<IActionResult> LeaveTournament(int id)
        {
            string userId = User.Id();

            var player = await playerService.FindPlayerByUserIdAsync(userId);

            if (player == null)
            {
                return RedirectToAction("Login", "Account", new { Area = "Identity" });
            }

            int playerId = player.Id;

            var model = await playerService.RemovePlayerFromTournamentAsync(playerId, id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LeaveTournamentConfirmed(int id)
        {
            string userId = User.Id();

            var player = await playerService.FindPlayerByUserIdAsync(userId);

            if (player == null)
            {
                return RedirectToAction("Login", "Account", new { Area = "Identity" });
            }

            int playerId = player.Id;

            await playerService.RemovePlayerFromTournamentConfirmedAsync(playerId, id);

            return RedirectToAction("Mine", "Tournament");
        }

    }
}
