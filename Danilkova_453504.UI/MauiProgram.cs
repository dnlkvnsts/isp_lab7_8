using CommunityToolkit.Maui;
using Danilkova_453504.Application;
using Danilkova_453504.Persistence;
using Microsoft.Extensions.Logging;

namespace Danilkova_453504.UI
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services
                .AddPersistence()
                .AddApplication()
                .RegisterPages()
                .RegisterViewModels();

            


            return builder.Build();
        }
    }
}
