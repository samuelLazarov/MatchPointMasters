
namespace MatchPointMasters.Areas.Admin.Controllers
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Core.Models.Admin.QueryModels;
    using MatchPointMasters.Infrastructure.Data.Models.Roles;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using static MatchPointMasters.Core.Constants.AdministratorConstants;
    using static System.Security.Claims.ClaimsPrincipalsExtension;
    public class UserController : AdminBaseController
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserService userService;
        private readonly ITournamentHostService tournamentHostService;
        private readonly IAdminService adminService;

        public UserController(UserManager<ApplicationUser> _userManager, IUserService _userService, ITournamentHostService _tournamentHostService, IAdminService _adminService)
        {
            userManager = _userManager;
            userService = _userService;
            tournamentHostService = _tournamentHostService;
            adminService = _adminService;
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllUsersQueryModel model)
        {
            var allUsers = await userService.AllAsync(
                User.Id(),
                model.SearchTerm,
                model.RoleStatus,
                model.CurrentPage,
                model.UsersPerPage);

            model.TotalUsersCount = allUsers.TotalUsersCount;
            model.Users = allUsers.Users;

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string userId)
        {
            var user = await userService.GetUserByIdAsync(userId);

            if (user == null)
            {
                return BadRequest();
            }

            var currentUserDetails = await userService.DetailsAsync(userId);

            return View(currentUserDetails);
        }

        [HttpGet]
        public async Task<IActionResult> AddTournamentHost(string id)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await userService.ExistsByIdAsync(id))
            {
                return BadRequest();
            }
            else if (await tournamentHostService.ExistsByUserIdAsync(id))
            {
                return RedirectToAction(nameof(All));
            }

            var user = await userService.GetUserByIdAsync(id);

            var hostForm = new UserServiceModel()
            {
                Id = id,
                FullName = userService.UserFullNameAsync(id).Result,
                Email = user.Email,
                IsTournamentHost = tournamentHostService.ExistsByUserIdAsync(id).Result,
                IsAdmin = userManager.IsInRoleAsync(user, AdminRole).Result
            };

            return View(hostForm);
        }

        [HttpPost]
        public async Task<IActionResult> AddTournamentHostConfirmed(string id)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await userService.ExistsByIdAsync(id))
            {
                return BadRequest();
            }
            else if (await tournamentHostService.ExistsByUserIdAsync(id))
            {
                return RedirectToAction(nameof(All));
            }

            await adminService.AddTournamentHostAsync(id);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> RemoveTournamentHost(string id)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await userService.ExistsByIdAsync(id))
            {
                return BadRequest();
            }
            else if (!await tournamentHostService.ExistsByUserIdAsync(id))
            {
                return RedirectToAction(nameof(All));
            }

            var user = await userService.GetUserByIdAsync(id);

            var hostForm = new UserServiceModel()
            {
                Id = id,
                FullName = userService.UserFullNameAsync(id).Result,
                Email = user.Email,
                IsTournamentHost = tournamentHostService.ExistsByUserIdAsync(id).Result,
                IsAdmin = userManager.IsInRoleAsync(user, AdminRole).Result
            };

            return View(hostForm);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveTournamentHostConfirmed(string id)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await userService.ExistsByIdAsync(id))
            {
                return BadRequest();
            }
            else if (!await tournamentHostService.ExistsByUserIdAsync(id))
            {
                return RedirectToAction(nameof(All));
            }

            await adminService.RemoveTournamentHostConfirmedAsync(id);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> AddAdmin(string id)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await userService.ExistsByIdAsync(id))
            {
                return BadRequest();
            }

            var user = await userService.GetUserByIdAsync(id);

            if (await userManager.IsInRoleAsync(user, AdminRole))
            {
                return RedirectToAction(nameof(All));
            }

            var adminForm = new UserServiceModel()
            {
                Id = id,
                FullName = userService.UserFullNameAsync(id).Result,
                Email = user.Email,
                IsTournamentHost = tournamentHostService.ExistsByUserIdAsync(id).Result,
                IsAdmin = userManager.IsInRoleAsync(user, AdminRole).Result
            };

            return View(adminForm);
        }

        [HttpPost]
        public async Task<IActionResult> AddAdminConfirmed(string id)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await userService.ExistsByIdAsync(id))
            {
                return BadRequest();
            }

            var user = await userService.GetUserByIdAsync(id);

            if (await userManager.IsInRoleAsync(user, AdminRole))
            {
                return RedirectToAction(nameof(All));
            }

            await adminService.AddAdminAsync(id);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> RemoveAdmin(string id)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await userService.ExistsByIdAsync(id))
            {
                return BadRequest();
            }

            var user = await userService.GetUserByIdAsync(id);

            if (!await userManager.IsInRoleAsync(user, AdminRole))
            {
                return RedirectToAction(nameof(All));
            }

            var adminForm = new UserServiceModel()
            {
                Id = id,
                FullName = userService.UserFullNameAsync(id).Result,
                Email = user.Email,
                IsTournamentHost = tournamentHostService.ExistsByUserIdAsync(id).Result,
                IsAdmin = userManager.IsInRoleAsync(user, AdminRole).Result
            };

            return View(adminForm);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveAdminConfirmed(string id)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await userService.ExistsByIdAsync(id))
            {
                return BadRequest();
            }

            var user = await userService.GetUserByIdAsync(id);

            if (!await userManager.IsInRoleAsync(user, AdminRole))
            {
                return RedirectToAction(nameof(All));
            }

            await adminService.RemoveAdminConfirmedAsync(id);

            return RedirectToAction(nameof(All));
        }


    }
}
