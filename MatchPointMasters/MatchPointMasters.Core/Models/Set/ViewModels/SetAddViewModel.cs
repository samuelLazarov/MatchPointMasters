namespace MatchPointMasters.Core.Models.Set.ViewModels
{
    using MatchPointMasters.Core.Contracts;
    using System.ComponentModel.DataAnnotations;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants.MatchConstants;

    public class SetAddViewModel : ISetModel
    {

        [Required]
        [Range(GamesMinRange, GamesMaxRange, ErrorMessage = RangeErrorMessage)]
        public int PlayerOneGamesWon { get; set; }

        [Required]
        [Range(GamesMinRange, GamesMaxRange, ErrorMessage = RangeErrorMessage)]
        public int PlayerTwoGamesWon { get; set; }

        [Required]
        public bool HasTiebreak { get; set; } = false;

        public int? TiebreakId { get; set; }
    }
}
