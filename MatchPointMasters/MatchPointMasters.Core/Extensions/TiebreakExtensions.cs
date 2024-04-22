using MatchPointMasters.Core.Contracts;

namespace MatchPointMasters.Core.Extensions
{
    public static class TiebreakExtensions
    {
        public static string GetInformation(this ITiebreakModel tiebreak)
        {
            return tiebreak.PlayerOnePoints.ToString().Replace(" ", "-") + "/" + tiebreak.PlayerTwoPoints.ToString().Replace(" ", "-");
        }
    }
}
