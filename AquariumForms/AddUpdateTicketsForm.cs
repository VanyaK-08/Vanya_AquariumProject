using AquariumController;
using AquariumData.Entities;

namespace AquariumForms
{
    public partial class AddUpdateTicketsForm : Form
    {
        public AddUpdateTicketsForm()
        {
            InitializeComponent();
            BookingController bookingcontroller = new BookingController();
            comboBox1.DataSource = bookingcontroller.GetAllBookings();
            comboBox1.DisplayMember = "ToString";
            ExhibitController exhibitController = new ExhibitController();
            comboBox2.DataSource = exhibitController.GetAllExhibits();
            comboBox2.DisplayMember = "ToString";
        }
        public AddUpdateTicketsForm(Ticket selectedTicket)
        {
            InitializeComponent();
            editTicket = selectedTicket;
            BookingController bookingcontroller = new BookingController();
            comboBox1.DataSource = bookingcontroller.GetAllBookings();
            comboBox1.DisplayMember = "ToString";
            ExhibitController exhibitController = new ExhibitController();
            comboBox2.DataSource = exhibitController.GetAllExhibits();
            comboBox2.DisplayMember = "ToString";
            numericUpDown1.Value = editTicket.Price;
            dateTimePicker1.Value = editTicket.VisitDate;
            comboBox1.SelectedItem = editTicket.Booking;
            comboBox2.SelectedItem = editTicket.Exhibit;
        }
        public Ticket Ticket = null;
        public Ticket editTicket = null;

        private void button1_Click(object sender, EventArgs e)
        {
            int price = (int)numericUpDown1.Value;
            DateTime visitDate = dateTimePicker1.Value;
            Booking booking = (Booking)comboBox1.SelectedItem;
            Exhibit exhibit = (Exhibit)comboBox2.SelectedItem;
            if (price < 0)
            {
                MessageBox.Show("Price cannot be negative.");
                return;
            }
            if (visitDate < DateTime.Now)
            {
                MessageBox.Show("Visit date cannot be in the past.");
                return;
            }
            if (booking == null)
            {
                MessageBox.Show("Please select a booking.");
                return;
            }
            if (exhibit == null)
            {
                MessageBox.Show("Please select an exhibit.");
                return;
            }
            if (booking.Id == 0 || exhibit.Id == 0)
            {
                MessageBox.Show("Error.");
                return;
            }
            TicketController controller = new TicketController();
            Ticket ticket = new Ticket
            {
                Price = price,
                VisitDate = visitDate,
                BookingId = booking.Id,
                ExhibitId = exhibit.Id
            };
            Ticket = ticket;
        }
    }
}
