using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquariumData.Entities
{
    public class BookingClient
    {
        public int BookingId { get; set; }
        public Booking? Booking { get; set; }

        public int ClientId { get; set; }
        public User? Client { get; set; }
    }
}
