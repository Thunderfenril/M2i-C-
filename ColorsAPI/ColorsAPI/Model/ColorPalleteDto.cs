using ColorsAPI.Entity;

namespace ColorsAPI.Model;

public class ColorPalleteDto
{
    public Guid? Id { get; set; }
    public required DateTimeOffset UpdatedAt { get; set; }
    public required List<ColorEntity> Colors { get; set; }
    public bool? IsArchived { get; internal set; }
}
