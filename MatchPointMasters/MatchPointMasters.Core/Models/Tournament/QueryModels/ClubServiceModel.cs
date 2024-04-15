namespace MatchPointMasters.Core.Models.Tournament.QueryModels
{
    using MatchPointMasters.Infrastructure.Data.Enums.Tournament;
    using System.ComponentModel.DataAnnotations;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants.ClubConstants;

    public class ClubServiceModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ClubNameMaxLength, MinimumLength = ClubNameMinLength, ErrorMessage = LengthErrorMessage)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(ClubAddressMaxLength, MinimumLength = ClubAddressMinLength, ErrorMessage = LengthErrorMessage)]
        public string Address { get; set; } = string.Empty;

        [Required]
        [StringLength(ClubPhoneMaxLength, MinimumLength = ClubPhoneMinLength, ErrorMessage = LengthErrorMessage)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(ClubImageUrlMaxLength, MinimumLength = ClubImageUrlMaxLength, ErrorMessage = LengthErrorMessage)]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        public CourtSurface CourtSurface { get; set; }
    }
}
