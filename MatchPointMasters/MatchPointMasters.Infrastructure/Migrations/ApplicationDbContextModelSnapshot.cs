﻿// <auto-generated />
using System;
using MatchPointMasters.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MatchPointMasters.Infrastructure.Migrations
{
    [DbContext(typeof(MatchPointMastersDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MatchPointMasters.Infrastructure.Data.Models.Article.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("The current Article's Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)")
                        .HasComment("The current Article's Content");

                    b.Property<DateTime>("DatePublished")
                        .HasColumnType("datetime2")
                        .HasComment("The date on which the current Article was posted");

                    b.Property<string>("HostUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("The current author's identifier");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("The current Article's Image Url");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)")
                        .HasComment("The current Article's Title");

                    b.Property<int>("ViewsCount")
                        .HasColumnType("int")
                        .HasComment("The current Article's Views Count");

                    b.HasKey("Id");

                    b.HasIndex("HostUserId");

                    b.ToTable("Articles");

                    b.HasComment("Articles can be created by Tournament Hosts and commented by Players");
                });

            modelBuilder.Entity("MatchPointMasters.Infrastructure.Data.Models.Mappings.PlayerMatch", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("int")
                        .HasComment("The current Player's Identifier");

                    b.Property<int>("MatchId")
                        .HasColumnType("int")
                        .HasComment("The current Tennis Match Identifier");

                    b.HasKey("PlayerId", "MatchId");

                    b.HasIndex("MatchId");

                    b.ToTable("PlayersMatches");
                });

            modelBuilder.Entity("MatchPointMasters.Infrastructure.Data.Models.Mappings.PlayerTournament", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("int")
                        .HasComment("The current Player's Identifier");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int")
                        .HasComment("The current Tournament's Identifier");

                    b.HasKey("PlayerId", "TournamentId");

                    b.HasIndex("TournamentId");

                    b.ToTable("PlayersTournaments");
                });

            modelBuilder.Entity("MatchPointMasters.Infrastructure.Data.Models.Mappings.TournamentMatch", b =>
                {
                    b.Property<int>("TournamentId")
                        .HasColumnType("int")
                        .HasComment("The current Tournament's Identifier");

                    b.Property<int>("MatchId")
                        .HasColumnType("int")
                        .HasComment("The current Tennis Match Identifier");

                    b.HasKey("TournamentId", "MatchId");

                    b.HasIndex("MatchId");

                    b.ToTable("TournamentMatches");
                });

            modelBuilder.Entity("MatchPointMasters.Infrastructure.Data.Models.Match.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("The current Match Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MatchRound")
                        .HasColumnType("int")
                        .HasComment("The current Match Round from Tournament");

                    b.Property<int>("PlayerOneId")
                        .HasColumnType("int")
                        .HasComment("The current Player One's Identifier");

                    b.Property<int>("PlayerOneSetsWon")
                        .HasColumnType("int");

                    b.Property<int>("PlayerTwoId")
                        .HasColumnType("int")
                        .HasComment("The current Player Two's Identifier");

                    b.Property<int>("PlayerTwoSetsWon")
                        .HasColumnType("int");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int")
                        .HasComment("The current Tournament Identifier");

                    b.Property<int>("Winner")
                        .HasColumnType("int")
                        .HasComment("Indicates who wins the match");

                    b.HasKey("Id");

                    b.HasIndex("PlayerOneId");

                    b.HasIndex("PlayerTwoId");

                    b.HasIndex("TournamentId");

                    b.ToTable("Matches");

                    b.HasComment("Tennis match between two players in a tournament");
                });

            modelBuilder.Entity("MatchPointMasters.Infrastructure.Data.Models.Match.Set", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("The current Set's Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("HasTiebreak")
                        .HasColumnType("bit")
                        .HasComment("Indicates if current set is decided by tiebreak");

                    b.Property<int>("MatchId")
                        .HasColumnType("int")
                        .HasComment("Current Match Identifier");

                    b.Property<int>("PlayerOneGamesWon")
                        .HasColumnType("int")
                        .HasComment("Indicates number of games won by Player One in the current set");

                    b.Property<int>("PlayerTwoGamesWon")
                        .HasColumnType("int")
                        .HasComment("Indicates number of games won by Player Two in the current set");

                    b.Property<int?>("TiebreakId")
                        .HasColumnType("int")
                        .HasComment("The curent Tiebreak's Identifier");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.HasIndex("TiebreakId");

                    b.ToTable("Sets");
                });

            modelBuilder.Entity("MatchPointMasters.Infrastructure.Data.Models.Match.Tiebreak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PlayerOnePoints")
                        .HasColumnType("int")
                        .HasComment("Player One points");

                    b.Property<int>("PlayerTwoPoints")
                        .HasColumnType("int")
                        .HasComment("Player Two points");

                    b.Property<int>("SetId")
                        .HasColumnType("int")
                        .HasComment("Current Set Identifier");

                    b.HasKey("Id");

                    b.HasIndex("SetId");

                    b.ToTable("Tiebreaks");

                    b.HasComment("If a set must be decided by tiebreak");
                });

            modelBuilder.Entity("MatchPointMasters.Infrastructure.Data.Models.Player.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("The current Player's Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Backhand")
                        .HasColumnType("int")
                        .HasComment("Player's backhand style");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DominantHand")
                        .HasColumnType("int")
                        .HasComment("Player's dominant hand");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("The current Player's First Name");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("The current Player's Last Name");

                    b.Property<int>("Losses")
                        .HasColumnType("int")
                        .HasComment("Player's losses counter");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Player's phone");

                    b.Property<int?>("PlayingStyle")
                        .HasColumnType("int")
                        .HasComment("Player's style of play");

                    b.Property<int?>("TennisRacket")
                        .HasColumnType("int")
                        .HasComment("Player's racket brand");

                    b.Property<int?>("TournamentWins")
                        .HasColumnType("int")
                        .HasComment("Player's Tournament wins counter");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User Identifier");

                    b.Property<int>("Wins")
                        .HasColumnType("int")
                        .HasComment("Player's wins counter");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("MatchPointMasters.Infrastructure.Data.Models.Roles.TournamentHost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("The current Tournament host's Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Tournament host's phone");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("The current User's Identifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("TournamentHost");

                    b.HasComment("A user who will host a tournament");
                });

            modelBuilder.Entity("MatchPointMasters.Infrastructure.Data.Models.Tournament.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Tennis Club's Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Club's address");

                    b.Property<int>("CourtSurface")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Tennis club's image url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("The current club's name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Club's phone");

                    b.HasKey("Id");

                    b.ToTable("Club");

                    b.HasComment("Tennis club hosting a tournament");
                });

            modelBuilder.Entity("MatchPointMasters.Infrastructure.Data.Models.Tournament.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("The current Tournament's Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasComment("Tournament description");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2")
                        .HasComment("The current Tournament's end date and hour");

                    b.Property<decimal>("Fee")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Tournament fee");

                    b.Property<int>("HostClubId")
                        .HasColumnType("int")
                        .HasComment("Host club's Identifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("The current Tournament's Name");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2")
                        .HasComment("The current Tournament's start date and hour");

                    b.Property<int>("TournamentBalls")
                        .HasColumnType("int");

                    b.Property<int>("TournamentHostId")
                        .HasColumnType("int")
                        .HasComment("Tournament Host's Identifier");

                    b.HasKey("Id");

                    b.HasIndex("HostClubId");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MatchPointMasters.Infrastructure.Data.Models.Article.Article", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "HostUser")
                        .WithMany()
                        .HasForeignKey("HostUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HostUser");
                });

            modelBuilder.Entity("MatchPointMasters.Infrastructure.Data.Models.Mappings.PlayerMatch", b =>
                {
                    b.HasOne("MatchPointMasters.Infrastructure.Data.Models.Match.Match", "Match")
                        .WithMany("PlayerMatches")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MatchPointMasters.Infrastructure.Data.Models.Player.Player", "Player")
                        .WithMany("PlayerMatches")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("MatchPointMasters.Infrastructure.Data.Models.Mappings.PlayerTournament", b =>
                {
                    b.HasOne("MatchPointMasters.Infrastructure.Data.Models.Player.Player", "Player")
                        .WithMany("PlayerTournaments")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MatchPointMasters.Infrastructure.Data.Models.Tournament.Tournament", "Tournament")
                        .WithMany("PlayerTournaments")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("MatchPointMasters.Infrastructure.Data.Models.Mappings.TournamentMatch", b =>
                {
                    b.HasOne("MatchPointMasters.Infrastructure.Data.Models.Match.Match", "Match")
                        .WithMany("TournamentMatches")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MatchPointMasters.Infrastructure.Data.Models.Tournament.Tournament", "Tournament")
                        .WithMany("TournamentMatches")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("MatchPointMasters.Infrastructure.Data.Models.Match.Match", b =>
                {
                    b.HasOne("MatchPointMasters.Infrastructure.Data.Models.Player.Player", "PlayerOne")
                        .WithMany()
                        .HasForeignKey("PlayerOneId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MatchPointMasters.Infrastructure.Data.Models.Player.Player", "PlayerTwo")
                        .WithMany()
                        .HasForeignKey("PlayerTwoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MatchPointMasters.Infrastructure.Data.Models.Tournament.Tournament", "Tournament")
                        .WithMany()
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlayerOne");

                    b.Navigation("PlayerTwo");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("MatchPointMasters.Infrastructure.Data.Models.Match.Set", b =>
                {
                    b.HasOne("MatchPointMasters.Infrastructure.Data.Models.Match.Match", "Match")
                        .WithMany("Sets")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MatchPointMasters.Infrastructure.Data.Models.Match.Tiebreak", "Tiebreak")
                        .WithMany()
                        .HasForeignKey("TiebreakId");

                    b.Navigation("Match");

                    b.Navigation("Tiebreak");
                });

            modelBuilder.Entity("MatchPointMasters.Infrastructure.Data.Models.Match.Tiebreak", b =>
                {
                    b.HasOne("MatchPointMasters.Infrastructure.Data.Models.Match.Set", "Set")
                        .WithMany()
                        .HasForeignKey("SetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Set");
                });

            modelBuilder.Entity("MatchPointMasters.Infrastructure.Data.Models.Player.Player", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MatchPointMasters.Infrastructure.Data.Models.Roles.TournamentHost", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MatchPointMasters.Infrastructure.Data.Models.Tournament.Tournament", b =>
                {
                    b.HasOne("MatchPointMasters.Infrastructure.Data.Models.Roles.TournamentHost", "TournamentHost")
                        .WithMany("Tournaments")
                        .HasForeignKey("HostClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MatchPointMasters.Infrastructure.Data.Models.Tournament.Club", "HostClub")
                        .WithMany()
                        .HasForeignKey("HostClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HostClub");

                    b.Navigation("TournamentHost");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MatchPointMasters.Infrastructure.Data.Models.Match.Match", b =>
                {
                    b.Navigation("PlayerMatches");

                    b.Navigation("Sets");

                    b.Navigation("TournamentMatches");
                });

            modelBuilder.Entity("MatchPointMasters.Infrastructure.Data.Models.Player.Player", b =>
                {
                    b.Navigation("PlayerMatches");

                    b.Navigation("PlayerTournaments");
                });

            modelBuilder.Entity("MatchPointMasters.Infrastructure.Data.Models.Roles.TournamentHost", b =>
                {
                    b.Navigation("Tournaments");
                });

            modelBuilder.Entity("MatchPointMasters.Infrastructure.Data.Models.Tournament.Tournament", b =>
                {
                    b.Navigation("PlayerTournaments");

                    b.Navigation("TournamentMatches");
                });
#pragma warning restore 612, 618
        }
    }
}
