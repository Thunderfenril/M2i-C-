using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RGBMAUI
{
    public partial class MainPage : ContentPage
    {
        private readonly IColorsRepository repository;

        public ObservableCollection<NamedColor> NamedColors { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand AddCommand { get; private set; }

        public MainPage(IColorsRepository repository)
        {
            InitializeComponent();
            DeleteCommand = new Command<NamedColor>(DeleteColor);
            AddCommand = new Command<NamedColor>(AddColor);
            BindingContext = this;
            this.repository = repository;
            CreateNamedColorCollection();
        }

        private void DeleteColor(NamedColor color)
        {
            NamedColors.Remove(color);
            repository.DeleteColor(color);
        }

        private void AddColor(NamedColor color) {
            var test = new NamedColor
            {
                Name = "Gray",
                Red = 173,
                Green = 173,
                Blue = 173
            };
            NamedColors.Add(test);
            repository.AddColor(test);
        }

        void CreateNamedColorCollection()
        {
            NamedColors = new ObservableCollection<NamedColor>();
            var temp = repository.GetColors();
            foreach (var item in temp)
            {
                var tempItem = new NamedColor(item.Name, item.Red, item.Green, item.Blue);
                NamedColors.Add(tempItem);
            }
        }

        public async void GetRGB(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            var valueRed = NamedColors.First(item => item.Name == button.Text).Red;
            var valueGreen = NamedColors.First(item => item.Name == button.Text).Green;
            var valueBlue = NamedColors.First(item => item.Name == button.Text).Blue;

            System.Diagnostics.Debug.WriteLine("(" + valueRed + ", " + valueGreen + ", " + valueBlue + ")");
            // RGB.Text = "(" + valueRed + ", " + valueGreen + ", " + valueBlue + ")";
            await Navigation.PushAsync(new Detail(button.Text, valueRed, valueGreen, valueBlue));
        }

        private void OnAppearing(object sender, EventArgs e)
        {
            var temp = repository.GetColors();
            foreach (var item in temp)
            {
                NamedColors.Add(item);
            }
        }
    }

}
