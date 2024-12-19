using Xunit;
using TicTacToe;
using FluentAssertions;

namespace TestTicTacToe
{
    public class RandomPlayer_Default_TestMove
    {
        [Fact]
        public void GetNextMove_Default_TestMove_Success()
        {
            char playerIcon = 'X';
            RandomPlayer randomPlayer = new RandomPlayer(playerIcon);

            var test = randomPlayer.GetNextMove();

            Assert.InRange(test.Value.Row,
                           1,
                           3);

            Assert.InRange(test.Value.Column,
                           1,
                           3);

            test.Value.Row.
                Should().
                BeInRange(1, 3);

            test.Value.Column.
                Should().
                BeInRange(1, 3);
        }
    }
}