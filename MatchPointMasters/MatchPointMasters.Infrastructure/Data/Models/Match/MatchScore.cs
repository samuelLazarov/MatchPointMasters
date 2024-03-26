namespace MatchPointMasters.Infrastructure.Data.Models.Match
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class MatchScore
    {
        public int Id { get; set; }

        public bool PlayerOneWon { get; set; } = false;

        public bool PlayerTwoWon { get; set; } = false;

        [Required]
        public int MatchId { get; set; }

        [ForeignKey(nameof(MatchId))]
        public Match Match { get; set; } = null!;

        public ICollection<Set> PlayerOneSetsWon { get; set; } = new List<Set>();

        public ICollection<Set> PlayerTwoSetsWon { get; set; } = new List<Set>();

    }
}
