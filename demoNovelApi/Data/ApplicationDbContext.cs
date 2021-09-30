using demoNovelApi.Model;
using Microsoft.EntityFrameworkCore;

namespace demoNovelApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Novel> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Novel>().HasData(new Novel
            {
                Id = 1,
                Name = "GaraudZhep"
            }, new Novel
            {
                Id = 2,
                Name = "Shiva"
            });
        }
    }
}
