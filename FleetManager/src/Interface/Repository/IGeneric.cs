using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interface.Repository
{
    public interface IGeneric<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IList<T>> ListAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
