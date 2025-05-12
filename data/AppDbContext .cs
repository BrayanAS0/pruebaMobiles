using Microsoft.EntityFrameworkCore;
using pruebaMobiles.Entities;

namespace pruebaMobiles.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<prueba> prueba { get; set; }
        public DbSet<User> User { get; set; }

    }

}
