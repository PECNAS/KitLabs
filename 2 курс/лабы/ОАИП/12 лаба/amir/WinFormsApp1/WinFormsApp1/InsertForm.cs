using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Models;

namespace WinFormsApp1
{
    public partial class InsertForm : Form
    {
        public InsertForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string title = textBox1.Text;
            string desc = textBox2.Text;
            DateTime create_date = dateTimePicker1.Value;
            if (title == "" || title == " " ||
                desc == "" || desc == " ") MessageBox.Show("Ошибка! Не все данные заполнены");
            else
            {
                var notion2add = new Notion
                {
                    Title = title,
                    Description = desc,
                    CreateDate = create_date.Date.ToString()
                };

                using (var db = new MobileContext())
                {
                    db.Notions.Add(notion2add);
                    db.SaveChanges();
                }

                MessageBox.Show("Новая заметка успешно добавлена!");

                this.Close();
            }

        }
    }
}
