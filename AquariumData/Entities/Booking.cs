namespace AquariumData.Entities
{
    public class Booking
    {
        public int Id { get; set; }

        public DateTime BookingDate { get; set; }

        public int UserEmployeeId { get; set; }

        public Userr? Employee { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public override string ToString()
        {
            return $"{BookingDate:yyyy-MM-dd}";
        }
    }
}
