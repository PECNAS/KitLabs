namespace WinFormsApp1
{
    partial class LoginForm
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
            label1 = new Label();
            button1 = new Button();
            PasswordTextBox = new TextBox();
            EmailTextBox = new TextBox();
            CreateAccaunt = new LinkLabel();
            ForgotPassword = new LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(45, 9);
            label1.Name = "label1";
            label1.Size = new Size(234, 25);
            label1.TabIndex = 0;
            label1.Text = "Вход в личный кабинет";
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(77, 137);
            button1.Name = "button1";
            button1.Size = new Size(167, 23);
            button1.TabIndex = 2;
            button1.Text = "Войти";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(77, 93);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PlaceholderText = "Пароль";
            PasswordTextBox.Size = new Size(167, 23);
            PasswordTextBox.TabIndex = 1;
            // 
            // EmailTextBox
            // 
            EmailTextBox.Location = new Point(77, 64);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.PlaceholderText = "Почта";
            EmailTextBox.Size = new Size(167, 23);
            EmailTextBox.TabIndex = 0;
            // 
            // CreateAccaunt
            // 
            CreateAccaunt.AutoSize = true;
            CreateAccaunt.Location = new Point(34, 175);
            CreateAccaunt.Name = "CreateAccaunt";
            CreateAccaunt.Size = new Size(95, 15);
            CreateAccaunt.TabIndex = 3;
            CreateAccaunt.TabStop = true;
            CreateAccaunt.Text = "Создать аккаунт";
            CreateAccaunt.LinkClicked += CreateAccaunt_LinkClicked;
            // 
            // ForgotPassword
            // 
            ForgotPassword.AutoSize = true;
            ForgotPassword.Location = new Point(192, 175);
            ForgotPassword.Name = "ForgotPassword";
            ForgotPassword.Size = new Size(98, 15);
            ForgotPassword.TabIndex = 4;
            ForgotPassword.TabStop = true;
            ForgotPassword.Text = "Забыли пароль?";
            ForgotPassword.LinkClicked += ForgotPassword_LinkClicked;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(329, 257);
            Controls.Add(ForgotPassword);
            Controls.Add(CreateAccaunt);
            Controls.Add(EmailTextBox);
            Controls.Add(PasswordTextBox);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private TextBox PasswordTextBox;
        private TextBox EmailTextBox;
        private LinkLabel CreateAccaunt;
        private LinkLabel ForgotPassword;
    }
}