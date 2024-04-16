namespace MatchPointMasters.Core.Models.Match.QueryModels
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Infrastructure.Data.Enums.Match;
    using System.ComponentModel.DataAnnotations;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants.MatchConstants;

    public class MatchServiceModel : IMatchModel
    {
        public int Id { get; set; }

        [Required]
        public int TournamentId { get; set; }

        [Required]
        public MatchRound MatchRound { get; set; }

        [Required]
        public string PlayerOneName { get; set; } = string.Empty;

        [Required]
        public string PlayerTwoName { get; set; } = string.Empty; 

        [Required]
        [Range(SetsMinRange, SetsMaxRange, ErrorMessage = RangeErrorMessage)]
        public int PlayerOneSetsWon { get; set; } = 0;

        [Required]
        [Range(SetsMinRange, SetsMaxRange, ErrorMessage = RangeErrorMessage)]
        public int PlayerTwoSetsWon { get; set; } = 0;

        public Winner? Winner { get; set; }
    }
}