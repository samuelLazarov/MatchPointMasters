using MatchPointMasters.Core.Models.Match;

namespace MatchPointMasters.Core.Contracts
{
    public interface IMatchService
    {
        Task<MatchServiceModel> GetMatchById(int id);
    }
}
