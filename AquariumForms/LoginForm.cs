using AquariumController;
using AquariumData.Entities;
using AquariumData.Enums;


namespace AquariumForms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

        }
        private Userr CurrentClient { get; set; }
        private Userr CurrentEmployee { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerform = new RegisterForm();
            DialogResult res = registerform.ShowDialog();
            if (res == DialogResult.OK) MessageBox.Show("successful registration!");
            this.Show();
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            LoggingController controller = new LoggingController();
            Userr user = await controller.Login(textBox1.Text, textBox2.Text, textBox3.Text);
            if (user == null)
            {
                MessageBox.Show("Invalid credentials. Please try again.");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                return;
            }
            this.Hide();
            if (user.Role == Role.Employee)
            {
                CurrentEmployee = user;
                EmployeeForm employeeForm = new EmployeeForm(CurrentEmployee);
                employeeForm.ShowDialog();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
            if (user.Role == Role.Client)
            {
                CurrentClient = user;
                ClientForm clientForm = new ClientForm(CurrentClient);

                clientForm.ShowDialog();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
            this.Show();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
