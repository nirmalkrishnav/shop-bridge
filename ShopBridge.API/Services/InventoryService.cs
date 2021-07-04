using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShopBridge.Interfaces.Service;
using ShopBridge.Entities;
using ShopBridge.DTOs;
using ShopBridge.Interfaces.Repository;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ShopBridge.Services
{
    public class InventoryService : IInventoryService
    {
        readonly IAsyncRepository<Entities.Inventory> _inventoryRepo;
        readonly IAsyncRepository<Entities.Category> _categoryRepo;
        private readonly ILogger<InventoryService> _logger;

        public InventoryService(
            IAsyncRepository<Entities.Inventory> inventoryRepo,
            IAsyncRepository<Entities.Category> categoryRepo,
            ILogger<InventoryService> logger
            )
        {
            _inventoryRepo = inventoryRepo;
            _categoryRepo = categoryRepo;
            _logger = logger;
        }
        public async Task<List<DTOs.Inventory>> GetAll()
        {
            return await (from inv in _inventoryRepo.Queryable()
                          join cat in _categoryRepo.Queryable() on inv.CategoryId equals cat.Id
                          select new DTOs.Inventory
                          {
                              Id = inv.Id,
                              Name = inv.Name,
                              Description = inv.Description,
                              Price = inv.Price,
                              Unit = inv.Unit,
                              IsActive = inv.IsActive,
                              Quantity = inv.Quantity,
                              Status = inv.Status,
                              Category = new DTOs.Category { Id = cat.Id, CategoryName = cat.CategoryName, Code = cat.Code },
                          }
                    ).ToListAsync();
        }

        public async Task<bool> AddToInventory(DTOs.Inventory inv)
        {
            Entities.Inventory item = new Entities.Inventory()
            {
                Name = inv.Name,
                CategoryId = inv.Category.Id,
                Description = inv.Description,
                Price = inv.Price,
                Unit = inv.Unit,
                IsActive = inv.IsActive,
                Quantity = inv.Quantity,
                Status = inv.Status,
            };
            var res = await _inventoryRepo.AddAsync(item);
            if (res != null)
            {
                return true;
            }
            else
            {
                throw new InvalidOperationException($"New inventory {inv.Name} was not inserted");
            }
        }

        public async Task<DTOs.Inventory> GetById(int Id)
        {

            return await (from inv in _inventoryRepo.Queryable()
                          join cat in _categoryRepo.Queryable() on inv.CategoryId equals cat.Id
                          where inv.Id == Id
                          select new DTOs.Inventory
                          {
                              Id = inv.Id,
                              Name = inv.Name,
                              Description = inv.Description,
                              Price = inv.Price,
                              Unit = inv.Unit,
                              IsActive = inv.IsActive,
                              Quantity = inv.Quantity,
                              Status = inv.Status,
                              Category = new DTOs.Category { Id = cat.Id, CategoryName = cat.CategoryName, Code = cat.Code },
                          }
                 ).FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteById(int Id)
        {
            var item = await _inventoryRepo.GetByIdAsync(Id);
            if (item == null)
            {
                throw new InvalidOperationException($"item of {Id} not found");
            }

            var res = await _inventoryRepo.DeleteAsync(item);
            _logger.LogInformation($"Item {Id} was deleted");
            return true;

        }
    }
}
