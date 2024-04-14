using MatchPointMasters.Core.Contracts;
using MatchPointMasters.Infrastructure.Data.Enums.Tournament;
using System.ComponentModel.DataAnnotations;
using static MatchPointMasters.Infrastructure.Constants.DataConstants;
using static MatchPointMasters.Infrastructure.Constants.DataConstants.TournamentConstants;
using static MatchPointMasters.Infrastructure.Constants.DataConstants.ClubConstants;

namespace MatchPointMasters.Core.Models.Tournament
{
    public class TournamentEditViewModel : ITournamentModel
    {

        [Required]
        public int Id { get; set; }
        
        [Required]
        [StringLength(TournamentNameMaxLength, MinimumLength = TournamentNameMinLength, ErrorMessage = LengthErrorMessage)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(ClubNameMaxLength, MinimumLength = ClubNameMinLength, ErrorMessage = LengthErrorMessage)]
        public int HostClubId { get; set; }

        [Required]
        [StringLength(TournamentDescriptionMaxLength, MinimumLength = TournamentDescriptionMinLength, ErrorMessage = LengthErrorMessage)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [Range(TournamentFeeMinRange, TournamentFeeMaxRange)]
        public decimal Fee { get; set; }

        [Required]
        [Range(TournamentCapacityMinRange, TournamentCapacityMaxRange)]
        public int Capacity { get; set; }

        [Required]
        [StringLength(TournamentImageUrlMaxLength, MinimumLength = TournamentImageUrlMinLength, ErrorMessage = LengthErrorMessage)]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        public TennisBalls TournamentBalls { get; set; }

    }
}
