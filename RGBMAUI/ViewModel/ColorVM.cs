using CommunityToolkit.Mvvm.ComponentModel;


namespace RGBMAUI.ViewModel
{
    public partial class ColorVM : ObservableObject
    {
        [ObservableProperty]
        private string type;

        [ObservableProperty]
        [NotifyPropertyChangedFor("Color")]
        private int red;

        [ObservableProperty]
        [NotifyPropertyChangedFor("Color")]
        private int green;

        [ObservableProperty]
        [NotifyPropertyChangedFor("Color")]
        private int blue;

        public Color Color => Color.FromRgb(Red, Green, Blue);


        public ColorVM(string type, int r, int g, int b)
        {
            this.Type = type;
            this.Red = r;
            this.Green = g;
            this.Blue = b;
        }
    }
}
