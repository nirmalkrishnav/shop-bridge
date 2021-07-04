using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBridge.Interfaces.Service;
using ShopBridge.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace ShopBridge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class InventoryController : ControllerBase
    {
        readonly IInventoryService _inventoryService;

        public InventoryController(
             IInventoryService inventoryService
            )
        {
            _inventoryService = inventoryService;
        }

        // GET: api/Inventory
        [HttpGet]
        public async Task<List<Inventory>> Get()
        {
            return await _inventoryService.GetAll();
        }

        // GET: api/Inventory/5
        [HttpGet("{Id}", Name = "GetInventory")]
        public async Task<Inventory> Get(int Id)
        {
            return await _inventoryService.GetById(Id);
        }

        // POST: api/Inventory
        [HttpPost]
        public async Task<bool> Post([FromBody] Inventory inv)
        {
            return await _inventoryService.AddToInventory(inv);
        }

        // PUT: api/Inventory/5
        [HttpPut("{id}")]
        public async Task<bool> Put(int id, [FromBody] Inventory inv)
        {
            return await _inventoryService.Update(id, inv);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{Id}")]
        public async Task<bool> Delete(int Id)
        {
            return await _inventoryService.DeleteById(Id);
        }
    }
}
