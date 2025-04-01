using System.Text.Json;
using ColorsAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace ColorsAPI.Controllers;

[ApiController]
[Route("api/palettes")]
[Consumes("application/json")]
[Produces("application/json")]
public class ColorPalettesController : ControllerBase
{
    public ColorPalettesController()
    {

    }

    [HttpGet]
    public async Task<ActionResult<CollectionResponse<ColorPaletteDto>>> GetColorPalette()
    {
        await Task.CompletedTask;

        var randomPalettes = new CollectionResponse<ColorPaletteDto>
        {
            Items = new List<ColorPaletteDto>
            {
                ColorPaletteDto.RandomPalette(),
                ColorPaletteDto.RandomPalette(),
                ColorPaletteDto.RandomPalette(),
                ColorPaletteDto.RandomPalette(),
                ColorPaletteDto.RandomPalette(),
                ColorPaletteDto.RandomPalette(),
                ColorPaletteDto.RandomPalette()
            }
        };


        return Ok(randomPalettes);
    }
}
