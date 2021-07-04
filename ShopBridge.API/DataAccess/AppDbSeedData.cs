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
                    Name = "10x Bass Wired Microphone",
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
            modelBuilder.Entity<Inventory>().HasData(
              new Inventory
              {
                  Id = 4,
                  Name = "LED Lamp",
                  IsActive = true,
                  Price = 249,
                  Unit = "INR",
                  Quantity = 1000,
                  Status = 2,
                  CategoryId = 1,
                  Description = "10x10 array LED"
              }
             );
            modelBuilder.Entity<Inventory>().HasData(
            new Inventory
            {
                Id = 5,
                Name = "Rose Room freshner",
                IsActive = true,
                Price = 149,
                Unit = "INR",
                Quantity = 1000,
                Status = 2,
                CategoryId = 1,
                Description = "Rose flavor room freshner"
            }
           );
            modelBuilder.Entity<Inventory>().HasData(
               new Inventory
               {
                   Id = 6,
                   Name = "Kaaza USB Stick - 500 GB",
                   IsActive = true,
                   Price = 999,
                   Unit = "INR",
                   Quantity = 400,
                   Status = 1,
                   CategoryId = 2,
                   Description = "500 GB USB Stick"
               }
              );

            modelBuilder.Entity<Inventory>().HasData(
             new Inventory
             {
                 Id = 7,
                 Name = "Kaaza USB Stick - 1 TB",
                 IsActive = true,
                 Price = 1899,
                 Unit = "INR",
                 Quantity = 200,
                 Status = 1,
                 CategoryId = 2,
                 Description = "1TB USB Stick"
             }
            );
            modelBuilder.Entity<Inventory>().HasData(
               new Inventory
               {
                   Id = 8,
                   Name = "TWS Earphones",
                   IsActive = true,
                   Price = 1899,
                   Unit = "INR",
                   Quantity = 50,
                   Status = 1,
                   CategoryId = 2,
                   Description = "TWS Earphones"
               }
              );
            modelBuilder.Entity<Inventory>().HasData(
              new Inventory
              {
                  Id = 9,
                  Name = "Rezer Mechanical feel keyboard",
                  IsActive = true,
                  Price = 4999,
                  Unit = "INR",
                  Quantity = 50,
                  Status = 1,
                  CategoryId = 2,
                  Description = "First copy Cherry Blue keys"
              }
             );
            modelBuilder.Entity<Inventory>().HasData(
             new Inventory
             {
                 Id = 10,
                 Name = "Razor Mechanical keyboard",
                 IsActive = true,
                 Price = 9999,
                 Unit = "INR",
                 Quantity = 10,
                 Status = 1,
                 CategoryId = 2,
                 Description = "Original Cherry mx Blue keys"
             }
            );
        }
    }
}
