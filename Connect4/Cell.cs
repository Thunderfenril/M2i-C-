using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    public partial class Cell : ObservableObject
    {
        public int Row { get; set; }
        public int Column { get; set; }

        [ObservableProperty]
        public string content;

        [ObservableProperty]
        private Color color;

        public Cell(int row, int column, string content)
        {
            this.Row = row;
            this.Column = column;
            this.Content = content;
            Color = Colors.Violet;
        }
    }
}
