namespace MatchPointMasters.Core.Contracts
{
    using MatchPointMasters.Core.Models.Article;
    using MatchPointMasters.Core.Models.Match;
    using MatchPointMasters.Core.Models.Set;
    using MatchPointMasters.Core.Models.Tiebreak;
    using MatchPointMasters.Core.Models.Tournament;
    using MatchPointMasters.Infrastructure.Data.Models.Mappings;

    public interface ITournamentHostService
    {
        Task<bool> ExistsByIdAsync(string userId);
        Task<int?> GetTournamentHostIdAsync(string userId);

      


    }
}
