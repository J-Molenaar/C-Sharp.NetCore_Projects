using Microsoft.EntityFrameworkCore;
using ActivityCenter.Models;
 
namespace ActivityCenter.Models
{
    public class ActivityCenterContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public ActivityCenterContext(DbContextOptions<ActivityCenterContext> options) : base(options) { }
        // This DbSet contains "Person" objects and is called "Users"
        public DbSet<User> Users { get; set; }
        public DbSet<Activity> Activities  { get; set; }
        public DbSet<Guest> Guests { get; set; }
    }

}