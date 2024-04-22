using MatchPointMasters.Core.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace MatchPointMasters.Core.Models.Tournament.QueryModels
{
    public class AllTournamentsQueryModel
    {

        [Display(Name = "Търсене")]
        public string SearchTerm { get; set; } = null!;

        [Display(Name = "Сортиране")]
        public TournamentSorting Sorting { get; set; }

        [Display(Name = "Статус")]
        public TournamentStatus Status { get; set; }

        public int TotalTournamentsCount { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int TournamentsPerPage { get; } = 8;

        public IEnumerable<TournamentServiceModel> Tournaments { get; set; } = new HashSet<TournamentServiceModel>();
    }
}
