namespace MatchPointMasters.Extensions
{
    using Microsoft.AspNetCore.Identity;
    using System.Security.Claims;
    using static MatchPointMasters.Core.Constants.AdministratorConstants;
    public static class ClaimsPrincipalsExtension
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(AdminRole);
        }

        //public static async Task<bool> IsAdminAsync(this IdentityUser user, UserManager<IdentityUser> userManager)
        //{
        //    // Check if the user is in the Admin role
        //    return await userManager.IsInRoleAsync(user, "Admin");
        //}
    }
}
