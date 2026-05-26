namespace AquariumForms
{
    partial class ClientTicketDetails
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
            button1 = new Button();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.LightSteelBlue;
            button1.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold);
            button1.Location = new Point(324, 369);
            button1.Name = "button1";
            button1.Size = new Size(118, 48);
            button1.TabIndex = 1;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(234, 37);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(301, 326);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // ClientTicketDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.clientTicketDetails;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(richTextBox1);
            Controls.Add(button1);
            Name = "ClientTicketDetails";
            Text = "ClientTicketDetails";
            Load += ClientTicketDetails_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private RichTextBox richTextBox1;
    }
}