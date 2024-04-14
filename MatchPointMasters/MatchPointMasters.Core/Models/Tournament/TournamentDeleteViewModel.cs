using MatchPointMasters.Core.Contracts;

namespace MatchPointMasters.Core.Models.Tournament
{
    public class TournamentDeleteViewModel : ITournamentModel
    {
        public string Name { get; set; } = string.Empty;
        public int HostClubId { get; set; }
    }
}
