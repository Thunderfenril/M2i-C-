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

        [Fact]
        public void Initialisation_GridWith42Place() {
            //Agence

            //Act
            Board board = new Board();

            //Assert
            board.grid.Count.Should().Be(42);
        }

        [Fact]
        public void Initialisation_Grid6On7()
        {
            // Agence

            // Act
            Board board = new Board();

            // Assert
            board.grid.
                Where((cell) => cell.Row == 1)
                .Should()
                .NotBeEmpty()
                .And.HaveCount(7);

            board.grid.
                Where((cell) => cell.Column == 1)
                .Should()
                .NotBeEmpty()
                .And.HaveCount(6);
        }

        [Fact]
        public void PlayerMove_ValidMove_ReturnValidMove()
        {
            // Agence
            Board board = new Board();
            // Act
            bool result = board.PlayerMove(1, 'X');

            // Assert
            result.Should().BeTrue();
        }


    }
}
