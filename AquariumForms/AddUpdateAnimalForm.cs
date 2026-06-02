using AquariumController;
using AquariumData.Entities;

namespace AquariumForms
{
    public partial class AddUpdateAnimalForm : Form
    {
        public AddUpdateAnimalForm()
        {
            InitializeComponent();
            
            comboBox1.DisplayMember = "ToString";
        }
        TankController tankcontroller = new TankController();
        AnimalController animalcontroller = new AnimalController();
        public AddUpdateAnimalForm(Animal selectedAnimal)
        {
            InitializeComponent();
            editAnimal = selectedAnimal;
            textBox1.Text = editAnimal.Name;
            textBox2.Text = editAnimal.Species;
            dateTimePicker1.Value = editAnimal.ArrivalDate;
            
            
            comboBox1.DisplayMember = "ToString";
            comboBox1.SelectedItem = editAnimal.Tank;
        }
        public Animal Animal = null;
        public Animal editAnimal = null;
        private void button1_Click(object sender, EventArgs e)
        {
            
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

            if (editAnimal != null)
            {
                animal.Id = editAnimal.Id;
            }

            animal.Name = name;
            animal.Species = species;
            animal.ArrivalDate = arrivalDate;
            animal.TankId = tankId;

            Animal = animal;
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private async void AddUpdateAnimalForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = await tankcontroller.GetAllTanks();
        }
    }
}
