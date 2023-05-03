using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Mindscape.Raygun4Net.NetCore;
using Mindscape.Raygun4Net;
using Mindscape.Raygun4Net.Messages;

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
            })
            .Logging
                .AddDebug()
                .AddRaygun4Maui(options =>
                {
                    options.ApiKey = "YOUR_APP_API_KEY";
                    options.SendDefaultTags = true;
                    options.SendDefaultCustomData = true;
                    options.MinLogLevel = LogLevel.Warning;
                    options.MaxLogLevel = LogLevel.Error;
                });

        var app = builder.Build();

        RaygunClient.Attach("YOUR_APP_API_KEY");

        app.UnhandledException += (sender, e) =>
        {
            var exception = e.Exception;
            var message = new RaygunMessage(exception);
            RaygunClient.Current.Send(message);
        };

        return app;
    }
}