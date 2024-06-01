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
            string psswd = this.PasswordTextBox.Text;

            if (!(BuyerContext.email_check(email, false) && psswd != "" && psswd != " "))
            {
                MessageBox.Show("Ошибка! Неверный формат пароля или email");
                return;
            }

            using (BuyerContext db = new BuyerContext())
            {
                string hash = GetHashString(psswd);
                var buyer = db.Buyers.FirstOrDefault
                    (x => x.Email == email && x.Password == hash);

                if (buyer != null)
                {
                    MessageBox.Show("Вход успешен!");
                    BuyerForm bf = new BuyerForm();
                    bf.setBuyerData(buyer);
                    bf.Show();
                }
                else MessageBox.Show("Логин или пароль указан неверно!");
            }

        }

        private void CreateAccaunt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegForm rf = new RegForm();
            rf.Show();
            return;
        }

        private void ForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string email = this.EmailTextBox.Text;
            if (BuyerContext.email_check(email, false))
            {
                using (BuyerContext db = new BuyerContext())
                {
                    Buyer buyer = db.Buyers.FirstOrDefault(x => x.Email == email);
                    if (buyer != null)
                    {
                        MailAddress from = new MailAddress("busovrm4@mail.ru", "Влад");
                        MailAddress to = new MailAddress(email);
                        MailMessage m = new MailMessage(from, to);

                        Random rand = new Random();
                        int psswd = rand.Next(10000000, 99999999);
                        buyer.Password = GetHashString(psswd.ToString());
                        db.SaveChanges();

                        m.Subject = "Тест";
                        m.Body = $"<h1>Новый пароль для вашего аккаунта: </h1><h3>{psswd}</h3>";
                        m.IsBodyHtml = true;

                        SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
                        smtp.Credentials = new NetworkCredential("busovrm4@mail.ru", "8uWd9NHMNvT6KhnHDg4n");
                        smtp.EnableSsl = true;
                        smtp.Send(m);

                        MessageBox.Show("Пароль отправлен вам на почту");
                    } else
                    {
                        MessageBox.Show("Пользователь с таким email не зарегистрирован");
                    }
                }
            } else {
                MessageBox.Show("Ошибка! Для восстановления пароля нужно заполнить поле Email");
                return;
            }
        }
    }
}
