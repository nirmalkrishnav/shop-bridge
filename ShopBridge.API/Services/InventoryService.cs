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
        public InventoryService(
            IAsyncRepository<Entities.Inventory> inventoryRepo
            )
        {
            _inventoryRepo = inventoryRepo;

        }
        public async Task<List<DTOs.Inventory>> GetAll()
        {
            return await _inventoryRepo.Queryable()
                .Select(e => new DTOs.Inventory
                {
                    Id = e.Id,
                    Title = e.Title
                })
                .ToListAsync(); ;
        }


    }
}
