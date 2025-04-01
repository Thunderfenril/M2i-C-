namespace ColorsAPI.Model;

public record ColorPaletteDto(List<ColorDto> Colors)
{
    public static ColorPaletteDto RandomPalette()
    {
        var random = new Random();
        var colors = new List<ColorDto>();

        colors.Add(new ColorDto(
            (ColorType)random.Next(0, 5), 
            random.Next(0, 256), 
            random.Next(0, 256), 
            random.Next(0, 256)));

        return new ColorPaletteDto(colors);
    }
}
