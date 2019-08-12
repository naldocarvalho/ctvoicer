using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IVehicle : IGeneric<Vehicle>
    {
        Task<Vehicle> GetByChassisAsync(string chassis);
    }
}