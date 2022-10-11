using borker_api.ApiInteraction.Service;
using borker_api.ApiInteraction.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace borker_api.ApiInteraction
{
    public static class ServicesRegistrator
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services) => services
            .AddTransient<IRatesRepository, Repository>()
        ;
    }
}
