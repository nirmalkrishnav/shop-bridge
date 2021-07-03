using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShopBridge.DTOs;

namespace ShopBridge.Interfaces.Service
{
    public interface IInventoryService
    {
        Task<List<DTOs.Inventory>> GetAll();
    }
}
