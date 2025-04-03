using Microsoft.Extensions.Logging;
using RGBMAUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RGBMAUI.Api;

public class ColorPaletteApi(IHttpClientFactory httpClientFactory, ILogger<ColorPaletteApi> logger) : IColorPaletteApi
{
    public async Task<IReadOnlyCollection<ColorPaletteDto>> GetColorPalettesAsync(CancellationToken c = default)
    {
        using HttpClient client = httpClientFactory.CreateClient("color-api");
        using HttpResponseMessage response = await client.GetAsync("api/palettes", c);

        string content = await response.Content.ReadAsStringAsync(c);

        if (string.IsNullOrWhiteSpace(content) || content == "[]")
        {
            return new List<ColorPaletteDto>(); // Return empty list for empty content
        }

        var result = JsonSerializer.Deserialize<ColorPalettesDto>(
            content,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );

        return result?.Items ?? new List<ColorPaletteDto>();
    }
}
