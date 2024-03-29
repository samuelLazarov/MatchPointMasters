namespace MatchPointMasters.Infrastructure.Data.SeedDb.Configuration
{
    using MatchPointMasters.Infrastructure.Data.Models.Article;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            var data = new DataSeed();

            builder.HasData(new Article[] 
            { 
                data.ArticleZashoOpen2024, 
                data.ArticleVSSportOpen2024, 
                data.ArticleLeaderOpen2024 
            });
        }
    }
}
