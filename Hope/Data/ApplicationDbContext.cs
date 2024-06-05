using Hope.Models;
using Microsoft.EntityFrameworkCore;

namespace Hope.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Photo>().HasData(
                new Photo { Id = 1, ImageUrl = "" },
                new Photo { Id = 2, ImageUrl = "" },
                new Photo { Id = 3, ImageUrl = "" }
                );
        }
    }
}
