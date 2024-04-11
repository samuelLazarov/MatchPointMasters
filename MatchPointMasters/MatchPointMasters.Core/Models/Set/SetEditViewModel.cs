﻿namespace MatchPointMasters.Core.Models.Set
{
    using MatchPointMasters.Core.Contracts;
    using System.ComponentModel.DataAnnotations;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants.MatchConstants;

    public class SetEditViewModel : ISetModel
    {
        public int Id { get; set; }

        [Required]
        public int MatchId { get; set; }

        [Required]
        [Range(GamesMinRange, GamesMaxRange, ErrorMessage = RangeErrorMessage)]
        public int PlayerOneGamesWon { get; set; }

        [Required]
        [Range(GamesMinRange, GamesMaxRange, ErrorMessage = RangeErrorMessage)]
        public int PlayerTwoGamesWon { get; set; }

        [Required]
        public bool HasTiebreak { get; set; } = false;

        public int? TiebreakId { get; set; }
    }
}
