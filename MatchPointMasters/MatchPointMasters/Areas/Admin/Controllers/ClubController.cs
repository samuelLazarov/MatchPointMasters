using MatchPointMasters.Controllers;
using MatchPointMasters.Core.Contracts;
using MatchPointMasters.Core.Models.Club;
using MatchPointMasters.Infrastructure.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MatchPointMasters.Areas.Admin.Controllers
{
    public class ClubController : AdminBaseController
    {
        private readonly IClubService clubService;
        public ClubController(IClubService clubService)
        {
            this.clubService = clubService;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<AllClubViewModel> allClubs
                = await clubService.AllAsync();

            return View(allClubs);
        }
        [HttpGet]
        public IActionResult Add()
        {
            AddClubFormModel model = new AddClubFormModel();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddClubFormModel model)
        {
            await clubService.AddAsync(model);
            return RedirectToAction("Index", "Home", new { Area = "Admin"});
        }
    }
}
