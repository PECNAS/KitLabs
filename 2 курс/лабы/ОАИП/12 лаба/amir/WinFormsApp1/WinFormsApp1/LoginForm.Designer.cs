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
            EmailTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(115, 29);
            label1.Name = "label1";
            label1.Size = new Size(181, 39);
            label1.TabIndex = 0;
            label1.Text = "Авторизация";
            // 
            // EmailTextBox
            // 
            EmailTextBox.Location = new Point(115, 147);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(181, 23);
            EmailTextBox.TabIndex = 1;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(115, 209);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(181, 23);
            PasswordTextBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(116, 129);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 3;
            label2.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(116, 191);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 4;
            label3.Text = "Пароль";
            // 
            // button1
            // 
            button1.Location = new Point(116, 290);
            button1.Name = "button1";
            button1.Size = new Size(180, 23);
            button1.TabIndex = 5;
            button1.Text = "Войти в аккаунт";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(116, 328);
            button2.Name = "button2";
            button2.Size = new Size(180, 23);
            button2.TabIndex = 6;
            button2.Text = "Зарегистрироваться";
            button2.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(408, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(PasswordTextBox);
            Controls.Add(EmailTextBox);
            Controls.Add(label1);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox EmailTextBox;
        private TextBox PasswordTextBox;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button button2;
    }
}