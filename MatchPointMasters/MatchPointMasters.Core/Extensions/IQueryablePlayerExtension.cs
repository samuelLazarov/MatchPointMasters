using MatchPointMasters.Core.Models.Match.QueryModels;
using MatchPointMasters.Core.Models.Roles.QueryModels;
using MatchPointMasters.Infrastructure.Data.Models.Player;

namespace MatchPointMasters.Core.Extensions
{
    public static class IQueryablePlayerExtension
    {
        public static IQueryable<PlayerServiceModel> ProjectToPlayerServiceModel(this IQueryable<Player> players)
        {
            return players.Select(p => new PlayerServiceModel()
            {
                Id = p.Id,
                FullName = p.User.FirstName + " " + p.User.LastName,
                UserId = p.UserId,
                BirthDate = p.BirthDate,
                Gender = p.Gender,
                DominantHand = p.DominantHand,
                PhoneNumber = p.PhoneNumber,
                Backhand = p.Backhand,
                PlayingStyle = p.PlayingStyle,
                TennisRacket = p.TennisRacket,
                Wins = p.Wins,
                Losses = p.Losses,
                TournamentWins = p.TournamentWins,
                ImageUrl = p.ImageUrl,

            });
        }
    }
}
