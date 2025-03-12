using Connect4;
using Xunit;

namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void InitializeCells_ShouldCreate42Cell()
        {
            //Arrange
            var viewModel = new MainPageVM();
            
            // Act
            var cells = viewModel.Cells;

            // Assert
            Assert.Equal(42, cells.Count);
        }

        [Fact]
        public void InitializeCells_ShouldCreate42Cell6Row7sColumnsVioletColor()
        {
            //Arrange
            var viewModel = new MainPageVM();

            // Act
            var cells = viewModel.Cells;

            // Assert
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    var cell = cells[row * 7 + col];
                    Assert.Equal(row, cell.Row);
                    Assert.Equal(col, cell.Column);
                    Assert.Equal(Colors.Violet, cell.Color);
                }
            }
        }

        [Fact]
        public void CellClicked_ShouldChangePlayerAfterEachMove()
        {
            // Arrange
            var viewModel = new MainPageVM();
            var firstCell = viewModel.Cells[0];

            // Act
            viewModel.CellClickedCommand.Execute(firstCell);
            var firstPlayer = viewModel.CurrentPlayer;

            viewModel.CellClickedCommand.Execute(viewModel.Cells[1]);
            var secondPlayer = viewModel.CurrentPlayer;

            // Assert
            Assert.NotEqual(firstPlayer, secondPlayer);
        }

        [Fact]
        public void CheckForWin_ShouldDetectHorizontalWin()
        {
            // Arrange
            var viewModel = new MainPageVM();
            for (int col = 0; col < 4; col++)
            {
                viewModel.Cells[0 * 7 + col].Color = Colors.Red;
            }

            // Act
            var result = viewModel.CheckForWin(0, 3, Colors.Red);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckForWin_ShouldDetectVerticalWin()
        {
            // Arrange
            var viewModel = new MainPageVM();
            for (int row = 0; row < 4; row++)
            {
                viewModel.Cells[row * 7 + 0].Color = Colors.Red;
            }

            // Act
            var result = viewModel.CheckForWin(3, 0, Colors.Red);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckForWin_ShouldDetectDiagonalDownRightWin()
        {
            // Arrange
            var viewModel = new MainPageVM();
            for (int i = 0; i < 4; i++)
            {
                viewModel.Cells[i * 7 + i].Color = Colors.Red;
            }

            // Act
            var result = viewModel.CheckForWin(3, 3, Colors.Red);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsBoardFull_ShouldDetectDraw()
        {
            // Arrange
            var viewModel = new MainPageVM();
            foreach (var cell in viewModel.Cells)
            {
                cell.Color = Colors.Red; // Fill all cells
            }

            // Act
            var result = viewModel.IsBoardFull();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CellClicked_ShouldNotAllowMovesAfterWin()
        {
            // Arrange
            var viewModel = new MainPageVM();
            for (int col = 0; col < 4; col++)
            {
                viewModel.Cells[0 * 7 + col].Color = Colors.Red;
            }
            viewModel.CheckForWin(0, 3, Colors.Red); // Simulate a win

            var firstCell = viewModel.Cells[4 * 7 + 0]; // Any cell

            // Act
            viewModel.CellClickedCommand.Execute(firstCell);
            var cellColorAfterClick = firstCell.Color;

            // Assert
            Assert.Equal(Colors.Violet, cellColorAfterClick); // Color should not change
        }

        [Fact]
        public void CellClicked_ShouldNotAllowMovesAfterDraw()
        {
            // Arrange
            var viewModel = new MainPageVM();
            foreach (var cell in viewModel.Cells)
            {
                cell.Color = Colors.Red; // Fill all cells
            }
            viewModel.IsBoardFull(); // Simulate a draw

            var firstCell = viewModel.Cells[4 * 7 + 0]; // Any cell

            // Act
            viewModel.CellClickedCommand.Execute(firstCell);
            var cellColorAfterClick = firstCell.Color;

            // Assert
            Assert.Equal(Colors.Red, cellColorAfterClick); // Color should not change
        }

    }
}
