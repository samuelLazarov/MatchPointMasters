namespace MatchPointMasters.Infrastructure.Data.SeedDb.Configuration
{
    using MatchPointMasters.Infrastructure.Data.Models.Tournament;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    internal class TournamentConfiguration : IEntityTypeConfiguration<Tournament>
    {
        public void Configure(EntityTypeBuilder<Tournament> builder)
        {
            var data = new DataSeed();

            builder.HasData(new Tournament[] { data.ZashoOpen, data.VSSportOpen, data.LeaderOpen });
        }
    }
}
