using Raygun4Maui;
using Microsoft.Extensions.Logging;

namespace MauiTest;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
        RaygunMauiClient.Current.User = "Test@gmail.com";
        RaygunMauiClient.Current.ApplicationVersion = "5.0";
        RaygunMauiClient.Current.Send(new Exception("Test Exception"));

		//You can also send exceptions using loggers 
        //logger = Handler.MauiContext.Services.GetService<ILogger<MainPage>>();
        //logger.LogInformation("mauitests.TestLoggerErrorsSent: {MethodName}", "OnCounterClicked");
        //logger.Log(LogLevel.Error, new Exception("wow"), "Exception caught at {Timestamp}", DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));S

        count++;

		if (count == 1)
			CounterBtn.Text = $"{count} Exception sent";
		else
			CounterBtn.Text = $"{count} Exceptions sent";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

