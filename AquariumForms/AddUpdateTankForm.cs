using AquariumController;
using AquariumData.Entities;

namespace AquariumForms
{
    public partial class AddUpdateTankForm : Form
    {
        public AddUpdateTankForm()
        {
            InitializeComponent();

            comboBox1.DisplayMember = "ToString";
        }
        TankController controller = new TankController();
        ExhibitController exhibitController = new ExhibitController();
        public AddUpdateTankForm(Tank tank)
        {
            InitializeComponent();
            editTank = tank;

            comboBox1.DisplayMember = "ToString";
            textBox1.Text = editTank.Name;
            textBox2.Text = editTank.CapacityLiters.ToString();
            textBox3.Text = editTank.WaterTemperature.ToString();
            comboBox1.SelectedItem = editTank.Exhibit;
        }
        public Tank Tank = null;
        public Tank editTank = null;

        private void button1_Click(object sender, EventArgs e)
        {

            string name = textBox1.Text;
            int waterCpacity = int.Parse(textBox2.Text);
            decimal temp = decimal.Parse(textBox3.Text);
            Exhibit exhibit = comboBox1.SelectedItem as Exhibit;

            if (exhibit == null)
            {
                MessageBox.Show("Please select an exhibit.");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                comboBox1.SelectedIndex = -1;
                return;
            }
            int exhibitID = exhibit.Id;
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Name cannot be empty!");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                comboBox1.SelectedIndex = -1;
                return;
            }
            if (name.Any(char.IsDigit))
            {
                MessageBox.Show("Name cannot contain numbers!");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                comboBox1.SelectedIndex = -1;
                return;
            }
            if (waterCpacity < 0)
            {
                MessageBox.Show("Water capacity cannot be below 0!");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                comboBox1.SelectedIndex = -1;
                return;
            }
            if (exhibitID == 0)
            {
                MessageBox.Show("Error.");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                comboBox1.SelectedIndex = -1;
                return;
            }
            Tank tank = new Tank();
            tank.Name = name;
            tank.CapacityLiters = waterCpacity;
            tank.WaterTemperature = temp;
            tank.ExhibitId = exhibitID;
            if (editTank != null)
            {
                tank.Id = editTank.Id;
            }
            Tank = tank;
            DialogResult = DialogResult.OK;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private async void AddUpdateTankForm_Load(object sender, EventArgs e)
        {

            comboBox1.DataSource = await exhibitController.GetAllExhibits();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
