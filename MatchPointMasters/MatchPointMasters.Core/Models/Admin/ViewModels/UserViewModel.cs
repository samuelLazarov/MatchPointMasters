namespace MatchPointMasters.Core.Models.Admin.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants.TournamentHostConstants;
    public class UserViewModel
    {
        [Required]
        [RegularExpression(HostEmailRegex)]
        public string Email { get; set; } = string.Empty;
    }
}
