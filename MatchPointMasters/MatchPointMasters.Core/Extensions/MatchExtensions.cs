namespace MatchPointMasters.Core.Extensions
{
    using MatchPointMasters.Core.Contracts;

    public static class MatchExtensions
    {
        public static string GetInformation(this IMatchModel currentMatch)
        {
            return $"{currentMatch.PlayerOneName} - {currentMatch.PlayerTwoName}";
        }

    }
}
