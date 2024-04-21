namespace MatchPointMasters.Core.Contracts
{
    using MatchPointMasters.Core.Models.Article;
    using MatchPointMasters.Core.Models.Match;
    using MatchPointMasters.Core.Models.Set;
    using MatchPointMasters.Core.Models.Tiebreak;
    using MatchPointMasters.Core.Models.Tournament;
    using MatchPointMasters.Infrastructure.Data.Models.Mappings;
    using MatchPointMasters.Infrastructure.Data.Models.Roles;

    public interface ITournamentHostService
    {
        Task<bool> ExistsByTournamentHostIdAsync(int userId);
        Task<bool> ExistsByUserIdAsync(string userId);
        Task<bool> ExistsByEmailAsync(string publisherEmail);
        Task<TournamentHost> GetTournamentHostByEmailAsync(string publisherEmail);
        Task<int?> GetTournamentHostIdAsync(string UserId);

    }
}
