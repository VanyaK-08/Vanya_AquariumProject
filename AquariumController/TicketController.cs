using AquariumData;
using AquariumData.Entities;
using AquariumData.Enums;
using Microsoft.EntityFrameworkCore;

namespace AquariumController
{
    public class TicketController
    {
        AquariumContext context = new AquariumContext();
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
            var checkBooking = await context.Bookings.FindAsync(ticket.BookingId);
            if (checkBooking == null)
            {
                throw new ArgumentException("Booking with the specified ID does not exist.");
            }
            if (checkBooking == null)
            {
                throw new ArgumentException("Booking with the specified ID does not exist.");
            }
            ticket.ClientId = null;
            context.Tickets.Add(ticket);
            await context.SaveChangesAsync();
        }

        public async Task UpdateTicket(Ticket ticket)
        {
            var existingTicket = await context.Tickets.FindAsync(ticket.Id);
            if (existingTicket == null)
            {
                throw new ArgumentException("Ticket with the specified ID does not exist.");
            }
            if (ticket.Price <= 0)
            {
                throw new ArgumentException("Ticket price must be greater than zero.");
            }
            if (ticket.VisitDate < DateTime.Now)
            {
                throw new ArgumentException("Visit date cannot be in the past.");
            }
            var checkBooking = await context.Bookings.FindAsync(ticket.BookingId);
            if (checkBooking == null)
            {
                throw new ArgumentException("Booking with the specified ID does not exist.");
            }
            existingTicket.Price = ticket.Price;
            existingTicket.VisitDate = ticket.VisitDate;
            existingTicket.BookingId = ticket.BookingId;
            existingTicket.ClientId = null;
            await context.SaveChangesAsync();
        }

        public async Task BookTicketClient(Ticket ticket, Userr client)
        {
            var existingTicket = await context.Tickets.FindAsync(ticket.Id);
            if (existingTicket == null)
            {
                throw new ArgumentException("Ticket with the specified ID does not exist.");
            }
            var existingClient = await context.Users.Where(c => c.Role == Role.Client && c.Id == client.Id).FirstOrDefaultAsync();
            if (existingClient == null)
            {
                throw new ArgumentException("Client with the specified ID does not exist.");
            }
            existingTicket.ClientId = client.Id;
            await context.SaveChangesAsync();
        }

        public async Task UnbookTicketClient(Ticket ticket)
        {
            var existingTicket = await context.Tickets.FindAsync(ticket.Id);
            if (existingTicket == null)
            {
                throw new ArgumentException("Ticket with the specified ID does not exist.");
            }
            existingTicket.ClientId = null;
            await context.SaveChangesAsync();
        }

        public async Task<List<Ticket>> GetAllTickets()
        {
            return await context.Tickets.Include(t => t.Exhibit).ToListAsync();
        }
    }
}
