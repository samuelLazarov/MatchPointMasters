namespace MatchPointMasters.Core.Contracts
{
    using MatchPointMasters.Core.Models.Tiebreak;
    using MatchPointMasters.Infrastructure.Data.Models.Match;
    public interface ITiebreakService
    {
        //Tiebreak
        Task<TiebreakQueryServiceModel> AllAsync();
        Task<bool> TiebreakExistsAsync(int tiebreakId);
        Task<Tiebreak> FindTiebreakByIdAsync(int tiebreakId);
        Task<TiebreakDetailsViewModel> TiebreakDetailsAsync(int tiebreakId);

    }
}
