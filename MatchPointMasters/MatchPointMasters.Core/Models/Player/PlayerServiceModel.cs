
namespace MatchPointMasters.Core.Models.Player
{
    using MatchPointMasters.Infrastructure.Data.Enums.Player;
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class PlayerServiceModel
    {

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
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
