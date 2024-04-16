using MatchPointMasters.Infrastructure.Data.Enums.Match;

namespace MatchPointMasters.Core.Contracts
{
    public interface IMatchModel
    {
        public MatchRound MatchRound { get; set; }
        public string PlayerOneName { get; set; }
        public string PlayerTwoName { get; set; }

    }
}
