
using CSharpFunctionalExtensions;

namespace Morpion_2
{
    internal class Game
    {
        public static char PlayerOneIcon = 'O';
        public static char PlayerTwoIcon = 'X';

        private readonly Board board;
        private readonly IPlayer player1;
        private readonly IPlayer player2;

        public IPlayer currentPlayer { get; private set; }

        public Game()
        {
            this.board = new Board();
            this.player1 = new Player(PlayerOneIcon);
            this.player2 = new IAPlayer(PlayerTwoIcon);
        }

        public void Init()
        {
            this.board.Init();
            this.currentPlayer = this.player1;
        }

        public void Play()
        {
            board.DisplayGameBoardAndHeader();

            while (true)
            {
                Result<PlayerMoves> playerMoves = currentPlayer.GetNextMove();
                if (playerMoves.IsFailure)
                {
                    Console.WriteLine(playerMoves.Error);
                    continue;
                }

                bool movePlayedSuccessfully = board.PlayMoveOnBoard(playerMoves.Value, currentPlayer.icon);
                if (movePlayedSuccessfully is false)
                {
                    Console.WriteLine("Invalid move");
                    continue;
                }
                board.DisplayGameBoardAndHeader();

                Maybe<string> gameResult = board.IsGameOver(currentPlayer);
                if (gameResult.HasValue)
                {
                    Console.WriteLine(gameResult.Value);
                    break;
                }

                SwitchPlayer();
            }
        }

        private void SwitchPlayer()
        {
            if (currentPlayer == player1)
                currentPlayer = player2;
            else
                currentPlayer = player1;
        }

    }
}
