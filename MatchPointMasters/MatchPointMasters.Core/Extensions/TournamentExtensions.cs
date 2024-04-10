namespace MatchPointMasters.Core.Extensions
{
    using MatchPointMasters.Core.Contracts;

    public static class TournamentExtensions
    {
        public static string GetInformation(this ITournamentModel currentTournament)
        {
            var tournamentInfo = currentTournament.Name + " - " + currentTournament.HostClub;
            return tournamentInfo;
        }

    }
}
