using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interface.Repository
{
    public interface IRepositoryGeneric<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IList<T>> ListAsync();
        Task AddAsync(T entity);
        void Update(T entity);
        void Update(IEnumerable<T> entities);
        void Delete(T entity);
    }
}