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
    public class CategoryService : ICategoryService
    {
        readonly IAsyncRepository<Entities.Category> _categoryRepo;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(
            IAsyncRepository<Entities.Category> categoryRepo,
            ILogger<CategoryService> logger
            )
        {
            _categoryRepo = categoryRepo;
            _logger = logger;
        }
        public async Task<List<DTOs.Category>> GetAll()
        {
            return await (from cat in _categoryRepo.Queryable()
                          select new DTOs.Category
                          {
                              Id = cat.Id,
                              CategoryName = cat.CategoryName,
                              Code = cat.Code
                          }
                    ).ToListAsync();
        }

        public async Task<bool> AddToCategory(DTOs.Category cat)
        {
            Entities.Category item = new Entities.Category()
            {
                Code = cat.Code,
                CategoryName = cat.CategoryName
            };

            var res = await _categoryRepo.AddAsync(item);
            if (res != null)
            {
                return true;
            }
            else
            {
                throw new InvalidOperationException($"New category {cat.CategoryName} was not inserted");
            }
        }

        public async Task<DTOs.Category> GetById(int Id)
        {

            return await (from cat in _categoryRepo.Queryable()
                          where cat.Id == Id
                          select new DTOs.Category
                          {
                              Id = cat.Id,
                              CategoryName = cat.CategoryName,
                              Code = cat.Code
                          }
                 ).FirstOrDefaultAsync();
        }
    }
}
