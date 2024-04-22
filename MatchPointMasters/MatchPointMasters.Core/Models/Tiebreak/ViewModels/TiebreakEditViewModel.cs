namespace MatchPointMasters.Core.Models.Tiebreak.ViewModels
{
    using MatchPointMasters.Core.Contracts;
    using System.ComponentModel.DataAnnotations;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants.MatchConstants;

    public class TiebreakEditViewModel : ITiebreakModel
    {
        public int Id { get; set; }

        [Required]
        [Range(TiebreakMinRange, TiebreakMaxRange, ErrorMessage = RangeErrorMessage)]
        public int PlayerOnePoints { get; set; }

        [Required]
        [Range(TiebreakMinRange, TiebreakMaxRange, ErrorMessage = RangeErrorMessage)]
        public int PlayerTwoPoints { get; set; }

    }
}
