using System.ComponentModel.DataAnnotations;

namespace MatchPointMasters.Core.Models.Set.QueryModels
{
    public class SetServiceModel
    {
        public int Id { get; set; }

        [Required]
        public int MatchId { get; set; }

        [Required]
        public int PlayerOneGamesWon { get; set; }

        [Required]
        public int PlayerTwoGamesWon { get; set; }

        [Required]
        public bool HasTiebreak { get; set; } = false;

        public int? TiebreakId { get; set; }

    }
}
