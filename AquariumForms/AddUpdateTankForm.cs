using AquariumController;
using AquariumData;
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
    public partial class AddUpdateTankForm : Form
    {
        public AddUpdateTankForm()
        {
            InitializeComponent();
            TankController controller = new TankController();
            comboBox1.DataSource = controller.GetAllTanks();
            comboBox1.DisplayMember = "ToString";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            TankController controller = new TankController();
            string name = textBox1.Text;
            int waterCpacity = int.Parse(textBox2.Text);
            decimal temp = decimal.Parse(textBox3.Text);
            Exhibit exhibit = (Exhibit)comboBox1.SelectedItem;
            int exhibitID = exhibit.Id;
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Name cannot be empty!");
                return;
            }
            if (waterCpacity < 0)
            {
                MessageBox.Show("Water capacity cannot be below 0!");
                return;
            }
            if (exhibitID == 0)
            {
                MessageBox.Show("Error.");
                return;
            }
            Tank tank = new Tank();
            tank.Name = name;
            tank.CapacityLiters = waterCpacity;
            tank.WaterTemperature = temp;
            tank.ExhibitId = exhibitID;
            tank.Exhibit = exhibit;
            try
            {
                await controller.AddTank(tank);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DialogResult = DialogResult.OK;
        }
    }
}
