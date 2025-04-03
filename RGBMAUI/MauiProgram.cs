using Microsoft.Extensions.Logging;
using RGBMAUI.Services;
using RGBMAUI.ViewModel;

namespace RGBMAUI
{
    public static class MauiProgram
    {

        
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<Database>();
            builder.Services.AddSingleton<IColorsRepository, ColorsRepository>();
            //builder.Services.AddSingleton<IColorsRepository, FakeColorRepository>();

            builder.Services.ConfigureColorsApi();
            builder.Services.AddTransient<ColorPalettesVM>();

#if DEBUG
            builder.Logging.AddDebug();

#endif

            return builder.Build();
        }
    }
}
