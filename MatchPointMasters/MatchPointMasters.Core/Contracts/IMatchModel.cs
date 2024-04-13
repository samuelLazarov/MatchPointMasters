using MatchPointMasters.Infrastructure.Data.Enums.Match;

namespace MatchPointMasters.Core.Contracts
{
    public interface IMatchModel
    {
        public MatchRound MatchRound { get; set; }
        public int PlayerOneId { get; set; }
        public int PlayerTwoId { get; set; }

    }
}
