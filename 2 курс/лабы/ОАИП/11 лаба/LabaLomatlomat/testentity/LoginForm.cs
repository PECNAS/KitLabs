using System.Text;
using System.Security.Cryptography;
using Microsoft.VisualBasic.ApplicationServices;
using System.Net.Mail;
using System.Net;

namespace WinFormsApp1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private string GetHashString(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = "";
            foreach (byte b in byteHash)
            {
                hash += string.Format("{0:x2}", b);
            }
            return hash;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = this.EmailTextBox.Text;
            if (!ResearcherContext.email_check(email, false))
            {
                MessageBox.Show("Ошибка! Неверный формат электронной почты");
                return;
            }

            using (ResearcherContext db = new ResearcherContext())
            {
                foreach (Researcher researcher in db.Researchers)
                {
                    if (email == researcher.Email && this.GetHashString(PasswordTextBox.Text) == researcher.Password)
                    {
                        MessageBox.Show("Вход успешен!");
                        ResearcherForm rf = new ResearcherForm();
                        rf.setBuyerData(researcher);
                        rf.Show();
                        this.Visible = false;
                        return;
                    }
                }
                MessageBox.Show("Логин или пароль указан неверно!");
            }

        }

        private void CreateAccaunt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegForm rf = new RegForm();
            rf.Show();
            this.Visible = false;
            return;
        }

        private void ForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string email = this.EmailTextBox.Text;
            if (ResearcherContext.email_check(email))
            {
                using (ResearcherContext db = new ResearcherContext())
                {
                    foreach (Researcher researcher in db.Researchers)
                    {
                        if (researcher.Email == email)
                        {
                            MailAddress from = new MailAddress("busovrm4@mail.ru", "Влад");
                            MailAddress to = new MailAddress(email);
                            MailMessage m = new MailMessage(from, to);

                            Random rand = new Random();
                            int psswd = rand.Next(10000000, 99999999);
                            researcher.Password = GetHashString(psswd.ToString());
                            db.Researchers.Add(researcher);

                            m.Subject = "Тест";
                            m.Body = $"<h1>Новый пароль для вашего аккаунта: </h1><h3>{psswd}</h3>";
                            m.IsBodyHtml = true;

                            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
                            smtp.Credentials = new NetworkCredential("busovrm4@mail.ru", "8uWd9NHMNvT6KhnHDg4n");
                            smtp.EnableSsl = true;
                            smtp.Send(m);
                            break;
                        }
                    }
                    db.SaveChanges();
                }
            } else {
                MessageBox.Show("Ошибка! Для восстановления пароля нужно заполнить поле Email");
                return;
            }
        }
    }
}
