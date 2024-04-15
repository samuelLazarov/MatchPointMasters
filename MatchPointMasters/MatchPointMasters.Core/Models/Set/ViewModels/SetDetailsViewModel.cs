using MatchPointMasters.Core.Contracts;
using System.ComponentModel.DataAnnotations;

namespace MatchPointMasters.Core.Models.Set.ViewModels
{
    public class SetDetailsViewModel : ISetModel
    {
        public int Id { get; set; }

        public int MatchId { get; set; }

        public int PlayerOneGamesWon { get; set; }

        public int PlayerTwoGamesWon { get; set; }

        public bool HasTiebreak { get; set; } = false;

        public int? TiebreakId { get; set; }
    }
}
