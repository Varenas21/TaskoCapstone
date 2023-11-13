using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskoCapstone.Models;

namespace TaskoCapstone.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<TaskManager> Tasks { get; set; }
    }
}