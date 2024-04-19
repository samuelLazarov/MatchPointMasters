namespace MatchPointMasters.Core.Extensions
{
    using MatchPointMasters.Core.Contracts;
    using System.Text.RegularExpressions;

    public static class TournamentExtensions
    {
        public static string GetInformation(this ITournamentModel tournament)
        {
            string info = tournament.Name.Replace(" ", "-") + GetHostClub(tournament.HostClub);
            info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);
            return info;
        }

        private static string GetHostClub(string hostClub)
        {
            hostClub = string.Join("-", hostClub.Split(" ").Take(3));
            return hostClub;
        }
    }
}
