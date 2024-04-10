namespace MatchPointMasters.Core.Extensions
{
    using MatchPointMasters.Core.Contracts;

    public static class MatchExtensions
    {
        public static string GetInformation(this IMatchModel currentMatch)
        {
            var matchInfo = currentMatch.PlayerOne + " / " + currentMatch.PlayerTwo;
            return matchInfo;
        }
    }
}
