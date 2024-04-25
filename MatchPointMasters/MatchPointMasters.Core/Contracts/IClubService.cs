using MatchPointMasters.Core.Models.Club;
using MatchPointMasters.Core.Models.Clubs;
using MatchPointMasters.Infrastructure.ViewModels;

namespace MatchPointMasters.Core.Contracts
{
    public interface IClubService
    {
        Task AddAsync(AddClubFormModel model);

        Task<IEnumerable<AllClubViewModel>> AllAsync();

        Task<IEnumerable<ClubForTournamentViewModel>> GetAllForTournament();
    }
}
