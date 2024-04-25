using MatchPointMasters.Attributes;
using MatchPointMasters.Core.Contracts;
using MatchPointMasters.Core.Extensions;
using MatchPointMasters.Core.Models.Set.QueryModels;
using MatchPointMasters.Core.Models.Set.ViewModels;
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
        public async Task<IActionResult> Add()
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
        public async Task<IActionResult> Add(SetAddViewModel setForm, int setid)
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

            await setService.AddTiebreakToSetAsync(setId);
            return RedirectToAction("All", "Set", new { id = setId });
        }


        [HttpGet]
        [MustBeATournamentHost]
        public async Task<IActionResult> Edit(int id)
        {
            if (await tournamentHost.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            if (!await setService.SetExistsAsync(id))
            {
                return BadRequest();
            }

            var set = await setService.EditSetAsyncGetAsync(id);

            return View(set);
        }

        [HttpPost]
        [MustBeATournamentHost]
        public async Task<IActionResult> Edit(SetEditViewModel model)
        {
            if (await tournamentHost.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            if (!await setService.SetExistsAsync(model.Id))
            {
                return BadRequest();
            }

            await setService.EditSetPostAsync(model);

            return RedirectToAction("Details", new { id = model.Id, information = model.GetInformation() });
        }

        [HttpGet]
        [MustBeATournamentHost]
        public async Task<IActionResult> Delete(int id)
        {
            if (await tournamentHost.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            if (!await setService.SetExistsAsync(id))
            {
                return BadRequest();
            }

            var searchedSet = await setService.DeleteSetAsync(id);


            return View(searchedSet);
        }

        [HttpPost]
        [MustBeATournamentHost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await tournamentHost.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            if (!await setService.SetExistsAsync(id))
            {
                return BadRequest();
            }

            await setService.DeleteSetConfirmedAsync(id);

            return RedirectToAction("All", "Set");
        }
    }
}
