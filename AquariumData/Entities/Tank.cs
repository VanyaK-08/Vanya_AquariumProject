using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquariumData.Entities
{
    public class Tank
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int CapacityLiters { get; set; }

        public decimal WaterTemperature { get; set; }

        public int ExhibitId { get; set; }

        public Exhibit? Exhibit { get; set; }

        public ICollection<Animal> Animals { get; set; } = new List<Animal>();

        public override string ToString()
        {
            return $"{Name}, {Exhibit?.Title}";
        }
    }
}
