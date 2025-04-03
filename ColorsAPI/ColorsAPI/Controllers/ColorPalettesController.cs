using System.Text.Json;
using ColorsAPI.Entity;
using ColorsAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ColorsAPI.Controllers;

[ApiController]
[Route("api/palettes")]
[Consumes("application/json")]
[Produces("application/json")]
public class ColorPalettesController(MyDbContext dbContext) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<CollectionResponse<ColorPaletteDto>>> GetColorPalette()
    {
        await Task.CompletedTask;

        //var randomPalettes = new CollectionResponse<ColorPaletteDto>
        //{
        //    Items = new List<ColorPaletteDto>
        //    {
        //        ColorPaletteDto.RandomPalette(5),
        //        ColorPaletteDto.RandomPalette(5),
        //    }
        //};

        var paletteColor = await dbContext.ColorPalettes
            .Include(p => p.Colors)
            .ToListAsync();


        return Ok(paletteColor);
    }

    [HttpPost]
    public async Task<IActionResult> createColorPalette([FromBody] ColorPalleteDto colorPaletteDto)
    {
        var colorPaletteEntity = new ColorPalleteEntity
        {
            Id = Guid.NewGuid(),
            UpdatedAt = colorPaletteDto.UpdatedAt,
            Colors = colorPaletteDto.Colors.Select(c => new ColorEntity
            {
                Id = Guid.NewGuid(),
                Red = c.Red,
                Green = c.Green,
                Blue = c.Blue,
                Type = c.Type
            }).ToList()
        };
        dbContext.ColorPalettes.Add(colorPaletteEntity);
        await dbContext.SaveChangesAsync();
        return CreatedAtAction(nameof(GetColorPalette), new { id = colorPaletteEntity.Id }, colorPaletteEntity);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteColorPalette(Guid Id)
    {
        var palette = await dbContext.ColorPalettes
            .Where(palette => palette.Id == Id)
            .FirstOrDefaultAsync();

        if(palette is null)
        {
            return NotFound();
        }

        palette.IsArchived = true;
        palette.UpdatedAt = DateTimeOffset.UtcNow;

        //dbContext.ColorPalettes.Remove(palette);

        await dbContext.SaveChangesAsync();

        return NoContent();
    }
}
