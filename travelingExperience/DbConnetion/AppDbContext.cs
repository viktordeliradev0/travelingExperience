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
        public DbSet<Travel> Travels { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
