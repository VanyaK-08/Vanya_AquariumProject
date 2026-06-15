namespace AquariumData.Entities
{
    public class Animal
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Species { get; set; } = string.Empty;

        public DateTime ArrivalDate { get; set; }

        public int TankId { get; set; }

        public Tank? Tank { get; set; }
        public override string ToString()
        {
            return $"{Name} ({Species}) - Arrival: {ArrivalDate:dd.MM.yyyy} | Tank: {Tank?.Name}";
        }
    }
}
