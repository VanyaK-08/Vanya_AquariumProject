using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquariumData.Entities
{
    public class Exhibit
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Theme { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public ICollection<Tank> Tanks { get; set; } = new List<Tank>();

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

        public string ImageUrl { get; set; } = string.Empty;
    }
}
