namespace MatchPointMasters.Core.Models.Player
{
    using MatchPointMasters.Infrastructure.Data.Enums.Player;
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants.PlayerConstants;


    public class PlayerServiceModel
    {

        public int Id { get; set; }

        [Required]
        [StringLength(PlayerNameMaxLength, MinimumLength = PlayerNameMinLength, ErrorMessage = LengthErrorMessage)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(PlayerNameMaxLength, MinimumLength = PlayerNameMinLength, ErrorMessage = LengthErrorMessage)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(PlayerPhoneMaxLength)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string UserId { get; set; } = string.Empty;

        public IdentityUser User { get; set; } = null!;

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public DominantHand? DominantHand { get; set; }

        public Backhand? Backhand { get; set; }

        public PlayingStyle? PlayingStyle { get; set; }

        public TennisRacket? TennisRacket { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        public int? TournamentWins { get; set; }

        [Required]
        public string ImageUrl { get; set; } = string.Empty;

    }
}
