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


            modelBuilder.Entity<AppUser>(e => e.ToTable(name: "AppUsers"));
            modelBuilder.Entity<AppRole>(e => e.ToTable(name: "AppRoles"));


            modelBuilder.Entity<AppUser>().HasData(
              new AppUser { Id = 1, Email = "admin1@shopbridge.com", NormalizedEmail = @"admin1@shopbridge.com".ToUpperInvariant(), UserName = @"admin1@shopbridge.com", NormalizedUserName = @"admin1@shopbridge.com".ToUpperInvariant() }
              );

            modelBuilder.Entity<AppRole>().HasData(
               new AppRole { Id = 1, Name = "Admin", NormalizedName = "Admin" }
               );

            modelBuilder.SeedCategory();
            modelBuilder.SeedProducts();
        }
        public DbSet<Inventory> Inventory { get; set; }

    }
}
