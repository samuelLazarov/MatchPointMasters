using MatchPointMasters.Infrastructure.Data.Models.Match;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchPointMasters.Infrastructure.Data.SeedDb.Configuration
{
    internal class TiebreakConfiguration : IEntityTypeConfiguration<Tiebreak>
    {
        public void Configure(EntityTypeBuilder<Tiebreak> builder)
        {
            var data = new DataSeed();

            builder.HasData(new Tiebreak[]
            {
                data.Tiebreak1Player1Player2,
                data.Tiebreak2Player7Player8,
                data.Tiebreak3Player7Player8
            });
        }
    }
}
