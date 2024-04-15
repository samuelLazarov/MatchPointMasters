namespace MatchPointMasters.Core.Contracts
{
    using MatchPointMasters.Core.Models.Admin.ViewModels;

    public interface IAdminService
    {
        Task<int> AddTournamentHostAsync(UserViewModel form);
        Task<UserRemoveViewModel> RemoveTournamentHostAsync(int tournamentHostId);
        Task<int> RemoveTournamentHostConfirmedAsync(int tournamentHostId);

        Task<int> AddAdminAsync(UserViewModel form);
        Task<UserViewModel> RemoveAdminAsync(int userId);
        Task<int> RemoveAdminConfirmedAsync(int userId);
    }
}