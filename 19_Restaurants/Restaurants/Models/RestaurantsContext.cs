using Microsoft.EntityFrameworkCore;
 
namespace Restaurants.Models
{
    public class RestaurantsContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public RestaurantsContext(DbContextOptions<RestaurantsContext> options) : base(options) { }

        public DbSet<Restaurant> Restaurant { get; set; }
    }
}
