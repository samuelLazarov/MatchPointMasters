namespace MatchPointMasters.Infrastructure.Data.Models.Mappings
{
    using MatchPointMasters.Infrastructure.Data.Models.Match;
    using MatchPointMasters.Infrastructure.Data.Models.Tournament;

    public class TournamentMatch
    {

        public int MatchId { get; set; }

        public TennisMatch Match { get; set; } = null!;

        public int TournamentId { get; set; }

        public Tournament Tournament { get; set; } = null!;

    }
}
