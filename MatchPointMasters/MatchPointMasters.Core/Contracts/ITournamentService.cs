namespace MatchPointMasters.Core.Contracts
{
    using MatchPointMasters.Core.Models.Tournament;

    public interface ITournamentService
    {
        Task<ICollection<TournamentServiceModel>> GetAllTournaments();
        Task<TournamentServiceModel> GetTournamentByID(int id);
        Task<TournamentServiceModel> GetAllPlayersInTournament(int tourId);
        Task<TournamentServiceModel> GetAllMatchesInTournament(int tourId);
    }
}