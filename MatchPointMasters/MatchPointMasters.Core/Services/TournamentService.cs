namespace MatchPointMasters.Core.Services
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Core.Models.Tournament;
    using MatchPointMasters.Infrastructure.Data.Common;

    public class TournamentService : ITournamentService
    {

        private readonly IRepository repository;


        public TournamentService(IRepository _repository)
        {
            repository = _repository;
        }

        public Task<TournamentServiceModel> GetAllMatchesInTournament(int tourId)
        {
            throw new NotImplementedException();
        }

        public Task<TournamentServiceModel> GetAllPlayersInTournament(int tourId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TournamentServiceModel>> GetAllTournaments()
        {
            throw new NotImplementedException();
        }

        public Task<TournamentServiceModel> GetTournamentByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
