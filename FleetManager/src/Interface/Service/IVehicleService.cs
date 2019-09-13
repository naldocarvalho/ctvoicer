using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interface.Service
{
    public interface IVehicleService
    {
        Task<Vehicle> GetAsync(int id);
        Task<Vehicle> GetByChassisAsync(string chassis);
        Task<IList<Vehicle>> ListAsync();
        Task AddAsync(Vehicle entity);
        void Update(Vehicle entity);
        void Delete(Vehicle entity);
    }
}