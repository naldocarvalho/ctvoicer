using Domain.Entities;
using System.Threading.Tasks;

namespace Interface.Repository
{
    public interface IVehicleRepository : IGeneric<Vehicle>
    {
        Task<Vehicle> GetByChassisAsync(string chassis);
    }
}