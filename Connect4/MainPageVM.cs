using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    class MainPageVM : ObservableObject
    {
        public ObservableCollection<Cell> Cells { get; }

        public MainPageVM()
        {
            Cells = new ObservableCollection<Cell>();
            InitializeCells();
        }

        private void InitializeCells()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Cells.Add(new Cell { Row = i, Column = j });
                }
            }
        }
    }
}
