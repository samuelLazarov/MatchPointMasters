﻿
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
        public DbSet<Set> Sets { get; set; } = null!;
        public DbSet<Tiebreak> Tiebreaks { get; set; } = null!;
        public DbSet<PlayerMatch> PlayersMatches { get; set; } = null!;
        public DbSet<PlayerTournament> PlayersTournaments { get; set; } = null!;
        public DbSet<TournamentMatch> TournamentMatches { get; set; } = null!;
        public DbSet<Article> Articles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<PlayerTournament>()
                .HasKey(pt => new { pt.PlayerId, pt.TournamentId });


            builder.Entity<PlayerTournament>()
                .HasOne(pt => pt.Player)
                .WithMany(p => p.PlayerTournaments)
                .HasForeignKey(pt => pt.PlayerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<PlayerTournament>()
                .HasOne(pt => pt.Tournament)
                .WithMany(pt => pt.PlayerTournaments)
                .HasForeignKey(pt => pt.TournamentId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<PlayerMatch>()
                .HasKey(pm => new { pm.PlayerId, pm.MatchId });


            builder.Entity<PlayerMatch>()
                .HasOne(p => p.Player)
                .WithMany(pm => pm.PlayerMatches)
                .HasForeignKey(p => p.PlayerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<PlayerMatch>()
                .HasOne(m => m.Match)
                .WithMany(pm => pm.PlayerMatches)
                .HasForeignKey(m => m.MatchId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<TournamentMatch>()
                .HasKey(tm => new { tm.TournamentId, tm.MatchId });

            builder.Entity<TournamentMatch>()
                .HasOne(m => m.Tournament)
                .WithMany(pm => pm.TournamentMatches)
                .HasForeignKey(m => m.TournamentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<TournamentMatch>()
                .HasOne(m => m.Match)
                .WithMany(pm => pm.TournamentMatches)
                .HasForeignKey(m => m.MatchId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Tournament>()
                .Property(f => f.Fee)
                .HasPrecision(18, 2);

            builder.Entity<Match>()
                .HasOne(m => m.PlayerOne)
                .WithMany()
                .HasForeignKey(m => m.PlayerOneId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Match>()
                .HasOne(m => m.PlayerTwo)
                .WithMany()
                .HasForeignKey(m => m.PlayerTwoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Set>()
                .HasOne(m => m.Match)
                .WithMany()
                .HasForeignKey(m => m.MatchId)
                .OnDelete(DeleteBehavior.NoAction);

            //Configuration(Data Seeding)
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new TournamentHostConfiguration());
            builder.ApplyConfiguration(new TournamentConfiguration());
            builder.ApplyConfiguration(new ClubConfiguration());
            builder.ApplyConfiguration(new PlayerConfiguration());
            builder.ApplyConfiguration(new TiebreakConfiguration());
            builder.ApplyConfiguration(new SetConfiguration());
            builder.ApplyConfiguration(new MatchConfiguration());
            builder.ApplyConfiguration(new ArticleConfiguration());
            

            base.OnModelCreating(builder);
        }

    }
}