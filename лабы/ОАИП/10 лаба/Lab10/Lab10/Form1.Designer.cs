namespace Lab10
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            richTextBox = new RichTextBox();
            toolStrip1 = new ToolStrip();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            открытьToolStripMenuItem = new ToolStripMenuItem();
            сохранитьКакToolStripMenuItem = new ToolStripMenuItem();
            toolStripButton1 = new ToolStripButton();
            Info = new GroupBox();
            labeltime = new Label();
            labelperm = new Label();
            labelComp = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            MethodChoose = new GroupBox();
            radioButtonImproved = new RadioButton();
            radioButtonSimple = new RadioButton();
            Generator = new GroupBox();
            buttonGeneration = new Button();
            labelTrackBar = new Label();
            trackBar1 = new TrackBar();
            buttonSort = new Button();
            buttonClear = new Button();
            toolStrip1.SuspendLayout();
            Info.SuspendLayout();
            MethodChoose.SuspendLayout();
            Generator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // richTextBox
            // 
            richTextBox.Location = new Point(12, 28);
            richTextBox.Name = "richTextBox";
            richTextBox.ReadOnly = true;
            richTextBox.Size = new Size(678, 435);
            richTextBox.TabIndex = 0;
            richTextBox.Text = "";
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1, toolStripButton1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(906, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { открытьToolStripMenuItem, сохранитьКакToolStripMenuItem });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(49, 22);
            toolStripDropDownButton1.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            открытьToolStripMenuItem.Size = new Size(154, 22);
            открытьToolStripMenuItem.Text = "Открыть";
            открытьToolStripMenuItem.Click += открытьToolStripMenuItem_Click;
            // 
            // сохранитьКакToolStripMenuItem
            // 
            сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            сохранитьКакToolStripMenuItem.Size = new Size(154, 22);
            сохранитьКакToolStripMenuItem.Text = "Сохранить как";
            сохранитьКакToolStripMenuItem.Click += сохранитьКакToolStripMenuItem_Click;
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(51, 22);
            toolStripButton1.Text = "Анализ";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // Info
            // 
            Info.Controls.Add(labeltime);
            Info.Controls.Add(labelperm);
            Info.Controls.Add(labelComp);
            Info.Controls.Add(label3);
            Info.Controls.Add(label2);
            Info.Controls.Add(label1);
            Info.Location = new Point(696, 28);
            Info.Name = "Info";
            Info.Size = new Size(200, 100);
            Info.TabIndex = 2;
            Info.TabStop = false;
            Info.Text = "Инфо";
            // 
            // labeltime
            // 
            labeltime.AutoSize = true;
            labeltime.Location = new Point(131, 70);
            labeltime.Name = "labeltime";
            labeltime.Size = new Size(13, 15);
            labeltime.TabIndex = 5;
            labeltime.Text = "0";
            // 
            // labelperm
            // 
            labelperm.AutoSize = true;
            labelperm.Location = new Point(131, 44);
            labelperm.Name = "labelperm";
            labelperm.Size = new Size(13, 15);
            labelperm.TabIndex = 4;
            labelperm.Text = "0";
            // 
            // labelComp
            // 
            labelComp.AutoSize = true;
            labelComp.Location = new Point(131, 19);
            labelComp.Name = "labelComp";
            labelComp.Size = new Size(13, 15);
            labelComp.TabIndex = 3;
            labelComp.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 70);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 2;
            label3.Text = "Время";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 44);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 1;
            label2.Text = "Перестановок";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 0;
            label1.Text = "Сравнений";
            // 
            // MethodChoose
            // 
            MethodChoose.Controls.Add(radioButtonImproved);
            MethodChoose.Controls.Add(radioButtonSimple);
            MethodChoose.Location = new Point(696, 134);
            MethodChoose.Name = "MethodChoose";
            MethodChoose.Size = new Size(200, 100);
            MethodChoose.TabIndex = 3;
            MethodChoose.TabStop = false;
            MethodChoose.Text = "Выбор метода";
            // 
            // radioButtonImproved
            // 
            radioButtonImproved.AutoSize = true;
            radioButtonImproved.Location = new Point(9, 59);
            radioButtonImproved.Name = "radioButtonImproved";
            radioButtonImproved.Size = new Size(164, 19);
            radioButtonImproved.TabIndex = 1;
            radioButtonImproved.TabStop = true;
            radioButtonImproved.Text = "Поразрядная сортировка";
            radioButtonImproved.UseVisualStyleBackColor = true;
            // 
            // radioButtonSimple
            // 
            radioButtonSimple.AutoSize = true;
            radioButtonSimple.Location = new Point(9, 25);
            radioButtonSimple.Name = "radioButtonSimple";
            radioButtonSimple.Size = new Size(105, 19);
            radioButtonSimple.TabIndex = 0;
            radioButtonSimple.Text = "Метод выбора";
            radioButtonSimple.UseVisualStyleBackColor = true;
            // 
            // Generator
            // 
            Generator.Controls.Add(buttonGeneration);
            Generator.Controls.Add(labelTrackBar);
            Generator.Controls.Add(trackBar1);
            Generator.Location = new Point(696, 240);
            Generator.Name = "Generator";
            Generator.Size = new Size(200, 100);
            Generator.TabIndex = 4;
            Generator.TabStop = false;
            Generator.Text = "Генератор";
            // 
            // buttonGeneration
            // 
            buttonGeneration.Location = new Point(6, 73);
            buttonGeneration.Name = "buttonGeneration";
            buttonGeneration.Size = new Size(188, 23);
            buttonGeneration.TabIndex = 2;
            buttonGeneration.Text = "Генерировать";
            buttonGeneration.UseVisualStyleBackColor = true;
            buttonGeneration.Click += buttonGeneration_Click;
            // 
            // labelTrackBar
            // 
            labelTrackBar.AutoSize = true;
            labelTrackBar.Location = new Point(78, 52);
            labelTrackBar.Name = "labelTrackBar";
            labelTrackBar.Size = new Size(0, 15);
            labelTrackBar.TabIndex = 1;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(6, 22);
            trackBar1.Maximum = 100;
            trackBar1.Minimum = 10;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(188, 45);
            trackBar1.TabIndex = 0;
            trackBar1.Value = 10;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // buttonSort
            // 
            buttonSort.BackgroundImageLayout = ImageLayout.None;
            buttonSort.Location = new Point(696, 412);
            buttonSort.Name = "buttonSort";
            buttonSort.Size = new Size(200, 51);
            buttonSort.TabIndex = 5;
            buttonSort.Text = "Начать сортировку";
            buttonSort.UseVisualStyleBackColor = false;
            buttonSort.Click += buttonSort_Click;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(696, 346);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(200, 44);
            buttonClear.TabIndex = 6;
            buttonClear.Text = "Очистить";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(906, 475);
            Controls.Add(buttonClear);
            Controls.Add(buttonSort);
            Controls.Add(Generator);
            Controls.Add(MethodChoose);
            Controls.Add(Info);
            Controls.Add(toolStrip1);
            Controls.Add(richTextBox);
            Name = "Form1";
            Text = "Form1";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            Info.ResumeLayout(false);
            Info.PerformLayout();
            MethodChoose.ResumeLayout(false);
            MethodChoose.PerformLayout();
            Generator.ResumeLayout(false);
            Generator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private ToolStripButton toolStripButton1;
        private GroupBox Info;
        private GroupBox MethodChoose;
        private GroupBox Generator;
        private Label labelTrackBar;
        private TrackBar trackBar1;
        private Button buttonSort;
        private Button buttonGeneration;
        private RadioButton radioButtonImproved;
        private RadioButton radioButtonSimple;
        public RichTextBox richTextBox;
        private Button buttonClear;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label labeltime;
        private Label labelperm;
        private Label labelComp;
    }
}
