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

        public async Task<IActionResult> Details(string playerId)
        {
            try
            {
                var player = await playerService.GetPlayerById(playerId);
                return View(player);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
