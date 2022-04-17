using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PackingApp.Infrastructure.Models;

namespace PackingApp.Infrastructure.Configurations
{
    public class ReadConfiguration : IEntityTypeConfiguration<SuitcaseReadModel>, IEntityTypeConfiguration<SuitcaseItemReadModel>
    {
        public void Configure(EntityTypeBuilder<SuitcaseReadModel> builder)
        {
            builder.ToTable("Suitcases");
            builder.HasKey(s => s.Id);

            builder
                .Property(s => s.Location)
                .HasConversion(l => l.ToString(), l => LocationReadModel.Create(l));

            builder
                .HasMany(s => s.SuitcaseItems)
                .WithOne(i => i.Suitcase);
        }

        public void Configure(EntityTypeBuilder<SuitcaseItemReadModel> builder)
        {
            builder.ToTable("SuitcaseItems");
        }
    }
}
