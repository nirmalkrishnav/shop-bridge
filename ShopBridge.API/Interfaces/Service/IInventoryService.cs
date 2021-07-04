using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShopBridge.DTOs;

namespace ShopBridge.Interfaces.Service
{
    public interface IInventoryService
    {
        Task<List<Inventory>> GetAll();
        Task<Inventory> GetById(int Id);
        Task<bool> AddToInventory(Inventory inv);
        Task<bool> DeleteById(int Id);
        Task<bool> Update(int Id, Inventory inv);


    }
}
