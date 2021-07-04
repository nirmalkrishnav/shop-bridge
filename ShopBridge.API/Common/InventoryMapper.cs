using System;
using ShopBridge.DTOs;

namespace ShopBridge.Common
{
    public static class InventoryMapper
    {
        public static Entities.Inventory ToEntity(DTOs.Inventory dtoObj, Entities.Inventory entObj)
        {
            
            entObj.Name = dtoObj.Name;
            entObj.Description = dtoObj.Description;
            entObj.Price = dtoObj.Price;
            entObj.Unit = dtoObj.Unit;
            entObj.IsActive = dtoObj.IsActive;
            entObj.Quantity = dtoObj.Quantity;
            entObj.Status = dtoObj.Status;
            entObj.CategoryId = dtoObj.Category.Id;
            return entObj;
        }
    }

}
