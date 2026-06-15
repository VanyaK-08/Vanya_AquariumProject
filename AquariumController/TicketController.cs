using AquariumData;
using AquariumData.Entities;
using AquariumData.Enums;
using Microsoft.EntityFrameworkCore;

namespace AquariumController
{
    public class TicketController
    {
        private readonly AquariumContext context;

        public TicketController()
        {
            context = new AquariumContext();
        }

        public TicketController(AquariumContext context)
        {
            this.context = context;
        }

        public async Task<List<Ticket>> GetAllTickets()
        {
            return await context.Tickets
                .Include(t => t.Exhibit)
                .Include(t => t.Booking)
                .ToListAsync();
        }

        public async Task AddTicket(Ticket ticket)
        {
            if (ticket.Price <= 0)
            {
                throw new ArgumentException("Ticket price must be greater than zero.");
            }

            if (ticket.VisitDate < DateTime.Now)
            {
                throw new ArgumentException("Visit date cannot be in the past.");
            }

            bool bookingExists = await context.Bookings
                .AnyAsync(b => b.Id == ticket.BookingId);

            if (!bookingExists)
            {
                throw new ArgumentException("Booking does not exist.");
            }

            bool exhibitExists = await context.Exhibits
                .AnyAsync(e => e.Id == ticket.ExhibitId);

            if (!exhibitExists)
            {
                throw new ArgumentException("Exhibit does not exist.");
            }

            context.Tickets.Add(ticket);

            await context.SaveChangesAsync();
        }

        public async Task UpdateTicket(Ticket ticket)
        {
            var existingTicket = await context.Tickets
                .FindAsync(ticket.Id);

            if (existingTicket == null)
            {
                throw new ArgumentException("Ticket not found.");
            }

            if (ticket.Price <= 0)
            {
                throw new ArgumentException("Ticket price must be greater than zero.");
            }

            if (ticket.VisitDate < DateTime.Now)
            {
                throw new ArgumentException("Visit date cannot be in the past.");
            }

            bool bookingExists = await context.Bookings
                .AnyAsync(b => b.Id == ticket.BookingId);

            if (!bookingExists)
            {
                throw new ArgumentException("Booking does not exist.");
            }

            bool exhibitExists = await context.Exhibits
                .AnyAsync(e => e.Id == ticket.ExhibitId);

            if (!exhibitExists)
            {
                throw new ArgumentException("Exhibit does not exist.");
            }

            existingTicket.Price = ticket.Price;
            existingTicket.VisitDate = ticket.VisitDate;
            existingTicket.BookingId = ticket.BookingId;
            existingTicket.ExhibitId = ticket.ExhibitId;

            await context.SaveChangesAsync();
        }

        public async Task DeleteTicket(int id)
        {
            var ticket = await context.Tickets
                .Include(t => t.ClientTickets)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (ticket == null)
            {
                throw new ArgumentException("Ticket not found.");
            }

            if (ticket.ClientTickets.Any())
            {
                throw new InvalidOperationException(
                    "Cannot delete a ticket assigned to clients.");
            }

            context.Tickets.Remove(ticket);

            await context.SaveChangesAsync();
        }
    }
}
