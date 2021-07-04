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
            Assert.IsAssignableFrom<List<DTOs.Inventory>>(result);
            Assert.Equal(expected, result);
            Assert.Equal(expected.Count, result.Count);
        }

        [Fact]
        public async Task GetAll_ShouldAdd_OneItem()
        {
            //arrange
            var input = GetTestInput();

            var expected = true;
            _InventoryServiceMoq.Setup(x => x.AddToInventory(input)).Returns(Task.FromResult(true));
            //act
            InventoryController ctr = new InventoryController(_InventoryServiceMoq.Object);
            bool result = await ctr.Post(input);

            //assert
            Assert.IsAssignableFrom<bool>(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task GetAll_ShouldGet_OneItem_ById()
        {
            var expected = new DTOs.Inventory
            {
                Id = 1,
                Name = "sample1"
            };
            _InventoryServiceMoq.Setup(x => x.GetById(1)).Returns(Task.FromResult(expected));
            
            InventoryController ctr = new InventoryController(_InventoryServiceMoq.Object);
            DTOs.Inventory result = await ctr.Get(1);

            Assert.NotNull(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task GetAll_ShouldDelete_OneItem_ById()
        {
            _InventoryServiceMoq.Setup(x => x.DeleteById(3)).Returns(Task.FromResult(true));
            InventoryController ctr = new InventoryController(_InventoryServiceMoq.Object);
            
            bool result = await ctr.Delete(100);
            
            Assert.IsType<bool>(result);
        }

        private DTOs.Inventory GetTestInput()
        {
            var input =
                new DTOs.Inventory
                {
                    Id = 1,
                    Name = "sample1"

                };

            return input;
        }

        private List<DTOs.Inventory> GetTestInputs()
        {
            var input = new List<DTOs.Inventory>();
            input.Add(new DTOs.Inventory { Id = 1, Name = "Sample 1" });
            input.Add(new DTOs.Inventory { Id = 2, Name = "Sample 2" });
            input.Add(new DTOs.Inventory { Id = 3, Name = "Sample 3" });



            return input;
        }

    }
}
