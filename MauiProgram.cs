using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Mindscape.Raygun4Maui;

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
                    services.AddRaygun4Maui(options =>
                    {
                        options.ApiKey = "YOUR_API_KEY_HERE";
                        options.SendDefaultTags = true;
                        options.SendDefaultCustomData = true;
                        options.MinLogLevel = LogLevel.Warning;
                        options.MaxLogLevel = LogLevel.Error;
                    });
                });
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}