using AquariumController;
using AquariumData.Entities;

namespace AquariumForms
{
    public partial class ClientBookTicket : Form
    {
        public ClientBookTicket(Userr currentClient)
        {
            InitializeComponent();
            TicketController controller = new TicketController();
            comboBox1.DataSource = controller.GetAllTickets();
            comboBox1.DisplayMember = "ToString";
            this.currentClient1 = currentClient;
        }
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
    }
}
