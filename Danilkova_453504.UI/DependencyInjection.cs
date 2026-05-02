using Danilkova_453504.UI.Pages;
using Danilkova_453504.UI.ViewModels;


namespace Danilkova_453504.UI
{
    public static class DependencyInjection
    {

        public static IServiceCollection RegisterPages(this IServiceCollection services)
        {

            services.AddTransient<Singers>();
            services.AddTransient<SongInformation>();
            services.AddTransient<CreateSongForSinger>();
            services.AddTransient<CreateSinger>();
            services.AddTransient<UpdateSinger>();
            services.AddTransient<UpdateSong>();
           
            return services;
        }

        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddTransient<SingersViewModel>();
            services.AddTransient<SongInformationViewModel>();
            services.AddTransient<CreateSongForSingerViewModel>();
            services.AddTransient<CreateSingerViewModel>();
            services.AddTransient<UpdateSingerViewModel>();
            services.AddTransient<UpdateSongViewModel>();
            return services;
        }


    }
}
