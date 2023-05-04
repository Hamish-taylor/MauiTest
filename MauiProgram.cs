using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Raygun4Maui;

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

        // Add Raygun4Maui module and attach RaygunClient
        builder.Services.AddRaygun();
        builder.Services.Configure<RaygunSettings>(settings =>
        {
            settings.ApiKey = "YOUR_API_KEY_HERE";
        });
        builder.Services.BuildServiceProvider().GetRequiredService<RaygunClient>();

        return builder.Build();
    }
}