using Domain.Entities;
using System.Threading.Tasks;

namespace Interface.Service
{
    public interface IVehicleService
    {
        Task<Vehicle> GetByChassisAsync(string chassis);
    }
}