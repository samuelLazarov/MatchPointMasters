using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchPointMasters.Infrastructure.Data.SeedDb.Configurations
{
    public class UserClaimsConfiguration : IEntityTypeConfiguration<IdentityUserClaim<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
        {
            var data = new DataSeed();

            builder.HasData(data. AdminUserClaim, data.HostUserClaim, data.Player1UserClaim, data.GuestUserClaim);
        }
    }
}
