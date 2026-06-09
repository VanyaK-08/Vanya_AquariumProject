using AquariumController;
using AquariumData;
using AquariumData.Entities;
using TestControllers.Saving;

namespace TestControllers.Tests
{
    public class AnimalControlTests
    {
        private AnimalController controller;
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

            context.Tanks.Add(new Tank
            {
                Id = 1,
                Name = "Tank1",
                CapacityLiters = 1000,
                WaterTemperature = 25,
                ExhibitId = 1
            });

            context.SaveChanges();

            controller = new AnimalController(context);
        }

        [Test]
        public async Task AddAnimal_SuccessfullyAddAnimal()
        {
            Animal animal = new Animal
            {
                Name = "Nemo",
                Species = "Clownfish",
                ArrivalDate = DateTime.Parse("2026-01-01"),
                TankId = 1
            };

            await controller.AddAnimal(animal);
            var animals = await controller.GetAllAnimals();
            var addedAnimal = animals.FirstOrDefault();
            Assert.IsNotNull(addedAnimal);
            Assert.AreEqual("Nemo", addedAnimal.Name);
            Assert.AreEqual("Clownfish", addedAnimal.Species);
            Assert.AreEqual(DateTime.Parse("2026-01-01"), addedAnimal.ArrivalDate);
        }
        [Test]
        public void AddAnimal_InvalidName_ThrowsException()
        {
            Animal animal = new Animal
            {
                Name = "",
                Species = "Clownfish",
                ArrivalDate = DateTime.Parse("2026-01-01"),
                TankId = 1
            };
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.AddAnimal(animal));
        }
        [Test]
        public void AddAnimal_InvalidSpecies_ThrowsException()
        {
            Animal animal = new Animal
            {
                Name = "Nemo",
                Species = "",
                ArrivalDate = DateTime.Parse("2026-01-01"),
                TankId = 1
            };
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.AddAnimal(animal));
        }
        [Test]
        public void AddAnimal_FutureArrivalDate_ThrowsException()
        {
            Animal animal = new Animal
            {
                Name = "Nemo",
                Species = "Clownfish",
                ArrivalDate = DateTime.Now.AddDays(1),
                TankId = 1
            };
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.AddAnimal(animal));
        }
        [Test]
        public void AddAnimal_NonExistentTank_ThrowsException()
        {
            Animal animal = new Animal
            {
                Name = "Nemo",
                Species = "Clownfish",
                ArrivalDate = DateTime.Parse("2026-01-01"),
                TankId = 999
            };
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.AddAnimal(animal));
        }
        [Test]
        public async Task AddAnimal_DuplicateAnimal_ThrowsException()
        {
            Animal animal1 = new Animal
            {
                Name = "Nemo",
                Species = "Clownfish",
                ArrivalDate = DateTime.Parse("2026-01-01"),
                TankId = 1
            };
            await controller.AddAnimal(animal1);
            Animal animal2 = new Animal
            {
                Name = "Nemo",
                Species = "Clownfish",
                ArrivalDate = DateTime.Parse("2026-01-01"),
                TankId = 1
            };
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.AddAnimal(animal2));
        }
        [Test]
        public async Task UpdateAnimal_NonExistentAnimal_ThrowsException()
        {
            Animal animal = new Animal
            {
                Id = 999,
                Name = "Nemo",
                Species = "Clownfish",
                ArrivalDate = DateTime.Parse("2026-01-01"),
                TankId = 1
            };
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.UpdateAnimal(animal));
        }
        [Test]
        public async Task UpdateAnimal_SuccessfullyUpdateAnimal()
        {
            Animal animal = new Animal
            {
                Name = "Nemo",
                Species = "Clownfish",
                ArrivalDate = DateTime.Parse("2026-01-01"),
                TankId = 1
            };
            await controller.AddAnimal(animal);
            var animals = await controller.GetAllAnimals();
            var addedAnimal = animals.FirstOrDefault();
            Assert.IsNotNull(addedAnimal);
            addedAnimal.Name = "Dory";
            addedAnimal.Species = "Blue Tang";
            await controller.UpdateAnimal(addedAnimal);
            var updatedAnimals = await controller.GetAllAnimals();
            var updatedAnimal = updatedAnimals.FirstOrDefault();
            Assert.IsNotNull(updatedAnimal);
            Assert.AreEqual("Dory", updatedAnimal.Name);
            Assert.AreEqual("Blue Tang", updatedAnimal.Species);
        }
        [Test]
        public async Task UpdateAnimal_InvalidName_ThrowsException()
        {
            Animal animal = new Animal
            {
                Name = "Nemo",
                Species = "Clownfish",
                ArrivalDate = DateTime.Parse("2026-01-01"),
                TankId = 1
            };
            await controller.AddAnimal(animal);
            var animals = await controller.GetAllAnimals();
            var addedAnimal = animals.FirstOrDefault();
            Assert.IsNotNull(addedAnimal);
            addedAnimal.Name = "";
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.UpdateAnimal(addedAnimal));
        }
        [Test]
        public async Task UpdateAnimal_InvalidSpecies_ThrowsException()
        {
            Animal animal = new Animal
            {
                Name = "Nemo",
                Species = "Clownfish",
                ArrivalDate = DateTime.Parse("2026-01-01"),
                TankId = 1
            };
            await controller.AddAnimal(animal);
            var animals = await controller.GetAllAnimals();
            var addedAnimal = animals.FirstOrDefault();
            Assert.IsNotNull(addedAnimal);
            addedAnimal.Species = "";
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.UpdateAnimal(addedAnimal));
        }

        [Test]
        public async Task UpdateAnimal_FutureArrivalDate_ThrowsException()
        {
            Animal animal = new Animal
            {
                Name = "Nemo",
                Species = "Clownfish",
                ArrivalDate = DateTime.Parse("2026-01-01"),
                TankId = 1
            };
            await controller.AddAnimal(animal);
            var animals = await controller.GetAllAnimals();
            var addedAnimal = animals.FirstOrDefault();
            Assert.IsNotNull(addedAnimal);
            addedAnimal.ArrivalDate = DateTime.Parse("2027-01-01");
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.UpdateAnimal(addedAnimal));
        }
        [Test]
        public async Task UpdateAnimal_NonExistentTank_ThrowsException()
        {
            Animal animal = new Animal
            {
                Name = "Nemo",
                Species = "Clownfish",
                ArrivalDate = DateTime.Parse("2026-01-01"),
                TankId = 1
            };
            await controller.AddAnimal(animal);
            var animals = await controller.GetAllAnimals();
            var addedAnimal = animals.FirstOrDefault();
            Assert.IsNotNull(addedAnimal);
            addedAnimal.TankId = 999;
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.UpdateAnimal(addedAnimal));
        }
        [Test]
        public async Task UpdateAnimal_DuplicateAnimal_ThrowsException()
        {
            Animal animal1 = new Animal
            {
                Name = "Nemo",
                Species = "Clownfish",
                ArrivalDate = DateTime.Parse("2026-01-01"),
                TankId = 1
            };
            await controller.AddAnimal(animal1);
            Animal animal2 = new Animal
            {
                Name = "Dory",
                Species = "Blue Tang",
                ArrivalDate = DateTime.Parse("2026-01-01"),
                TankId = 1
            };
            await controller.AddAnimal(animal2);
            var animals = await controller.GetAllAnimals();
            var addedAnimal1 = animals.FirstOrDefault(a => a.Name == "Nemo");
            var addedAnimal2 = animals.FirstOrDefault(a => a.Name == "Dory");
            Assert.IsNotNull(addedAnimal1);
            Assert.IsNotNull(addedAnimal2);
            addedAnimal2.Name = "Nemo";
            addedAnimal2.Species = "Clownfish";
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.UpdateAnimal(addedAnimal2));
        }
        [Test]
        public async Task GetAllAnimals_ReturnsAllAnimals()
        {
            Animal animal1 = new Animal
            {
                Name = "Nemo",
                Species = "Clownfish",
                ArrivalDate = DateTime.Parse("2026-01-01"),
                TankId = 1
            };
            await controller.AddAnimal(animal1);
            Animal animal2 = new Animal
            {
                Name = "Dory",
                Species = "Blue Tang",
                ArrivalDate = DateTime.Parse("2026-01-01"),
                TankId = 1
            };
            await controller.AddAnimal(animal2);
            var animals = await controller.GetAllAnimals();
            Assert.AreEqual(2, animals.Count);
        }
    }
}