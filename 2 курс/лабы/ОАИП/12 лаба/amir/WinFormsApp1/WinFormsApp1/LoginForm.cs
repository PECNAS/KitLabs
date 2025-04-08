using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Models;

namespace WinFormsApp1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = this.EmailTextBox.Text;
            string psswd = this.PasswordTextBox.Text;

            if (email == "" || email == " " ||
                psswd == "" || psswd == " ") MessageBox.Show("Ошибка! Должны быть заполнены все поля");
            else
            {
                using (var db = new MobileContext())
                {
                    var user = db.Users.FirstOrDefault(x => x.Email == email && x.Password == psswd);
                    if (user != null)
                    {
                        var win = new DataViewForm();
                        win.Show();
                        this.Close();
                    } else MessageBox.Show("Ошибка авторизации: неверные данные");
                }
            }
        }
    }
}
