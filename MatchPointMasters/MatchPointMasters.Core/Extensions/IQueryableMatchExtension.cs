using MatchPointMasters.Core.Models.Match.QueryModels;
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
                PlayerOneName = m.PlayerOne.Id.ToString(),
                PlayerTwoName = m.PlayerTwo.Id.ToString(),
                PlayerOneSetsWon = m.PlayerOneSetsWon,
                PlayerTwoSetsWon = m.PlayerTwoSetsWon,
                Winner = m.Winner
            });

        }
    }
}
