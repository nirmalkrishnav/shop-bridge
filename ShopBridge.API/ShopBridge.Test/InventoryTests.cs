using System;
using Xunit;
using ShopBridge.API.Controllers;
using System.Threading.Tasks;
using ShopBridge.Service;
using Moq;
using ShopBridge.Entities;
using Microsoft.AspNetCore.Identity;
using ShopBridge.DTOs;
using Microsoft.Extensions.Options;
using ShopBridge.Services;
using ShopBridge.Interfaces.Repository;
using ShopBridge.Interfaces.Service;
using System.Collections.Generic;

namespace ShopBridge.Tests
{
    public class InventoryTest
    {

        private readonly Mock<IInventoryService> _InventoryServiceMoq = new Mock<IInventoryService>();


        [Fact]
        public async Task GetAll_ShouldReturn_AListOfItems()
        {
            //arrange
            var expected = new List<DTOs.Inventory>()
            {
                new DTOs.Inventory{
                    Id= 1,
                    Name= "sample1"
                },
                     new DTOs.Inventory{
                    Id= 2,
                    Name= "sample2"
                }
            };

            _InventoryServiceMoq.Setup(x => x.GetAll()).Returns(Task.FromResult(expected));
            //act
            InventoryController ctr = new InventoryController(_InventoryServiceMoq.Object);
            List<DTOs.Inventory> result = await ctr.Get();

            //assert
            Assert.Equal(expected, result);
            Assert.Equal(expected.Count, result.Count);
        }

        [Fact]
        public async Task GetAll_ShouldAdd_OneItem()
        {
            //arrange
            var input =
                new DTOs.Inventory
                {
                    Id = 1,
                    Name = "sample1"

                };
            var expected = true;
            _InventoryServiceMoq.Setup(x => x.AddToInventory(input)).Returns(Task.FromResult(true));
            //act
            InventoryController ctr = new InventoryController(_InventoryServiceMoq.Object);
            bool result = await ctr.Post(input);

            //assert
            Assert.Equal(expected, result);
        }

    }
}
