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
        [Comment("Indicates number of games won by Player One in the current set")]
        public int PlayerOneGamesWon { get; set; }

        [Required]
        [Comment("Indicates number of games won by Player Two in the current set")]
        public int PlayerTwoGamesWon { get; set; }

        [Required]
        [Comment("Indicates if current set is decided by tiebreak")]
        public bool IsTiebreak { get; set; } = false;

        [Required]
        [Comment("The curent Tiebreak's Identifier")]
        public int? TiebreakId { get; set; }

        [ForeignKey(nameof(TiebreakId))]
        public Tiebreak Tiebreak { get; set; } = null!;

        
    }
}
