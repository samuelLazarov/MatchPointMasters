namespace MatchPointMasters.Core.Models.Roles.ViewModels
{
    using MatchPointMasters.Core.Contracts;
    public class PlayerDetailsViewModel : IPlayerModel
    {
        public string FullName { get; set; } = string.Empty;
    }
}
