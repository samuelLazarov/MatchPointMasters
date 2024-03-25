using MatchPointMasters.Infrastructure.Data.Enums.Tournament;

namespace MatchPointMasters.Infrastructure.Data.Models.Tournament
{
    using MatchPointMasters.Infrastructure.Data.Models.Match;
    using MatchPointMasters.Infrastructure.Data.Models.Player;

    public class Tournament
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Club HostClub { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Description { get; set; }

        public decimal Fee { get; set; }

        public TennisBalls TournamentBalls { get; set; }

        public ICollection<Player> Players { get; set; } = new HashSet<Player>();

        public ICollection<TennisMatch> Matches { get; set; } = new HashSet<TennisMatch>();
    }
}
