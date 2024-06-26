﻿namespace MatchPointMasters.Infrastructure.Data.Models.Tournament
{
    using MatchPointMasters.Infrastructure.Data.Enums.Tournament;
    using MatchPointMasters.Infrastructure.Data.Models.Mappings;
    using MatchPointMasters.Infrastructure.Data.Models.Roles;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants.TournamentConstants;

    public class Tournament
    {
        [Key]
        [Comment("The current Tournament's Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TournamentNameMaxLength)]
        [Comment("The current Tournament's Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(TournamentDescriptionMaxLength)]
        [Comment("Tournament description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("The current Tournament's start date and hour")]
        public DateTime StartDate { get; set; }

        [Required]
        [Comment("The current Tournament's end date and hour")]
        public DateTime EndDate { get; set; }

        [Required]
        [Comment("Host club's Identifier")]
        public int HostClubId { get; set; }

        [Required]
        [ForeignKey(nameof(HostClubId))]
        public Club HostClub { get; set; } = null!;

        [Required]
        [Comment("Tournament Host's Identifier")]
        public int TournamentHostId { get; set; }

        [Required]
        [ForeignKey(nameof(TournamentHostId))]
        public TournamentHost TournamentHost { get; set; } = null!;

        [Required]
        [Comment("Tournament fee")]
        public decimal Fee { get; set; }

        [Required]
        [Comment("Tournament's total capacity")]
        public int Capacity { get; set; }
        
        [Required]
        [MaxLength(TournamentImageUrlMaxLength)]
        [Comment("The current Event's Image Url")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public TennisBalls TournamentBalls { get; set; }

        public ICollection<TournamentMatch> TournamentMatches { get; set; } = new List<TournamentMatch>();

        public ICollection<PlayerTournament> PlayerTournaments { get; set; } = new List<PlayerTournament>();
    }
}
