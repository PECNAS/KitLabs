using System.Text;
using System.Security.Cryptography;

namespace WinFormsApp1
{
    public partial class RegForm : Form
    {
        public RegForm()
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

        private void linkLabel1_LinkClicked(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm();
            lf.Show();
            this.Visible = false;
            return;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string name = this.NameTextBox.Text;
            string surname = this.SurnameTextBox.Text;
            string bdate = this.BDateTextBox.Text;
            string adress = this.AdressTextBox.Text;
            string phone_number = this.PhoneNumberTextBox.Text;
            string first_buy_date = this.FirstBuyDateTextBox.Text;
            string password = this.PasswordTextBox.Text;
            string email = this.EmailTextBox.Text;

            if (!BuyerContext.email_check(email)) {
                MessageBox.Show("Ошибка! Неверный формат почты");
                return;
            } else {
                if (!BuyerContext.date_check(first_buy_date)) {
                    MessageBox.Show("Ошибка! Неверный формат даты первой покупки");
                    return;
                } else {
                    if (!BuyerContext.date_check(bdate)) {
                        MessageBox.Show("Ошибка! Неверный формат даты рождения");
                        return;
                    }
                }
            }

            if (name != "" && name != " " &&
                surname != "" && surname != " " &&
                bdate != "" && bdate != " " &&
                adress != "" && adress != " " &&
                phone_number != "" && phone_number != " " &&
                phone_number.Length == 11 && long.TryParse(phone_number, out long _) &&
                first_buy_date != "" && first_buy_date != " " &&
                password != "" && password != " " && password.Length >= 8 || true)
            {

                using (BuyerContext db = new BuyerContext())
                {
                    DateOnly bd_date = BuyerContext.to_date(bdate);
                    DateOnly fbd_date = BuyerContext.to_date(first_buy_date);

                    Buyer buyer = new Buyer(
                            Name: name,
                            Surname: surname,
                            BDate: bd_date,
                            PhoneNumber: phone_number,
                            Adress: adress,
                            FirstBuyDate: fbd_date,
                            Password: GetHashString(password),
                            Email: email
                            );
                        db.Buyers.Add(buyer);
                        db.SaveChanges();

                        BuyerForm bf = new BuyerForm();
                        bf.Show();
                        bf.setBuyerData(buyer);
                }
            } else MessageBox.Show("Необходимо заполнить все поля!" +
                "Также проверьте, что номер телефона является числом с 11 цифрами");

        }
    }
}
