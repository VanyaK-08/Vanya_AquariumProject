using AquariumData.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquariumData.Entities
{
    public class Userr
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public Role Role { get; set; }

        public ICollection<Booking> EmployeeBookings { get; set; } = new List<Booking>();

        public ICollection<ClientTicket> ClientTickets { get; set; } = new List<ClientTicket>();
    }
}
