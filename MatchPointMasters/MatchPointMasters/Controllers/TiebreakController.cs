using MatchPointMasters.Attributes;
using MatchPointMasters.Core.Contracts;
using MatchPointMasters.Core.Models.Tiebreak.QueryModels;
using Microsoft.AspNetCore.Mvc;
using MatchPointMasters.Core.Extensions;
using System.Security.Claims;
using MatchPointMasters.Core.Models.Tiebreak.ViewModels;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Authorization;

namespace MatchPointMasters.Controllers
{
    public class TiebreakController : BaseController
    {
        private readonly ITiebreakService tiebreakService;
        private readonly ITournamentHostService tournamentHost;

        public TiebreakController(ITiebreakService _tiebreakService, ITournamentHostService _tournamentHost)
        {
            tiebreakService = _tiebreakService;
            tournamentHost = _tournamentHost;
            
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
        [MustBeATournamentHost]
        public async Task<IActionResult> AddTiebreak()
        {
            if (await tournamentHost.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            var tiebreakForm = new TiebreakAddViewModel();
           
            return View(tiebreakForm);
        }

        [HttpPost]
        [MustBeATournamentHost]
        public async Task<IActionResult> AddTiebreak(TiebreakAddViewModel tiebreakForm, int setid)
        {
            if (await tournamentHost.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            if (await tiebreakService.TiebreakExistsAsync(tiebreakForm.SetId))
            {
                ModelState.AddModelError(nameof(tiebreakForm.SetId), "A tiebreak is already added to current set!");
            }

            if (!ModelState.IsValid)
            {
                return View(tiebreakForm);
            }

            int newTiebreakId = await tiebreakService.AddTiebreakAsync(tiebreakForm, setid);

            return RedirectToAction("All", "Tiebreak");

        }

        [HttpGet]
        [MustBeATournamentHost]
        public async Task<IActionResult> EditTiebreak(int id)
        {
            if (await tournamentHost.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            if (!await tiebreakService.TiebreakExistsAsync(id))
            {
                return BadRequest();
            }
            var tiebreakForm = await tiebreakService.EditTiebreakGetAsync(id);
            return View(tiebreakForm);
        }

        [HttpPost]
        [MustBeATournamentHost]
        public async Task<IActionResult> EditTiebreak(TiebreakEditViewModel tiebreakForm)
        {
            if (await tournamentHost.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            if (tiebreakForm == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(tiebreakForm);
            }

            int id = tiebreakForm.Id;
            await tiebreakService.EditTiebreakPostAsync(tiebreakForm);
            return RedirectToAction("Details", "Tiebreak", new {id, information = tiebreakForm.GetInformation() });

        }

        [HttpGet]
        [MustBeATournamentHost]
        public async Task<IActionResult> DeleteTiebreak(int id)
        {
            if (await tournamentHost.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            if (!await tiebreakService.TiebreakExistsAsync(id))
            {
                return BadRequest();
            }

            var searchedTiebreak = await tiebreakService.DeleteTiebreakAsync(id);

            return View(searchedTiebreak);

        }

        [HttpPost]
        [MustBeATournamentHost]
        public async Task<IActionResult> DeleteTiebreakConfirmed(int id)
        {
            if (await tournamentHost.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            if (!await tiebreakService.TiebreakExistsAsync(id))
            {
                return BadRequest();
            }

            await tiebreakService.DeleteTiebreakConfirmedAsync(id);

            return RedirectToAction("All", "Tiebreak");
        }


        [AllowAnonymous]
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
