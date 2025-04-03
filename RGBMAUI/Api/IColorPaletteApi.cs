using RGBMAUI.Model;

namespace RGBMAUI.Api
{
    public interface IColorPaletteApi
    {
        public Task<IReadOnlyCollection<ColorPaletteDto>> GetColorPalettesAsync(CancellationToken cancellationToken = default);
    }
}
