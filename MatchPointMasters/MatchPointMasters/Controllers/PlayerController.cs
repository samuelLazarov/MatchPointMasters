namespace MatchPointMasters.Controllers
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Core.Models.Roles.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using static MatchPointMasters.Core.Constants.MessageConstants;

    public class PlayerController : BaseController
    {
        private readonly IPlayerService playerService;
        private readonly IUserService userService;

        public PlayerController(IPlayerService _playerService, IUserService _userService)
        {
            playerService = _playerService;
            userService = _userService;
        }


        [HttpGet]
        public IActionResult BecomePlayerGet()
        {
            var model = new PlayerAddViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> BecomePlayerPost(PlayerAddViewModel model)
        {
            if (await playerService.UserWithPhoneNumberExistsAsync(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), PhoneExists);
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await playerService.AddAsync(User.Id(), model);

            return RedirectToAction("Mine", "Tournament");

        }


        public async Task<IActionResult> All()
        {
            var players = await playerService.AllAsync();

            return View(players);
        }

        public async Task<IActionResult> Details(string playerId)
        {
            return null;
        }
    }
}
