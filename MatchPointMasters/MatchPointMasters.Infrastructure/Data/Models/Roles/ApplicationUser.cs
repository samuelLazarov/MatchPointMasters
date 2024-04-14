﻿namespace MatchPointMasters.Infrastructure.Data.Models.Roles
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants.ApplicationUserConstants;
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [PersonalData]
        [MaxLength(ApplicationUserFirstNameMaxLength)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [PersonalData]
        [MaxLength(ApplicationUserLastNameMaxLength)]
        public string LastName { get; set; } = string.Empty;
    }
}
