using MatchPointMasters.Infrastructure.Data.Enums.Player;
using System.ComponentModel.DataAnnotations;

namespace MatchPointMasters.Infrastructure.Data.Models.Player
{
    using MatchPointMasters.Infrastructure.Data.Models.Tournament;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Player
    {
        [Key]
        [Comment("The current Player's Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("The current Player's First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Comment("The current Player's Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
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

        public DominantHand? DominantHand { get; set; }

        public Backhand? Backhand { get; set; }

        public PlayingStyle? PlayingStyle { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        public int TournamentWins { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public ICollection<Tournament> Tournaments { get; set; } = new HashSet<Tournament>();


    }
}
