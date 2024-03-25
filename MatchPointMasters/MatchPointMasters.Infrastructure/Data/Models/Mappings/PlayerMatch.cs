﻿
namespace MatchPointMasters.Infrastructure.Data.Models.Mappings
{
    using MatchPointMasters.Infrastructure.Data.Models.Match;
    using MatchPointMasters.Infrastructure.Data.Models.Player;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PlayerMatch
    {
        [Required]
        [Comment("The current Player's Identifier")]
        public int PlayerId { get; set; }

        [ForeignKey(nameof(PlayerId))]
        [Comment("The current Player")]
        public Player Player { get; set; } = null!;

        [Required]
        [Comment("The current Tennis Match Identifier")]
        public int TennisMatchId { get; set; }

        [ForeignKey(nameof(TennisMatchId))]
        [Comment("The current Tennis Match")]
        public TennisMatch TennisMatch { get; set; } = null!;
    }
}
