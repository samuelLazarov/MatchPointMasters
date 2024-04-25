using MatchPointMasters.Core.Contracts;

namespace MatchPointMasters.Core.Models.Tiebreak.ViewModels
{
    public class TiebreakDeleteViewModel : ITiebreakModel
    {
        public int Id { get; set; }
        public int PlayerOnePoints { get; set; }
        public int PlayerTwoPoints { get; set; }
        public int SetId {  get; set; }

    }
}
