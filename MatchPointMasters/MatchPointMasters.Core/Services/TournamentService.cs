namespace MatchPointMasters.Core.Services
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Core.Models;

    public class TournamentService : ITournamentService
    {
        public Task<TournamentServiceModel> GetAllMatchesInTournament(string tourId)
        {
            throw new NotImplementedException();
        }

        public Task<TournamentServiceModel> GetAllPlayersInTournament(string tourId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TournamentServiceModel>> GetAllTournaments()
        {
            throw new NotImplementedException();
        }

        public Task<TournamentServiceModel> GetTournamentByID(string id)
        {
            throw new NotImplementedException();
        }
    }
}
