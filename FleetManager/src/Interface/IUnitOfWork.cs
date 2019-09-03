using Infrastructure.Data.Context;
using System;
using System.Threading.Tasks;

namespace Interface
{
    public interface IUnitOfWork : IDisposable
    {
        SQLiteContext Context { get; }
        void BeginTransaction();
        Task Commit();
        void Rollback();
    }
}