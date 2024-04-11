namespace MatchPointMasters.Core.Models.Match
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Infrastructure.Data.Enums.Match;
    using System.ComponentModel.DataAnnotations;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants.MatchConstants;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants.PlayerConstants;

    public class MatchServiceModel : IMatchModel
    {
        public int Id { get; set; }

        [Required]
        public MatchRound MatchRound { get; set; }

        [Required]
        [StringLength(PlayerNameMinLength, MinimumLength = PlayerNameMinLength, ErrorMessage = LengthErrorMessage)]
        public string PlayerOneName { get; set; } = string.Empty;

        [Required]
        [StringLength(PlayerNameMinLength, MinimumLength = PlayerNameMinLength, ErrorMessage = LengthErrorMessage)]
        public string PlayerTwoName { get; set; } = string.Empty;

        [Required]
        [Range(SetsMinRange, SetsMaxRange, ErrorMessage = RangeErrorMessage)]
        public int PlayerOneSetsWon { get; set; } = 0;

        [Required]
        [Range(SetsMinRange, SetsMaxRange, ErrorMessage = RangeErrorMessage)]
        public int PlayerTwoSetsWon { get; set; } = 0;

        public Winner Winner { get; set; }
    }
}