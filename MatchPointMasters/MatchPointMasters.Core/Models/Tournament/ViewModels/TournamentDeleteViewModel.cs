using MatchPointMasters.Core.Contracts;

namespace MatchPointMasters.Core.Models.Tournament.ViewModels
{
    public class TournamentDeleteViewModel : ITournamentModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string HostClub { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
