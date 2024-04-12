namespace MatchPointMasters.Core.Contracts
{
    using MatchPointMasters.Core.Models.Set;
    using MatchPointMasters.Core.Models.Tiebreak;
    using MatchPointMasters.Infrastructure.Data.Models.Match;

    public interface ISetService
    {
        //Set
        Task<SetQueryServiceModel> AllAsync();
        Task<bool> SetExistsAsync(int setId);
        Task<Set> FindSetByIdAsync(int setId);
        Task<SetDetailsViewModel> SetDetailsAsync(int setId);
        Task<bool> HasTiebreakAsync(int setId);
    }
}
