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
                })
                .AddRaygun4Maui("paste_your_api_key_here");
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}