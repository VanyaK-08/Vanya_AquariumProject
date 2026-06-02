using AquariumController;
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

namespace AquariumForms
{
    public partial class AddUpdateBookingForm : Form
    {
        public AddUpdateBookingForm()
        {
            InitializeComponent();
        }
        BookingController controller = new BookingController();
        public AddUpdateBookingForm(Userr curEmployee)
        {
            InitializeComponent();
            this.currentEmployee = curEmployee;
        }
        public AddUpdateBookingForm(Booking selectedBooking)
        {
            InitializeComponent();
            this.editBooking = selectedBooking;
            dateTimePicker1.Value = editBooking.BookingDate;
        }
        private Userr currentEmployee { get; set; }
        public Booking booking = null;
        public Booking editBooking = null;
        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value < DateTime.Now)
            {
                MessageBox.Show("Booking date cannot be in the past.");
                return;
            }

            Booking newBooking = new Booking
            {
                BookingDate = dateTimePicker1.Value
            };

            if (editBooking != null)
            {
                newBooking.UserEmployeeId = editBooking.UserEmployeeId;
                newBooking.Id = editBooking.Id;
            }
            else
            {
                newBooking.UserEmployeeId = currentEmployee.Id;
            }
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
