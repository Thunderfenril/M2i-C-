namespace Connect4
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            System.Diagnostics.Debug.WriteLine("Hello");
            var MainPageVM = new MainPageVM();
            BindingContext = MainPageVM;
            InitializeComponent();
        }

        
    }

}
