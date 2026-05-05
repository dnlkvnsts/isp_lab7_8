using CommunityToolkit.Maui;
using Danilkova_453504.Application;
using Danilkova_453504.Persistence;
using Danilkova_453504.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Danilkova_453504.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            string settingsStream = "Danilkova_453504.UI.appsettings.json";

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("fa-solid-900.ttf", "FASolid");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream(settingsStream);
            builder.Configuration.AddJsonStream(stream);



            var connStr = builder.Configuration.GetConnectionString("SqliteConnection");
            string dataDirectory = FileSystem.Current.AppDataDirectory + "/"; 
            connStr = String.Format(connStr, dataDirectory);

            
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(connStr)
                .Options;


            

            builder.Services
                .AddPersistence(options)
                .AddApplication()
                .RegisterPages()
                .RegisterViewModels();

            DbInitializer
                .Initialize(builder.Services.BuildServiceProvider())
                .Wait();

            return builder.Build();
        }
    }
}
