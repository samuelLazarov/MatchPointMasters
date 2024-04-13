﻿namespace MatchPointMasters.Core.Models.Match
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Infrastructure.Data.Enums.Match;
    using System.ComponentModel.DataAnnotations;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants.MatchConstants;

    public class MatchEditViewModel : IMatchModel
    {
        public int Id { get; set; }

        [Required]
        public int TournamentId { get; set; }
        
        [Required]
        public MatchRound MatchRound { get; set; }

        [Required]
        public int PlayerOneId { get; set; }

        [Required]
        public int PlayerTwoId { get; set; }

        [Required]
        [Range(SetsMinRange, SetsMaxRange, ErrorMessage = RangeErrorMessage)]
        public int PlayerOneSetsWon { get; set; } = 0;

        [Required]
        [Range(SetsMinRange, SetsMaxRange, ErrorMessage = RangeErrorMessage)]
        public int PlayerTwoSetsWon { get; set; } = 0;

        public Winner Winner { get; set; }

    }
}
