namespace MatchPointMasters.Infrastructure.Data.SeedDb.Configuration
{
    using MatchPointMasters.Infrastructure.Data.Models.Roles;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var data = new DataSeed();
            builder.HasData(new ApplicationUser[]
            {
                data.AdminUser,
                data.HostUser,
                data.Player1User,
                data.Player2User,
                data.Player3User,
                data.Player4User,
                data.Player5User,
                data.Player6User,
                data.Player7User,
                data.Player8User,
                data.GuestUser
            });
        }
    }
}
