using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PackingApp.Domain.Entities;
using PackingApp.Domain.ValueObjects;
using System;

namespace PackingApp.Infrastructure.Configurations
{
    public class WriteConfiguration : IEntityTypeConfiguration<Suitcase>, IEntityTypeConfiguration<SuitcaseItem>
    {
        public void Configure(EntityTypeBuilder<Suitcase> builder)
        {
            builder.HasKey(s => s.Id);

            var locationConverter = new ValueConverter<Location, string>(l => l.ToString(),
                l => Location.CreateLocationFromString(l));

            var suitcaseNameConverter = new ValueConverter<SuitcaseName, string>(n => n.Value,
                n => new SuitcaseName(n));

            builder
                .Property(s => s.Id)
                .HasConversion(id => id.Value, id => new SuitcaseId(id));

            builder
                .Property(typeof(Location), "_location")
                .HasConversion(locationConverter)
                .HasColumnName("Location");

            builder
               .Property(typeof(SuitcaseName), "_name")
               .HasConversion(suitcaseNameConverter)
               .HasColumnName("Name");

            builder.HasMany(typeof(SuitcaseItem), "_clothes");

            builder.ToTable("Suitcases");
        }

        public void Configure(EntityTypeBuilder<SuitcaseItem> builder)
        {
            builder.Property<Guid>("Id");
            builder.Property(i => i.Name);
            builder.Property(i => i.Quantity);
            builder.Property(i => i.IsPacked);
            builder.ToTable("SuitcaseItems");
        }
    }
}
