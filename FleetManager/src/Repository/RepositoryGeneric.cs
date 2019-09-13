using Interface;
using Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : class
    {
        public readonly IUnitOfWork UnitOfWork;

        public RepositoryGeneric(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public virtual async Task AddAsync(T entity)
        {
            await this.UnitOfWork.Context.Set<T>().AddAsync(entity);
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await this.UnitOfWork.Context.Set<T>().FindAsync(id);
        }

        public virtual async Task<IList<T>> ListAsync()
        {
            return await this.UnitOfWork.Context.Set<T>().ToListAsync();
        }

        public virtual void Update(T entity)
        {
            this.UnitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Update(IEnumerable<T> entities)
        {
            this.UnitOfWork.Context.Entry(entities).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            this.UnitOfWork.Context.Set<T>().Remove(entity);
        }
    }
}