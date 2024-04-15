using System.ComponentModel.DataAnnotations;

namespace MatchPointMasters.Core.Models.Tiebreak.ViewModels
{
    public class TiebreakDetailsViewModel
    {
        public int Id { get; set; }
        public int PlayerOnePoints { get; set; }
        public int PlayerTwoPoints { get; set; }
    }
}
