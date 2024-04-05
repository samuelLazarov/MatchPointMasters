namespace MatchPointMasters.Core.Contracts
{
    using MatchPointMasters.Core.Models;

    public interface ITournamentService
    {
        Task<ICollection<TournamentServiceModel>> GetAllTournaments();
        Task<TournamentServiceModel> GetTournamentByID(string id);
        Task<TournamentServiceModel> GetAllPlayersInTournament(string tourId);
        Task<TournamentServiceModel> GetAllMatchesInTournament(string tourId);
    }
}