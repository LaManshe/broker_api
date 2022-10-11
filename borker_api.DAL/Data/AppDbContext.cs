using borker_api.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace borker_api.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Rate> Rates { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
