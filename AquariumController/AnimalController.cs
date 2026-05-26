using AquariumData;
using AquariumData.Entities;
using Microsoft.EntityFrameworkCore;

namespace AquariumController
{
    public class AnimalController
    {
        AquariumContext context = new AquariumContext();
        public async Task<List<Animal>> GetAllAnimals()
        {
            return await context.Animals.Include(a=>a.Tank).ToListAsync();
        }

        public async Task AddAnimal(Animal animal)
        {
            if (string.IsNullOrEmpty(animal.Name) || string.IsNullOrWhiteSpace(animal.Name)
                || string.IsNullOrEmpty(animal.Species) || string.IsNullOrWhiteSpace(animal.Species))
            {
                throw new ArgumentException("Invalid animal data.");
            }
            if (animal.ArrivalDate > DateTime.Now)
            {
                throw new ArgumentException("Arrival date cannot be in the future.");
            }
            if (!context.Tanks.Any(t => t.Id == animal.TankId))
            {
                throw new ArgumentException("Tank with the specified ID does not exist.");
            }
            if (context.Animals.Any(a => a.Name == animal.Name && a.Species == animal.Species && a.TankId == animal.TankId))
            {
                throw new ArgumentException("An animal with the same name, species, and tank already exists.");
            }
            context.Animals.Add(animal);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAnimal(Animal animal)
        {
            var existingAnimal = await context.Animals.FindAsync(animal.Id);
            if (existingAnimal == null)
            {
                throw new ArgumentException("Animal with the specified ID does not exist.");
            }
            if (string.IsNullOrEmpty(animal.Name) || string.IsNullOrWhiteSpace(animal.Name)
                || string.IsNullOrEmpty(animal.Species) || string.IsNullOrWhiteSpace(animal.Species))
            {
                throw new ArgumentException("Invalid animal data.");
            }
            if (animal.ArrivalDate > DateTime.Now)
            {
                throw new ArgumentException("Arrival date cannot be in the future.");
            }
            if (!context.Tanks.Any(t => t.Id == animal.TankId))
            {
                throw new ArgumentException("Tank with the specified ID does not exist.");
            }
            if (context.Animals.Any(a => a.Id != animal.Id && a.Name == animal.Name && a.Species == animal.Species && a.TankId == animal.TankId))
            {
                throw new ArgumentException("Another animal with the same name, species, and tank already exists.");
            }
            existingAnimal.Name = animal.Name;
            existingAnimal.Species = animal.Species;
            existingAnimal.ArrivalDate = animal.ArrivalDate;
            existingAnimal.TankId = animal.TankId;
            await context.SaveChangesAsync();
        }
    }
}
