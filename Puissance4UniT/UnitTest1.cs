using FluentAssertions;
using Puissance4.Board;

namespace Puissance4UniT
{
    public class UnitTest1
    {
        [Fact]
        public void Initialisation_Success()
        {
            //Arrange

            //Act
            Board board = new Board();

            //Assert
            board.Should().NotBeNull();
        }

        [Fact]
        public void Initialisation_GridWith42Place() {
            //Arrange

            //Act
            Board board = new Board();

            //Assert
            board.grid.Count.Should().Be(42);
        }

        [Fact]
        public void Initialisation_Grid6On7()
        {
            // Arrange

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
            // Arrange
            Board board = new Board();
            // Act
            bool result = board.PlayerMove(1, 'X');

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void PlayerMove_InvalidMove_ReturnInvalidMove()
        {
            // Arrange
            Board board = new Board();

            // Act
            bool result = board.PlayerMove(666, 'X');

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void PlayerMove_ValidMoveTwoTokenSameColumn_ReturnValidMove()
        {
            // Arrange
            Board board = new Board();
            board.PlayerMove(1, 'X');
            board.PlayerMove(1, 'O');

            // Act
            char? player1 = board.GetCellContent(1, 1);
            char? player2 = board.GetCellContent(2, 1);

            // Assert

            player1.Should().Be('X');
            player2.Should().Be('O');
        }

        [Fact]
        public void PlayerMove_InFullColumn_ReturnInvalidMove()
        {
            // Arrange
            Board board = new Board();
            bool result = true;


            for (int i = 1; i < 7; i++)
            {
                char playerSymbol = i % 2 == 0 ? 'X' : 'O';
                board.PlayerMove(1, playerSymbol);
            }

            // Act

            result = board.PlayerMove(1, 'O');

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void GameVictory_EmptyGrid_ReturnFalse()
        {
            // Arrange
            Board board = new Board();

            // Act
            bool result = board.checkVictory();

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void GameVictory_4InColumn_ReturnTrue()
        {
            // Arrange
            Board board = new Board();
            for(int i = 1; i < 5; i++)
            {
                board.PlayerMove(1, 'X');
            }

            // Act
            bool result = board.checkVictory();

            // Assert
            result.Should().BeTrue();
        }

        

    }
}
