using Danilkova_453504.UI.Pages;
using Danilkova_453504.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danilkova_453504.UI
{
    public static class DependencyInjection
    {

        public static IServiceCollection RegisterPages(this IServiceCollection services)
        {

            services.AddTransient<Singers>();
            return services;
        }

        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddTransient<SingersViewModel>();
            return services;
        }


    }
}
