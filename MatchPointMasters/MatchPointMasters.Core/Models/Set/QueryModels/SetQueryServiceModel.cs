namespace MatchPointMasters.Core.Models.Set.QueryModels
{
    public class SetQueryServiceModel
    {
        public int TotalSetsCount { get; set; }
        public IEnumerable<SetServiceModel> Sets { get; set; } = new List<SetServiceModel>();
    }
}
