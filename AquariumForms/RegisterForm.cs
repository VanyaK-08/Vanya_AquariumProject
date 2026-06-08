using AquariumData;
using AquariumData.Entities;
using AquariumData.Enums;
using Microsoft.VisualBasic.ApplicationServices;
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

            user.Username = textBox1.Text;
            user.Email = textBox2.Text;
            user.Password = textBox3.Text;
            user.Role = (Role)comboBox1.SelectedIndex;
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Enter all the information required!");
                return;
            }
            if (textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("Passwords aren't the same");
                return;
            }
            if (context.Users.Any(x => x.Username == textBox1.Text))
            {
                MessageBox.Show("Username already exists!");
                return;
            }

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            DialogResult = DialogResult.OK;
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Enum.GetValues(typeof(Role));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
