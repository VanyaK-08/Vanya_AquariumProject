using AquariumController;
using AquariumData.Entities;

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
        public AddUpdateAnimalForm(Animal selectedAnimal)
        {
            InitializeComponent();
            editAnimal = selectedAnimal;
            textBox1.Text = editAnimal.Name;
            textBox2.Text = editAnimal.Species;
            dateTimePicker1.Value = editAnimal.ArrivalDate;
            TankController controller = new TankController();
            comboBox1.DataSource = controller.GetAllTanks();
            comboBox1.DisplayMember = "ToString";
            comboBox1.SelectedItem = editAnimal.Tank;
        }
        public Animal Animal = null;
        public Animal editAnimal = null;
        private void button1_Click(object sender, EventArgs e)
        {
            AnimalController controller = new AnimalController();
            string name = textBox1.Text;
            string species = textBox2.Text;
            DateTime arrivalDate = dateTimePicker1.Value;
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
            Animal = animal;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
