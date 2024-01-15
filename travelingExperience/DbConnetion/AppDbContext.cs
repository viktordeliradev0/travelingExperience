using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using travelingExperience.Entity;
using travelingExperience.Models;

namespace travelingExperience.DbConnetion
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Travel>()
                .HasOne(t => t.User)
                .WithMany(u => u.Travels)
                .HasForeignKey(t => t.UserID);




        }
        public DbSet<Reserve> Reserves { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
