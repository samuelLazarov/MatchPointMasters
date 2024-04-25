namespace MatchPointMasters.Core.Models.Roles.QueryModels
{
    using MatchPointMasters.Core.Enumerations;
    using System.ComponentModel.DataAnnotations;
    public class AllPlayersQueryModel
    {
        public int PlayerId { get; set; }
        public PlayerSorting Sorting { get; set; }

        [Display(Name = "Търсене")]
        public string SearchTerm { get; set; } = string.Empty;

        public int CurrentPage { get; set; } = 1;
        public int PlayersPerPage { get; } = 8;

        public int TotalPlayersCount { get; set; }
        public IEnumerable<PlayerServiceModel> Players { get; set; } = new HashSet<PlayerServiceModel>();
    }
}
