using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBMAUI.ViewModel
{
    public partial class ColorPaletteVM : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<ColorVM> listColor;

        public ColorPaletteVM()
        {
            ListColor = new ObservableCollection<ColorVM>();
        }
    }


}
