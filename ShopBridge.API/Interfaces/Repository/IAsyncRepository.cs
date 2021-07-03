using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopBridge.Entities;

namespace ShopBridge.Interfaces.Repository
{
    public interface IAsyncRepository<T> where T : EntityBase
    {

        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
    }
}
