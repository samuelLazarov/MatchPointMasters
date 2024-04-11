using MatchPointMasters.Core.Contracts;
using MatchPointMasters.Infrastructure.Data.Enums.Match;

namespace MatchPointMasters.Core.Models.Match
{
    public class MatchDeleteViewModel : IMatchModel
    {
        public MatchRound MatchRound { get; set; }
        public string PlayerOneName { get; set; } = string.Empty;
        public string PlayerTwoName { get; set; } = string.Empty;
    }
}
