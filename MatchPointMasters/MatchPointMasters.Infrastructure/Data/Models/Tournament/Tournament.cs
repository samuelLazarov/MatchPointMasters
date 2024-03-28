namespace MatchPointMasters.Infrastructure.Data.Models.Tournament
{
    using MatchPointMasters.Infrastructure.Data.Models.Match;
    using MatchPointMasters.Infrastructure.Data.Models.Player;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using MatchPointMasters.Infrastructure.Data.Enums.Tournament;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants.TournamentConstants;
    using System.ComponentModel.DataAnnotations.Schema;
    using MatchPointMasters.Infrastructure.Data.Models.Roles;

    public class Tournament
    {
        [Key]
        [Comment("The current Tournament's Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TournamentNameMaxLength)]
        [Comment("The current Tournament's Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(TournamentDescriptionMaxLength)]
        [Comment("Tournament description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("The current Tournament's start date and hour")]
        public DateTime StartDate { get; set; }

        [Required]
        [Comment("The current Tournament's end date and hour")]
        public DateTime EndDate { get; set; }

        [Required]
        [Comment("Host club's Identifier")]
        public int HostClubId { get; set; }

        [Required]
        [ForeignKey(nameof(HostClubId))]
        public Club HostClub { get; set; } = null!;

        [Required]
        [Comment("Tournament Host's Identifier")]
        public int TournamentHostId { get; set; }

        [Required]
        [ForeignKey(nameof(HostClubId))]
        public TournamentHost TournamentHost { get; set; } = null!;

        [Required]
        [Comment("Tournament fee")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Fee { get; set; }

        public TennisBalls TournamentBalls { get; set; }

        public ICollection<Player> Players { get; set; } = new HashSet<Player>();

        public ICollection<Match> Matches { get; set; } = new HashSet<Match>();
    }
}
