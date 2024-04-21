namespace MatchPointMasters.Core.Services
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Infrastructure.Data.Common;
    using MatchPointMasters.Infrastructure.Data.Models.Roles;
    using Microsoft.EntityFrameworkCore;

    public class TournamentHostService : ITournamentHostService
    {
        public readonly IRepository repository;

        public TournamentHostService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<bool> ExistsByTournamentHostIdAsync(int tournamentHostId)
        {
            return await repository
                .AllAsReadOnly<TournamentHost>()
                .AnyAsync(th => th.Id == tournamentHostId);
        }

        public async Task<bool> ExistsByUserIdAsync(string userId)
        {
            return await repository
                .AllAsReadOnly<TournamentHost>()
                .AnyAsync(th => th.UserId == userId);
        }

        public async Task<bool> ExistsByEmailAsync(string tournamentHostEmail)
        {
            return await repository
                .AllAsReadOnly<TournamentHost>()
                .AnyAsync(u => u.User.Email.ToLower() == tournamentHostEmail.ToLower());
        }

        public async Task<TournamentHost> GetTournamentHostByEmailAsync(string tournamentHostEmail)
        {
            return await repository
                .All<TournamentHost>()
                .FirstOrDefaultAsync(u => u.User.Email.ToLower() == tournamentHostEmail.ToLower());
        }

        public async Task<int?> GetTournamentHostIdAsync(string userId)
        {
            return (await repository
                .AllAsReadOnly<TournamentHost>()
                .FirstOrDefaultAsync(p => p.UserId == userId))?.Id;
        }

    }
}
