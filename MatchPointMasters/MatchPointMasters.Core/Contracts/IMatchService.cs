using MatchPointMasters.Core.Models.Match;
using MatchPointMasters.Infrastructure.Data.Models.Match;

namespace MatchPointMasters.Core.Contracts
{
    public interface IMatchService
    {
        Task<Match> FindMatchByIdAsync(int matchId);
        Task<bool> MatchExistAsync (int matchId);
        Task<MatchDetailsViewModel> DetailsAsync(int matchId);

    }
}
