using ColorsAPI.Entity;
using ColorsAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ColorsAPI;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }
    public DbSet<ColorEntity> Colors { get; set; }
    public DbSet<ColorPalleteEntity> ColorPalettes { get; set; }
}
