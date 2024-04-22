using MatchPointMasters.Core.Contracts;

namespace MatchPointMasters.Core.Models.Tiebreak.ViewModels
{
    public class TiebreakDeleteViewModel : ITiebreakModel
    {
        public int PlayerOnePoints { get; set; }
        public int PlayerTwoPoints { get; set; }

    }
}
