using ColorsAPI.Model;

namespace ColorsAPI.Entity;

public class ColorEntity
{
    public Guid Id { get; set; }
    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }

    public ColorType Type { get; set; }

}
