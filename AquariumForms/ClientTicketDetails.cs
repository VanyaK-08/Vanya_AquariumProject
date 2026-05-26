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
    public partial class ClientTicketDetails : Form
    {
        public ClientTicketDetails()
        {
            InitializeComponent();
        }
        public ClientTicketDetails(Ticket selectedTicket)
        {
            InitializeComponent();
            this.ticket = selectedTicket;
        }
        public Ticket ticket { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void ClientTicketDetails_Load(object sender, EventArgs e)
        {
            List<Tank> tanks = ticket.Exhibit.Tanks.ToList();
            richTextBox1.Text = $"Exhibit: {ticket.Exhibit}\n" +
                $"Exhibit description: {ticket.Exhibit.Description}\n" +
                $"Price: {ticket.Price}\n" +
                $"Employee: {ticket.Booking.Employee}\n" +
                $"Tank/s: {string.Join("; ", tanks)})";
        }
    }
}
