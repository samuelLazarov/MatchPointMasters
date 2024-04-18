using MatchPointMasters.Core.Contracts;

namespace MatchPointMasters.Core.Extensions
{
    public static class PlayerExtensions
    {
        public static string GetInformation(this IPlayerModel model)
        {
            return model.FullName.Replace(" ", "");
        }
    }
}
