using CommunityToolkit.Maui;
using CurrencyConverter.Services;
using CurrencyConverter.ViewModels;
using CurrencyConverter.Views;
using Microsoft.Extensions.Logging;

namespace CurrencyConverter
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<LocalDbConnection>();

            builder.Services.AddSingleton<ConverterPage>();
            builder.Services.AddSingleton<LocationPage>();
            builder.Services.AddSingleton<RegisterPage>();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<HistoryPage>();
            builder.Services.AddSingleton<ProfilePage>();
            builder.Services.AddSingleton<HistoriesPage>();


            builder.Services.AddSingleton<ConverterViewModel>();
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<RegisterViewModel>();
            builder.Services.AddSingleton<HistoryViewModel>();
            builder.Services.AddSingleton<LocationViewModel>();
            builder.Services.AddSingleton<ProfilePageViewModel>();
            builder.Services.AddSingleton<HistoriesPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
