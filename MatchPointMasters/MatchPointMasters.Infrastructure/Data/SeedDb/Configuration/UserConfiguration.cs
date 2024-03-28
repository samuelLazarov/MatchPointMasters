namespace MatchPointMasters.Infrastructure.Data.SeedDb.Configuration
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            var data = new DataSeed();
            builder.HasData(new IdentityUser[]
            {
                data.HostUser,
                data.Player1User,
                data.Player2User,
                data.Player3User,
                data.Player4User,
                data.Player5User,
                data.Player6User,
                data.Player7User,
                data.Player8User,
            });
        }
    }
}
