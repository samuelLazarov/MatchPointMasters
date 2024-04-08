namespace MatchPointMasters.Core.Contracts
{
    public interface ITournamentHostService
    {
        Task<bool> ExistsByIdAsync (string userId);
        Task<int?> GetTournamentHostIdAsync (string userId);
    }
}
