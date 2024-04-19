namespace MatchPointMasters.Core.Extensions
{
    using MatchPointMasters.Core.Contracts;
    using System.Text.RegularExpressions;

    public static class MatchExtensions
    {
        public static string GetInformation(this IMatchModel match)
        {
            string info = $"{match.PlayerOneName} - {match.PlayerTwoName}";
            info = info.Replace(" ", "-");
            info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);
            return info;

        }

    }
}
