using MatchPointMasters.Infrastructure.Data.Models.Match;

namespace MatchPointMasters.Core.Contracts
{
    public interface ITiebreakService
    {
        Task<bool> TiebreakExistsAsync(int tiebreakId);
        Task<Tiebreak> FindTiebreakByIdAsync(int tiebreakId);

    }
}
