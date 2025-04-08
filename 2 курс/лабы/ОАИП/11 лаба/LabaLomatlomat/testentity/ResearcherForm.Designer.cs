namespace WinFormsApp1
{
    partial class ResearcherForm
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
            NameLabel = new Label();
            SurnameLabel = new Label();
            PhoneNumberLabel = new Label();
            EmailLabel = new Label();
            FirstBuyDateLabel = new Label();
            BDateLabel = new Label();
            AdressLabel = new Label();
            SuspendLayout();
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(23, 23);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(34, 15);
            NameLabel.TabIndex = 0;
            NameLabel.Text = "Имя:";
            // 
            // SurnameLabel
            // 
            SurnameLabel.AutoSize = true;
            SurnameLabel.Location = new Point(23, 51);
            SurnameLabel.Name = "SurnameLabel";
            SurnameLabel.Size = new Size(64, 15);
            SurnameLabel.TabIndex = 1;
            SurnameLabel.Text = "Фамилия: ";
            // 
            // PhoneNumberLabel
            // 
            PhoneNumberLabel.AutoSize = true;
            PhoneNumberLabel.Location = new Point(23, 81);
            PhoneNumberLabel.Name = "PhoneNumberLabel";
            PhoneNumberLabel.Size = new Size(104, 15);
            PhoneNumberLabel.TabIndex = 2;
            PhoneNumberLabel.Text = "Номер телефона:";
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Location = new Point(23, 167);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(44, 15);
            EmailLabel.TabIndex = 3;
            EmailLabel.Text = "Почта:";
            // 
            // FirstBuyDateLabel
            // 
            FirstBuyDateLabel.AutoSize = true;
            FirstBuyDateLabel.Location = new Point(23, 139);
            FirstBuyDateLabel.Name = "FirstBuyDateLabel";
            FirstBuyDateLabel.Size = new Size(119, 15);
            FirstBuyDateLabel.TabIndex = 4;
            FirstBuyDateLabel.Text = "Первая публикация:";
            // 
            // BDateLabel
            // 
            BDateLabel.AutoSize = true;
            BDateLabel.Location = new Point(23, 194);
            BDateLabel.Name = "BDateLabel";
            BDateLabel.Size = new Size(93, 15);
            BDateLabel.TabIndex = 5;
            BDateLabel.Text = "Дата рождения:";
            // 
            // AdressLabel
            // 
            AdressLabel.AutoSize = true;
            AdressLabel.Location = new Point(23, 111);
            AdressLabel.Name = "AdressLabel";
            AdressLabel.Size = new Size(136, 15);
            AdressLabel.TabIndex = 8;
            AdressLabel.Text = "Область исследования:";
            // 
            // ResearcherForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(475, 260);
            Controls.Add(AdressLabel);
            Controls.Add(BDateLabel);
            Controls.Add(FirstBuyDateLabel);
            Controls.Add(EmailLabel);
            Controls.Add(PhoneNumberLabel);
            Controls.Add(SurnameLabel);
            Controls.Add(NameLabel);
            Name = "ResearcherForm";
            Text = "BuyerForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NameLabel;
        private Label SurnameLabel;
        private Label PhoneNumberLabel;
        private Label EmailLabel;
        private Label FirstBuyDateLabel;
        private Label BDateLabel;
        private Label AdressLabel;
    }
}