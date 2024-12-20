using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puissance4.Board
{
    
    public class Board
    {
        public List<Cell> grid { get; }
        public Board() { 
            grid = InitializeGrid();

        }

        private List<Cell> InitializeGrid()
        {
            List<Cell> Grid = new List<Cell>();
            for (int i = 1; i <= 6; i++)
            {
                for(int j = 1; j <= 7; j++)
                {
                    Grid.Add(new Cell(i, j));
                }
            }

            return Grid;
        }

        public bool PlayerMove(int col, char playerSymbol)
        {
            if(col < 1 || col > 7) { 
                return false; 
            }

            Cell? cell = GetCell(col);

            if (cell == null)
            {
                return false;
            }

            cell.updateCell(playerSymbol);

            return true;
        }

        private Cell? GetCell(int col)
        {
            return grid
                .Where((cell) => cell.Column == col)
                .Where((cellRow) => cellRow.Value == null)
                .FirstOrDefault(); ;
        }

        public char? GetCellContent(int row, int col)
        {
            Cell desiredCell = grid
                .Where((cell) => cell.Column == col)
                .Where((cellRow) => cellRow.Row == row)
                .First();

            return desiredCell.Value;
        }

        public bool checkVictory()
        {
            IEnumerable<IGrouping<int, Cell>> cols = grid
            .GroupBy(cell => cell.Column);

            if(cols.Any(
                column =>
                column.Count(cell => cell.Value == 'X') == 4 ||
                column.Count(cell => cell.Value == 'O') == 4
             ))
            {
                return true;
            }

            return false;
        }
    }
}
