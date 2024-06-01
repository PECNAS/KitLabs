namespace WinFormsApp1
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
            pictureBox1 = new PictureBox();
            button1 = new Button();
            label1 = new Label();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox4 = new TextBox();
            label5 = new Label();
            textBox5 = new TextBox();
            label6 = new Label();
            label8 = new Label();
            textBox7 = new TextBox();
            textBox8 = new TextBox();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            up_btn = new Button();
            left_btn = new Button();
            right_btn = new Button();
            down_btn = new Button();
            comboBox1 = new ComboBox();
            label12 = new Label();
            button10 = new Button();
            button6 = new Button();
            dropFigure = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(626, 626);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(1032, 47);
            button1.Name = "button1";
            button1.Size = new Size(160, 55);
            button1.TabIndex = 1;
            button1.Text = "Прямоугольник";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(1032, 9);
            label1.Name = "label1";
            label1.Size = new Size(161, 25);
            label1.TabIndex = 2;
            label1.Text = "Добавить фигуру";
            // 
            // button2
            // 
            button2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(1033, 108);
            button2.Name = "button2";
            button2.Size = new Size(160, 55);
            button2.TabIndex = 3;
            button2.Text = "Круг";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(1033, 169);
            button3.Name = "button3";
            button3.Size = new Size(160, 55);
            button3.TabIndex = 4;
            button3.Text = "Треугольник";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(1032, 230);
            button4.Name = "button4";
            button4.Size = new Size(160, 55);
            button4.TabIndex = 5;
            button4.Text = "Многоугольник";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(1032, 291);
            button5.Name = "button5";
            button5.Size = new Size(160, 55);
            button5.TabIndex = 6;
            button5.Text = "Ррррракета";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(974, 47);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(52, 23);
            textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(974, 76);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(52, 23);
            textBox2.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(913, 50);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 9;
            label2.Text = "Ширина:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(918, 79);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 10;
            label3.Text = "Высота:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(974, 108);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(52, 23);
            textBox3.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(919, 108);
            label4.Name = "label4";
            label4.Size = new Size(48, 15);
            label4.TabIndex = 12;
            label4.Text = "Радиус:";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(974, 137);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(52, 23);
            textBox4.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(871, 140);
            label5.Name = "label5";
            label5.Size = new Size(96, 15);
            label5.TabIndex = 14;
            label5.Text = "Длина стороны:";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(974, 166);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(52, 23);
            textBox5.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(885, 169);
            label6.Name = "label6";
            label6.Size = new Size(83, 15);
            label6.TabIndex = 16;
            label6.Text = "Кол-во углов:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(843, 240);
            label8.Name = "label8";
            label8.Size = new Size(183, 25);
            label8.TabIndex = 19;
            label8.Text = "Положение фигуры";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(922, 311);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(87, 23);
            textBox7.TabIndex = 21;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(922, 271);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(87, 23);
            textBox8.TabIndex = 20;
            textBox8.Tag = "";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(814, 274);
            label9.Name = "label9";
            label9.Size = new Size(102, 15);
            label9.TabIndex = 22;
            label9.Text = "Положение по X:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(814, 314);
            label10.Name = "label10";
            label10.Size = new Size(102, 15);
            label10.TabIndex = 23;
            label10.Text = "Положение по Y:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(677, 9);
            label11.Name = "label11";
            label11.Size = new Size(191, 25);
            label11.TabIndex = 24;
            label11.Text = "Переместить фигуру";
            // 
            // up_btn
            // 
            up_btn.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            up_btn.Location = new Point(738, 100);
            up_btn.Name = "up_btn";
            up_btn.Size = new Size(60, 60);
            up_btn.TabIndex = 25;
            up_btn.Text = "Up";
            up_btn.UseVisualStyleBackColor = true;
            up_btn.Click += up_btn_Click;
            // 
            // left_btn
            // 
            left_btn.Location = new Point(672, 162);
            left_btn.Name = "left_btn";
            left_btn.Size = new Size(60, 60);
            left_btn.TabIndex = 26;
            left_btn.Text = "Left";
            left_btn.UseVisualStyleBackColor = true;
            left_btn.Click += left_btn_Click;
            // 
            // right_btn
            // 
            right_btn.Location = new Point(804, 162);
            right_btn.Name = "right_btn";
            right_btn.Size = new Size(60, 60);
            right_btn.TabIndex = 27;
            right_btn.Text = "Right";
            right_btn.UseVisualStyleBackColor = true;
            right_btn.Click += right_btn_Click;
            // 
            // down_btn
            // 
            down_btn.Location = new Point(738, 225);
            down_btn.Name = "down_btn";
            down_btn.Size = new Size(60, 60);
            down_btn.TabIndex = 28;
            down_btn.Text = "Down";
            down_btn.UseVisualStyleBackColor = true;
            down_btn.Click += down_btn_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(706, 71);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 29;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(717, 50);
            label12.Name = "label12";
            label12.Size = new Size(100, 15);
            label12.TabIndex = 30;
            label12.Text = "Выбрать фигуру:";
            // 
            // button10
            // 
            button10.Location = new Point(1033, 352);
            button10.Name = "button10";
            button10.Size = new Size(160, 55);
            button10.TabIndex = 31;
            button10.Text = "Квадрат";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button6
            // 
            button6.Location = new Point(1033, 413);
            button6.Name = "button6";
            button6.Size = new Size(160, 55);
            button6.TabIndex = 32;
            button6.Text = "Эллипс";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // dropFigure
            // 
            dropFigure.Location = new Point(738, 162);
            dropFigure.Name = "dropFigure";
            dropFigure.Size = new Size(60, 60);
            dropFigure.TabIndex = 33;
            dropFigure.Text = "Удалить";
            dropFigure.UseVisualStyleBackColor = true;
            dropFigure.Click += dropFigure_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1195, 650);
            Controls.Add(dropFigure);
            Controls.Add(button6);
            Controls.Add(button10);
            Controls.Add(label12);
            Controls.Add(comboBox1);
            Controls.Add(down_btn);
            Controls.Add(right_btn);
            Controls.Add(left_btn);
            Controls.Add(up_btn);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(textBox8);
            Controls.Add(textBox7);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(textBox5);
            Controls.Add(label5);
            Controls.Add(textBox4);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private Label label1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox4;
        private Label label5;
        private TextBox textBox5;
        private Label label6;
        private Label label8;
        private TextBox textBox7;
        private TextBox textBox8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Button up_btn;
        private Button left_btn;
        private Button right_btn;
        private Button down_btn;
        private Label label12;
        private Button button10;
        private Button button6;
        private Button dropFigure;
        public ComboBox comboBox1;
    }
}
