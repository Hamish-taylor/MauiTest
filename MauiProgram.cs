using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Mindscape.Raygun4Maui;

namespace mauitests;

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
                });
#if DEBUG
        builder.Logging.AddDebug();
#endif

        // Add Raygun Crash Reporting
        var raygunSettings = new RaygunMauiSettings("YOUR_RAYGUN_API_KEY");
        builder.UseRaygunCrashReporting(raygunSettings);

        return builder.Build();
    }
}