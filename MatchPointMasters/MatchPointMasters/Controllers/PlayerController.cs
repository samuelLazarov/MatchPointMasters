namespace MatchPointMasters.Controllers
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Core.Extensions;
    using MatchPointMasters.Core.Models.Roles.QueryModels;
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
        public async Task<IActionResult> Become()
        {
            string userId = User.Id();

            var player = await playerService.FindPlayerByUserIdAsync(userId);

            if (player != null)
            {
                return RedirectToAction("All", "Tournament");
            }

            var model = new PlayerAddViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Become(PlayerAddViewModel model)
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

            return RedirectToAction("All", "Tournament");

        }


        public async Task<IActionResult> All([FromQuery] AllPlayersQueryModel model)
        {
            var players = await playerService.AllAsync(
                model.SearchTerm, 
                model.Sorting, 
                model.CurrentPage, 
                model.PlayersPerPage);

            model.TotalPlayersCount = players.TotalPlayersCount;
            model.Players = players.Players;

            return View(players);
        }

        public async Task<IActionResult> Details(string playerId, string information)
        {
            if (!await userService.ExistsByIdAsync(playerId))
            {
                return BadRequest();
            }

            var player = await playerService.PlayerDetailsByIdAsync(playerId);

            if (information != player.GetInformation())
            {
                return BadRequest();
            }

            return View(player);
        }
    }
}
