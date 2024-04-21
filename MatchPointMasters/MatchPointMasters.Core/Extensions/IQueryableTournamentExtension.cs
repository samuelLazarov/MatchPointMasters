using MatchPointMasters.Core.Models.Match.QueryModels;
using MatchPointMasters.Core.Models.Tournament.QueryModels;
using MatchPointMasters.Infrastructure.Data.Models.Tournament;

namespace MatchPointMasters.Core.Extensions
{
    public static class IQueryableTournamentExtension
    {
        public static IQueryable<TournamentServiceModel> ProjectToTournamentServiceModel(this IQueryable<Tournament> tournaments)
        {
            return tournaments.Select(t => new TournamentServiceModel()
            {
                Id = t.Id,
                Name = t.Name,
                HostClub = t.HostClub.Name,
                Description = t.Description,
                StartDate = t.StartDate,
                EndDate = t.EndDate,
                Fee = t.Fee,
                Capacity = t.Capacity,
                ImageUrl = t.ImageUrl,
                TournamentBalls = t.TournamentBalls,
            });


        }

    }
}
