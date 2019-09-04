using Domain.Entities;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interface.Service
{
    public interface IService<T> where T : BaseEntity
    {
        Task<T> Post<V>(T obj) where V : AbstractValidator<T>;

        Task<T> Put<V>(T obj) where V : AbstractValidator<T>;

        Task Delete(int id);

        Task<T> Get(int id);

        Task<IList<T>> List();
    }
}