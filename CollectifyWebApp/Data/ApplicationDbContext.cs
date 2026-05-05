using Microsoft.EntityFrameworkCore;
using CollectifyWebApp.Models;

namespace CollectifyWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Add your DbSets here, e.g.:
         public DbSet<Item> Items { get; set; }
    }
}