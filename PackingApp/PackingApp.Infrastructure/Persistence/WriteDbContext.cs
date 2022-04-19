using Microsoft.EntityFrameworkCore;
using PackingApp.Domain.Entities;
using PackingApp.Domain.ValueObjects;
using PackingApp.Infrastructure.Configurations;

namespace PackingApp.Infrastructure.Persistence
{
    public class WriteDbContext : DbContext
    {
        public DbSet<Suitcase> Suitcases { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("packing");

            var configuration = new WriteConfiguration();
            modelBuilder.ApplyConfiguration<Suitcase>(configuration);
            modelBuilder.ApplyConfiguration<SuitcaseItem>(configuration);
        }
    }
}

