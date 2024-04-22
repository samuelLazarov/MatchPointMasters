using MatchPointMasters.Core.Contracts;

namespace MatchPointMasters.Core.Extensions
{
    public static class SetExtensions
    {
        public static string GetInformation(this ISetModel set)
        {
            return set.PlayerOneGamesWon.ToString().Replace(" ", "-") + "/" + set.PlayerTwoGamesWon.ToString().Replace(" ", "-");
        }
    }
}
