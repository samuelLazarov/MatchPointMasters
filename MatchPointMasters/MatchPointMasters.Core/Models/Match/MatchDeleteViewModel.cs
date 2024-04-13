using MatchPointMasters.Core.Contracts;
using MatchPointMasters.Infrastructure.Data.Enums.Match;

namespace MatchPointMasters.Core.Models.Match
{
    public class MatchDeleteViewModel : IMatchModel
    {
        public MatchRound MatchRound { get; set; }
        public int PlayerOneId { get; set; }
        public int PlayerTwoId { get; set; }
    }
}
