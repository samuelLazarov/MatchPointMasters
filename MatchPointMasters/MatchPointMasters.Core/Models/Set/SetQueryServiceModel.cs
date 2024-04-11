namespace MatchPointMasters.Core.Models.Set
{
    public class SetQueryServiceModel
    {
        public int TotalSetsCount { get; set; }
        public IEnumerable<SetServiceModel> Sets { get; set; } = new List<SetServiceModel>();
    }
}
