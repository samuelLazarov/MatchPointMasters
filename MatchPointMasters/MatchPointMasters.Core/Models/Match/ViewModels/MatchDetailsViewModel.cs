namespace MatchPointMasters.Core.Models.Match.ViewModels
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Infrastructure.Data.Enums.Match;
    public class MatchDetailsViewModel : IMatchModel
    {
        public int Id { get; set; }
        public MatchRound MatchRound { get; set; }
        public string PlayerOneName { get; set; } = string.Empty;
        public string PlayerTwoName { get; set; } = string.Empty;
        public int PlayerOneSetsWon { get; set; } = 0;
        public int PlayerTwoSetsWon { get; set; } = 0;
        public Winner? Winner { get; set; }
    }
}
