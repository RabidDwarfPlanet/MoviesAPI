using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Models.Movie> Movies { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
