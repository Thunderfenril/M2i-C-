using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Connect4
{
    public class MainPageVM : ObservableObject
    {
        public ObservableCollection<Cell> Cells { get; }
        private string currentPlayer;
        private bool isGameOver;
        private string gameOverMessage;

        public ICommand CellClickedCommand { get; set; }

        public MainPageVM()
        {
            Cells = new ObservableCollection<Cell>();
            CellClickedCommand = new Command<Cell>(CellClicked);
            InitializeCells();
            currentPlayer = "Player 1";
            isGameOver = false;
            gameOverMessage = "";
        }
        public string CurrentPlayer
        {
            get => currentPlayer;
            set => SetProperty(ref currentPlayer, value);
        }

        public string GameOverMessage
        {
            get => gameOverMessage;
            set => SetProperty(ref gameOverMessage, value);
        }

        private void InitializeCells()
        {
            System.Diagnostics.Debug.WriteLine("Hello world");
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    var temp = new Cell(row, col, $"{row},{col}");
                    Cells.Add(temp);
                }
            }
        }

        private void CellClicked(Cell cell)
        {

            if (isGameOver)
                return;

            var columnCells = Cells.Where(c => c.Column == cell.Column).OrderByDescending(c => c.Row);
            var lowestAvailableCell = columnCells.FirstOrDefault(c => c.Color == Colors.Violet);

            if (lowestAvailableCell == null)
                return;

            lowestAvailableCell.Color = CurrentPlayer == "Player 1" ? Colors.Red : Colors.Yellow;

            if (CheckForWin(lowestAvailableCell.Row, lowestAvailableCell.Column, lowestAvailableCell.Color))
            {
                isGameOver = true;
                GameOverMessage = $"{CurrentPlayer} wins!";
                return;
            }

            if(IsBoardFull())
            {
                isGameOver = true;
                GameOverMessage = "Draw !";
                return;

            }

            CurrentPlayer = CurrentPlayer == "Player 1" ? "Player 2" : "Player 1";
        }

        public bool CheckForWin(int row, int col, Color color)
        {
            return CheckDirection(row, col, color, 1, 0) ||
                   CheckDirection(row, col, color, 0, 1) ||
                   CheckDirection(row, col, color, 1, 1) ||
                   CheckDirection(row, col, color, 1, -1);
        }

        private bool CheckDirection(int row, int col, Color color, int rowDir, int colDir)
        {
            int count = 1;

            count += CountCells(row, col, color, rowDir, colDir);

            count += CountCells(row, col, color, -rowDir, -colDir);

            return count >= 4;
        }

        private int CountCells(int row, int col, Color color, int rowDir, int colDir)
        {
            int count = 0;
            int newRow = row + rowDir;
            int newCol = col + colDir;

            while (IsValidCell(newRow, newCol) && Cells[newRow * 7 + newCol].Color == color)
            {
                count++;
                newRow += rowDir;
                newCol += colDir;
            }

            return count;
        }

        private bool IsValidCell(int row, int col)
        {
            return row >= 0 && row < 6 && col >= 0 && col < 7;
        }

        public bool IsBoardFull()
        {
            foreach (var cell in Cells)
            {
                if (cell.Color == Colors.Violet)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
