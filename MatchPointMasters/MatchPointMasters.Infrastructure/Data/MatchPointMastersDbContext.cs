
namespace MatchPointMasters.Infrastructure.Data
{
    using MatchPointMasters.Infrastructure.Data.Models.Article;
    using MatchPointMasters.Infrastructure.Data.Models.Mappings;
    using MatchPointMasters.Infrastructure.Data.Models.Match;
    using MatchPointMasters.Infrastructure.Data.Models.Player;
    using MatchPointMasters.Infrastructure.Data.Models.Tournament;
    using MatchPointMasters.Infrastructure.Data.SeedDb.Configuration;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class MatchPointMastersDbContext : IdentityDbContext
    {
        public MatchPointMastersDbContext(DbContextOptions<MatchPointMastersDbContext> options)
            : base(options)
        {
           
        }

        public DbSet<Tournament> Tournaments { get; set; } = null!;
        public DbSet<Player> Players { get; set; } = null!;
        public DbSet<Match> Matches { get; set; } = null!;
        public DbSet<MatchScore> MatchScores { get; set; } = null!;
        public DbSet<Set> Sets { get; set; } = null!;
        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<Tiebreak> Tiebreaks { get; set; } = null!;
        public DbSet<PlayerMatch> PlayersMatches { get; set; } = null!;
        public DbSet<PlayerTournament> PlayersTournaments { get; set; } = null!;
        public DbSet<Article> Articles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            builder.ApplyConfiguration(new ArticleConfiguration());
            
            
            base.OnModelCreating(builder);
        }

    }
}