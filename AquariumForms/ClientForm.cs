using AquariumController;
using AquariumData.Entities;
using System.Threading.Tasks;

namespace AquariumForms
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
        }
        public ClientForm(Userr currentClient)
        {
            InitializeComponent();
            this.currentClient1 = currentClient;
        }
        TicketController ticketController = new TicketController();
        private Userr currentClient1 { get; set; }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ExhibitGallary exhibitGallaryForm = new ExhibitGallary();
            exhibitGallaryForm.ShowDialog();
            this.Show();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClientTicketController controller = new ClientTicketController();
            TicketController ticketController = new TicketController();
            var checkTickets = await ticketController.GetAllTickets();
            if (checkTickets.Count == 0)
            {
                MessageBox.Show("No tickets available for booking at the moment.\nPlease wait until tickets are released by an employee.");
                this.Show();
                return;
            }
            ClientBookTicket bookTicket = new ClientBookTicket(currentClient1);
            bookTicket.ShowDialog();
            if (bookTicket.DialogResult == DialogResult.OK)
            {
                try
                {
                    await controller.BookTicket(currentClient1.Id, bookTicket.Ticket.Id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            this.Show();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to unbook this ticket?",
                    "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int index = listBox1.SelectedIndex;
                    Ticket ticket = (Ticket)listBox1.Items[index];
                    TicketController controller = new TicketController();
                    ClientTicketController ticketController = new ClientTicketController();
                    await ticketController.UnbookTicket(currentClient1.Id, ticket.Id);
                    listBox1.Items.RemoveAt(index);
                    MessageBox.Show("Ticket unbooked successfully.");
                }
            }
            else
            {
                MessageBox.Show("Please select a ticket to unbook.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (listBox1.SelectedIndex != -1)
            {

                int index = listBox1.SelectedIndex;
                Ticket ticket = (Ticket)listBox1.Items[index];
                ClientTicketDetails details = new ClientTicketDetails(ticket);
                details.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a trip to view details.");
            }
            this.Show();
        }

        private async void ClientForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            ClientForm_Load(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
