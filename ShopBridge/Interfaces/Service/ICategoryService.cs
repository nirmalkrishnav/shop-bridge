using ShopBridge.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Interfaces.Service
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();
        Task<Category> GetById(int Id);
        Task<bool> AddToCategory(Category cat);
    }
}
