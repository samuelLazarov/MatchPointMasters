using MatchPointMasters.Attributes;
using MatchPointMasters.Core.Contracts;
using MatchPointMasters.Core.Models.Tiebreak.QueryModels;
using Microsoft.AspNetCore.Mvc;
using MatchPointMasters.Core.Extensions;

namespace MatchPointMasters.Controllers
{
    public class TiebreakController : BaseController
    {
        private readonly ITiebreakService tiebreakService;

        public TiebreakController(ITiebreakService _tiebreakService)
        {
            tiebreakService = _tiebreakService;
        }

        [HttpGet]
        [MustBeATournamentHost]
        public async Task<IActionResult> All([FromQuery]TiebreakQueryServiceModel model)
        {
            var allTiebreaks = await tiebreakService.AllAsync();

            model.TotalTiebreaksCount = allTiebreaks.TotalTiebreaksCount;
            model.Tiebreaks = allTiebreaks.Tiebreaks;
            
            
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, string information)
        {
            if(!await tiebreakService.TiebreakExistsAsync(id))
            {
                return BadRequest();
            }

            var currentTiebreak = await tiebreakService.TiebreakDetailsAsync(id);

            if (information != currentTiebreak.GetInformation())
            {
                return BadRequest();
            }

            return View(currentTiebreak);

        }

    }
}
