namespace MatchPointMasters.Infrastructure.Data.Models.Tournament
{
    using MatchPointMasters.Infrastructure.Data.Enums.Tournament;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants.ClubConstants;
    
    [Comment("Tennis club hosting a tournament")]
    public class Club
    {
        [Key]
        [Comment("Tennis Club's Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(ClubNameMaxLength)]
        [Comment("The current club's name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(ClubAddressMaxLength)]
        [Comment("Club's address")]
        public string Address { get; set; } = string.Empty;

        [Required]
        [MaxLength(ClubPhoneMaxLength)]
        [Comment("Club's phone")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(ClubNameMaxLength)]
        [Comment("Tennis club's image url")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        public CourtSurface CourtSurface { get; set; }

        

    }
}
