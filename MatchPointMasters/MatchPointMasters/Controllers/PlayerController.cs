
namespace MatchPointMasters.Controllers
{
    using MatchPointMasters.Core.Contracts;
    using Microsoft.AspNetCore.Mvc;

    public class PlayerController : BaseController
    {
        private readonly IPlayerService playerService;

        public PlayerController(IPlayerService _playerService)
        {
            playerService = _playerService;
        }

        public async Task<IActionResult> Index()
        {
            var players = playerService.GetAllPlayers();

            return View(players);
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var player = await playerService.GetPlayerById(id);
                return View(player);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
