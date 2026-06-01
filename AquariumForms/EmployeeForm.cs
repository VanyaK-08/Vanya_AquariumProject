using AquariumController;
using AquariumData.Entities;
using System.Threading.Tasks;

namespace AquariumForms
{
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }
        public EmployeeForm(Userr curEmployee)
        {
            InitializeComponent();
            this.currentEmployee = curEmployee;
        }
        private Userr currentEmployee { get; set; }

        private async void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            AnimalController controller = new AnimalController();
            var checkAnimals = await controller.GetAllAnimals();
            if (checkAnimals.Count == 0)
            {
                MessageBox.Show("No animals added at the moment.");
                this.Show();
                return;
            }
            List<Animal> animals = await controller.GetAllAnimals();
            foreach (Animal animal in animals)
            {
                listBox1.Items.Add(animal.ToString());
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddUpdateAnimalForm animalForm = new AddUpdateAnimalForm();
            AnimalController controller = new AnimalController();
            animalForm.ShowDialog();
            if (animalForm.DialogResult == DialogResult.OK)
            {
                try
                {
                    await controller.AddAnimal(animalForm.Animal);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ExhibitGallary exhibits = new ExhibitGallary();
            exhibits.ShowDialog();
            this.Show();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddUpdateExhibitForm exhibits = new AddUpdateExhibitForm();
            ExhibitController controller = new ExhibitController();
            exhibits.ShowDialog();
            if (exhibits.DialogResult == DialogResult.OK)
            {
                try
                {
                    await controller.AddExhibit(exhibits.Exhibit);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            this.Show();
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            TankController controller = new TankController();
            var checkTanks = await controller.GetAllTanks();
            if (checkTanks.Count == 0)
            {
                MessageBox.Show("No tanks available for booking at the moment.");
                this.Show();
                return;
            }
            List<Tank> tanks = await controller.GetAllTanks();
            foreach (Tank tank in tanks)
            {
                listBox1.Items.Add(tank.ToString());
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddUpdateTankForm tankForm = new AddUpdateTankForm();
            TankController controller = new TankController();
            tankForm.ShowDialog();
            if (tankForm.DialogResult == DialogResult.OK)
            {
                try
                {
                    await controller.AddTank(tankForm.Tank);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            this.Show();
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (listBox1.SelectedIndex != -1)
            {
                Animal selectedAnimal = (Animal)listBox1.Items[listBox1.SelectedIndex];
                try
                {
                    AddUpdateAnimalForm updated = new AddUpdateAnimalForm(selectedAnimal);
                    AnimalController controller = new AnimalController();
                    updated.ShowDialog();
                    if (updated.DialogResult == DialogResult.OK)
                    {
                        try
                        {
                            await controller.UpdateAnimal(updated.Animal);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select an animal to view details.");
            }
            this.Show();
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (listBox1.SelectedIndex != -1)
            {
                Exhibit selectedExhibit = (Exhibit)listBox1.Items[listBox1.SelectedIndex];
                try
                {
                    AddUpdateExhibitForm updated = new AddUpdateExhibitForm(selectedExhibit);
                    ExhibitController controller = new ExhibitController();
                    updated.ShowDialog();
                    if (updated.DialogResult == DialogResult.OK)
                    {
                        try
                        {
                            await controller.UpdateExhibit(updated.Exhibit);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select an exhibit to view details.");
            }
            this.Show();
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (listBox1.SelectedIndex != -1)
            {
                Tank selectedTank = (Tank)listBox1.Items[listBox1.SelectedIndex];
                try
                {
                    AddUpdateTankForm updated = new AddUpdateTankForm(selectedTank);
                    TankController controller = new TankController();
                    updated.ShowDialog();
                    if (updated.DialogResult == DialogResult.OK)
                    {
                        try
                        {
                            await controller.UpdateTank(updated.Tank);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a tank to view details.");
            }
            this.Show();
        }

        private async void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddUpdateBookingForm bookingForm = new AddUpdateBookingForm();
            BookingController controller = new BookingController();
            bookingForm.ShowDialog();
            if (bookingForm.DialogResult == DialogResult.OK)
            {
                try
                {
                    await controller.AddBooking(bookingForm.booking);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            this.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            BookingController controller = new BookingController();
            List<Booking> checkBookings = controller.GetBookingForEmployee(currentEmployee).Result;
            if (checkBookings.Count == 0)
            {
                MessageBox.Show("No tickets available for booking at the moment.");
                this.Show();
                return;
            }
            listBox1.Items.Clear();
            List<Booking> bookings = controller.GetBookingForEmployee(currentEmployee).Result;
            foreach (Booking booking in bookings)
            {
                listBox1.Items.Add(booking.ToString());
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (listBox1.SelectedIndex != -1)
            {
                int index = listBox1.SelectedIndex;
                Booking booking = (Booking)listBox1.Items[index];
                EmployeetBookingsDetailsForm details = new EmployeetBookingsDetailsForm(booking);
                details.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a trip to view details.");
            }
            this.Show();

        }

        private async void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (listBox1.SelectedIndex != -1)
            {
                Booking selectedBooking = (Booking)listBox1.Items[listBox1.SelectedIndex];
                try
                {
                    AddUpdateBookingForm updated = new AddUpdateBookingForm(selectedBooking);
                    BookingController controller = new BookingController();
                    updated.ShowDialog();
                    if (updated.DialogResult == DialogResult.OK)
                    {
                        try
                        {
                            await controller.UpdateBooking(updated.booking);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a booking to view details.");
            }
            this.Show();
        }

        private async void button14_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddUpdateTicketsForm ticketsForm = new AddUpdateTicketsForm();
            TicketController controller = new TicketController();
            ticketsForm.ShowDialog();
            if (ticketsForm.DialogResult == DialogResult.OK)
            {
                try
                {
                    await controller.AddTicket(ticketsForm.Ticket);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            this.Show();
        }

        private async void button15_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            TicketController controller = new TicketController();
            var checkTickets = await controller.GetAllTickets();
            if (checkTickets.Count == 0)
            {
                MessageBox.Show("No tickets available for booking at the moment.");
                this.Show();
                return;
            }
            List<Ticket> tickets = controller.GetAllTickets().Result;
            foreach (Ticket ticket in tickets)
            {
                listBox1.Items.Add(ticket.ToString());
            }
        }

        private async void button16_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (listBox1.SelectedIndex != -1)
            {
                Ticket selectedTicket = (Ticket)listBox1.Items[listBox1.SelectedIndex];
                try
                {
                    AddUpdateTicketsForm updated = new AddUpdateTicketsForm(selectedTicket);
                    TicketController controller = new TicketController();
                    updated.ShowDialog();
                    if (updated.DialogResult == DialogResult.OK)
                    {
                        try
                        {
                            await controller.UpdateTicket(updated.Ticket);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a ticket to view details.");
            }
            this.Show();
        }
    }
}
