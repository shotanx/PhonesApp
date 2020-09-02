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
        }
    }
}
