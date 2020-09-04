using Microsoft.EntityFrameworkCore;
using Phones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phones.Data
{
    public class PhonesContext : DbContext
    {
        public PhonesContext(DbContextOptions options) : base(options) { }

        public DbSet<Phone> Phones { get; set; }
        public DbSet<Producer> Producers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>().ToTable("Phone");
            modelBuilder.Entity<Producer>().ToTable("Producer");

            modelBuilder.Entity<Phone>()
                .HasOne(ph => ph.Producer)
                .WithMany(pr => pr.Phones);

            modelBuilder.Entity<Phone>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(150);

            modelBuilder.Entity<Phone>()
                .Property(p => p.ImgUrl)
                .IsRequired()
                .HasMaxLength(150);

            modelBuilder.Entity<Phone>()
                .Property(p => p.Weight).HasColumnType("decimal(18, 5)");

            modelBuilder.Entity<Phone>()
                .Property(p => p.ScreenSize).HasColumnType("decimal(18, 5)");

            modelBuilder.Entity<Phone>()
                .Property(p => p.Storage).HasColumnType("decimal(18, 5)");

            modelBuilder.Entity<Phone>()
                .Property(p => p.Price).HasColumnType("decimal(18, 5)");

            modelBuilder.Entity<Producer>()
                .Property(p => p.ProducerName)
                .IsRequired()
                .HasMaxLength(150);

            modelBuilder.Entity<Producer>()
                .Property(p => p.ProducerCountry)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
