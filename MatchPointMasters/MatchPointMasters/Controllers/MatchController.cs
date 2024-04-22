﻿using MatchPointMasters.Core.Contracts;
using MatchPointMasters.Core.Extensions;
using MatchPointMasters.Core.Models.Match.QueryModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MatchPointMasters.Controllers
{
    public class MatchController : BaseController
    {
        private readonly IMatchService matchService;
        private readonly ITournamentService tournamentService;

        public MatchController(IMatchService _matchService, ITournamentService tournamentService)
        {
            matchService = _matchService;
            this.tournamentService = tournamentService;
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
    }
}
