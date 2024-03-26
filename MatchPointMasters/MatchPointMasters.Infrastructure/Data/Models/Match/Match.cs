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
        [Comment("The current First Player's Identifier")]
        public int FirstPlayerId { get; set; }

        [ForeignKey(nameof(FirstPlayerId))]
        [Comment("The current First Player")]
        public Player FirstPlayer { get; set; }= null!;

        [Required]
        [Comment("The current First Player's Identifier")]
        public int SecondPlayerId { get; set; }

        [ForeignKey(nameof(SecondPlayerId))]
        [Comment("The current Second Player")]
        public Player SecondPlayer { get; set; } = null!;

        [Required]
        [Comment("The current Match Score's Identifier")]
        public int MatchScoreId { get; set; }

        [ForeignKey(nameof(MatchScoreId))]
        [Comment("The current Match Score")]
        public MatchScore MatchScore { get; set; } = null!;
        
        public ICollection<PlayerMatch> PlayerMatches { get; set; } = new List<PlayerMatch>();

        //public ICollection<int> FirstPlayerGamesWon { get; set; } = new List<int>();
        //public ICollection<int> SecondPlayerGamesWon { get; set; } = new List<int>();

    }
}
