﻿namespace MatchPointMasters.Core.Models.Roles.QueryModels
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Infrastructure.Data.Enums.Player;
    using System.ComponentModel.DataAnnotations;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants.PlayerConstants;


    public class PlayerServiceModel : IPlayerModel
    {

        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public DominantHand? DominantHand { get; set; }

        public Backhand? Backhand { get; set; }

        public PlayingStyle? PlayingStyle { get; set; }

        public TennisRacket? TennisRacket { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        public int? TournamentWins { get; set; }

        [Required]
        public string ImageUrl { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
    }
}
