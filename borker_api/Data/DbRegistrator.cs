using borker_api.DAL;
using borker_api.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace borker_api.Data
{
    public static class DbRegistrator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            return services
            .AddDbContext<AppDbContext>(
                options => options.UseMySql(configuration.GetConnectionString("LocalCS_MySql"), new MySqlServerVersion(new Version(8, 0, 29))))
            .AddRepositoriesInDB()
            ;
        }
    }
}
