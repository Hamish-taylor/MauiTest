# Raygun4Maui Sample application
This app shows a very minimal installation and usage of Raygu4Maui, see the official [Raygun documentation](https://raygun.com/documentation/language-guides/dotnet/crash-reporting/maui/) for more indepth installation and usage instructions.

## Usage
To get the application to send exceptions to your raygun app, all you have to do is navigate to `MauiProgram.cs` and replace the string `paste_your_api_key_here` with your Raygun application API key. You can find this under `Application settings` in the Raygun app.

## Sending exceptions
The sample app includes a main page with a button that when pressed will send a test exception to Raygun, you can view the code for this in `MainPage.xaml.cs`.
