using MatchPointMasters.Infrastructure.Data.Enums.Tournament;
using MatchPointMasters.Infrastructure.Data.Models.Mappings;
using MatchPointMasters.Infrastructure.Data.Models.Roles;
using MatchPointMasters.Infrastructure.Data.Models.Tournament;
using System.ComponentModel.DataAnnotations;

namespace MatchPointMasters.Core.Models.Player
{
    public class TournamentHostServiceModel
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
        public Club HostClub { get; set; } = null!;

        [Required]
        public int TournamentHostId { get; set; }

        [Required]
        public TournamentHost TournamentHost { get; set; } = null!;

        [Required]
        public decimal Fee { get; set; }

        [Required]
        public TennisBalls TournamentBalls { get; set; }

        public ICollection<TournamentMatch> TournamentMatches { get; set; } = new List<TournamentMatch>();

        public ICollection<PlayerTournament> PlayerTournaments { get; set; } = new List<PlayerTournament>();
    }
}
