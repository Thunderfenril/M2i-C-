using FluentAssertions;
using Puissance4.Board;

namespace Puissance4UniT
{
    public class UnitTest1
    {
        [Fact]
        public void Initialisation_Success()
        {
            //Agence

            //Act
            Board board = new Board();

            //Assert
            board.Should().NotBeNull();
        }
    }
}
