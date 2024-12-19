namespace TicTacToe.Boards;

public record PlayerMove(int Row, int Column)
{
    public static PlayerMove Random
    {
        get
        {
            var row = System.Random.Shared.Next(1, 4);
            var col = System.Random.Shared.Next(1, 4);
            return new PlayerMove(row, col);
        }
    }
}