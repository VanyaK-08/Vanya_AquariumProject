using AquariumData.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquariumData.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public Role Role { get; set; }

        public ICollection<Booking> EmployeeBookings { get; set; } = new List<Booking>();

        public ICollection<BookingClient> BookingClients { get; set; } = new List<BookingClient>();

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
