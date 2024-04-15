namespace MatchPointMasters.Core.Models.Match.QueryModels
{
    public class MatchQueryServiceModel
    {
        public int TotalMatchesCount { get; set; }
        public IEnumerable<MatchServiceModel> Matches { get; set; } = new List<MatchServiceModel>();
    }
}
