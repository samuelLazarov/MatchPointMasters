namespace MatchPointMasters.Core.Models.Match.ViewModels
{
    using MatchPointMasters.Infrastructure.Data.Enums.Match;
    public class MatchDetailsViewModel
    {
        public int Id { get; set; }
        public MatchRound MatchRound { get; set; }
        public int PlayerOneId { get; set; }
        public int PlayerTwoId { get; set; }
        public int PlayerOneSetsWon { get; set; } = 0;
        public int PlayerTwoSetsWon { get; set; } = 0;
        public Winner? Winner { get; set; }
    }
}
