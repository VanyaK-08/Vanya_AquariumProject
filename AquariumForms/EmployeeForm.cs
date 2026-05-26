using AquariumController;
using AquariumData.Entities;

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

        private async void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            AnimalController controller = new AnimalController();
            List<Animal> animals = await controller.GetAllAnimals();
            foreach (Animal animal in animals)
            {
                listBox1.Items.Add(animal.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddUpdateAnimalForm animalForm = new AddUpdateAnimalForm();
            animalForm.ShowDialog();
            if (animalForm.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("Animal added successfully.");
            }
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ExhibitGallary exhibits = new ExhibitGallary();
            exhibits.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddUpdateExhibitForm exhibits = new AddUpdateExhibitForm();
            exhibits.ShowDialog();
            if (exhibits.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("Exhibit added succesfully!");
            }
            this.Show();
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            TankController controller = new TankController();
            List<Tank> tanks = await controller.GetAllTanks();
            foreach (Tank tank in tanks)
            {
                listBox1.Items.Add(tank.ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddUpdateTankForm tankForm = new AddUpdateTankForm();
            tankForm.ShowDialog();
            if (tankForm.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("Tank added succesfully!");
            }
            this.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
