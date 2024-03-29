
namespace MatchPointMasters.Infrastructure.Data.SeedDb.Configuration
{
    using MatchPointMasters.Infrastructure.Data.Models.Match;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    internal class SetConfiguration : IEntityTypeConfiguration<Set>
    {
        public void Configure(EntityTypeBuilder<Set> builder)
        {
            var data = new DataSeed();

            builder.HasData(new Set[]
            {
                data.Set1Player1Player2, 
                data.Set2Player1Player2,
                data.Set3Player1Player2,
                data.Set4Player3Player4,
                data.Set5Player3Player4,
                data.Set6Player5Player6,    
                data.Set7Player5Player6,
                data.Set8Player7Player8,
                data.Set9Player7Player8,
                data.Set10Player7Player8,
            });

        }
    }
}
