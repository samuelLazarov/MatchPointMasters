namespace MatchPointMasters.Infrastructure.Data.SeedDb.Configuration
{
    using MatchPointMasters.Infrastructure.Data.Models.Player;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    internal class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            var data = new DataSeed();
            builder.HasData(new Player[] 
            {
                data.Player1,
                data.Player2,
                data.Player3,
                data.Player4,
                data.Player5,
                data.Player6,
                data.Player7,
                data.Player8,
            });
        }
    }
}
