using Microsoft.EntityFrameworkCore;
using ShopBridge.Entities;
using System;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Inventory>().HasData(
                new Inventory { Id = 1, Title = "Water bottle" }
                );
            modelBuilder.Entity<Inventory>().HasData(
               new Inventory { Id = 2, Title = "Fountain Pen" }
               );
        }
        public DbSet<Inventory> Inventory { get; set; }

    }
}
