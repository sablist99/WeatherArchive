using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Weather> Weather { get; set; }
        
        public ApplicationContext()
        {
        }

        public void ReloadConfigure()
        {
            OnConfiguring(new DbContextOptionsBuilder());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }
    }
}
