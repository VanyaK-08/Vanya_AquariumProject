namespace AquariumForms
{
    partial class AddUpdateExhibitForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Sans Serif Collection", 10.1999989F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(113, 83);
            label3.Name = "label3";
            label3.Size = new Size(63, 58);
            label3.TabIndex = 4;
            label3.Text = "Title";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Sans Serif Collection", 10.1999989F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(113, 125);
            label1.Name = "label1";
            label1.Size = new Size(86, 58);
            label1.TabIndex = 5;
            label1.Text = "Theme";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Sans Serif Collection", 10.1999989F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(113, 184);
            label2.Name = "label2";
            label2.Size = new Size(126, 58);
            label2.TabIndex = 6;
            label2.Text = "Description";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(241, 92);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(249, 27);
            textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(241, 135);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(249, 27);
            textBox2.TabIndex = 8;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(245, 184);
            richTextBox1.MaxLength = 1000;
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(245, 49);
            richTextBox1.TabIndex = 9;
            richTextBox1.Text = "";
            // 
            // button1
            // 
            button1.BackColor = Color.LightSteelBlue;
            button1.Font = new Font("Sans Serif Collection", 10.1999989F, FontStyle.Bold);
            button1.Location = new Point(113, 341);
            button1.Name = "button1";
            button1.Size = new Size(117, 52);
            button1.TabIndex = 13;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.LightSteelBlue;
            button2.Font = new Font("Sans Serif Collection", 10.1999989F, FontStyle.Bold);
            button2.Location = new Point(373, 341);
            button2.Name = "button2";
            button2.Size = new Size(117, 52);
            button2.TabIndex = 14;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(535, 83);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(217, 188);
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // button3
            // 
            button3.BackColor = Color.LightSteelBlue;
            button3.Font = new Font("Sans Serif Collection", 7.799999F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button3.Location = new Point(113, 257);
            button3.Name = "button3";
            button3.Size = new Size(151, 43);
            button3.TabIndex = 16;
            button3.Text = "Show image...";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // AddUpdateExhibitForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.exhibitAddUpdForm;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 451);
            Controls.Add(button3);
            Controls.Add(pictureBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label3);
            Name = "AddUpdateExhibitForm";
            Text = "AddExhibitForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private RichTextBox richTextBox1;
        private Button button1;
        private Button button2;
        private PictureBox pictureBox1;
        private Button button3;
    }
}