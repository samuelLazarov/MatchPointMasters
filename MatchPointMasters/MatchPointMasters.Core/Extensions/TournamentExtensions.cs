namespace MatchPointMasters.Core.Extensions
{
    using MatchPointMasters.Core.Contracts;

    public static class TournamentExtensions
    {
        public static string GetInformation(this ITournamentModel currentTournament)
        {
            return currentTournament.Name.Replace(" ", "-") + GetHostClub(currentTournament.HostClub);
        }

        private static string GetHostClub(string hostClub)
        {
            hostClub = string.Join("-", hostClub.Split(" "));
            return hostClub;
        }

    }
}
