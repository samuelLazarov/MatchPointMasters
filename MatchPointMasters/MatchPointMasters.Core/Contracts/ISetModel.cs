namespace MatchPointMasters.Core.Contracts
{
    public interface ISetModel
    {
        public int PlayerOneGamesWon { get; set; }
        public int PlayerTwoGamesWon { get; set; }
        public bool HasTiebreak {  get; set; }
    }
}
