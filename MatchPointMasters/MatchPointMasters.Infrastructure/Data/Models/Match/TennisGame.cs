namespace MatchPointMasters.Infrastructure.Data.Models.Match
{
    using MatchPointMasters.Infrastructure.Data.Models;
    using MatchPointMasters.Infrastructure.Data.Models.Player;

    public class TennisGame
    {
        private int player1Points;
        private int player2Points;
        private Player winner;

        public TennisGame()
        {
            player1Points = 0;
            player2Points = 0;
            winner = null;
        }

        public void StartGame()
        {
            player1Points = 0;
            player2Points = 0;
        }

        public void RecordPoint(Player player)
        {
            if (winner != null)
            {
                throw new InvalidOperationException("Game is already finished.");
            }

            if (player == "Player 1")
            {
                player1Points++;
            }
            else if (player == "Player 2")
            {
                player2Points++;
            }

            if (IsFinished())
            {
                winner = player;
            }
        }

        public bool IsFinished()
        {
            return Math.Abs(player1Points - player2Points) >= 2 && Math.Max(player1Points, player2Points) >= 4;
        }
    }
}
