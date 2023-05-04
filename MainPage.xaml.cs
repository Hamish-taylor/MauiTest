using Microsoft.Extensions.Logging;
using Raygun4Maui;
using Microsoft.Maui.Controls;

namespace mauitests
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        ILogger logger = null;
        public MainPage()
        {
            InitializeComponent();
            RaygunMauiClient.Current.Init("YOUR_APP_API_KEY");
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            //logger = Handler.MauiContext.Services.GetService<ILogger<MainPage>>();
            //logger.LogInformation("mauitests.TestLoggerErrorsSent: {MethodName}", "OnCounterClicked");
            //logger.Log(LogLevel.Error, new Exception("wow"), "Exception caught at {Timestamp}", DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
            RaygunMauiClient.Current.User = "Hamish@raygun.com";
            RaygunMauiClient.Current.ApplicationVersion = "5.0";
            RaygunMauiClient.Current.Send(new Exception("peace"));
            //throw new Exception("this exception should have a stack trace");
            count++;
            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";
            CounterBtn.Text = DeviceInfo.Current.Name;
            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}