using Domain.Entities;
using FluentValidation;
using Interface.Repository;
using Repository.Vehicles;
using Service.Validators;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class VehicleService : IVehicleRepository
    {
        private readonly VehicleRepository repository;

        public VehicleService(VehicleRepository vehiculeRepositorio)
        {
            repository = vehiculeRepositorio;
        }

        public async Task AddAsync(Vehicle entity)
        {
            entity.DateCreate = DateTime.Now;

            switch (entity.Type.ToLower().Replace("ô", "o").Replace("ã", "a"))
            {
                case string x when x.Equals("onibus", StringComparison.InvariantCultureIgnoreCase):
                    entity.PassengerCapacity = 42;
                    break;
                case string x when x.Equals("caminhao", StringComparison.InvariantCultureIgnoreCase):
                    entity.PassengerCapacity = 2;
                    break;
                default:
                    entity.PassengerCapacity = 0;
                    break;
            }

            Validate(entity, Activator.CreateInstance<VehicleValidator>());

            await repository.AddAsync(entity);
        }

        public async Task UpdateAsync(Vehicle entity)
        {
            entity.DateUpdate = DateTime.Now;

            Validate(entity, Activator.CreateInstance<VehicleValidator>());

            await repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IList<Vehicle>> ListAsync()
        {
            return await repository.ListAsync();
        }

        public async Task<Vehicle> GetAsync(int id)
        {
            return await repository.GetAsync(id);
        }

        public async Task<Vehicle> GetByChassisAsync(string chassis)
        {
            if (string.IsNullOrEmpty(chassis))
            {
                throw new ArgumentException("O chassi deve ser informado.");
            }

            return await repository.GetByChassisAsync(chassis);
        }

        private void Validate(Vehicle entity, AbstractValidator<Vehicle> validator)
        {
            if (entity == null)
                throw new Exception("Registro não detectado!");

            validator.ValidateAndThrow(entity);
        }
    }
}