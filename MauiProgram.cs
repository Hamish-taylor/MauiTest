Here is the modified version of the user code with Raygun Crash Reporting setup:

``` csharp
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
            .Logging
                .AddDebug()
                .AddRaygun4Maui("paste_your_api_key_here");

        return builder.Build();
    }
}
```

Make sure to replace `"paste_your_api_key_here"` with your actual Raygun API key. Also, ensure that the `Raygun4Maui` NuGet package is installed in your project.