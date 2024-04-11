namespace MatchPointMasters.Core.Models.Match
{
    public class MatchQueryServiceModel
    {
        public int TotalMatchesCount { get; set; }
        public IEnumerable<MatchServiceModel> Matches { get; set; } = new List<MatchServiceModel>();
    }
}
