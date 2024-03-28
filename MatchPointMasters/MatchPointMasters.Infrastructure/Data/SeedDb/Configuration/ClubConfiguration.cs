namespace MatchPointMasters.Infrastructure.Data.SeedDb.Configuration
{
    using MatchPointMasters.Infrastructure.Data.Models.Tournament;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    internal class ClubConfiguration : IEntityTypeConfiguration<Club>
    {
        public void Configure(EntityTypeBuilder<Club> builder)
        {
            var data = new DataSeed();
            builder.HasData(new Club[]
            {
                data.TkNikaSarafovo,
                data.TkLokoPlovdiv,
                data.TkAvenue,
                data.TkVelto
            });
        }
    }
}
