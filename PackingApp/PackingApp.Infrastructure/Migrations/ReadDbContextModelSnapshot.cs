﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PackingApp.Infrastructure.Persistence;

namespace PackingApp.Infrastructure.Migrations
{
    [DbContext(typeof(ReadDbContext))]
    partial class ReadDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("packing")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PackingApp.Infrastructure.Models.SuitcaseItemReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsPacked")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid?>("SuitcaseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SuitcaseId");

                    b.ToTable("SuitcaseItems");
                });

            modelBuilder.Entity("PackingApp.Infrastructure.Models.SuitcaseReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Suitcases");
                });

            modelBuilder.Entity("PackingApp.Infrastructure.Models.SuitcaseItemReadModel", b =>
                {
                    b.HasOne("PackingApp.Infrastructure.Models.SuitcaseReadModel", "Suitcase")
                        .WithMany("SuitcaseItems")
                        .HasForeignKey("SuitcaseId");

                    b.Navigation("Suitcase");
                });

            modelBuilder.Entity("PackingApp.Infrastructure.Models.SuitcaseReadModel", b =>
                {
                    b.Navigation("SuitcaseItems");
                });
#pragma warning restore 612, 618
        }
    }
}
