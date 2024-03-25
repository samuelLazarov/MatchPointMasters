
namespace MatchPointMasters.Infrastructure.Data.Models.Match
{
    using MatchPointMasters.Infrastructure.Data.Models.Player;
    public class TennisSet
    {
        private int player1Score;
        private int player2Score;
        private Player winner;
        private List<TennisGame> games;
        private TennisGame currentGame;

        public TennisSet()
        {
            player1Score = 0;
            player2Score = 0;
            winner = null;
            games = new List<TennisGame>();
            currentGame = null;
        }

        public void StartSet()
        {
            currentGame = new TennisGame();
            currentGame.StartGame();
            games.Add(currentGame);
        }

        public void RecordPoint(Player player)
        {
            if (winner != null)
            {
                throw new InvalidOperationException("Set is already finished.");
            }

            if (currentGame == null)
            {
                StartSet();
            }

            currentGame.RecordPoint(player);

            if (currentGame.IsFinished())
            {
                currentGame = new TennisGame();
                currentGame.StartGame();
                games.Add(currentGame);
            }

            if (IsFinished())
            {
                winner = GetWinner();
            }
        }

        public bool IsFinished()
        {
            return player1Score >= 6 || player2Score >= 6 || (player1Score == 5 && player2Score == 5);
        }

        public string GetWinner()
        {
            if (player1Score > player2Score)
            {
                return "Player 1";
            }
            else if (player2Score > player1Score)
            {
                return "Player 2";
            }
            else
            {
                return null;
            }
        }

    }
}
