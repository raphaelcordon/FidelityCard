using Microsoft.EntityFrameworkCore;
using PromoManagement.Models;

namespace PromoManagement.Data
{
    public class PromoDbContext : DbContext
    {
        public PromoDbContext(DbContextOptions<PromoDbContext> opts) : base(opts) { }

        public DbSet<Promo> Promos { get; set; }
        public DbSet<UserEngagement> UserEngagements { get; set; }
    }
}
