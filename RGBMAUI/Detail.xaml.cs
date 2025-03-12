
using CommunityToolkit.Mvvm.ComponentModel;

namespace RGBMAUI;

public partial class Detail : ContentPage
{
	//public Detail()
	//{
	//	InitializeComponent();
	//}

	public Detail(string text, int valueRed, int valueGreen, int valueBlue)
	{
		InitializeComponent();
		var viewModel = new DetailVM
		(
			text,
			valueRed.ToString(),
			valueGreen.ToString(),
            valueBlue.ToString()

        );
        BindingContext = viewModel;
		System.Diagnostics.Debug.WriteLine("(" + valueRed + ", " + valueGreen + ", " + valueBlue + ")");
	}

}