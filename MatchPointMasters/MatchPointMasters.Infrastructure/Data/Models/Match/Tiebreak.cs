namespace MatchPointMasters.Infrastructure.Data.Models.Match
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Comment("If a set must be decided by tiebreak")]
    public class Tiebreak
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Comment("Player One points")]
        public int PlayerOnePoints { get; set; } = 0;

        [Required]
        [Comment("Player Two points")]
        public int PlayerTwoPoints { get; set; } = 0;

        [Required]
        [Comment("Current Set Identifier")]
        public int SetId { get; set; }

        [ForeignKey(nameof(SetId))]
        [Comment("Current Set")]
        public Set Set { get; set; } = null!;
    }
}
