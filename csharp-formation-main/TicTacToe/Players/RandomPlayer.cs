using CSharpFunctionalExtensions;
using TicTacToe.Boards;
using TicTacToe.Players;

namespace TicTacToe;

public class RandomPlayer : Player
{
    public override char Icon { get; }

    public RandomPlayer(char icon)
    {
        this.Icon = icon;
    }

    public async override Task<Result<PlayerMove>> GetNextMove()
    {
        await Task.Delay(System.Random.Shared.Next(1, 4) * 1000);
        return await Task.Run(getRandom);
    }

    public Result<PlayerMove> getRandom()
    {
        return PlayerMove.Random;
    }
}