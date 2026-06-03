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

            context.Tanks.Add(new Tank
            {
                Id = 1,
                Name = "Tank1",
                CapacityLiters = 1000
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
    }
}