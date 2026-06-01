using AquariumData.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

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
            List<Ticket> tickets = booking.Tickets.ToList();
            richTextBox1.Text = $"Employee: {booking.Employee}\n" +
                $"Booking date: {booking.BookingDate}\n" +
                $"Ticket/s: {string.Join("; ", tickets)}";
        }
    }
}
