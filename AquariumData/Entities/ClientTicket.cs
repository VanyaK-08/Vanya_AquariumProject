using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquariumData.Entities
{
    public class ClientTicket
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public Ticket? Ticket { get; set; }
        public int ClientId { get; set; }
        public Userr? Client { get; set; }
    }
}
