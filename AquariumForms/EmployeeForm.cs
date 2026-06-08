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
        AnimalController animalController = new AnimalController();
        BookingController bookingController = new BookingController();
        ExhibitController exhibitController = new ExhibitController();
        TankController tankController = new TankController();
        TicketController ticketController = new TicketController();
        private async void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var checkAnimals = await animalController.GetAllAnimals();
            if (checkAnimals.Count == 0)
            {
                MessageBox.Show("No animals added at the moment.");
                return;
            }
            List<Animal> animals = await animalController.GetAllAnimals();
            foreach (Animal animal in animals)
            {
                listBox1.Items.Add(animal);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddUpdateAnimalForm animalForm = new AddUpdateAnimalForm();
            animalForm.ShowDialog();
            if (animalForm.DialogResult == DialogResult.OK)
            {
                try
                {
                    await animalController.AddAnimal(animalForm.Animal);
                    MessageBox.Show("Animal added successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            this.Show();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var checkExhibits = await exhibitController.GetAllExhibits();
            if (checkExhibits.Count == 0)
            {
                MessageBox.Show("No exhibits added at the moment.");
                return;
            }
            List<Exhibit> exhibits = await exhibitController.GetAllExhibits();
            foreach (Exhibit exhibit in exhibits)
            {
                listBox1.Items.Add(exhibit);
            }
        }


        private async void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddUpdateExhibitForm exhibits = new AddUpdateExhibitForm();
            exhibits.ShowDialog();
            if (exhibits.DialogResult == DialogResult.OK)
            {
                try
                {
                    await exhibitController.AddExhibit(exhibits.Exhibit);
                    MessageBox.Show("Exhibit added successfully!");
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
            var checkTanks = await tankController.GetAllTanks();
            if (checkTanks.Count == 0)
            {
                MessageBox.Show("No tanks available for booking at the moment.");
                return;
            }
            List<Tank> tanks = await tankController.GetAllTanks();
            foreach (Tank tank in tanks)
            {
                listBox1.Items.Add(tank);
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddUpdateTankForm tankForm = new AddUpdateTankForm();
            tankForm.ShowDialog();
            if (tankForm.DialogResult == DialogResult.OK)
            {
                try
                {
                    await tankController.AddTank(tankForm.Tank);
                    MessageBox.Show("Tank added successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
                    updated.ShowDialog();
                    if (updated.DialogResult == DialogResult.OK)
                    {
                        try
                        {
                            await animalController.UpdateAnimal(updated.Animal);
                            MessageBox.Show("Animal updated successfully!");
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
                    updated.ShowDialog();
                    if (updated.DialogResult == DialogResult.OK)
                    {
                        try
                        {
                            await exhibitController.UpdateExhibit(updated.Exhibit);
                            MessageBox.Show("Exhibit updated successfully!");
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
                    updated.ShowDialog();
                    if (updated.DialogResult == DialogResult.OK)
                    {
                        try
                        {
                            await tankController.UpdateTank(updated.Tank);
                            MessageBox.Show("Tank updated successfully!");
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
            AddUpdateBookingForm bookingForm = new AddUpdateBookingForm(currentEmployee);
            bookingForm.ShowDialog();
            if (bookingForm.DialogResult == DialogResult.OK)
            {
                try
                {
                    await bookingController.AddBooking(bookingForm.Booking);
                    MessageBox.Show("Booking added successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            this.Show();
        }

        private async void button10_Click(object sender, EventArgs e)
        {
            List<Booking> checkBookings = await bookingController.GetBookingForEmployee(currentEmployee);
            if (checkBookings.Count == 0)
            {
                MessageBox.Show("No tickets available for booking at the moment.");
                return;
            }
            listBox1.Items.Clear();
            List<Booking> bookings = await bookingController.GetBookingForEmployee(currentEmployee);
            foreach (Booking booking in bookings)
            {
                listBox1.Items.Add(booking);
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
                    updated.ShowDialog();
                    if (updated.DialogResult == DialogResult.OK)
                    {
                        try
                        {
                            await bookingController.UpdateBooking(updated.Booking);
                            MessageBox.Show("Booking updated successfully!");
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
            try
            {
                AddUpdateTicketsForm ticketsForm = new AddUpdateTicketsForm();
                ticketsForm.ShowDialog();
                if (ticketsForm.DialogResult == DialogResult.OK)
                {
                    try
                    {
                        await ticketController.AddTicket(ticketsForm.Ticket);
                        MessageBox.Show("Ticket added successfully!");
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
            this.Show();
        }

        private async void button15_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var checkTickets = await ticketController.GetAllTickets();
            if (checkTickets.Count == 0)
            {
                MessageBox.Show("No tickets available for booking at the moment.");
                return;
            }
            List<Ticket> tickets = await ticketController.GetAllTickets();
            foreach (Ticket ticket in tickets)
            {
                listBox1.Items.Add(ticket);
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
                    updated.ShowDialog();
                    if (updated.DialogResult == DialogResult.OK)
                    {
                        try
                        {
                            await ticketController.UpdateTicket(updated.Ticket);
                            MessageBox.Show("Ticket updated successfully!");
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

        private void EmployeeForm_Load(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
