using AquariumData;
using AquariumData.Entities;
using Microsoft.EntityFrameworkCore;

namespace AquariumController
{
    public class ExhibitController
    {
        private AquariumContext context;
        public ExhibitController()
        {
            context = new AquariumContext();
        }
        public ExhibitController(AquariumContext context)
        {
            this.context = context;
        }
        public async Task<List<Exhibit>> GetAllExhibits()
        {
            return await context.Exhibits.ToListAsync();
        }

        public async Task AddExhibit(Exhibit exhibit)
        {
            if (string.IsNullOrEmpty(exhibit.Title) || string.IsNullOrWhiteSpace(exhibit.Title))
            {
                throw new ArgumentException("Invalid exhibit data.");
            }
            if (context.Exhibits.Any(e => e.Title == exhibit.Title))
            {
                throw new ArgumentException("An exhibit with the same title already exists.");
            }
            context.Exhibits.Add(exhibit);
            await context.SaveChangesAsync();
        }

        public async Task UpdateExhibit(Exhibit exhibit)
        {
            var existingExhibit = await context.Exhibits.FindAsync(exhibit.Id);
            if (existingExhibit == null)
            {
                throw new ArgumentException("Exhibit with the specified ID does not exist.");
            }
            if (string.IsNullOrEmpty(exhibit.Title) || string.IsNullOrWhiteSpace(exhibit.Title))
            {
                throw new ArgumentException("Invalid exhibit data.");
            }
            if (context.Exhibits.Any(e => e.Id != exhibit.Id && e.Title == exhibit.Title))
            {
                throw new ArgumentException("Another exhibit with the same title already exists.");
            }
            existingExhibit.Id = exhibit.Id;
            existingExhibit.Title = exhibit.Title;
            existingExhibit.Theme = exhibit.Theme;
            existingExhibit.Description = exhibit.Description;
            existingExhibit.ImageUrl = exhibit.ImageUrl;
            await context.SaveChangesAsync();
        }
    }
}
