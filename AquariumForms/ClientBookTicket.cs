using AquariumController;
using AquariumData.Entities;

namespace AquariumForms
{
    public partial class ClientBookTicket : Form
    {
        public ClientBookTicket(Userr currentClient)
        {
            InitializeComponent();
            
            comboBox1.DisplayMember = "ToString";
            this.currentClient1 = currentClient;
        }
        TicketController ticketController = new TicketController();
        private Userr currentClient1 { get; set; }
        public Ticket Ticket = null;
        private void button1_Click(object sender, EventArgs e)
        {
            Ticket ticket = (Ticket)comboBox1.SelectedItem;
            if (ticket == null)
            {
                MessageBox.Show("Please select a ticket to book.");
                return;
            }
            Ticket = ticket;
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private async void ClientBookTicket_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = await ticketController.GetAllTickets();
        }
    }
}
