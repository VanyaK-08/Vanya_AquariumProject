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
    public partial class AddUpdateAnimalForm : Form
    {
        public AddUpdateAnimalForm()
        {
            InitializeComponent();
            TankController controller = new TankController();
            comboBox1.DataSource = controller.GetAllTanks();
            comboBox1.DisplayMember = "ToString";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            AnimalController controller = new AnimalController();
            string name = textBox1.Text;
            string species = textBox2.Text;
            DateTime arrivalDate = DateTime.Now;
            Tank tank = (Tank)comboBox1.SelectedItem;
            int tankId = tank.Id;
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Name cannot be empty!");
                return;
            }
            if (string.IsNullOrEmpty(species) || string.IsNullOrWhiteSpace(species))
            {
                MessageBox.Show("Species cannot be empty!");
                return;
            }
            if (arrivalDate > DateTime.Now)
            {
                MessageBox.Show("Arrival date cannot be in the future.");
                return;
            }
            if (tankId == 0)
            {
                MessageBox.Show("Error.");
                return;
            }
            Animal animal = new Animal();
            animal.Name = name;
            animal.Species = species;
            animal.ArrivalDate = arrivalDate;
            animal.TankId = tankId;
            animal.Tank = tank;
            try
            {
                await controller.AddAnimal(animal);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
