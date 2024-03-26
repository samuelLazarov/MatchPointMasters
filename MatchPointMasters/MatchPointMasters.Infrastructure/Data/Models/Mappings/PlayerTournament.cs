namespace MatchPointMasters.Infrastructure.Data.Models.Mappings
{
    using MatchPointMasters.Infrastructure.Data.Models.Player;
    using MatchPointMasters.Infrastructure.Data.Models.Tournament;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PlayerTournament
    {
        [Required]
        [Comment("The current Player's Identifier")]
        public int PlayerId { get; set; }

        [ForeignKey(nameof(PlayerId))]
        [Comment("The current Player")]
        public Player Player { get; set; } = null!;

        [Required]
        [Comment("The current Tournament's Identifier")]
        public int TournamentId { get; set; }

        [ForeignKey(nameof(PlayerId))]
        [Comment("The current Tournament")]
        public Tournament Tournament { get; set; } = null!;
    }
}
