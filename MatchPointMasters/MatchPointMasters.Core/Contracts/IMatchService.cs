using MatchPointMasters.Core.Models;

namespace MatchPointMasters.Core.Contracts
{
    public interface IMatchService
    {
        Task<MatchServiceModel> GetMatchById(string id);
    }
}
