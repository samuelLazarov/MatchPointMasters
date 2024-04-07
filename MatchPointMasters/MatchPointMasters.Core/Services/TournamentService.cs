namespace MatchPointMasters.Core.Services
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Core.Models.Tournament;

    public class TournamentService : ITournamentService
    {
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
