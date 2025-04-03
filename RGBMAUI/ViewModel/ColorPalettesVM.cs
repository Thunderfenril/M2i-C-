using CommunityToolkit.Mvvm.ComponentModel;
using RGBMAUI.Api;
using RGBMAUI.Model;
using System.Collections.ObjectModel;

namespace RGBMAUI.ViewModel;

public partial class ColorPalettesVM : ObservableObject
{
    private readonly IColorPaletteApi ColorPaletteApi;

    [ObservableProperty]
    private ObservableCollection<ColorPaletteVM> listListColor;

    public ColorPalettesVM(IColorPaletteApi colorPaletteApi)
    {
        ColorPaletteApi = colorPaletteApi;
        RefreshPalettes();
    }

    public async Task<IReadOnlyCollection<ColorPaletteDto>> RefreshPalettes()
    {
        var result = await ColorPaletteApi.GetColorPalettesAsync();
        return result;
    }
}
