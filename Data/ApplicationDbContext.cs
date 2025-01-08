using Microsoft.EntityFrameworkCore;
using WorldKitchen.Models;

namespace WorldKitchen.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<DatabaseWorldKitchenCountry> Country { get; set; }
        public DbSet<DatabaseWorldKitchenDish> Dish { get; set; }

    }
}

