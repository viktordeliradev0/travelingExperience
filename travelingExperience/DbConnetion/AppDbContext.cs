using Microsoft.EntityFrameworkCore;
using travelingExperience.Entity;
using travelingExperience.Models;

namespace travelingExperience.DbConnetion
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
           
        }

        public AppDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Replace 'YourConnectionString' with your actual database connection string
                optionsBuilder.UseSqlServer("Data Source=VIKTOR\\SQLEXPRESS1111;Initial Catalog=logingin;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
