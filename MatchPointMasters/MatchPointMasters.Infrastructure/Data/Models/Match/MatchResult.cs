
namespace MatchPointMasters.Infrastructure.Data.Models.Match
{
    using MatchPointMasters.Infrastructure.Data.Models.Player;
    public class MatchResult
    {
        private Player firstPlayer;
        private Player secondPlayer;
        private List<TennisSet> sets;
        private TennisSet currentSet;
        private Player winner;

        public MatchResult(Player _firstPlayer, Player _secondPlayer)
        {
            firstPlayer = _firstPlayer;
            secondPlayer = _secondPlayer;
            sets = new List<TennisSet>();
            currentSet = null;
            winner = null;
        }

        public void StartMatch()
        {
            currentSet = new TennisSet();
            currentSet.StartSet();
            sets.Add(currentSet);
        }

        public void RecordPoint(Player player)
        {
            if (winner != null)
            {
                throw new InvalidOperationException("Match is already finished.");
            }

            if (currentSet == null)
            {
                StartMatch();
            }

            currentSet.RecordPoint(player);

            if (currentSet.IsFinished())
            {
                currentSet = new TennisSet();
                currentSet.StartSet();
                sets.Add(currentSet);
            }

            if (IsMatchFinished())
            {
                winner = player;
            }
        }

        public bool IsMatchFinished()
        {
            if (sets.Count == 3)
            {
                return true;
            }
            else if (sets.Count == 2)
            {
                if (sets[0].GetWinner() == firstPlayer || sets[0].GetWinner() == secondPlayer)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
