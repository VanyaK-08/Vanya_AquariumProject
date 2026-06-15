using AquariumData;
using AquariumData.Entities;
using AquariumData.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquariumController
{
    public class ClientTicketController
    {
        private readonly AquariumContext context;

        public ClientTicketController()
        {
            context = new AquariumContext();
        }

        public ClientTicketController(AquariumContext context)
        {
            this.context = context;
        }

        public async Task<List<ClientTicket>> GetAllClientTickets()
        {
            return await context.ClientsTickets
                .Include(ct => ct.Client)
                .Include(ct => ct.Ticket)
                    .ThenInclude(t => t.Exhibit)
                .ToListAsync();
        }

        public async Task<List<ClientTicket>> GetTicketsForClient(int clientId)
        {
            return await context.ClientsTickets
                .Include(ct => ct.Ticket)
                    .ThenInclude(t => t.Exhibit)
                .Where(ct => ct.ClientId == clientId)
                .ToListAsync();
        }

        public async Task BookTicket(int clientId, int ticketId)
        {
            bool ticketExists = await context.Tickets
                .AnyAsync(t => t.Id == ticketId);

            if (!ticketExists)
            {
                throw new ArgumentException("Ticket not found.");
            }

            bool clientExists = await context.Users
                .AnyAsync(u => u.Id == clientId &&
                               u.Role == Role.Client);

            if (!clientExists)
            {
                throw new ArgumentException("Client not found.");
            }

            bool alreadyBooked = await context.ClientsTickets
                .AnyAsync(ct => ct.ClientId == clientId &&
                                ct.TicketId == ticketId);

            if (alreadyBooked)
            {
                throw new ArgumentException(
                    "This client already owns this ticket.");
            }

            var clientTicket = new ClientTicket
            {
                ClientId = clientId,
                TicketId = ticketId
            };

            context.ClientsTickets.Add(clientTicket);

            await context.SaveChangesAsync();
        }

        public async Task UnbookTicket(int clientId, int ticketId)
        {
            var relation = await context.ClientsTickets
                .FirstOrDefaultAsync(ct =>
                    ct.ClientId == clientId &&
                    ct.TicketId == ticketId);

            if (relation == null)
            {
                throw new ArgumentException(
                    "Ticket booking not found.");
            }

            context.ClientsTickets.Remove(relation);

            await context.SaveChangesAsync();
        }

        public async Task DeleteClientTicket(int id)
        {
            var clientTicket = await context.ClientsTickets
                .FindAsync(id);

            if (clientTicket == null)
            {
                throw new ArgumentException(
                    "Client ticket relationship not found.");
            }

            context.ClientsTickets.Remove(clientTicket);

            await context.SaveChangesAsync();
        }
    }
}
