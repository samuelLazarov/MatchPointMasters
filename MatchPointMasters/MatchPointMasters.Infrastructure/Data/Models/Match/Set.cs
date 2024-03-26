using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchPointMasters.Infrastructure.Data.Models.Match
{
    public class Set
    {
        public int Id { get; set; }

        public bool PlayerOneWon { get; set; } = false;

        public bool PlayerTwoWon { get; set; } = false;

        [Required]
        public bool IsTiebreak { get; set; } = false;

        [Required]
        public int MatchScoreId { get; set; }

        [ForeignKey(nameof(MatchScoreId))]
        public MatchScore MatchScore { get; set; } = null!;

        [Required]
        public int TiebreakId { get; set; }

        [ForeignKey(nameof(TiebreakId))]
        public Tiebreak Tiebreak { get; set; } = null!;

        public ICollection<Game> PlayerOneGamesWon { get; set; } = new List<Game>();

        public ICollection<Game> PlayerTwoGamesWon { get; set; } = new List<Game>();
    }
}
