namespace MatchPointMasters.Core.Contracts
{
    using MatchPointMasters.Core.Models.Tiebreak.QueryModels;
    using MatchPointMasters.Core.Models.Tiebreak.ViewModels;
    using MatchPointMasters.Infrastructure.Data.Models.Match;
    public interface ITiebreakService
    {

        //CRUD operations
        Task<int> AddTiebreakAsync(TiebreakAddViewModel tiebreakForm, int setId);
        Task<TiebreakEditViewModel> EditTiebreakGetAsync(int tiebreakId);
        Task<int> EditTiebreakPostAsync(TiebreakEditViewModel tiebreakForm);
        Task<TiebreakDeleteViewModel> DeleteTiebreakAsync(int tiebreakId);
        Task<int> DeleteTiebreakConfirmedAsync(int tiebreakId);


        //Query operations
        Task<TiebreakQueryServiceModel> AllAsync();
        Task<bool> TiebreakExistsAsync(int tiebreakId);
        Task<Tiebreak> FindTiebreakByIdAsync(int tiebreakId);
        Task<TiebreakDetailsViewModel> TiebreakDetailsAsync(int tiebreakId);

    }
}
