using Domain.Entities;
using System.Threading.Tasks;

namespace Interface.Repository.Vehicles
{
    public interface IVehicleRepository : IRepositoryGeneric<Vehicle>
    {
        Task<Vehicle> GetByChassisAsync(string chassis);
    }
}