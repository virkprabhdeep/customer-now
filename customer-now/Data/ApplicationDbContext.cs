using customer_now.Models;
using Microsoft.EntityFrameworkCore;

namespace customer_now.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<User> Users { get; set; }
    }
}