using Domain.Entities;
using Infrastructure.Data.Context;
using Interface.Repository.Vehicles;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Vehicles
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly DbContextOptions<SQLiteContext> options;

        public VehicleRepository()
        {
            options = new DbContextOptions<SQLiteContext>();
        }

        public async Task AddAsync(Vehicle entity)
        {
            using (SQLiteContext database = new SQLiteContext(options))
            {
                await database.AddAsync(entity);
                database.SaveChanges();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (SQLiteContext database = new SQLiteContext(options))
            {
                database.Vehicles.Remove(await GetAsync(id));
                database.SaveChanges();
            }
        }

        public async Task<Vehicle> GetAsync(int id)
        {
            using (SQLiteContext database = new SQLiteContext(options))
            {
                return await database.Vehicles
                    .AsNoTracking()
                    .Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            }
        }

        public async Task<Vehicle> GetByChassisAsync(string chassis)
        {
            using (SQLiteContext database = new SQLiteContext(options))
            {
                return await (from v in database.Vehicles
                              where v.Chassis.Equals(chassis)
                              select v).FirstOrDefaultAsync();
            }
        }

        public async Task<IList<Vehicle>> ListAsync()
        {
            using (SQLiteContext database = new SQLiteContext(options))
            {
                return await database.Vehicles
                    .AsNoTracking()
                    .ToListAsync();
            }
        }

        public async Task UpdateAsync(Vehicle entity)
        {
            using (SQLiteContext database = new SQLiteContext(options))
            {
                database.Entry(entity).State = EntityState.Modified;
                await database.SaveChangesAsync();
            }
        }
    }
}