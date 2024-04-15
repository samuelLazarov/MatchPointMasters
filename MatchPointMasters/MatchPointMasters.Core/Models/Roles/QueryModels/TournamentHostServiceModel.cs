namespace MatchPointMasters.Core.Models.Roles.QueryModels
{
    using System.ComponentModel.DataAnnotations;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants.TournamentHostConstants;

    public class TournamentHostServiceModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(HostPhoneMaxLength)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string UserId { get; set; } = string.Empty;

    }
}
