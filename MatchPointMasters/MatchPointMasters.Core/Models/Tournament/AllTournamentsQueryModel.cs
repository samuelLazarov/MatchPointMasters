using MatchPointMasters.Core.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace MatchPointMasters.Core.Models.Tournament
{
    public class AllTournamentsQueryModel
    {
        public int EventsPerPage { get; } = 8;

        [Display(Name = "Търсене")]
        public string SearchTerm { get; set; } = null!;

        [Display(Name = "Сортиране")]
        public TournamentSorting Sorting { get; set; }

        [Display(Name = "Статус")]
        public TournamentStatus Status { get; set; }

        public int TotalEventsCount { get; set; }
        public int CurrentPage { get; set; } = 1;

        public IEnumerable<TournamentServiceModel> Events { get; set; } = new HashSet<TournamentServiceModel>();
    }
}
