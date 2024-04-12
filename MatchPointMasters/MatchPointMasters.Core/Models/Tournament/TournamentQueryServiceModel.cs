namespace MatchPointMasters.Core.Models.Tournament
{
    public class TournamentQueryServiceModel
    {
        public int TotalTournamentsCount { get; set; }
        public IEnumerable<TournamentServiceModel> Tournaments { get; set;} = new List<TournamentServiceModel>();
    }
}
