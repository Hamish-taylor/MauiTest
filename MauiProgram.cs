using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Mindscape.Raygun4Net;

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
                });

            // Add Raygun Crash Reporting
            builder.Logging.AddRaygun(options =>
            {
                options.ApiKey = "YOUR_APP_API_KEY";
            });

            return builder.Build();
        }
    }
}