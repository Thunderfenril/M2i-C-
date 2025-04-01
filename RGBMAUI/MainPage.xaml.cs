using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RGBMAUI
{
    public partial class MainPage : ContentPage
    {
        private readonly IColorsRepository repository;

        public ObservableCollection<NamedColor> NamedColors { get; private set; } = new ObservableCollection<NamedColor>();
        public ICommand DeleteCommand { get; private set; }
        public ICommand AddCommand { get; private set; }

        public MainPage(IColorsRepository repository)
        {
            InitializeComponent();
            DeleteCommand = new Command<NamedColor>(DeleteColor);
            AddCommand = new Command<NamedColor>(AddColor);
            BindingContext = this;
            this.repository = repository;
        }

        private void DeleteColor(NamedColor color)
        {
            NamedColors.Remove(color);
            repository.DeleteColor(color);
        }

        private void AddColor(NamedColor color) {
            Random r = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var name = new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[r.Next(s.Length)]).ToArray());
            var rouge = r.Next(0, 255);
            var vert = r.Next(0, 255);
            var bleu = r.Next(0, 255);
            var test = new NamedColor
            {
                Name = name,
                Red = rouge,
                Green = vert,
                Blue = bleu,
            };
            NamedColors.Add(test);
            repository.AddColor(test);
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

        private async void OnAppearing(object sender, EventArgs e)
        {
            NamedColors.Clear();
            var temp = await repository.GetColors();
            foreach (var item in temp)
            {
                NamedColors.Add(item);
            }
        }
    }

}
