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
        private Userr currentClient1 { get; set; }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ExhibitGallary exhibitGallaryForm = new ExhibitGallary();
            exhibitGallaryForm.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClientBookTicket bookTicket = new ClientBookTicket(currentClient1);
            bookTicket.ShowDialog();
            if (bookTicket.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("Ticket booked successfully.");
            }
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
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
                    controller.UnbookTicketClient(ticket);
                    listBox1.Items.RemoveAt(index);
                    MessageBox.Show("Ticket unbooked successfully.");
                }
            }
            else
            {
                MessageBox.Show("Please select a ticket to unbook.");
            }
            this.Show();
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
    }
}
