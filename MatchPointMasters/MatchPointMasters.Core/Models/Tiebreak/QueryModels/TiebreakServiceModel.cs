namespace MatchPointMasters.Core.Models.Tiebreak.QueryModels
{
    using MatchPointMasters.Core.Contracts;
    using System.ComponentModel.DataAnnotations;

    public class TiebreakServiceModel : ITiebreakModel
    {
        public int Id { get; set; }

        [Required]
        public int PlayerOnePoints { get; set; }

        [Required]
        public int PlayerTwoPoints { get; set; }

        [Required]
        public int SetId { get; set; }

    }
}
