using FluentAssertions;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Boards;
using TicTacToe.Display;
using TicTacToe.Players;

namespace TestTicTacToe
{
    public class Win
    {
        [Fact]
        public void winRowSuccess()
        {
            //Arrange
            Board board = new Board(new DebugDisplay());

            IPlayer player = new HumanPlayer('X');

            board.PlayMoveOnBoard(new PlayerMove(1, 1), 'X');
            board.PlayMoveOnBoard(new PlayerMove(1, 2), 'X');

            board.PlayMoveOnBoard(new PlayerMove(1, 3), 'X');

            //Act
            Maybe<string> resultFinal = board.IsGameOver(player);


            //Assert
            resultFinal.HasValue.Should().BeTrue();
            resultFinal.ToString().Should().Be("Player X has won the game !!!!");
        }

        [Fact]
        public void testInTheMiddleOfTheGame()
        {
            //Arrange
            Board board = new Board(new DebugDisplay());

            IPlayer player = new HumanPlayer('X');

            board.PlayMoveOnBoard(new PlayerMove(1, 1), 'X');
            board.PlayMoveOnBoard(new PlayerMove(1, 2), 'X');

            //Act
            Maybe<string> resultInTheMiddleOfTheGame = board.IsGameOver(player);

            //Assert
            resultInTheMiddleOfTheGame.HasNoValue.Should().BeTrue();
        }

        [Fact]
        public void winRowFail()
        {
            //Arrange
            Board board = new Board(new DebugDisplay());

            IPlayer player = new HumanPlayer('X');

            board.PlayMoveOnBoard(new PlayerMove(1, 1), 'X');
            board.PlayMoveOnBoard(new PlayerMove(2, 1), 'X');

            board.PlayMoveOnBoard(new PlayerMove(3, 2), 'X');

            //Act
            Maybe<string> resultFinal = board.IsGameOver(player);


            //Assert
            resultFinal.HasNoValue.Should().BeTrue();
        }

        [Fact]
        public void draw()
        {
            //Arrange
            Board board = new Board(new DebugDisplay());

            IPlayer player = new HumanPlayer('X');

            board.PlayMoveOnBoard(new PlayerMove(1, 1), 'X');
            board.PlayMoveOnBoard(new PlayerMove(2, 1), 'X');

            board.PlayMoveOnBoard(new PlayerMove(3, 2), 'X');

            board.PlayMoveOnBoard(new PlayerMove(1, 2), 'O');
            board.PlayMoveOnBoard(new PlayerMove(2, 2), 'O');

            board.PlayMoveOnBoard(new PlayerMove(3, 1), 'O');

            board.PlayMoveOnBoard(new PlayerMove(1, 3), 'X');
            board.PlayMoveOnBoard(new PlayerMove(2, 3), 'O');

            board.PlayMoveOnBoard(new PlayerMove(3, 3), 'X');

            //Act
            Maybe<string> resultFinal = board.IsGameOver(player);


            //Assert
            resultFinal.ToString().Should().Be("it's a draw!");
        }
    }

    
}
