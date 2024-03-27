using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchPointMasters.Infrastructure.Data.Models.Match
{
    public class Set
    {
        [Key]
        [Comment("The current Set's Identifier")]
        public int Id { get; set; }
        
        [Required]
        [Comment("Indicates if Player Two wins the current set")]
        public bool PlayerOneWon { get; set; } = false;

        [Required]
        [Comment("Indicates if Player Two wins the current set")]
        public bool PlayerTwoWon { get; set; } = false;

        [Required]
        [Comment("Indicates if current set is decided by tiebreak")]
        public bool IsTiebreak { get; set; } = false;

        [Required]
        [Comment("The curent Match score's Identifier")]
        public int MatchScoreId { get; set; }

        [ForeignKey(nameof(MatchScoreId))]
        public MatchScore MatchScore { get; set; } = null!;

        [Required]
        [Comment("The curent Tiebreak's Identifier")]
        public int TiebreakId { get; set; }

        [ForeignKey(nameof(TiebreakId))]
        public Tiebreak Tiebreak { get; set; } = null!;

        public ICollection<Game> PlayerOneGamesWon { get; set; } = new List<Game>();

        public ICollection<Game> PlayerTwoGamesWon { get; set; } = new List<Game>();
    }
}
