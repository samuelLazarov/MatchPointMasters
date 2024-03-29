namespace MatchPointMasters.Infrastructure.Data.SeedDb.Configuration
{
    using MatchPointMasters.Infrastructure.Data.Models.Match;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {

        public void Configure(EntityTypeBuilder<Match> builder)
        {
            var data = new DataSeed();
            builder.HasData(new Match[]
            {
                data.MatchP1P2,
                data.MatchP3P4,
                data.MatchP5P6,
                data.MatchP7P8
            });
        }
    }
}
