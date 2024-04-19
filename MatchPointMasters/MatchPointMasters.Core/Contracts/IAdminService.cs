namespace MatchPointMasters.Core.Contracts
{
    using MatchPointMasters.Core.Models.Admin.QueryModels;

    public interface IAdminService
    {
        Task<int> AddTournamentHostAsync(string userId);
        Task<UserServiceModel> RemoveTournamentHostAsync(string userId);
        Task<int> RemoveTournamentHostConfirmedAsync(string userId);

        Task<string> AddAdminAsync(string userId);
        Task<UserServiceModel> RemoveAdminAsync(string userId);
        Task<string> RemoveAdminConfirmedAsync(string userId);
    }
}