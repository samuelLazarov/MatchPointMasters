namespace MatchPointMasters.Core.Services
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Core.Enumerations;
    using MatchPointMasters.Core.Extensions;
    using MatchPointMasters.Core.Models.Match.QueryModels;
    using MatchPointMasters.Core.Models.Roles.QueryModels;
    using MatchPointMasters.Core.Models.Roles.ViewModels;
    using MatchPointMasters.Core.Models.Tournament.QueryModels;
    using MatchPointMasters.Infrastructure.Data.Common;
    using MatchPointMasters.Infrastructure.Data.Models.Mappings;
    using MatchPointMasters.Infrastructure.Data.Models.Player;
    using MatchPointMasters.Infrastructure.Data.Models.Roles;
    using MatchPointMasters.Infrastructure.Data.Models.Tournament;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class PlayerService : IPlayerService
    {
        private readonly IRepository repository;

        public PlayerService(
            IRepository _repository)
        {
            repository = _repository;
        }

        public async Task AddAsync(string userId, PlayerAddViewModel playerForm)
        {
            await repository.AddAsync(new Player()
            {
                UserId = userId,
                PhoneNumber = playerForm.PhoneNumber,
                BirthDate = playerForm.BirthDate,
                Gender = playerForm.Gender,
                DominantHand = playerForm.DominantHand,
                Backhand = playerForm.Backhand,
                PlayingStyle = playerForm.PlayingStyle,
                TennisRacket = playerForm.TennisRacket,
                ImageUrl = playerForm.ImageUrl,
                Wins = 0,
                Losses = 0,
                TournamentWins = 0
            });

            await repository.SaveChangesAsync();
        }

        public async Task<PlayerEditViewModel> EditGetAsync(int playerId)
        {
            var currentPlayer = await repository.All<Player>()
                .FirstOrDefaultAsync(p => p.Id == playerId);

            var playerForm = new PlayerEditViewModel()
            {
                Id = currentPlayer.Id,
                PhoneNumber = currentPlayer.PhoneNumber,
                BirthDate = currentPlayer.BirthDate,
                Gender = currentPlayer.Gender,
                DominantHand = currentPlayer.DominantHand,
                Backhand = currentPlayer.Backhand,
                PlayingStyle = currentPlayer.PlayingStyle,
                TennisRacket = currentPlayer.TennisRacket,
                ImageUrl = currentPlayer.ImageUrl,
            };

            return playerForm;
        }

        public async Task<int> EditPostAsync(PlayerEditViewModel playerForm)
        {
            var player = await repository.All<Player>()
                .Where(p => p.Id == playerForm.Id)
                .FirstOrDefaultAsync();

            player.PhoneNumber = playerForm.PhoneNumber;
            player.BirthDate = playerForm.BirthDate;
            player.Gender = playerForm.Gender;
            player.DominantHand = playerForm.DominantHand;
            player.Backhand = playerForm.Backhand;
            player.PlayingStyle = playerForm.PlayingStyle;
            player.TennisRacket = playerForm.TennisRacket;
            player.ImageUrl = playerForm.ImageUrl;

            await repository.SaveChangesAsync();

            return player.Id;
        }

        public async Task<PlayerQueryServiceModel> AllAsync(
            string? searchTerm = null,
            PlayerSorting sorting = PlayerSorting.All,
            int currentPage = 1,
            int playersPerPage = 8)
        {

            var playersToShow = repository.AllAsReadOnly<Player>()
                .OrderByDescending(p => p.Wins)
                .ThenBy(p => p.Losses);

            var players = await playersToShow
                .Skip((currentPage - 1) * playersPerPage)
                .Take(playersPerPage)
                .ProjectToPlayerServiceModel()
                .ToListAsync();

            return new PlayerQueryServiceModel()
            {
                Players = players,
                TotalPlayersCount = playersToShow.Count(),
            };
        }


        public async Task<bool> PlayerExistsByIdAsync(int playerId)
        {
            return await repository.AllAsReadOnly<Player>()
                .AnyAsync(p => p.Id == playerId);
        }

        public async Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber)
        {
            return await repository.AllAsReadOnly<Player>()
                .AnyAsync(p => p.PhoneNumber == phoneNumber);
        }


        public async Task<Player> FindPlayerByIdAsync(int playerId)
        {
            return await repository.GetByIdAsync<Player>(playerId);
        }

        public async Task<Player> FindPlayerByUserIdAsync(string userId)
        {
            var user = await repository.GetByIdAsync<ApplicationUser>(userId);
            var player = await repository.AllAsReadOnly<Player>()
                .Where(p => p.UserId == user.Id)
                .FirstOrDefaultAsync();
            return player;
        }

        public async Task<string> PlayerFullNameAsync(string userId)
        {
            string result = string.Empty;
            var player = await repository.GetByIdAsync<ApplicationUser>(userId);

            if (player != null)
            {
                result = $"{player.FirstName} {player.LastName}";
            }
            return result;
        }

        public async Task<MatchQueryServiceModel> GetPlayerMatches(
            int playerId,
            MatchStatus status = MatchStatus.All,
            int currentPage = 1,
            int matchesPerPage = 8)
        {
            var matchesToShow = repository.AllAsReadOnly<Infrastructure.Data.Models.Match.Match>()
                .Where(m => m.PlayerMatches.Any(pm => pm.PlayerId == playerId));

            matchesToShow = status switch
            {
                MatchStatus.All => matchesToShow.OrderBy(m => m.Id),
                MatchStatus.HasEnded => matchesToShow.Where(m => m.Winner != null).OrderBy(m => m.Id),
                MatchStatus.InProgress => matchesToShow.Where(m => m.Winner == null).OrderBy(m => m.Id),
                MatchStatus.Upcoming => matchesToShow.Where(m => m.Winner == null).OrderByDescending(m => m.Id),
                _ => matchesToShow.OrderByDescending(m => m.Id),
            };

            var matches = await matchesToShow
                .Skip((currentPage - 1) * matchesPerPage)
                .Take(matchesPerPage)
                .ProjectToMatchServiceModel()
                .ToListAsync();

            int totalMatches = await matchesToShow.CountAsync();

            return new MatchQueryServiceModel()
            {
                Matches = matches,
                TotalMatchesCount = totalMatches
            };
        }

        public async Task<TournamentQueryServiceModel> GetPlayerTournaments(
            int playerId,
            TournamentSorting sorting = TournamentSorting.Newest,
            int currentPage = 1,
            int tournamentsPerPage = 8)
        {
            var tournamentsToShow = repository.AllAsReadOnly<Tournament>()
                    .Where(m => m.PlayerTournaments.Any(pt => pt.PlayerId == playerId));


            var tournaments = await tournamentsToShow
                .Skip((currentPage - 1) * tournamentsPerPage)
                .Take(tournamentsPerPage)
                .ProjectToTournamentServiceModel()
                .ToListAsync();


            int totalTournaments = await tournamentsToShow.CountAsync();

            return new TournamentQueryServiceModel()
            {
                Tournaments = tournaments,
                TotalTournamentsCount = totalTournaments
            };

        }

        public async Task<bool> PlayerIsInTournamentAsync(int playerId, int tournamentId)
        {
            return await repository.AllAsReadOnly<PlayerTournament>()
                .AnyAsync(pt => pt.PlayerId == playerId && pt.TournamentId == tournamentId);
        }

        public async Task<PlayerTournament> AddPlayerToTournamentAsync(int playerId, int tournamentId)
        {
            var playerTournament = await repository.All<PlayerTournament>()
                .Where(pt => pt.PlayerId == playerId && pt.TournamentId == tournamentId)
                .FirstOrDefaultAsync();

            if (playerTournament == null)
            {
                playerTournament = new PlayerTournament()
                {
                    PlayerId = playerId,
                    TournamentId = tournamentId
                };

                await repository.AddAsync(playerTournament);
                await repository.SaveChangesAsync();
            }

            return playerTournament;
        }

        public async Task<PlayerTournamentDeleteViewModel> RemovePlayerFromTournamentAsync(int playerId, int tournamentId)
        {
            var player = await repository.GetByIdAsync<Player>(playerId);
            var tournament = await repository.GetByIdAsync<Tournament>(tournamentId);
            var deleteForm = new PlayerTournamentDeleteViewModel()
            {
                PlayerName = $"{player.User.FirstName} {player.User.LastName}",
                TournamentName = tournament.Name
            };

            return deleteForm;
        }

        public async Task RemovePlayerFromTournamentConfirmedAsync(int playerId, int tournamentId)
        {
            var playerInTheCurrentTournament = await repository.All<PlayerTournament>()
                .Where(pt => pt.PlayerId == playerId && pt.TournamentId == tournamentId)
                .FirstOrDefaultAsync();

            await repository.RemoveAsync<PlayerTournament>(playerInTheCurrentTournament);
            await repository.SaveChangesAsync();
        }

        public async Task<Player> FindPlayerByNameAsync(string name)
        {
            var user = await repository.AllAsReadOnly<ApplicationUser>()
                .Where(u => u.FirstName.ToLower() + " " + u.LastName.ToLower() == name.ToLower())
                .FirstOrDefaultAsync();

            var player = await repository.AllAsReadOnly<Player>()
                .Where(p => p.UserId == user.Id)
                .FirstOrDefaultAsync();

            return player;
        }

        public async Task<PlayerDetailsViewModel> PlayerDetailsByIdAsync(string playerId)
        {
            var user = await repository.GetByIdAsync<ApplicationUser>(playerId);

            var player = await repository.AllAsReadOnly<Player>()
                .Where(p => p.UserId == user.Id)
                .FirstOrDefaultAsync();

            return new PlayerDetailsViewModel()
            {
                FullName = $"{user.FirstName} {user.LastName}",
                BirthDate = player.BirthDate,
                Gender = player.Gender,
                DominantHand = player.DominantHand,
                Backhand = player.Backhand,
                PlayingStyle = player.PlayingStyle,
                TennisRacket = player.TennisRacket,
                Wins = player.Wins,
                Losses = player.Losses,
                TournamentWins = player.TournamentWins,
                ImageUrl = player.ImageUrl,
            };
        }

        public async Task<bool> PlayerExistsByUserIdAsync(string userId)
        {
            var user = await repository.GetByIdAsync<ApplicationUser>(userId);

            var player = await repository.AllAsReadOnly<Player>()
                .FirstOrDefaultAsync(p => p.UserId == userId);

            if (player == null)
            {
                return false;
            }

            return true;
        }
    }
}
