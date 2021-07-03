using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using ShopBridge.Entities;
using ShopBridge.Interfaces.Repository;

namespace EY.EOS.Infrastructure.DataAccess
{
    public class EfRepository<T> : IAsyncRepository<T> where T : EntityBase
    {
        protected readonly AppDbContext _dbContext;
        public EfRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
      
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
        public IQueryable<T> Queryable()
        {
            return _dbContext.Set<T>().AsQueryable();
        }
    }
}
