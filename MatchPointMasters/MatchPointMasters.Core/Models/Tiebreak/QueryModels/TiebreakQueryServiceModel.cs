namespace MatchPointMasters.Core.Models.Tiebreak.QueryModels
{
    public class TiebreakQueryServiceModel
    {
        public int TotalTiebreaksCount { get; set; }
        public IEnumerable<TiebreakServiceModel> Tiebreaks { get; set; } = new List<TiebreakServiceModel>();
    }
}
