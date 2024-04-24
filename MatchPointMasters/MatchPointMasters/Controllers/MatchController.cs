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
        private readonly IUserService userService;

        public MatchController(
            IMatchService _matchService, 
            ITournamentService _tournamentService, 
            IPlayerService _playerService, 
            IUserService _userService)
        {
            matchService = _matchService;
            tournamentService = _tournamentService;
            playerService = _playerService;
            userService = _userService;
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

        [HttpPost]
        [MustBeATournamentHost]
        public async Task<IActionResult> AddMatchAsync(MatchAddViewModel matchForm)
        {
            var playerOne = await playerService.FindPlayerByNameAsync(matchForm.PlayerOneName);
            var playerTwo = await playerService.FindPlayerByNameAsync(matchForm.PlayerTwoName);

            Match match = new Match()
            {
                TournamentId = matchForm.TournamentId,
                MatchRound = matchForm.MatchRound,
                PlayerOneId = playerOne.Id,
                PlayerTwoId = playerTwo.Id,
                PlayerOneSetsWon = matchForm.PlayerOneSetsWon,
                PlayerTwoSetsWon = matchForm.PlayerTwoSetsWon,
                Winner = matchForm.Winner,

            };

            return View();
        }

    }
}
