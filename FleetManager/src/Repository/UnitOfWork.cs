using Infrastructure.Data.Context;
using Interface;
using System;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public SQLiteContext Context { get; }

        public UnitOfWork(SQLiteContext context)
        {
            this.Context = context;
        }

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public async Task Commit()
        {
            await this.Context.SaveChangesAsync();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }
    }
}