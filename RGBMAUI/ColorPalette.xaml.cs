using RGBMAUI.Model;
using RGBMAUI.ViewModel;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace RGBMAUI;

public partial class ColorPalette : ContentPage
{
	public ObservableCollection<ColorPaletteVM> ColorApiSource { get; set; } = new ObservableCollection<ColorPaletteVM>();
    public ColorPalettesVM viewmodel;
    public ColorPalette(ColorPalettesVM viewmodel)
	{
		InitializeComponent();
		BindingContext = this;
		this.viewmodel = viewmodel;

    }

    private async void OnAppearing(object sender, EventArgs e)
    {
		ColorApiSource.Clear();
        var result = await viewmodel.RefreshPalettes();
        foreach (var item in result)
        {
			var palette = new ColorPaletteVM();
			foreach (var color in item.Colors)
			{
				var colorVM = new ColorVM(color.Type.ToString(), color.Red, color.Green, color.Blue);
				palette.ListColor.Add(colorVM);
            }
			ColorApiSource.Add(palette);
        }
    }

    /**
     * [
				{
					"Type": 0,
					"Red": 184,
					"Green": 94,
					"Blue": 124
				},
				{
					"Type": 1,
					"Red": 53,
					"Green": 168,
					"Blue": 178
				},
				{
					"Type": 2,
					"Red": 232,
					"Green": 56,
					"Blue": 202
				},
				{
					"Type": 3,
					"Red": 56,
					"Green": 90,
					"Blue": 76
				},
				{
					"Type": 4,
					"Red": 53,
					"Green": 26,
					"Blue": 89
				}
			]
     * */
}