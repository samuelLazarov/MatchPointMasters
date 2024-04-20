namespace MatchPointMasters.Core.Models.Match.QueryModels
{
    using MatchPointMasters.Core.Enumerations;
    using MatchPointMasters.Infrastructure.Data.Enums.Match;
    using System.ComponentModel.DataAnnotations;

    public class AllMatchesQueryModel
    {

        public int TournamentId { get; set; }
        public MatchRound MatchRound { get; set; }

        [Display(Name = "Търсене")]
        public string SearchTerm { get; set; } = string.Empty;

        [Display(Name = "Статус")]
        public MatchStatus Status { get; set; }

        public int CurrentPage { get; set; } = 1;
        public int MatchesPerPage { get; } = 8;

        public int TotalMatchesCount { get; set; }
        public IEnumerable<MatchServiceModel> Matches { get; set; } = new HashSet<MatchServiceModel>();
    }
}
