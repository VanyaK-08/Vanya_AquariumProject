using AquariumController;
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
    public partial class ExhibitGallary : Form
    {
        public ExhibitGallary()
        {
            InitializeComponent();
        }

        private async void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private async void ExhibitGallary_Load(object sender, EventArgs e)
        {
            await LoadExhibits();
        }

        private async Task LoadExhibits()
        {
            panel1.Controls.Clear();

            ExhibitController exhibitController = new ExhibitController();
            var exhibits = await exhibitController.GetAllExhibits();
            if (exhibits == null || exhibits.Count == 0)
            {
                MessageBox.Show("There's currently no working exhibits! :(");
                DialogResult = DialogResult.OK;
                return;
            }

            foreach (var exhibit in exhibits)
            {
                var panel = new Panel
                {
                    Dock = DockStyle.Top,
                    Height = 100,
                    Padding = new Padding(5)
                };

                var pictureBox = new PictureBox
                {
                    Image = Image.FromFile(exhibit.ImageUrl),
                    Size = new Size(100, 130),
                    Location = new Point(5, 10),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                panel.Controls.Add(pictureBox);
                panel1.Controls.Add(panel);
            }
        }
    }
}
