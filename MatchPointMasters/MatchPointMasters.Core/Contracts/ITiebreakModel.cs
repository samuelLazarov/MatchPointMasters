namespace MatchPointMasters.Core.Contracts
{
    public interface ITiebreakModel
    {
        public int PlayerOnePoints { get; set; }
        public int PlayerTwoPoints { get; set; }
    }
}
