using CommunityToolkit.Mvvm.ComponentModel;

namespace RGBMAUI
{
    public partial class DetailVM : ObservableObject
    {

        [ObservableProperty]
        private string text;

        [ObservableProperty]
        private string valueRed;

        [ObservableProperty]
        private string valueGreen;

        [ObservableProperty]
        private string valueBlue;

        public DetailVM(string text, string valueRed, string valueGreen, string valueBlue)
        {
            this.Text = text;
            this.ValueRed = valueRed;
            this.ValueGreen = valueGreen;
            this.ValueBlue = valueBlue;
        }
    }
}
