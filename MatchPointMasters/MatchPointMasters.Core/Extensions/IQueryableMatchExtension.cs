using MatchPointMasters.Core.Models.Match;
using MatchPointMasters.Infrastructure.Data.Models.Match;

namespace MatchPointMasters.Core.Extensions
{
    public static class IQueryableMatchExtension
    {
        public static IQueryable<MatchServiceModel> ProjectToMatchServiceModel(this IQueryable<Match> matches)
        {
            return matches.Select(m => new MatchServiceModel()
            {
                Id = m.Id,
                TournamentId = m.TournamentId,
                MatchRound = m.MatchRound,
                PlayerOneId = m.PlayerOneId,
                PlayerTwoId = m.PlayerTwoId,
                PlayerOneSetsWon = m.PlayerOneSetsWon,
                PlayerTwoSetsWon = m.PlayerTwoSetsWon,
                Winner = m.Winner
            });
        }
    }
}
