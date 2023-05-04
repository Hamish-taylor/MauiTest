using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Mindscape.Raygun4Net.Maui;

namespace mauitests
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<MainPage>()
                .Build();

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .ConfigureServices(services =>
                {
                    services.AddRaygunCrashReporting(configuration.GetSection("RaygunSettings"));
                });
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}