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
        public ICollection<ClientTicket> ClientTickets { get; set; } = new List<ClientTicket>();

        public override string ToString()
        {
            return $"{Exhibit?.Title} - {Price:F2}";
        }
    }
}
