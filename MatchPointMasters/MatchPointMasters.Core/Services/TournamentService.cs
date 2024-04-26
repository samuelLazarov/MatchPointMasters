namespace MatchPointMasters.Core.Services
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Core.Enumerations;
    using MatchPointMasters.Core.Extensions;
    using MatchPointMasters.Core.Models.Match.QueryModels;
    using MatchPointMasters.Core.Models.Roles.QueryModels;
    using MatchPointMasters.Core.Models.Tournament.QueryModels;
    using MatchPointMasters.Core.Models.Tournament.ViewModels;
    using MatchPointMasters.Infrastructure.Data.Common;
    using MatchPointMasters.Infrastructure.Data.Models.Mappings;
    using MatchPointMasters.Infrastructure.Data.Models.Match;
    using MatchPointMasters.Infrastructure.Data.Models.Player;
    using MatchPointMasters.Infrastructure.Data.Models.Roles;
    using MatchPointMasters.Infrastructure.Data.Models.Tournament;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Match = Infrastructure.Data.Models.Match.Match;

    public class TournamentService : ITournamentService
    {

        private readonly IRepository repository;
        private readonly IMatchService matchService;
        private readonly IPlayerService playerService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserService userService;


        public TournamentService(
            IRepository _repository,
            IMatchService _matchService,
            UserManager<ApplicationUser> _userManager,
            IPlayerService _playerService,
            IUserService _userService)
        {
            repository = _repository;
            matchService = _matchService;
            userManager = _userManager;
            playerService = _playerService;
            userService = _userService;
        }

        public async Task<int> AddTournamentAsync(TournamentAddViewModel tournamentForm)
        {
            Tournament tournament = new Tournament()
            {
                Name = tournamentForm.Name,
                Description = tournamentForm.Description,
                StartDate = tournamentForm.StartDate,
                EndDate = tournamentForm.EndDate,
                TournamentHostId = tournamentForm.TournamentHostId,
                HostClubId = tournamentForm.HostClubId,
                TournamentBalls = tournamentForm.TournamentBalls,
                Fee = tournamentForm.Fee,
                Capacity = tournamentForm.Capacity,
                ImageUrl = tournamentForm.ImageUrl
            };

            await repository.AddAsync(tournament);
            await repository.SaveChangesAsync();

            return tournament.Id;
        }

        public async Task<TournamentEditViewModel> EditTournamentGetAsync(int tournamentId)
        {
            var currentTournament = await repository.All<Tournament>()
                .FirstOrDefaultAsync(t => t.Id == tournamentId);

            var tournamentForm = new TournamentEditViewModel()
            {
                Id = currentTournament.Id,
                Name = currentTournament.Name,
                Description = currentTournament.Description,
                StartDate = currentTournament.StartDate,
                EndDate = currentTournament.EndDate,
                HostClubId = currentTournament.HostClubId,
                TournamentBalls = currentTournament.TournamentBalls,
                Fee = currentTournament.Fee,
                Capacity = currentTournament.Capacity,
                ImageUrl = currentTournament.ImageUrl
            };

            return tournamentForm;
        }

        public async Task<int> EditTournamentPostAsync(TournamentEditViewModel tournamentForm)
        {
            var tournament = await repository.All<Tournament>()
                .Where(t => t.Id == tournamentForm.Id)
                .FirstOrDefaultAsync();

            tournament.Name = tournamentForm.Name;
            tournament.Description = tournamentForm.Description;
            tournament.StartDate = tournamentForm.StartDate;
            tournament.EndDate = tournamentForm.EndDate;
            tournament.HostClubId = tournament.HostClubId;
            tournament.TournamentBalls = tournament.TournamentBalls;
            tournament.Fee = tournamentForm.Fee;
            tournament.Capacity = tournamentForm.Capacity;
            tournament.ImageUrl = tournamentForm.ImageUrl;

            await repository.SaveChangesAsync();

            return tournament.Id;

        }

        public async Task<TournamentDeleteViewModel> DeleteTournamentAsync(int tournamentId)
        {
            var currentTournament = await repository.GetByIdAsync<Tournament>(tournamentId);

            var deleteForm = new TournamentDeleteViewModel()
            {
                Id = currentTournament.Id,
                Name = currentTournament.Name,
                HostClubId = currentTournament.HostClubId,
                ImageUrl = currentTournament.ImageUrl

            };

            return deleteForm;
        }

        public async Task<int> DeleteTournamentConfirmedAsync(int tournamentId)
        {
            var currentTournament = await repository.GetByIdAsync<Tournament>(tournamentId);

            var playerTournaments = await repository.All<PlayerTournament>()
                .Where(pt => pt.TournamentId == tournamentId)
                .ToListAsync();

            if (playerTournaments != null && playerTournaments.Any())
            {
                await repository.RemoveRangeAsync(playerTournaments);
            }

            await repository.RemoveAsync<Tournament>(currentTournament);
            await repository.SaveChangesAsync();

            return currentTournament.Id;
        }

        public async Task<bool> MatchExistsInTournamentAsync(int matchId, int tournamentId)
        {
            return await repository.AllAsReadOnly<TournamentMatch>()
                .AnyAsync(tm => tm.MatchId == matchId && tm.TournamentId == tournamentId);
        }

        public async Task<TournamentMatch> AddMatchToTournamentAsync(int matchId, int tournamentId)
        {
            var tournamentMatch = await repository.All<TournamentMatch>()
                .Where(tm => tm.MatchId == matchId && tm.TournamentId == tournamentId)
                .FirstOrDefaultAsync();
            if (tournamentMatch == null)
            {
                tournamentMatch = new TournamentMatch()
                {
                    MatchId = matchId,
                    TournamentId = tournamentId
                };

                await repository.AddAsync(tournamentMatch);
                await repository.SaveChangesAsync();
            }

            return tournamentMatch;
        }

        public async Task<TournamentMatchDeleteViewModel> RemoveMatchFromTournamentAsync(int matchId, int tournamentId)
        {
            var match = await repository.GetByIdAsync<Match>(matchId);
            var tournament = await repository.GetByIdAsync<Tournament>(tournamentId);

            var deleteForm = new TournamentMatchDeleteViewModel()
            {
                MatchId = match.Id,
                TournamentId = tournament.Id,
                MatchRound = match.MatchRound,
                TournamentName = tournament.Name
            };

            return deleteForm;
        }

        public async Task RemoveMatchFromTournamentConfirmedAsync(int matchId, int tournamentId)
        {
            var matchInTheCurrentTournament = await repository.All<TournamentMatch>()
                .Where(tm => tm.MatchId == matchId && tm.TournamentId == tournamentId)
                .FirstOrDefaultAsync();

            await repository.RemoveAsync<TournamentMatch>(matchInTheCurrentTournament);
            await repository.SaveChangesAsync();
        }

        public async Task<TournamentQueryServiceModel> AllAsync(
            string? searchTerm = null,
            TournamentSorting sorting = TournamentSorting.Newest,
            TournamentStatus status = TournamentStatus.All,
            int currentPage = 1,
            int tournamentsPerPage = 4)
        {
            var tournamentsToShow = repository.AllAsReadOnly<Tournament>();

            if (status == TournamentStatus.Upcoming)
            {
                tournamentsToShow = tournamentsToShow
                    .Where(t => t.StartDate > DateTime.Now);
            }
            else if (status == TournamentStatus.HasEnded)
            {
                tournamentsToShow = tournamentsToShow
                    .Where(t => t.EndDate <= DateTime.Now);
            }

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();

                tournamentsToShow = tournamentsToShow
                    .Where(t => normalizedSearchTerm.Contains(t.Name.ToLower())
                    || normalizedSearchTerm.Contains(t.HostClub.Name.ToLower())
                    || normalizedSearchTerm.Contains(t.StartDate.ToString().ToLower())
                    || normalizedSearchTerm.Contains(t.EndDate.ToString().ToLower())
                    || t.Name.ToLower().Contains(normalizedSearchTerm)
                    || t.HostClub.Name.ToLower().Contains(normalizedSearchTerm)
                    || t.StartDate.ToString().ToLower().Contains(normalizedSearchTerm)
                    || t.EndDate.ToString().ToLower().Contains(normalizedSearchTerm));
            }

            tournamentsToShow = sorting switch
            {
                TournamentSorting.Oldest => tournamentsToShow.OrderBy(t => t.Id),
                _ => tournamentsToShow.OrderByDescending(t => t.Id)
            };


            var tournaments = await tournamentsToShow
                .Skip((currentPage - 1) * tournamentsPerPage)
                .Take(tournamentsPerPage)
                .Select(t => new TournamentServiceModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    HostClub = t.HostClub.Name,
                    Description = t.Description,
                    StartDate = t.StartDate,
                    EndDate = t.EndDate,
                    ImageUrl = t.ImageUrl,
                    Capacity = t.Capacity,
                    Fee = t.Fee,
                    TournamentBalls = t.TournamentBalls,
                })
                .ToListAsync();

            int totalTournaments = await tournamentsToShow.CountAsync();

            return new TournamentQueryServiceModel()
            {
                TotalTournamentsCount = totalTournaments,
                Tournaments = tournaments
            };
        }

        public async Task<bool> TournamentExistsByIdAsync(int tournamentId)
        {
            return await repository.AllAsReadOnly<Tournament>()
                .AnyAsync(t => t.Id == tournamentId);
        }

        public async Task<Tournament> FindTournamentByIdAsync(int tournamentId)
        {
            return await repository.GetByIdAsync<Tournament>(tournamentId);
        }

        public async Task<TournamentDetailsViewModel> DetailsAsync(int tournamentId)
        {
            Tournament? currentTournament = await repository.GetByIdAsync<Tournament>(tournamentId);
            int clubId = currentTournament.TournamentHostId;
            Club? currentClub = await repository.GetByIdAsync<Club>(clubId);

            var currentTournamentDetails = new TournamentDetailsViewModel()
            {
                Id = currentTournament.Id,
                Name = currentTournament.Name,
                Description = currentTournament.Description,
                HostClub = currentClub.Name,
                StartDate = currentTournament.StartDate,
                EndDate = currentTournament.EndDate,
                Capacity = currentTournament.Capacity,
                Fee = currentTournament.Fee,
                ImageUrl = currentTournament.ImageUrl,
                TournamentBalls = currentTournament.TournamentBalls
            };

            return currentTournamentDetails;
        }


        public async Task<MatchQueryServiceModel> GetAllMatchesInTournamentAsync(
             int tournamentId,
             string? matchRound = null,
             string? searchTerm = null,
             MatchStatus status = MatchStatus.All,
             int currentPage = 1,
             int matchesPerPage = 4)
        {
            var matchesToShow = repository.AllAsReadOnly<Match>()
                .Where(m => m.TournamentMatches.Any(tm => tm.TournamentId == tournamentId));

            if (matchRound != null)
            {
                matchesToShow = matchesToShow
                    .Where(m => m.MatchRound.ToString() == matchRound);
            }

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                matchesToShow = matchesToShow
                    .Where(m => normalizedSearchTerm.Contains(m.PlayerOneId.ToString().ToLower())
                    || normalizedSearchTerm.Contains(m.PlayerTwoId.ToString().ToLower())

                    || m.PlayerOneId.ToString().ToLower().Contains(normalizedSearchTerm)
                    || m.PlayerTwoId.ToString().ToLower().Contains(normalizedSearchTerm)
                    );
            }

            if (status == MatchStatus.HasEnded)
            {
                matchesToShow = matchesToShow
                    .Where(m => m.Winner != null);
            }
            else if (status == MatchStatus.InProgress)
            {
                matchesToShow = matchesToShow
                    .Where(m => m.Winner == Infrastructure.Data.Enums.Match.Winner.StillPlaying
                    && m.Sets.Any(s => s.PlayerOneGamesWon > 0 || s.PlayerTwoGamesWon > 0));
            }
            if (status == MatchStatus.Upcoming)
            {
                matchesToShow = matchesToShow
                    .Where(m => m.Sets.Count == 0 && m.Winner != Infrastructure.Data.Enums.Match.Winner.StillPlaying);
            }

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

        public async Task<PlayerQueryServiceModel> GetAllPlayersInTournamentAsync(
            int tournamentId,
            string? searchTerm = null,
            PlayerSorting sorting = PlayerSorting.All,
            int currentPage = 1,
            int playersPerPage = 4)
        {
            var playersToShow = repository.AllAsReadOnly<Player>()
                .Where(p => p.PlayerTournaments.Any(pt => pt.TournamentId == tournamentId));

            var playersUserIds = await playersToShow.Select(p => p.UserId).ToListAsync();
            var playersKVP = new Dictionary<string, string>();
            foreach (var userId in playersUserIds)
            {
                string currentPlayerFullName = await userService.UserFullNameAsync(userId);
                playersKVP.Add(userId, currentPlayerFullName);
            }

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();

                foreach (var player in playersKVP)
                {
                    if (normalizedSearchTerm.Contains(player.Value.ToLower())
                        || player.Value.ToLower().Contains(normalizedSearchTerm))
                    {
                        playersToShow = playersToShow
                            .Where(p => p.UserId == player.Key);
                    }
                }

            }

            playersToShow = sorting switch
            {
                PlayerSorting.WinsAscending => playersToShow.OrderBy(p => p.Wins).ThenBy(p => p.Losses),
                PlayerSorting.LossesAscending => playersToShow.OrderBy(p => p.Losses).ThenBy(p => p.Wins),
                _ => playersToShow.OrderByDescending(p => p.Id)
            };

            var players = await playersToShow
                .Skip((currentPage - 1) * playersPerPage)
                .Take(playersPerPage)
                .ProjectToPlayerServiceModel()
                .ToListAsync();

            int totalPlayers = await playersToShow.CountAsync();

            return new PlayerQueryServiceModel()
            {
                Players = players,
                TotalPlayersCount = totalPlayers
            };
        }

        public async Task<IEnumerable<TournamentIndexViewModel>> LastThreeTournamentsAsync()
        {
            return await repository
                 .AllAsReadOnly<Tournament>()
                 .OrderByDescending(t => t.StartDate)
                 .Select(tvm => new TournamentIndexViewModel()
                 {
                     Id = tvm.Id,
                     Name = tvm.Name,
                     ImageUrl = tvm.ImageUrl,
                     HostClub = tvm.HostClub.Name
                 })
                 .Take(3)
                 .ToListAsync();
        }

        public async Task<TournamentQueryServiceModel> AllTournamentsByPlayerIdAsync(
            int playerId,
            string? searchTerm = null,
            TournamentSorting sorting = TournamentSorting.Newest,
            TournamentStatus tournamentStatus = TournamentStatus.All,
            int currentPage = 1,
            int tournamentsPerPage = 4)
        {

            var tournamentsToShow = repository.AllAsReadOnly<Tournament>()
                .Where(t => t.PlayerTournaments.Any(pt => pt.PlayerId == playerId))
                .AsNoTracking();

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                tournamentsToShow = tournamentsToShow
                    .Where(t => normalizedSearchTerm.Contains(t.Name.ToLower())
                    || normalizedSearchTerm.Contains(t.HostClub.Name.ToLower())
                    || t.Name.ToLower().Contains(normalizedSearchTerm)
                    || t.HostClub.Name.ToLower().Contains(normalizedSearchTerm));
            }

            if (tournamentStatus == TournamentStatus.Upcoming)
            {
                tournamentsToShow = tournamentsToShow
                    .Where(t => t.StartDate > DateTime.Now);
            }
            else if (tournamentStatus == TournamentStatus.HasEnded)
            {
                tournamentsToShow = tournamentsToShow
                    .Where(t => t.EndDate <= DateTime.Now);
            }

            tournamentsToShow = sorting switch
            {
                TournamentSorting.Oldest => tournamentsToShow.OrderBy(t => t.StartDate),
                TournamentSorting.Newest => tournamentsToShow.OrderByDescending(t => t.StartDate),
                _ => tournamentsToShow.OrderByDescending(t => t.Id)
            };

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

        public async Task<bool> PlayerExistsInTournamentAsync(int playerId, int tournamentId)
        {
            return await repository.AllAsReadOnly<PlayerTournament>()
                .AnyAsync(pt => pt.PlayerId == playerId && pt.TournamentId == tournamentId);
        }
    }
}
