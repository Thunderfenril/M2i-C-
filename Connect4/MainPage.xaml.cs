namespace Connect4
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            var MainPageVM = new MainPageVM();
            BindingContext = MainPageVM;
            InitializeComponent();
        }

        
    }

}
