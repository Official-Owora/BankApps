namespace BankApp.WindowsForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            Register = new Button();
            button2 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button2);
            panel1.Controls.Add(Register);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(552, 450);
            panel1.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.GreenYellow;
            textBox3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox3.Location = new Point(200, 210);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(150, 29);
            textBox3.TabIndex = 2;
            textBox3.Text = "Enter Your Password";
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.GreenYellow;
            textBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(187, 160);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(184, 29);
            textBox2.TabIndex = 1;
            textBox2.Text = "Enter Your Email Address";
            textBox2.TextChanged += textBox2_TextChanged_1;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.GreenYellow;
            textBox1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.ForeColor = Color.DimGray;
            textBox1.Location = new Point(135, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(293, 39);
            textBox1.TabIndex = 0;
            textBox1.Text = "Welcome to the .NET Bank ";
            // 
            // Register
            // 
            Register.BackColor = Color.PaleGreen;
            Register.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            Register.Location = new Point(135, 261);
            Register.Name = "Register";
            Register.Size = new Size(97, 36);
            Register.TabIndex = 5;
            Register.Text = "Register";
            Register.UseVisualStyleBackColor = false;
            Register.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.PaleGreen;
            button2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(353, 261);
            button2.Name = "button2";
            button2.Size = new Size(75, 36);
            button2.TabIndex = 6;
            button2.Text = "Login";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(555, 450);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button button2;
        private Button Register;
    }
}