using System.ComponentModel.DataAnnotations;

namespace MatchPointMasters.Core.Models.Admin.QueryModels
{
    public class UserServiceModel
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;
        public bool IsTournamentHost { get; set; }
        public bool IsAdmin { get; set; }


    }
}
