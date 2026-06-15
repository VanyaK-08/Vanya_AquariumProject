namespace AquariumForms
{
    partial class RegisterForm
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            button2 = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            button1 = new Button();
            label5 = new Label();
            textBox4 = new TextBox();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Sans Serif Collection", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.White;
            label2.Location = new Point(142, 85);
            label2.Name = "label2";
            label2.Size = new Size(117, 58);
            label2.TabIndex = 4;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Sans Serif Collection", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(186, 143);
            label3.Name = "label3";
            label3.Size = new Size(73, 58);
            label3.TabIndex = 6;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Sans Serif Collection", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(142, 205);
            label4.Name = "label4";
            label4.Size = new Size(109, 58);
            label4.TabIndex = 7;
            label4.Text = "Password";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(280, 94);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(199, 27);
            textBox1.TabIndex = 9;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(280, 152);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(199, 27);
            textBox2.TabIndex = 10;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(280, 214);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(199, 27);
            textBox3.TabIndex = 11;
            textBox3.UseSystemPasswordChar = true;
            // 
            // button2
            // 
            button2.BackColor = Color.LightSteelBlue;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Sans Serif Collection", 10.1999989F, FontStyle.Bold);
            button2.ForeColor = SystemColors.ControlText;
            button2.Location = new Point(519, 88);
            button2.Name = "button2";
            button2.Size = new Size(117, 52);
            button2.TabIndex = 13;
            button2.Text = "Register";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_ClickAsync;
            // 
            // button1
            // 
            button1.BackColor = Color.LightSteelBlue;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Sans Serif Collection", 10.1999989F, FontStyle.Bold);
            button1.ForeColor = SystemColors.ControlText;
            button1.Location = new Point(519, 256);
            button1.Name = "button1";
            button1.Size = new Size(117, 52);
            button1.TabIndex = 14;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Sans Serif Collection", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(76, 272);
            label5.Name = "label5";
            label5.Size = new Size(183, 58);
            label5.TabIndex = 15;
            label5.Text = "Confirm password";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(280, 281);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(199, 27);
            textBox4.TabIndex = 16;
            textBox4.UseSystemPasswordChar = true;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.register;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox4);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "RegisterForm";
            Text = "RegisterForm";
            Load += RegisterForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button button2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button button1;
        private Label label5;
        private TextBox textBox4;
    }
}