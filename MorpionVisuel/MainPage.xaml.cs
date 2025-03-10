namespace MorpionVisuel
{
    public partial class MainPage : ContentPage
    {
        int counter = 0;
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            var row = Grid.GetRow(button);
            var column = Grid.GetColumn(button);
            var texte = button.Text;
            System.Diagnostics.Debug.WriteLine("Ligne: " + row +"\nColonne: " + column + "\nTexte :" + texte);


            if (texte == "O" || texte == "X")
            {
                return;
            }
            button.Text = counter % 2 == 0 ? "O" : "X";

            counter++;
        }
    }

}
