using MatchPointMasters.Infrastructure.Data.Enums.Match;

namespace MatchPointMasters.Core.Models.Tournament.ViewModels
{
    public class TournamentMatchDeleteViewModel
    {
        public int MatchId { get; set; }
        public int TournamentId { get; set; }
        public MatchRound MatchRound { get; set; }
        public string TournamentName { get; set; } = string.Empty;

    }
}
