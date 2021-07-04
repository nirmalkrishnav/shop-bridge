using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopBridge.Entities;

namespace ShopBridge.Interfaces.Repository
{
    public interface IAsyncRepository<T> where T : EntityBase
    {

        Task<List<T>> ListAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        IQueryable<T> Queryable();
        Task<T> DeleteAsync(T entity);
    }
}
