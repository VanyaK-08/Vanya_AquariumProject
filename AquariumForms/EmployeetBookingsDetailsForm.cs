using AquariumData;
using AquariumData.Entities;

namespace AquariumForms
{
    public partial class EmployeetBookingsDetailsForm : Form
    {
        public EmployeetBookingsDetailsForm()
        {
            InitializeComponent();
        }
        public EmployeetBookingsDetailsForm(Booking selectedBooking)
        {
            InitializeComponent();
            this.booking = selectedBooking;
        }
        public Booking booking { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void EmployeetBookingsDetailsForm_Load(object sender, EventArgs e)
        {
            List<Ticket> tickets = booking.Tickets.Where(t=>t.BookingId == booking.Id).ToList();
            richTextBox1.Text = $"Booking date: {booking.BookingDate}";
            if (tickets.Count > 0)
            {
                richTextBox1.Text += $"\nTickets:\n";
                foreach (var ticket in tickets)
                {
                    richTextBox1.Text += $"Exhibit: {ticket.Exhibit}\n" +
                        $"Exhibit description: {ticket.Exhibit.Description}\n" +
                        $"Price: {ticket.Price}\n" +
                        $"Employee: {ticket.Booking.Employee}\n" +
                        $"Tank/s: {string.Join("; ", ticket.Exhibit.Tanks)}\n\n";
                }
            }
            else
            {
                richTextBox1.Text += "\nNo tickets booked for this booking.";
            }
        }
    }
}
