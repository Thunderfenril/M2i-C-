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
            Cell cell = GetCell(col);

            cell.updateCell(playerSymbol);

            return true;
        }

        private Cell GetCell(int col)
        {
            Cell desiredCell = grid
                .Where((cell) => cell.Column == col)
                .Where((cellRow) => cellRow.Row == 6)
                .First();

            return desiredCell;
        }
    }
}
