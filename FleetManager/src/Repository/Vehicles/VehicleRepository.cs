using Domain.Entities;
using Interface;
using Interface.Repository.Vehicles;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Repository.Vehicles
{
    public class VehicleRepository : RepositoryGeneric<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<Vehicle> GetByChassisAsync(string chassis)
        {
            return await base.UnitOfWork.Context.Vehicles.AsNoTracking().FirstOrDefaultAsync(x => x.Chassis == chassis);
        }
    }
}