using MatchPointMasters.Infrastructure.Data.Enums.Match;

namespace MatchPointMasters.Core.Contracts
{
    public interface IMatchModel
    {
        public MatchRound MatchRound { get; set; }
        public string PlayerOne { get; set; }
        public string PlayerTwo { get; set; }
       
    }
}
