using borker_api.DAL.Entities;
using borker_api.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace borker_api.DAL
{
    public static class MockRepositoryRegistrator
    {
        public static IServiceCollection AddMockDb(this IServiceCollection services) => services
            .AddTransient<IRepository<Rate>, MockRepository>()
        ;
    }
}
