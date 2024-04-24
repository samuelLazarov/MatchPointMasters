using MatchPointMasters.Attributes;
using MatchPointMasters.Core.Contracts;
using MatchPointMasters.Core.Models.Set.QueryModels;
using MatchPointMasters.Core.Models.Set.ViewModels;
using MatchPointMasters.Core.Models.Tiebreak.ViewModels;
using MatchPointMasters.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MatchPointMasters.Controllers
{
    public class SetController : BaseController
    {
        private readonly ISetService setService;
        private readonly ITiebreakService tiebreakService;
        private readonly ITournamentHostService tournamentHost;

        public SetController(ISetService _service, ITournamentHostService _tournamentHost, ITiebreakService _tiebreakService)
        {
            setService = _service;
            tournamentHost = _tournamentHost;
            tiebreakService = _tiebreakService;
        }

        [HttpGet]
        [MustBeATournamentHost]
        public async Task<IActionResult> All([FromQuery] SetQueryServiceModel model)
        {
            var allSets = await setService.AllAsync();
            model.TotalSetsCount = allSets.TotalSetsCount;
            model.Sets = allSets.Sets;

            return View();
        }

        [HttpGet]
        [MustBeATournamentHost]
        public async Task<IActionResult> AddSet()
        {
            if (await tournamentHost.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            var setForm = new SetAddViewModel();

            return View(setForm);
        }

        [HttpPost]
        [MustBeATournamentHost]
        public async Task<IActionResult> AddSet(SetAddViewModel setForm, int setid)
        {
            if (await tournamentHost.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            if (await setService.SetExistsAsync(setForm.MatchId))
            {
                ModelState.AddModelError(nameof(setForm.MatchId), "This set is already added to current set!");
            }

            if (!ModelState.IsValid)
            {
                return View(setForm);
            }

            int newSetId = await setService.AddSetAsync(setForm, setid);

            return RedirectToAction("All", "Set");

        }

        [HttpGet]
        [MustBeATournamentHost]
        public async Task<IActionResult> AddTiebreakToSet(int tiebreakId, int setId)
        {
            if (await tournamentHost.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            if (!await setService.SetExistsAsync(setId) || !await tiebreakService.TiebreakExistsAsync(tiebreakId))
            {
                return BadRequest();
            }

            await setService.AddTiebreakToSetAsync(tiebreakId, setId);
            return RedirectToAction("All", "Set", new { id = setId });
        }
    }
}
