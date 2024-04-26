namespace MatchPointMasters.Core.Models.Roles.ViewModels
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Infrastructure.Data.Enums.Player;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants.PlayerConstants;

    public class PlayerAddViewModel : IPlayerModel
    {

        [Required]
        [StringLength(PlayerNameMaxLength, MinimumLength = PlayerNameMinLength, ErrorMessage = LengthErrorMessage)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [StringLength(PlayerPhoneMaxLength, MinimumLength = PlayerPhoneMinLength, ErrorMessage = LengthErrorMessage)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]

        public DateTime BirthDate { get; set; } = new DateTime(2006, 1, 1);

        [Required]
        public Gender Gender { get; set; }

        public DominantHand? DominantHand { get; set; }

        public Backhand? Backhand { get; set; }

        public PlayingStyle? PlayingStyle { get; set; }

        public TennisRacket? TennisRacket { get; set; }

        [Required]
        [StringLength(PlayerImageUrlMaxLength, MinimumLength = PlayerImageUrlMinLength, ErrorMessage = LengthErrorMessage)]
        public string ImageUrl { get; set; } = string.Empty;

        
    }
}
