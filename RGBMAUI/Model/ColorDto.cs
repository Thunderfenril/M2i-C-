using Color = System.Drawing.Color;

namespace RGBMAUI.Model;

public record ColorDto(ColorType Type, int Red, int Green, int Blue)
{
    public static ColorDto FromColor(ColorType type, Color color)
    {
        return new ColorDto(type, color.R, color.G, color.B);
    }
}

public enum ColorType
{
    Primary,
    Secondary,
    Tertiary,
    Accent,
    Neutral
}