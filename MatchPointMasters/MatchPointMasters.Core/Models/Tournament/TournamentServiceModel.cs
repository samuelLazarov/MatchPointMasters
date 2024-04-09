namespace MatchPointMasters.Core.Models.Tournament
{
    using System.ComponentModel.DataAnnotations;
    using MatchPointMasters.Infrastructure.Data.Enums.Tournament;

    public class TournamentServiceModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int HostClubId { get; set; }

        [Required]
        public int TournamentHostId { get; set; }

        [Required]
        public decimal Fee { get; set; }

        [Required]
        public TennisBalls TournamentBalls { get; set; }

    }
}
