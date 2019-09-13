using Domain.Entities;
using FluentValidation;
using Interface;
using Interface.Repository.Vehicles;
using Interface.Service;
using Service.Validators;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class VehicleService : ServiceGeneric, IVehicleService
    {
        private readonly IVehicleRepository repository;

        public VehicleService(IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.repository = vehicleRepository;
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

            //return entity;
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

        public async void Update(Vehicle entity)
        {
            entity.DateUpdate = DateTime.UtcNow;
            Validate(entity, Activator.CreateInstance<VehicleValidator>());
            repository.Update(entity);
            await base.Commit();

            //return entity;
        }

        public async void Delete(Vehicle entity)
        {
            repository.Delete(entity);
            await base.Commit();
        }

        private void Validate(Vehicle entity, AbstractValidator<Vehicle> validator)
        {
            if (entity == null)
            {
                throw new Exception("Registro não detectado!");
            }

            validator.ValidateAndThrow(entity);
        }
    }
}