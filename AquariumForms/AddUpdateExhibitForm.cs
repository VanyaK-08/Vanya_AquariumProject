using AquariumData.Entities;

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
                textBox1.Clear();
                textBox2.Clear();
                richTextBox1.Clear();
                return;
            }
            if (title.Any(char.IsDigit))
            {
                MessageBox.Show("Title cannot contain numbers!");
                textBox1.Clear();
                textBox2.Clear();
                richTextBox1.Clear();
                return;
            }
            if (string.IsNullOrEmpty(theme) || string.IsNullOrWhiteSpace(theme))
            {
                MessageBox.Show("Theme cannot be empty!");
                textBox1.Clear();
                textBox2.Clear();
                richTextBox1.Clear();
                return;
            }
            if (theme.Any(char.IsDigit))
            {
                MessageBox.Show("Theme cannot contain numbers!");
                textBox1.Clear();
                textBox2.Clear();
                richTextBox1.Clear();
                return;
            }
            if (string.IsNullOrEmpty(description) || string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Description cannot be empty!");
                textBox1.Clear();
                textBox2.Clear();
                richTextBox1.Clear();
                return;
            }
            Exhibit ex = new Exhibit();
            ex.Title = title;
            ex.Theme = theme;
            ex.Description = description;
            FileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            ex.ImageUrl = fileDialog.FileName;

            if (editExhibit != null)
            {
                ex.Id = editExhibit.Id;
            }
            Exhibit = ex;
            DialogResult = DialogResult.OK;
            textBox1.Clear();
            textBox2.Clear();
            richTextBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(editExhibit.ImageUrl);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
