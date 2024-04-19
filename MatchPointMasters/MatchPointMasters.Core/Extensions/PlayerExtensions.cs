using MatchPointMasters.Core.Contracts;
using MatchPointMasters.Infrastructure.Data.Models.Tournament;
using System.Text.RegularExpressions;

namespace MatchPointMasters.Core.Extensions
{
    public static class PlayerExtensions
    {
        public static string GetInformation(this IPlayerModel player)
        {
            string info = player.FullName.Replace(" ", "-");
            info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);
            return info;
        }
    }
}
