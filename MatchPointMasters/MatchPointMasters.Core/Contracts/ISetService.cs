namespace MatchPointMasters.Core.Contracts
{
    using MatchPointMasters.Core.Models.Set.QueryModels;
    using MatchPointMasters.Core.Models.Set.ViewModels;
    using MatchPointMasters.Infrastructure.Data.Models.Match;

    public interface ISetService
    {
        //CRUD operations
        Task<int> AddSetAsync(SetAddViewModel setForm, int matchId);
        Task<SetEditViewModel> EditSetASyncGetAsync(int setId);
        Task<int> EditSetPostAsync(SetEditViewModel setForm);
        Task<SetDeleteViewModel> DeleteSetAsync(int setId);
        Task<int> DeleteSetConfirmedAsync(int setId);

        //Query operations
        Task<SetQueryServiceModel> AllAsync();
        Task<bool> SetExistsAsync(int setId);
        Task<Set> FindSetByIdAsync(int setId);
        Task<SetDetailsViewModel> SetDetailsAsync(int setId);
        Task<bool> HasTiebreakAsync(int setId);
    }
}
