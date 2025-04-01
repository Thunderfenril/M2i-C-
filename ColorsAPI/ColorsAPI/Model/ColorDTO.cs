namespace ColorsAPI.Model;

public record ColorDto(ColorType Type, int Red, int Green, int Blue)
{
    public static ColorDto FromColor(ColorType, ColorType color)
}

public enum ColorType
{
    Primary,
    Secondary,
    Tertiary
}
