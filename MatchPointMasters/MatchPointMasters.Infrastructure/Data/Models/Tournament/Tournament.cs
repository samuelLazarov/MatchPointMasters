namespace MatchPointMasters.Infrastructure.Data.Models.Tournament
{
    using MatchPointMasters.Infrastructure.Data.Models.Match;
    using MatchPointMasters.Infrastructure.Data.Models.Player;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using MatchPointMasters.Infrastructure.Data.Enums.Tournament;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants;
    public class Tournament
    {
        [Key]
        [Comment("The current Tournament's Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLenght)]
        [Comment("The current Tournament's Name")]
        public string Name { get; set; }

        [Required]
        
        public Club HostClub { get; set; }

        [Required]
        [Comment("The current Tournament's start date and hour")]
        public DateTime StartDate { get; set; }

        [Required]
        [Comment("The current Tournament's end date and hour")]
        public DateTime EndDate { get; set; }

        public string Description { get; set; }

        public decimal Fee { get; set; }

        public TennisBalls TournamentBalls { get; set; }

        public ICollection<Player> Players { get; set; } = new HashSet<Player>();

        public ICollection<Match> Matches { get; set; } = new HashSet<Match>();
    }
}
