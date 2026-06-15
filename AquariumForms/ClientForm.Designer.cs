namespace AquariumForms
{
    partial class ClientForm
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
            listBox1 = new ListBox();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button1 = new Button();
            button5 = new Button();
            button6 = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.BackColor = Color.SkyBlue;
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(28, 32);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(270, 324);
            listBox1.TabIndex = 0;
            // 
            // button2
            // 
            button2.BackColor = Color.LightSteelBlue;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Sans Serif Collection", 10.1999989F, FontStyle.Bold);
            button2.ForeColor = SystemColors.ControlText;
            button2.Location = new Point(315, 92);
            button2.Name = "button2";
            button2.Size = new Size(182, 52);
            button2.TabIndex = 14;
            button2.Text = "Buy a new ticket";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.LightSteelBlue;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Sans Serif Collection", 10.1999989F, FontStyle.Bold);
            button3.ForeColor = SystemColors.ControlText;
            button3.Location = new Point(28, 362);
            button3.Name = "button3";
            button3.Size = new Size(312, 52);
            button3.TabIndex = 16;
            button3.Text = "See detailed ticket information";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.LightSteelBlue;
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Sans Serif Collection", 10.1999989F, FontStyle.Bold);
            button4.ForeColor = SystemColors.ControlText;
            button4.Location = new Point(315, 32);
            button4.Name = "button4";
            button4.Size = new Size(182, 52);
            button4.TabIndex = 17;
            button4.Text = "See exhibits";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.LightSteelBlue;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Sans Serif Collection", 10.1999989F, FontStyle.Bold);
            button1.ForeColor = SystemColors.ControlText;
            button1.Location = new Point(315, 150);
            button1.Name = "button1";
            button1.Size = new Size(182, 52);
            button1.TabIndex = 15;
            button1.Text = "Unbook ticket";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.LightSteelBlue;
            button5.Font = new Font("Sans Serif Collection", 10.1999989F, FontStyle.Bold);
            button5.Location = new Point(315, 208);
            button5.Name = "button5";
            button5.Size = new Size(182, 52);
            button5.TabIndex = 18;
            button5.Text = "Reload";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.LightSteelBlue;
            button6.Font = new Font("Sans Serif Collection", 7.799999F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button6.ForeColor = Color.Black;
            button6.Location = new Point(691, 397);
            button6.Name = "button6";
            button6.Size = new Size(97, 41);
            button6.TabIndex = 19;
            button6.Text = "Log Out";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.client;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(listBox1);
            Name = "ClientForm";
            Text = "ClientForm";
            Load += ClientForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button1;
        private Button button5;
        private Button button6;
    }
}