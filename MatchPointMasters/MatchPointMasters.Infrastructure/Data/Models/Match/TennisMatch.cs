namespace MatchPointMasters.Infrastructure.Data.Models.Match
{
    using MatchPointMasters.Infrastructure.Data.Enums.Match;
    using MatchPointMasters.Infrastructure.Data.Models.Player;

    public class TennisMatch
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public MatchRound MatchRound { get; set; }

        public int FirstPlayerId { get; set; }

        public Player FirstPlayer { get; set; }

        public ICollection<int> FirstPlayerResult { get; set; } = new List<int>();

        public int SecondPlayerId { get; set; }

        public Player SecondPlayer { get; set; }

        public ICollection<int> SecondPlayerResult { get; set; } = new List<int>();

    }
}
