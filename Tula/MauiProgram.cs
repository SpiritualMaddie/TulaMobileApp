
namespace Tula
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
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

            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
            
            builder.Services.AddSingleton<MakeService>();
            //builder.Services.AddSingleton<MainPage>();

            builder.Services.AddTransient<UserInputViewModel>();
            builder.Services.AddTransient<SupportNeedsChat>();

            return builder.Build();
        }
    }
}
