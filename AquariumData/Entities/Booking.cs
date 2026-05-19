namespace AquariumData.Entities
{
    public class Booking
    {
        public int Id { get; set; }

        public DateTime BookingDate { get; set; }

        public int UserEmployeeId { get; set; }

        public User? Employee { get; set; }

        public ICollection<BookingClient> BookingClients { get; set; } = new List<BookingClient>();

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
