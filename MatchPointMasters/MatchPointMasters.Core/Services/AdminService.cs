namespace MatchPointMasters.Core.Services
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Core.Models.Admin;
    using MatchPointMasters.Infrastructure.Data.Common;
    using MatchPointMasters.Infrastructure.Data.Models.Roles;

    public class AdminService : IAdminService
    {

        private readonly IRepository repository;
        private readonly ITournamentHostService tournamentHostService;
        private readonly IUserService userService;

        public AdminService(IRepository _repository, ITournamentHostService _tournamentHostService, IUserService _userService)
        {
            repository = _repository;
            tournamentHostService = _tournamentHostService;
            userService = _userService;
        }


        public async Task<int> AddTournamentHostAsync(UserViewModel form)
        {
            ApplicationUser user = userService.GetUserByEmailAsync(form.Email).Result;

            TournamentHost tournamentHost = new TournamentHost()
            {
                UserId = user.Id,
            };

            await repository.AddAsync(tournamentHost);
            await repository.SaveChangesAsync();

            return tournamentHost.Id;
        }

        public async Task<UserRemoveViewModel> RemoveTournamentHostAsync(int tournamentHostId)
        {
            TournamentHost? tournamentHost = repository.GetByIdAsync<TournamentHost>(tournamentHostId).Result;

            var deleteForm = new UserRemoveViewModel()
            {
                Id = tournamentHost.Id,
                FirstName = tournamentHost.User.FirstName,
                LastName = tournamentHost.User.LastName,
                Email = tournamentHost.User.Email
            };

            return deleteForm;
        }

        public async Task<int> RemoveTournamentHostConfirmedAsync(int tournamentHostId)
        {
            TournamentHost? tournamentHost = repository.GetByIdAsync<TournamentHost>(tournamentHostId).Result;

            await repository.RemoveAsync<TournamentHost>(tournamentHost);
            await repository.SaveChangesAsync();

            return tournamentHost.Id;
        }

        public async Task<int> AddAdminAsync(UserViewModel form)
        {
            throw new NotImplementedException();
        }

        public async Task<UserViewModel> RemoveAdminAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> RemoveAdminConfirmedAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
