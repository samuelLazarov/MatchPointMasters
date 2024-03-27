namespace MatchPointMasters.Infrastructure.Data.SeedDb.Configuration
{
    using MatchPointMasters.Infrastructure.Data.Models.Player;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    internal class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            throw new NotImplementedException();
        }
    }
}
