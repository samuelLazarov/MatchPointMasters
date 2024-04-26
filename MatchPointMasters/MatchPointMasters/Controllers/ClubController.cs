using MatchPointMasters.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MatchPointMasters.Controllers
{
    public class ClubController : BaseController
    {
        private readonly IClubService clubService;

        public ClubController(IClubService _clubService)
        {
            clubService = _clubService;
        }

        public async Task<IActionResult> All()
        {
            var allClubs = await clubService.AllAsync();
            return View(allClubs);
        }
    }
}
