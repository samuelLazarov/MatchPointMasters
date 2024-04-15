using MatchPointMasters.Core.Contracts;

namespace MatchPointMasters.Core.Models.Set.ViewModels
{
    public class SetDeleteViewModel
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int PlayerOneGamesWon { get; set; }
        public int PlayerTwoGamesWon { get; set; }

    }
}
