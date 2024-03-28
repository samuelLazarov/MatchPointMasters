using MatchPointMasters.Infrastructure.Data.Enums.Player;
using System.ComponentModel.DataAnnotations;

namespace MatchPointMasters.Infrastructure.Data.Models.Player
{
    using MatchPointMasters.Infrastructure.Data.Models.Mappings;
    using MatchPointMasters.Infrastructure.Data.Models.Tournament;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations.Schema;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants.PlayerConstants;

    public class Player
    {
        [Key]
        [Comment("The current Player's Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(PlayerNameMaxLength)]
        [Comment("The current Player's First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(PlayerNameMaxLength)]
        [Comment("The current Player's Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(PlayerPhoneMaxLength)]
        [Comment("Player's phone")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [Comment("User Identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Comment("Player's dominant hand")]
        public DominantHand? DominantHand { get; set; }

        [Comment("Player's backhand style")]
        public Backhand? Backhand { get; set; }

        [Comment("Player's style of play")]
        public PlayingStyle? PlayingStyle { get; set; }

        [Comment("Player's racket brand")]
        public TennisRacket? TennisRacket { get; set; }

        [Comment("Player's wins counter")]
        public int Wins { get; set; }

        [Comment("Player's losses counter")]
        public int Losses { get; set; }

        [Comment("Player's Tournament wins counter")]
        public int? TournamentWins { get; set; }

        [Required]
        [MaxLength(PlayerImageUrlMaxLength)]
        public string ImageUrl { get; set; } = string.Empty;

        public ICollection<PlayerMatch> PlayerMatches { get; set; } = new List<PlayerMatch>();

        public ICollection<PlayerTournament> PlayerTournaments { get; set; } = new List<PlayerTournament>();

    }
}
