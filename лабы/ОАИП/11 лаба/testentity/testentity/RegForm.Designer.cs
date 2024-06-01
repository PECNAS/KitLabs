namespace WinFormsApp1
{
    partial class RegForm
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
            NameTextBox = new TextBox();
            BDateTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            button1 = new Button();
            PhoneNumberTextBox = new TextBox();
            label1 = new Label();
            linkLabel1 = new LinkLabel();
            AdressTextBox = new TextBox();
            EmailTextBox = new TextBox();
            FirstBuyDateTextBox = new TextBox();
            SurnameTextBox = new TextBox();
            SuspendLayout();
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(72, 54);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.PlaceholderText = "Имя";
            NameTextBox.Size = new Size(148, 23);
            NameTextBox.TabIndex = 0;
            // 
            // BDateTextBox
            // 
            BDateTextBox.Location = new Point(72, 112);
            BDateTextBox.Name = "BDateTextBox";
            BDateTextBox.PlaceholderText = "Дата рождения";
            BDateTextBox.Size = new Size(148, 23);
            BDateTextBox.TabIndex = 4;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(72, 141);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PlaceholderText = "Пароль";
            PasswordTextBox.Size = new Size(148, 23);
            PasswordTextBox.TabIndex = 6;
            // 
            // button1
            // 
            button1.Location = new Point(172, 170);
            button1.Name = "button1";
            button1.Size = new Size(148, 23);
            button1.TabIndex = 8;
            button1.Text = "Зарегистрироваться";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // PhoneNumberTextBox
            // 
            PhoneNumberTextBox.Location = new Point(72, 83);
            PhoneNumberTextBox.Name = "PhoneNumberTextBox";
            PhoneNumberTextBox.PlaceholderText = "Номер телефона";
            PhoneNumberTextBox.Size = new Size(148, 23);
            PhoneNumberTextBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(82, 9);
            label1.Name = "label1";
            label1.Size = new Size(128, 25);
            label1.TabIndex = 5;
            label1.Text = "Регистрация";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(197, 196);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(94, 15);
            linkLabel1.TabIndex = 9;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Уже есть аккант";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // AdressTextBox
            // 
            AdressTextBox.Location = new Point(259, 83);
            AdressTextBox.Name = "AdressTextBox";
            AdressTextBox.PlaceholderText = "Адрес доставки";
            AdressTextBox.Size = new Size(148, 23);
            AdressTextBox.TabIndex = 3;
            // 
            // EmailTextBox
            // 
            EmailTextBox.Location = new Point(259, 141);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.PlaceholderText = "Почта";
            EmailTextBox.Size = new Size(148, 23);
            EmailTextBox.TabIndex = 7;
            // 
            // FirstBuyDateTextBox
            // 
            FirstBuyDateTextBox.Location = new Point(259, 112);
            FirstBuyDateTextBox.Name = "FirstBuyDateTextBox";
            FirstBuyDateTextBox.PlaceholderText = "Дата первой доставки";
            FirstBuyDateTextBox.Size = new Size(148, 23);
            FirstBuyDateTextBox.TabIndex = 5;
            // 
            // SurnameTextBox
            // 
            SurnameTextBox.Location = new Point(259, 54);
            SurnameTextBox.Name = "SurnameTextBox";
            SurnameTextBox.PlaceholderText = "Фамилия";
            SurnameTextBox.Size = new Size(148, 23);
            SurnameTextBox.TabIndex = 1;
            // 
            // RegForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 254);
            Controls.Add(AdressTextBox);
            Controls.Add(EmailTextBox);
            Controls.Add(FirstBuyDateTextBox);
            Controls.Add(SurnameTextBox);
            Controls.Add(linkLabel1);
            Controls.Add(label1);
            Controls.Add(PhoneNumberTextBox);
            Controls.Add(button1);
            Controls.Add(PasswordTextBox);
            Controls.Add(BDateTextBox);
            Controls.Add(NameTextBox);
            Name = "RegForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox NameTextBox;
        private TextBox BDateTextBox;
        private TextBox PasswordTextBox;
        private Button button1;
        private TextBox PhoneNumberTextBox;
        private Label label1;
        private LinkLabel linkLabel1;
        private TextBox AdressTextBox;
        private TextBox EmailTextBox;
        private TextBox FirstBuyDateTextBox;
        private TextBox SurnameTextBox;
    }
}
