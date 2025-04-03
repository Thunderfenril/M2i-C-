using System.Drawing;
using System.Text.Json.Serialization;

namespace ColorsAPI.Model;

public record ColorDto(ColorType Type, int Red, int Green, int Blue)
{
    public static ColorDto FromColor(ColorType type, Color color)
    {
        return new ColorDto(type, color.R, color.G, color.B);
    }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ColorType
{
    Primary,
    Secondary,
    Tertiary,
    Accent,
    Neutral
}
