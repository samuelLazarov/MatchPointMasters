namespace MatchPointMasters.Infrastructure.Data.Models.Match
{
    using MatchPointMasters.Infrastructure.Data.Enums.Match;
    using MatchPointMasters.Infrastructure.Data.Models.Mappings;
    using MatchPointMasters.Infrastructure.Data.Models.Player;
    using MatchPointMasters.Infrastructure.Data.Models.Tournament;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Match
    {
        [Key]
        [Comment("The current Match Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("The current Tournament Identifier")]
        public int TournamentId { get; set; }

        [ForeignKey(nameof(TournamentId))]
        [Comment("The current Match")]
        public Tournament Tournament { get; set; } = null!;

        [Required]
        [Comment("The current Match Round from Tournament")]
        public MatchRound MatchRound { get; set; }

        [Required]
        [Comment("The current Player One's Identifier")]
        public int PlayerOneId { get; set; }

        [ForeignKey(nameof(PlayerOneId))]
        [Comment("The current Player One")]
        public Player PlayerOne { get; set; }= null!;

        [Required]
        [Comment("The current Player Two's Identifier")]
        public int PlayerTwoId { get; set; }

        [ForeignKey(nameof(PlayerTwoId))]
        [Comment("The current Player Two")]
        public Player PlayerTwo { get; set; } = null!;

        [Required]
        [Comment("The current Match Score's Identifier")]
        public int MatchScoreId { get; set; }

        [ForeignKey(nameof(MatchScoreId))]
        [Comment("The current Match Score")]
        public MatchScore MatchScore { get; set; } = null!;
        
        public ICollection<PlayerMatch> PlayerMatches { get; set; } = new List<PlayerMatch>();

        

    }
}
