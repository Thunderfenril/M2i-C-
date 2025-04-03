using ColorsAPI.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColorsAPI.Configurations;

public class ColorPaletteEntityConfiguration : IEntityTypeConfiguration<ColorPalleteEntity>
{
    public void Configure(EntityTypeBuilder<ColorPalleteEntity> builder)
    {
        builder
            .HasKey(p => p.Id);

        builder.HasMany(p => p.Colors)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

    }
}
