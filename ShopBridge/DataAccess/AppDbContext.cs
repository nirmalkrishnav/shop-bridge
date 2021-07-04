using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopBridge.Entities;
using ShopBridge.Infrastructure.DataAccess;
using System;

namespace DataAccess
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.SeedAdmin();
            modelBuilder.SeedCategory();
            modelBuilder.SeedProducts();
        }
        public DbSet<Inventory> Inventory { get; set; }

    }
}
