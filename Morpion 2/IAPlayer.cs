using CSharpFunctionalExtensions;

namespace Morpion_2
{
    internal class IAPlayer : IPlayer
    {
        public char icon { get; init; }

        public IAPlayer(char icon)
        {
            this.icon = icon;
        }

        public Result<PlayerMoves> GetNextMove()
        {
            Random randomR = new Random();
            
            return Result.Success(new PlayerMoves(randomR.Next(1, 4), randomR.Next(1, 4)));
        }
    }
}