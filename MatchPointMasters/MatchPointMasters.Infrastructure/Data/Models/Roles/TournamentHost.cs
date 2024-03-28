namespace MatchPointMasters.Infrastructure.Data.Models.Roles
{
    using MatchPointMasters.Infrastructure.Data.Models.Tournament;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants.TournamentHostConstants;

    [Comment("A user who will host a tournament")]
    public class TournamentHost
    {
        [Key]
        [Comment("The current Tournament host's Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(HostPhoneMaxLength)]
        [Comment("Tournament host's phone")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [Comment("The current User's Identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        [Comment("The current User")]
        public IdentityUser User { get; set; } = null!;

        public ICollection<Tournament> Tournaments { get; set; } = new List<Tournament>();
    }
}
