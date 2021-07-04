using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBridge.DTOs;

namespace ShopBridge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly ICategoryService _categoryService;

        public CategoryController(
             ICategoryService categoryService
            )
        {
            _categoryService = categoryService;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<List<Category>> Get()
        {
            return await _categoryService.GetAll();
        }

        // GET: api/Category/5
        [HttpGet("{Id}", Name = "Get")]
        public async Task<Category> Get(int Id)
        {
            return await _categoryService.GetById(Id);
        }

        // POST: api/Category
        [HttpPost]
        public async Task<bool> Post([FromBody] Category category)
        {
            return await _categoryService.AddToCategory(category);
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _categoryService.DeleteById(id);
        }
    }
}
