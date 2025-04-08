namespace WinFormsApp1
{
    partial class DataViewForm
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
            DataTable = new DataGridView();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)DataTable).BeginInit();
            SuspendLayout();
            // 
            // DataTable
            // 
            DataTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataTable.Location = new Point(12, 12);
            DataTable.Name = "DataTable";
            DataTable.RowTemplate.Height = 25;
            DataTable.Size = new Size(587, 367);
            DataTable.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(605, 33);
            label1.Name = "label1";
            label1.Size = new Size(95, 21);
            label1.TabIndex = 1;
            label1.Text = "Управление";
            // 
            // button1
            // 
            button1.Location = new Point(613, 99);
            button1.Name = "button1";
            button1.Size = new Size(87, 36);
            button1.TabIndex = 2;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(613, 141);
            button2.Name = "button2";
            button2.Size = new Size(87, 34);
            button2.TabIndex = 3;
            button2.Text = "Удалить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(615, 344);
            button3.Name = "button3";
            button3.Size = new Size(85, 35);
            button3.TabIndex = 4;
            button3.Text = "Выход";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // DataViewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(713, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(DataTable);
            Name = "DataViewForm";
            Text = "DataViewForm";
            ((System.ComponentModel.ISupportInitialize)DataTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DataTable;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}