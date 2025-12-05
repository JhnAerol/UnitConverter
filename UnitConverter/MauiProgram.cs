using Microsoft.Extensions.Logging;

namespace UnitConverter
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
                    fonts.AddFont("Gorditas-Regular.ttf", "GorditasRegular");
                    fonts.AddFont("Gorditas-Bold.ttf", "Gorditasbold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
