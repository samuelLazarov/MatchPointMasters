namespace MatchPointMasters.Core.Models.Roles.ViewModels
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Infrastructure.Data.Enums.Player;

    public class PlayerDetailsViewModel : IPlayerModel
    {
        public string FullName { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }

        public DominantHand? DominantHand { get; set; }

        public Backhand? Backhand { get; set; }

        public PlayingStyle? PlayingStyle { get; set; }

        public TennisRacket? TennisRacket { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        public int? TournamentWins { get; set; }

        public string ImageUrl { get; set; } = string.Empty;
    }
}
