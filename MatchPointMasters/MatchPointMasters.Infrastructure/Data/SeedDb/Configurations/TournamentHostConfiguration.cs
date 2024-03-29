namespace MatchPointMasters.Infrastructure.Data.SeedDb.Configuration
{
    using MatchPointMasters.Infrastructure.Data.Models.Roles;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class TournamentHostConfiguration : IEntityTypeConfiguration<TournamentHost>
    {
        public void Configure(EntityTypeBuilder<TournamentHost> builder)
        {
            var data = new DataSeed();
            builder.HasData(new TournamentHost[] { data.TournamentHost });
        }
    }
}
