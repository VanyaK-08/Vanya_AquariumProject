using AquariumData;
using AquariumData.Entities;
using AquariumData.Enums;

namespace AquariumForms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private async void button2_ClickAsync(object sender, EventArgs e)
        {
            AquariumContext context = new AquariumContext();
            Userr user = new Userr();

            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Enter all the information required!");
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Email cannot be empty!");
                return;
            }
            if (textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("Passwords aren't the same");
                return;
            }
            if (string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Password cannot be empty!");
                return;
            }
            if (context.Users.Any(x => x.Username == textBox1.Text))
            {
                MessageBox.Show("Username already exists!");
                return;
            }
            if (context.Users.Any(x => x.Email == textBox2.Text))
            {
                MessageBox.Show("Email already exists!");
                return;
            }
            
            user.Username = textBox1.Text;
            user.Email = textBox2.Text;
            user.Password = textBox3.Text;
            user.Role = Role.Client;

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            DialogResult = DialogResult.OK;
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
