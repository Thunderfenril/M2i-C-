using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puissance4.Board
{
    
    public class Board
    {
        public List<char> Grid { get; }
        public Board() { 
            Grid = new List<char>();
        }

        public void InitializeGrid()
        {
            for (int i = 0; i < 42; i++)
            {
                Grid.Add('\0');
            }
        }
    }
}
