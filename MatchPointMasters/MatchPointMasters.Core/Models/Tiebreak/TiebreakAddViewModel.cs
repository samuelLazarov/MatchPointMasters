namespace MatchPointMasters.Core.Models.Tiebreak
{
    using MatchPointMasters.Core.Contracts;
    using System.ComponentModel.DataAnnotations;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants.MatchConstants;

    public class TiebreakAddViewModel : ITiebreakModel
    {
        [Required]
        [Range(TiebreakMinRange, TiebreakMaxRange, ErrorMessage = RangeErrorMessage)]
        public int PlayerOnePoints { get; set; }

        [Required]
        [Range(TiebreakMinRange, TiebreakMaxRange, ErrorMessage = RangeErrorMessage)]
        public int PlayerTwoPoints { get; set; }

        [Required]
        public int SetId { get; set; }
    }
}
