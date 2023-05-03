using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Mindscape.Raygun4Net;

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

        // Add Raygun Middleware
        builder.UseRaygun();

        // Add RaygunClient instance
        var raygunApiKey = configuration["Raygun:ApiKey"];
        var raygunClient = new RaygunClient(raygunApiKey);

        return builder.Build();
    }
}