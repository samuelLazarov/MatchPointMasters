using MatchPointMasters.Attributes;
using MatchPointMasters.Core.Contracts;
using MatchPointMasters.Core.Extensions;
using MatchPointMasters.Core.Models.Match.QueryModels;
using MatchPointMasters.Core.Models.Match.ViewModels;
using MatchPointMasters.Infrastructure.Data.Models.Match;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MatchPointMasters.Controllers
{
    public class MatchController : BaseController
    {
        private readonly IMatchService matchService;
        private readonly ITournamentService tournamentService;
        private readonly IPlayerService playerService;
        private readonly ITournamentHostService tournamentHostService;
        private readonly ISetService setService;

        public MatchController(
            IMatchService _matchService, 
            ITournamentService _tournamentService, 
            IPlayerService _playerService, 
            ITournamentHostService _tournamentHostService,
            ISetService _setService)
        {
            matchService = _matchService;
            tournamentService = _tournamentService;
            playerService = _playerService;
            tournamentHostService = _tournamentHostService;
            setService = _setService;
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllMatchesQueryModel model)
        {
            var allMatches = await tournamentService.GetAllMatchesInTournamentAsync(
                model.TournamentId,
                model.MatchRound.ToString(),
                model.SearchTerm,
                model.Status,
                model.CurrentPage,
                model.MatchesPerPage
                );

            model.TotalMatchesCount = allMatches.TotalMatchesCount;
            model.Matches = allMatches.Matches;

            return View(model);
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id, string information)
        {
            if (!await matchService.MatchExistsAsync(id))
            {
                return BadRequest();
            }

            var currentMatch = await matchService.MatchDetailsAsync(id);

            if (information != currentMatch.GetInformation())
            {
                return BadRequest();
            }

            return View(currentMatch);
        }

        [HttpGet]
        public async Task<IActionResult> Mine(string id, [FromQuery] AllMatchesQueryModel model)
        {
            var userId = User.Id();

            if (userId != id)
            {
                return Unauthorized();
            }

            var matchCollection = await matchService.AllMatchesByUserIdAsync(userId, 
                model.SearchTerm, 
                model.Status, 
                model.CurrentPage, 
                model.MatchesPerPage);

            return View(matchCollection);
        }


        [HttpGet]
        [MustBeATournamentHost]
        public async Task<IActionResult> AddMatch()
        {
            if (await tournamentHostService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            var matchForm = new MatchAddViewModel();
            
            return View(matchForm);
        }


        [HttpPost]
        [MustBeATournamentHost]
        public async Task<IActionResult> AddMatch(MatchAddViewModel matchForm)
        {
            if (await tournamentHostService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            var playerOne = await playerService.FindPlayerByNameAsync(matchForm.PlayerOneName);
            var playerTwo = await playerService.FindPlayerByNameAsync(matchForm.PlayerTwoName);

            if (playerOne == null)
            {
                ModelState.AddModelError(nameof(matchForm.PlayerOneName), "Player 1 not found!");
            }

            if (playerTwo == null)
            {
                ModelState.AddModelError(nameof(matchForm.PlayerTwoName), "Player 2 not found!");
            }

            if(!await tournamentService.TournamentExistsByIdAsync(matchForm.TournamentId))
            {
                ModelState.AddModelError(nameof(matchForm.TournamentId), "Tournament not found!");
            }

            if(!ModelState.IsValid)
            {
                return View(matchForm);
            }

            int newMatchId = await matchService.AddMatchAsync(matchForm);

            return RedirectToAction("All", "Match");
        }

        [HttpGet]
        [MustBeATournamentHost]
        public async Task<IActionResult> EditMatch(int id)
        {
            if (await tournamentHostService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            if (!await matchService.MatchExistsAsync(id))
            {
                return BadRequest();
            }

            var matchForm = await matchService.EditMatchGetAsync(id);

            return View(matchForm);

        }

        [HttpPost]
        [MustBeATournamentHost]
        public async Task<IActionResult> EditMatch(MatchEditViewModel matchForm)
        {
            if (await tournamentHostService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            if (matchForm == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(matchForm);
            }

            int id = matchForm.Id;
            await matchService.EditMatchPostAsync(matchForm);

            return RedirectToAction("Details", "Match", new { id, information = matchForm.GetInformation() });

        }

        [HttpGet]
        [MustBeATournamentHost]
        public async Task<IActionResult> DeleteMatch(int id)
        {
            if (await tournamentHostService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            if (!await matchService.MatchExistsAsync(id))
            {
                return BadRequest();
            }

            var searchedMatch = await matchService.DeleteMatchAsync(id);

            return View(searchedMatch);
        }

        [HttpPost]
        [MustBeATournamentHost]
        public async Task<IActionResult> DeleteMatchConfirmed(int id)
        {
            if (await tournamentHostService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            if (!await matchService.MatchExistsAsync(id))
            {
                return BadRequest();
            }

            await matchService.DeleteMatchConfirmedAsync(id);

            return RedirectToAction("All", "Matches");
        }

        [HttpGet]
        [MustBeATournamentHost]
        public async Task<IActionResult> AddSetToMatch(int setId, int matchId)
        {
            if (await tournamentHostService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            if (!await matchService.MatchExistsAsync(matchId) || !await setService.SetExistsAsync(setId))
            {
                return BadRequest();
            }

            var set = await matchService.AddSetToMatchAsync(setId, matchId);

            await matchService.AddSetToMatchAsync(matchId, setId);
            return RedirectToAction("All", "Match");

        }
    }
}
