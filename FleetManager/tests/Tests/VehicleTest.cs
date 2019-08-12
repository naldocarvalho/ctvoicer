using Bogus;
using Domain.Entities;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class VehicleTest
    {
        private readonly Faker fake = null;
        private readonly DbContextOptions<SQLiteContext> options;
        private readonly ITestOutputHelper output;
        readonly List<string> vehiculeTypes = new List<string> { "ônibus", "caminhão" };

        public VehicleTest(ITestOutputHelper testOutput)
        {
            fake = new Faker(locale: "pt_BR");
            options = TestHelper.GetSQLiteContextInMemory;
            output = testOutput;
        }

        [Fact]
        public async Task ShouldSaveWithSucess()
        {
            using (SQLiteContext context = new SQLiteContext(options))
            {
                Vehicle vehicule = CreateVehiculeFake();

                output.WriteLine($"chassi: {vehicule.Chassis}");

                context.Vehicles.Add(vehicule);

                await context.SaveChangesAsync();
            }
        }

        [Fact]
        public async Task ShouldHaveExistsVehicule()
        {
            using (SQLiteContext context = new SQLiteContext(options))
            {
                Vehicle vehicule = CreateVehiculeFake();

                output.WriteLine($"chassi: {vehicule.Chassis}");

                context.Vehicles.Add(vehicule);

                await context.SaveChangesAsync();

                Vehicle result = await context.Vehicles.FirstOrDefaultAsync(x => x.Chassis.Equals(vehicule.Chassis));

                output.WriteLine($"id: {result.Id}");

                Assert.NotNull(result);
            }
        }

        [Fact]
        public async Task ShouldDeleteWithSucess()
        {
            using (SQLiteContext context = new SQLiteContext(options))
            {
                Vehicle vehicule = CreateVehiculeFake();

                output.WriteLine($"chassi: {vehicule.Chassis}");

                context.Vehicles.Add(vehicule);

                await context.SaveChangesAsync();

                var result = await context.Vehicles.FirstOrDefaultAsync(x => x.Id.Equals(vehicule.Id));

                output.WriteLine($"id: {result.Id}");

                context.Remove(result);
            }
        }

        [Fact]
        public async Task ShouldUpdateWithSucess()
        {
            using (SQLiteContext context = new SQLiteContext(options))
            {
                Vehicle vehicule = CreateVehiculeFake();

                context.Vehicles.Add(vehicule);

                await context.SaveChangesAsync();

                Vehicle result = await context.Vehicles.FirstOrDefaultAsync(x => x.Id.Equals(vehicule.Id));

                output.WriteLine($"color before update: {result.Color}");

                vehicule.Color = "VERDE-LIMAO";

                context.Update(vehicule);

                await context.SaveChangesAsync();

                result = await context.Vehicles.FirstOrDefaultAsync(x => x.Id.Equals(vehicule.Id));

                output.WriteLine($"color after update: {result.Color}");

                Assert.Equal("VERDE-LIMAO", result.Color);
            }
        }

        private Faker<Vehicle> CreateVehiculeFake()
        {
            Faker<Vehicle> vehicle = new Faker<Vehicle>(locale: "pt_BR")
                .RuleFor(b => b.Id, f => f.Random.Number(1, int.MaxValue))
                .RuleFor(b => b.Chassis, f => f.Vehicle.Vin())
                .RuleFor(b => b.Color, f => f.Commerce.Color())
                .RuleFor(b => b.Type, f => f.PickRandom(vehiculeTypes))
                .RuleFor(b => b.DateCreate, f => f.Date.Future());

            return vehicle;
        }
    }
}