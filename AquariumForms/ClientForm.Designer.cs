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
            button1 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.BackColor = SystemColors.Window;
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(28, 32);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(270, 324);
            listBox1.TabIndex = 0;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Sans Serif Collection", 10.1999989F, FontStyle.Bold);
            button2.ForeColor = SystemColors.ControlLightLight;
            button2.Location = new Point(304, 32);
            button2.Name = "button2";
            button2.Size = new Size(182, 52);
            button2.TabIndex = 14;
            button2.Text = "Buy a new ticket";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Sans Serif Collection", 10.1999989F, FontStyle.Bold);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(304, 107);
            button1.Name = "button1";
            button1.Size = new Size(267, 52);
            button1.TabIndex = 15;
            button1.Text = "Change ticket information";
            button1.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.Transparent;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Sans Serif Collection", 10.1999989F, FontStyle.Bold);
            button3.ForeColor = SystemColors.ControlLightLight;
            button3.Location = new Point(28, 362);
            button3.Name = "button3";
            button3.Size = new Size(312, 52);
            button3.TabIndex = 16;
            button3.Text = "See detailed ticket information";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.Transparent;
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Sans Serif Collection", 10.1999989F, FontStyle.Bold);
            button4.ForeColor = SystemColors.ControlLightLight;
            button4.Location = new Point(304, 180);
            button4.Name = "button4";
            button4.Size = new Size(145, 52);
            button4.TabIndex = 17;
            button4.Text = "See exhibits";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.client;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(listBox1);
            Name = "ClientForm";
            Text = "ClientForm";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox1;
        private Button button2;
        private Button button1;
        private Button button3;
        private Button button4;
    }
}