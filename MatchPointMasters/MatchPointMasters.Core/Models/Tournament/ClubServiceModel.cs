namespace MatchPointMasters.Core.Models.Tournament
{
    using MatchPointMasters.Infrastructure.Data.Enums.Tournament;
    using System.ComponentModel.DataAnnotations;

    public class ClubServiceModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        public CourtSurface CourtSurface { get; set; }
    }
}
