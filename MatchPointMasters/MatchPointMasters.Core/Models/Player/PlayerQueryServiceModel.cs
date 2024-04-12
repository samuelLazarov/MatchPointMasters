namespace MatchPointMasters.Core.Models.Player
{
    public class PlayerQueryServiceModel
    {
        public int TotalPlayersCount { get; set; }
        public IEnumerable<PlayerServiceModel> Players { get; set; } = new List<PlayerServiceModel>();
    }
}
