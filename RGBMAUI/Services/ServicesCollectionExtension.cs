
using RGBMAUI.Api;

using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace RGBMAUI.Services
{
    public static class ServicesCollectionExtension
    {
        public static IServiceCollection ConfigureColorsApi(this IServiceCollection services)
        {
            services.AddTransient<IColorPaletteApi, ColorPaletteApi>();
            services.AddHttpClient("color-api", client =>
            {
                client.BaseAddress = new Uri("https://localhost:5001");
            });

            return services;
        }
    }
}
