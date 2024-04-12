using MatchPointMasters.Core.Contracts;
using MatchPointMasters.Infrastructure.Data.Enums.Tournament;
using System.ComponentModel.DataAnnotations;

namespace MatchPointMasters.Core.Models.Tournament
{
    public class TournamentDetailsViewModel : ITournamentModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string HostClub { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Fee { get; set; }
        public int Capacity { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public TennisBalls TournamentBalls { get; set; }
    }
}
