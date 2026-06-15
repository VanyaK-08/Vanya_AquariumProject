using AquariumController;
using AquariumData.Entities;

namespace AquariumForms
{
    public partial class AddUpdateTicketsForm : Form
    {
        public AddUpdateTicketsForm()
        {
            InitializeComponent();


            comboBox1.DisplayMember = "ToString";


            comboBox2.DisplayMember = "ToString";
        }
        BookingController bookingcontroller = new BookingController();
        ExhibitController exhibitController = new ExhibitController();
        public AddUpdateTicketsForm(Ticket selectedTicket)
        {
            InitializeComponent();
            editTicket = selectedTicket;


            comboBox1.DisplayMember = "ToString";


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
                numericUpDown1.Value = 10;
                dateTimePicker1.Value = DateTime.Now;
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                return;
            }
            if (visitDate < DateTime.Now)
            {
                MessageBox.Show("Visit date cannot be in the past or current.");
                numericUpDown1.Value = 10;
                dateTimePicker1.Value = DateTime.Now;
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                return;
            }
            if (booking == null)
            {
                MessageBox.Show("Please select a booking.");
                numericUpDown1.Value = 10;
                dateTimePicker1.Value = DateTime.Now;
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                return;
            }
            if (exhibit == null)
            {
                MessageBox.Show("Please select an exhibit.");
                numericUpDown1.Value = 10;
                dateTimePicker1.Value = DateTime.Now;
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                return;
            }
            if (booking.Id == 0 || exhibit.Id == 0)
            {
                MessageBox.Show("Error.");
                numericUpDown1.Value = 10;
                dateTimePicker1.Value = DateTime.Now;
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                return;
            }
            Ticket ticket = new Ticket
            {
                Price = price,
                VisitDate = visitDate,
                BookingId = booking.Id,
                ExhibitId = exhibit.Id
            };
            if (editTicket != null)
            {
                ticket.Id = editTicket.Id;
            }
            Ticket = ticket;
            DialogResult = DialogResult.OK;
            numericUpDown1.Value = 10;
            dateTimePicker1.Value = DateTime.Now;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
        }

        private async void AddUpdateTicketsForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = await bookingcontroller.GetAllBookings();
            comboBox2.DataSource = await exhibitController.GetAllExhibits();

            numericUpDown1.Value = 10;
            dateTimePicker1.Value = DateTime.Now;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
