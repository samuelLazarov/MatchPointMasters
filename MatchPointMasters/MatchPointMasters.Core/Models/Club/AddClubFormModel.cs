namespace MatchPointMasters.Infrastructure.ViewModels
{
    using MatchPointMasters.Infrastructure.Data.Enums.Tournament;
    using System.ComponentModel.DataAnnotations;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants.ClubConstants;

    public class AddClubFormModel
    {
        [Required]
        [MaxLength(ClubNameMaxLength)]
        [Display(Name = "Club Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(ClubAddressMaxLength)]
        [Display(Name = "Club Address")]
        public string Address { get; set; }

        [Required]
        [MaxLength(ClubPhoneMaxLength)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(ClubNameMaxLength)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "Court Surface")]
        public CourtSurface CourtSurface { get; set; }
    }
}