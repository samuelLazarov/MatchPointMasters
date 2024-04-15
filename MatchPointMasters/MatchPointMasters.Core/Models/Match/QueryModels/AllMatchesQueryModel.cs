namespace MatchPointMasters.Core.Models.Match.QueryModels
{
    using MatchPointMasters.Core.Enumerations;
    using System.ComponentModel.DataAnnotations;

    public class AllMatchesQueryModel
    {
        public int MatchesPerPage { get; } = 8;

        [Display(Name = "Търсене")]
        public string SearchTerm { get; set; } = null!;

        [Display(Name = "Статус")]
        public MatchStatus Status { get; set; }

        public int TotalMatchesCount { get; set; }
        public int CurrentPage { get; set; } = 1;

        public IEnumerable<MatchServiceModel> Matches { get; set; } = new HashSet<MatchServiceModel>();
    }
}
