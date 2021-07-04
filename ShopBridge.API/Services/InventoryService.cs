using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShopBridge.Interfaces.Service;
using ShopBridge.Entities;
using ShopBridge.DTOs;
using ShopBridge.Interfaces.Repository;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ShopBridge.Services
{
    public class InventoryService : IInventoryService
    {
        readonly IAsyncRepository<Entities.Inventory> _inventoryRepo;
        readonly IAsyncRepository<Entities.Category> _categoryRepo;

        public InventoryService(
            IAsyncRepository<Entities.Inventory> inventoryRepo,
            IAsyncRepository<Entities.Category> categoryRepo

            )
        {
            _inventoryRepo = inventoryRepo;
            _categoryRepo = categoryRepo;
        }
        public async Task<List<DTOs.Inventory>> GetAll()
        {
            return await (from inv in _inventoryRepo.Queryable()
                          join cat in _categoryRepo.Queryable() on inv.CategoryId equals cat.Id
                    select new DTOs.Inventory
                    {
                        Id = inv.Id,
                        Name = inv.Name,
                        CategoryId = inv.CategoryId,
                        Description = inv.Description,
                        Price = inv.Price,
                        Unit = inv.Unit,
                        IsActive = inv.IsActive,
                        Quantity = inv.Quantity,
                        Status = inv.Status,
                        CategoryName = cat.CategoryName,
                        Code = cat.Code
                    }
                    ).ToListAsync();
        }

        public async Task<bool> AddToInventory(DTOs.Inventory inv)
        {
            Entities.Inventory item = new Entities.Inventory()
            {
                Id = inv.Id,
                Name = inv.Name,
                Category = new Entities.Category { Id = inv.CategoryId },
                Description = inv.Description,
                Price = inv.Price,
                Unit = inv.Unit,
                IsActive = inv.IsActive,
                Quantity = inv.Quantity,
                Status = inv.Status,
            };
            try
            {
                var res = await _inventoryRepo.AddAsync(item);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}
