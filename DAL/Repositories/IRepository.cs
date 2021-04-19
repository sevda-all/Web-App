
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookush.DAL.Repositories
{
    public interface IRepository<T> where T:class
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        bool Exists(int id);
    }
}
