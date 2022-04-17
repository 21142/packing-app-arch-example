using Microsoft.EntityFrameworkCore;
using PackingApp.Infrastructure.Configurations;
using PackingApp.Infrastructure.Models;

namespace PackingApp.Infrastructure.Persistence
{
    public class ReadDbContext : DbContext
    {
        public DbSet<SuitcaseReadModel> Suitcases { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("packing");

            var configuration = new ReadConfiguration();
            modelBuilder.ApplyConfiguration<SuitcaseReadModel>(configuration);
            modelBuilder.ApplyConfiguration<SuitcaseItemReadModel>(configuration);

            base.OnModelCreating(modelBuilder);

        }
    }
}
