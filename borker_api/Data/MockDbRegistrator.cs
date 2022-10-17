using borker_api.DAL;
using borker_api.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace borker_api.Data
{
    public static class MockDbRegistrator
    {
        public static IServiceCollection MockDb(this IServiceCollection services)
        {
            return services
                .AddMockDb()
                ;
        }
    }
}
