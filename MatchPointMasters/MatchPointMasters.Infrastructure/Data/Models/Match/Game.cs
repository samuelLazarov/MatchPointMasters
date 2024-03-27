namespace MatchPointMasters.Infrastructure.Data.Models.Match
{
    using MatchPointMasters.Infrastructure.Data.Enums.Match;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Game
    {
        [Key]
        [Comment("The current Game's identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("The current Game's number")]
        public int GameNumber { get; set; }

        public TennisPoint PlayerOneCurrentPoint { get; set; } = TennisPoint.Love;

        public TennisPoint PlayerTwoCurrentPoint { get; set; } = TennisPoint.Love;

        [Required]
        [Comment("When Player One wins the current game")]
        public bool PlayerOneWon { get; set; }

        [Required]
        [Comment("When Player Two wins the current game")]
        public bool PlayerTwoWon { get; set; }

        [Required]
        [Comment("The current set identifier")]
        public int SetId { get; set; }

        [ForeignKey(nameof(SetId))]
        public Set Set { get; set; } = null!;
    }
}
