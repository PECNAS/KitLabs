namespace WinFormsApp1
{
    partial class RegForm
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
            button2 = new Button();
            label3 = new Label();
            label2 = new Label();
            NameTextBox = new TextBox();
            EmailTextBox = new TextBox();
            label1 = new Label();
            label4 = new Label();
            PasswordTextBox = new TextBox();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(99, 330);
            button2.Name = "button2";
            button2.Size = new Size(180, 23);
            button2.TabIndex = 13;
            button2.Text = "Зарегистрироваться";
            button2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(99, 183);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 11;
            label3.Text = "Имя";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(99, 131);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 10;
            label2.Text = "Email";
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(98, 201);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(181, 23);
            NameTextBox.TabIndex = 9;
            // 
            // EmailTextBox
            // 
            EmailTextBox.Location = new Point(98, 149);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(181, 23);
            EmailTextBox.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(106, 31);
            label1.Name = "label1";
            label1.Size = new Size(173, 39);
            label1.TabIndex = 7;
            label1.Text = "Регистрация";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(99, 237);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 15;
            label4.Text = "Пароль";
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(98, 255);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(181, 23);
            PasswordTextBox.TabIndex = 14;
            // 
            // RegForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(389, 450);
            Controls.Add(label4);
            Controls.Add(PasswordTextBox);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(NameTextBox);
            Controls.Add(EmailTextBox);
            Controls.Add(label1);
            Name = "RegForm";
            Text = "RegForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Label label3;
        private Label label2;
        private TextBox NameTextBox;
        private TextBox EmailTextBox;
        private Label label1;
        private Label label4;
        private TextBox PasswordTextBox;
    }
}