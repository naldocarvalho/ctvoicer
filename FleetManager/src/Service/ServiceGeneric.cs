using Interface;
using System;
using System.Threading.Tasks;

namespace Service
{
    public abstract class ServiceGeneric : IDisposable
    {
        protected readonly IUnitOfWork UnitOfWork;

        public ServiceGeneric(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        protected virtual async Task Commit()
        {
            await this.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            this.UnitOfWork.Dispose();
        }
    }
}