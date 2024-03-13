using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure
{
    public class AuctionDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Auction> Auctions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DbInitializer.Init(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
