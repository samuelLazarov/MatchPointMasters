namespace MatchPointMasters.Infrastructure.Data.Models.Mappings
{
    using MatchPointMasters.Infrastructure.Data.Models.Match;
    using MatchPointMasters.Infrastructure.Data.Models.Tournament;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TournamentMatch
    {
        [Required]
        [Comment("The current Tennis Match Identifier")]
        public int MatchId { get; set; }

        [ForeignKey(nameof(MatchId))]
        [Comment("The current Tennis Match")]
        public Match Match { get; set; } = null!;

        [Required]
        [Comment("The current Tournament's Identifier")]
        public int TournamentId { get; set; }

        [ForeignKey(nameof(TournamentId))]
        [Comment("The current Tournament")]
        public Tournament Tournament { get; set; } = null!;


    }
}
