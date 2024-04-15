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

            builder.HasData(
                data.AdminUserClaim, 
                data.HostUserClaim, 
                data.Player1UserClaim,
                data.Player2UserClaim,
                data.Player3UserClaim,
                data.Player4UserClaim,
                data.Player5UserClaim,
                data.Player6UserClaim,
                data.Player7UserClaim,
                data.Player8UserClaim,
                data.GuestUserClaim
                );
        }
    }
}
