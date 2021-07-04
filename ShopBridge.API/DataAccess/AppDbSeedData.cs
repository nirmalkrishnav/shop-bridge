using Microsoft.EntityFrameworkCore;
using ShopBridge.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopBridge.Infrastructure.DataAccess
{
    public static class AppDbSeedData
    {
        public static void SeedCategory(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Code = "HI", CategoryName = "Home Improvement" }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 2, Code = "ELEC", CategoryName = "Electronics" }
                );

        }

        public static void SeedProducts(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Inventory>().HasData(
                new Inventory
                {
                    Id = 1,
                    Name = "House plant 1",
                    IsActive = true,
                    Price = 259,
                    Unit = "INR",
                    Quantity = 200,
                    Status = 1,
                    CategoryId = 1,
                    Description = "Small house plant"
                }
                );
            modelBuilder.Entity<Inventory>().HasData(
                new Inventory
                {
                    Id = 2,
                    Name = "Microphone",
                    IsActive = true,
                    Price = 599.99,
                    Unit = "INR",
                    Quantity = 500,
                    Status = 1,
                    CategoryId = 2,
                    Description = "Noise cancelling microphone"
                }
               );
            modelBuilder.Entity<Inventory>().HasData(
                new Inventory
                {
                    Id = 3,
                    Name = "Door mat",
                    IsActive = true,
                    Price = 99,
                    Unit = "INR",
                    Quantity = 500,
                    Status = 1,
                    CategoryId = 1,
                    Description = "Rugged door mat"
                }
               );

        }
    }
}
