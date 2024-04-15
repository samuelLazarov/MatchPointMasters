namespace MatchPointMasters.Core.Services
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Core.Enumerations;
    using MatchPointMasters.Core.Models.Match.QueryModels;
    using MatchPointMasters.Core.Models.Roles.QueryModels;
    using MatchPointMasters.Core.Models.Tournament;
    using MatchPointMasters.Core.Models.Tournament.QueryModels;
    using MatchPointMasters.Core.Models.Tournament.ViewModels;
    using MatchPointMasters.Infrastructure.Data.Common;
    using MatchPointMasters.Infrastructure.Data.Models.Mappings;
    using MatchPointMasters.Infrastructure.Data.Models.Tournament;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class TournamentService : ITournamentService
    {

        private readonly IRepository repository;
        private readonly IMatchService matchService;


        public TournamentService(IRepository _repository, IMatchService _matchService)
        {
            repository = _repository;
            matchService = _matchService;
        }

        public async Task<int> AddTournamentAsync(TournamentAddViewModel tournamentForm)
        {
            Tournament tournament = new Tournament()
            {
                Name = tournamentForm.Name,
                Description = tournamentForm.Description,
                StartDate = tournamentForm.StartDate,
                EndDate = tournamentForm.EndDate,
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
            throw new NotImplementedException();
        }

        public async Task<int> DeleteTournamentConfirmedAsync(int tournamentId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> MatchExistsInTournamentAsync(int matchId, int tournamentId)
        {
            throw new NotImplementedException();
        }

        public Task<TournamentMatch> AddMatchToTournamentAsync(int matchId, int tournamentId)
        {
            throw new NotImplementedException();
        }

        public Task<TournamentMatchDeleteViewModel> RemoveMatchFromTournamentAsync(int matchId, int tournamentId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveMatchFromTournamentConfirmedAsync(int matchId, int tournamentId)
        {
            throw new NotImplementedException();
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
                    HostClubId = t.HostClubId,
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

        public async Task<bool> TournamentExistsAsync(int tournamentId)
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

            var currentTournamentDetails = new TournamentDetailsViewModel()
            {
                Id = currentTournament.Id,
                Name = currentTournament.Name,
                Description = currentTournament.Description,
                HostClubId = currentTournament.HostClubId,
                StartDate = currentTournament.StartDate,
                EndDate = currentTournament.EndDate,
                Capacity = currentTournament.Capacity,
                Fee = currentTournament.Fee,
                ImageUrl = currentTournament.ImageUrl,
                TournamentBalls = currentTournament.TournamentBalls

            };

            return currentTournamentDetails;
        }


        public Task<MatchQueryServiceModel> GetAllMatchesInTournamentAsync(int tournamentId)
        {
            throw new NotImplementedException();
        }

        public Task<PlayerQueryServiceModel> GetAllPlayersInTournamentAsync(int tournamentId)
        {
            throw new NotImplementedException();
        }

       

        
    }
}
