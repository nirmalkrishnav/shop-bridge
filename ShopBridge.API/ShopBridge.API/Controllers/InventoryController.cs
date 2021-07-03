using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBridge.Interfaces.Service;
using ShopBridge.DTOs;

namespace ShopBridge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Inventory
        [HttpPost]
        public async Task<bool> Post([FromBody] DTOs.Inventory inv)
        {
            return await _inventoryService.AddToInventory(inv);
        }

        // PUT: api/Inventory/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
