using AquariumData;
using AquariumData.Entities;
using Microsoft.EntityFrameworkCore;

namespace AquariumController
{
    public class TankController
    {
        private AquariumContext context;
        public TankController()
        {
            context = new AquariumContext();
        }
        public TankController(AquariumContext context)
        {
            this.context = context;
        }
        public async Task<List<Tank>> GetAllTanks()
        {
            return await context.Tanks.Include(t => t.Exhibit).ToListAsync();
        }

        public async Task AddTank(Tank tank)
        {
            if (string.IsNullOrEmpty(tank.Name) || string.IsNullOrWhiteSpace(tank.Name))
            {
                throw new ArgumentException("Invalid tank data.");
            }
            if (tank.CapacityLiters <= 0)
            {
                throw new ArgumentException("Tank capacity must be greater than zero.");
            }
            if (context.Tanks.Any(t => t.Name == tank.Name))
            {
                throw new ArgumentException("A tank with the same name already exists.");
            }
            var exhibitExists = await context.Exhibits.AnyAsync(e => e.Id == tank.ExhibitId);

            if (!exhibitExists)
            {
                throw new ArgumentException("Exhibit does not exist.");
            }
            context.Tanks.Add(tank);
            await context.SaveChangesAsync();
        }

        public async Task UpdateTank(Tank tank)
        {
            var existingTank = await context.Tanks.FindAsync(tank.Id);
            if (existingTank == null)
            {
                throw new ArgumentException("Tank with the specified ID does not exist.");
            }
            if (string.IsNullOrEmpty(tank.Name) || string.IsNullOrWhiteSpace(tank.Name))
            {
                throw new ArgumentException("Invalid tank data.");
            }
            if (tank.CapacityLiters <= 0)
            {
                throw new ArgumentException("Tank capacity must be greater than zero.");
            }
            if (context.Tanks.Any(t => t.Id != tank.Id && t.Name == tank.Name))
            {
                throw new ArgumentException("Another tank with the same name already exists.");
            }
            existingTank.ExhibitId = tank.ExhibitId;
            existingTank.Name = tank.Name;
            existingTank.CapacityLiters = tank.CapacityLiters;
            existingTank.WaterTemperature = tank.WaterTemperature;
            await context.SaveChangesAsync();
        }

        public async Task DeleteTank(int id)
        {
            var tank = await context.Tanks
                .Include(t => t.Animals)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (tank == null)
            {
                throw new ArgumentException("Tank not found.");
            }

            if (tank.Animals.Any())
            {
                throw new InvalidOperationException(
                    "Cannot delete tank that contains animals.");
            }

            context.Tanks.Remove(tank);

            await context.SaveChangesAsync();
        }
    }
}
