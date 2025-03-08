using Microsoft.EntityFrameworkCore;
using Reto.Models;

namespace Reto.Data
{
    public class RetoDbContext : DbContext
    {
        public RetoDbContext(DbContextOptions<RetoDbContext> contextOptions) : base(contextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
    }
}
