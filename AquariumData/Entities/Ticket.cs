using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquariumData.Entities
{
    public class Ticket
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public DateTime VisitDate { get; set; }

        public int BookingId { get; set; }

        public Booking? Booking { get; set; }

        public int ExhibitId { get; set; }

        public Exhibit? Exhibit { get; set; }

        public int? ClientId { get; set; }

        public Userr? Client { get; set; }

        public override string ToString()
            {
                return $"{Exhibit.Title} - {Price:f2}";
        }
    }
}
