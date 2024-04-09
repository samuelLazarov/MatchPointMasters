namespace MatchPointMasters.Core.Models.Match
{
    using System.ComponentModel.DataAnnotations;

    public class TiebreakServiceModel
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
