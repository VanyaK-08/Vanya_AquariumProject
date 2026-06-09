using AquariumController;
using AquariumData;
using AquariumData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestControllers.Saving;

namespace TestControllers.Tests
{
    public class TankControlTests
    {
        private TankController controller;
        [SetUp]
        public void Setup()
        {
            AquariumContext context = TestDBStuff.CreateContext();

            context.Exhibits.Add(new Exhibit
            {
                Id = 1,
                Title = "Exhibit1",
                Description = "Description1"
            });

            context.SaveChanges();

            controller = new TankController(context);
        }
        [Test]
        public async Task AddTank_SuccessfullyAddTank()
        {
            Tank tank = new Tank
            {
                Id = 1,
                Name = "Tank1",
                CapacityLiters = 1000,
                WaterTemperature = 25,
                ExhibitId = 1
            };
            await controller.AddTank(tank);
            var tanks = await controller.GetAllTanks();
            var addedTank = tanks.FirstOrDefault();
            Assert.IsNotNull(addedTank);
            Assert.AreEqual("Tank1", addedTank.Name);
            Assert.AreEqual(1000, addedTank.CapacityLiters);
            Assert.AreEqual(25, addedTank.WaterTemperature);
            Assert.AreEqual(1, addedTank.ExhibitId);
        }
        [Test]
        public async Task AddTank_InvalidName_ThrowsException()
        {
            Tank tank = new Tank
            {
                Id = 1,
                Name = "",
                CapacityLiters = 1000,
                WaterTemperature = 25,
                ExhibitId = 1
            };
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.AddTank(tank));
        }
        [Test]
        public async Task AddTank_InvalidCapacity_ThrowsException()
        {
            Tank tank = new Tank
            {
                Id = 1,
                Name = "Tank1",
                CapacityLiters = -1000,
                WaterTemperature = 25,
                ExhibitId = 1
            };
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.AddTank(tank));
        }
        [Test]
        public async Task AddTank_AlreadyExisting_ThrowsException()
        {
            Tank tank = new Tank
            {
                Id = 1,
                Name = "Tank1",
                CapacityLiters = 1000,
                WaterTemperature = 25,
                ExhibitId = 1
            };
            await controller.AddTank(tank);
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.AddTank(tank));
        }
        [Test]
        public async Task UpdateTank_SuccessfullyUpdateTank()
        {
            Tank tank = new Tank
            {
                Id = 1,
                Name = "Tank1",
                CapacityLiters = 1000,
                WaterTemperature = 25,
                ExhibitId = 1
            };
            await controller.AddTank(tank);
            tank.Name = "UpdatedTank";
            tank.CapacityLiters = 2000;
            tank.WaterTemperature = 30;
            await controller.UpdateTank(tank);
            var tanks = await controller.GetAllTanks();
            var updatedTank = tanks.FirstOrDefault();
            Assert.IsNotNull(updatedTank);
            Assert.AreEqual("UpdatedTank", updatedTank.Name);
            Assert.AreEqual(2000, updatedTank.CapacityLiters);
            Assert.AreEqual(30, updatedTank.WaterTemperature);
        }
        [Test]
        public async Task UpdateTank_NonExistingTank_ThrowsException()
        {
            Tank tank = new Tank
            {
                Id = 1,
                Name = "Tank1",
                CapacityLiters = 1000,
                WaterTemperature = 25,
                ExhibitId = 1
            };
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.UpdateTank(tank));
        }
        [Test]
        public async Task UpdateTank_InvalidName_ThrowsException()
        {
            Tank tank = new Tank
            {
                Id = 1,
                Name = "Tank1",
                CapacityLiters = 1000,
                WaterTemperature = 25,
                ExhibitId = 1
            };
            await controller.AddTank(tank);
            tank.Name = "";
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.UpdateTank(tank));
        }
        [Test]
        public async Task UpdateTank_InvalidCapacity_ThrowsException()
        {
            Tank tank = new Tank
            {
                Id = 1,
                Name = "Tank1",
                CapacityLiters = 1000,
                WaterTemperature = 25,
                ExhibitId = 1
            };
            await controller.AddTank(tank);
            tank.CapacityLiters = -1000;
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.UpdateTank(tank));
        }
        [Test]
        public async Task UpdateTank_AlreadyExistingName_ThrowsException()
        {
            Tank tank1 = new Tank
            {
                Id = 1,
                Name = "Tank1",
                CapacityLiters = 1000,
                WaterTemperature = 25,
                ExhibitId = 1
            };
            Tank tank2 = new Tank
            {
                Id = 2,
                Name = "Tank2",
                CapacityLiters = 2000,
                WaterTemperature = 30,
                ExhibitId = 1
            };
            await controller.AddTank(tank1);
            await controller.AddTank(tank2);
            tank2.Name = "Tank1";
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.UpdateTank(tank2));
        }
        [Test]
        public async Task GetAllTanks_ReturnsAllTanks()
        {
            Tank tank1 = new Tank
            {
                Id = 1,
                Name = "Tank1",
                CapacityLiters = 1000,
                WaterTemperature = 25,
                ExhibitId = 1
            };
            Tank tank2 = new Tank
            {
                Id = 2,
                Name = "Tank2",
                CapacityLiters = 2000,
                WaterTemperature = 30,
                ExhibitId = 1
            };
            await controller.AddTank(tank1);
            await controller.AddTank(tank2);
            var tanks = await controller.GetAllTanks();
            Assert.AreEqual(2, tanks.Count);
        }
    }
}
