using ConquerSite.Models;
using Microsoft.EntityFrameworkCore;
using ConquerSite.Models;


namespace ConquerSite.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<PlayerModels> accounts { get; set; }
        public DbSet<MarketItem> marketitems { get; set; }
        public DbSet<MiningModels> mined_items { get; set; }

        public DbSet<PaymentRecord> payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerModels>().ToTable("accounts"); 

        }
    }
}
