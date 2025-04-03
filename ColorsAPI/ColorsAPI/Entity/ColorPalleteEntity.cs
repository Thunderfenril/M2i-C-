namespace ColorsAPI.Entity;

public class ColorPalleteEntity
{
    public Guid Id { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public List<ColorEntity> Colors { get; set; }
    public bool IsArchived { get; internal set; }
}
