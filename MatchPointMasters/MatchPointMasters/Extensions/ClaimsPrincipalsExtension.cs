namespace System.Security.Claims
{
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
    }
}
