namespace MatchPointMasters.Infrastructure.Data.Models.Match
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class MatchScore
    {
        [Key]
        [Comment("The current Match score identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Indicates if Player One is winner")]
        public bool PlayerOneWon { get; set; } = false;

        [Required]
        [Comment("Indicates if Player Two is winner")]
        public bool PlayerTwoWon { get; set; } = false;

        [Required]
        [Comment("The current Match Identifier")]
        public int MatchId { get; set; }

        [ForeignKey(nameof(MatchId))]
        public Match Match { get; set; } = null!;

        public ICollection<Set> PlayerOneSetsWon { get; set; } = new List<Set>();

        public ICollection<Set> PlayerTwoSetsWon { get; set; } = new List<Set>();

    }
}
