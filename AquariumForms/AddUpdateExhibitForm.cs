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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AquariumForms
{
    public partial class AddUpdateExhibitForm : Form
    {
        public AddUpdateExhibitForm()
        {
            InitializeComponent();
        }

        public AddUpdateExhibitForm(Exhibit selectedExhibit)
        {
            InitializeComponent();
            editExhibit = selectedExhibit;
            textBox1.Text = editExhibit.Title;
            textBox2.Text = editExhibit.Theme;
            richTextBox1.Text = editExhibit.Description;
            pictureBox1.ImageLocation = editExhibit.ImageUrl;
        }
        public Exhibit Exhibit = null;
        public Exhibit editExhibit = null;

        private void button1_Click(object sender, EventArgs e)
        {
            string title = textBox1.Text;
            string theme = textBox2.Text;
            string description = richTextBox1.Text;
            if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Title cannot be empty!");
                return;
            }
            if (string.IsNullOrEmpty(theme) || string.IsNullOrWhiteSpace(theme))
            {
                MessageBox.Show("Theme cannot be empty!");
                return;
            }
            if (string.IsNullOrEmpty(description) || string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Description cannot be empty!");
                return;
            }
            Exhibit ex = new Exhibit();
            ex.Title = title;
            ex.Theme = theme;
            ex.Description = description;
            FileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            ex.ImageUrl = fileDialog.FileName;
            Exhibit = ex;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
