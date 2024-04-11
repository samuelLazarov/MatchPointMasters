namespace MatchPointMasters.Core.Contracts
{
    public interface ISetModel
    {
        public string PlayerOneGamesWon { get; set; }
        public string PlayerTwoGamesWon { get; set; }
        public bool HasTieBreak {  get; set; }
    }
}
