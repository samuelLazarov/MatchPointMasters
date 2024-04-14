namespace MatchPointMasters.Core.Services
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Core.Enumerations;
    using MatchPointMasters.Core.Models.Match;
    using MatchPointMasters.Core.Models.Player;
    using MatchPointMasters.Core.Models.Tournament;
    using MatchPointMasters.Infrastructure.Data.Common;
    using MatchPointMasters.Infrastructure.Data.Models.Mappings;
    using MatchPointMasters.Infrastructure.Data.Models.Tournament;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class TournamentService : ITournamentService
    {

        private readonly IRepository repository;


        public TournamentService(IRepository _repository)
        {
            repository = _repository;
        }

        public Task<int> AddTournamentAsync(TournamentAddViewModel tournamentForm)
        {
            throw new NotImplementedException();
        }

        public Task<TournamentEditViewModel> EditTournamentGetAsync(int tournamentId)
        {
            throw new NotImplementedException();
        }

        public Task<int> EditTournamentPostAsync(TournamentEditViewModel tournamentForm)
        {
            throw new NotImplementedException();
        }

        public Task<TournamentDeleteViewModel> DeleteTournamentAsync(int tournamentId)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteTournamentConfirmedAsync(int tournamentId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> MatchExistsInTournamentAsync(int matchId, int tournamentId)
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
                HostClub = currentTournament.HostClub.Name,
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
