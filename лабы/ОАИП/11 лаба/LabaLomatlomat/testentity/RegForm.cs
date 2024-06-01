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
            string research_location = this.AdressTextBox.Text;
            string phone_number = this.PhoneNumberTextBox.Text;
            string first_public_date = this.FirstBuyDateTextBox.Text;
            string password = this.PasswordTextBox.Text;
            string email = this.EmailTextBox.Text;

            if (!ResearcherContext.email_check(email)) {
                MessageBox.Show("Ошибка! Неверный формат почты");
                return;
            } else {
                if (!ResearcherContext.date_check(first_public_date)) {
                    MessageBox.Show("Ошибка! Неверный формат даты первой покупки");
                    return;
                } else {
                    if (!ResearcherContext.date_check(bdate)) {
                        MessageBox.Show("Ошибка! Неверный формат даты рождения");
                        return;
                    }
                }
            }

            if (name != "" &&
                surname != "" &&
                bdate != "" &&
                phone_number != "" &&
                password != "")
            {
                using (ResearcherContext db = new ResearcherContext())
                {

                        Researcher researcher = new Researcher(
                            Name: name,
                            Surname: surname,
                            BDate: bdate,
                            PhoneNumber: phone_number,
                            ResearchLocation: research_location,
                            FirstPublicDate: first_public_date,
                            Password: GetHashString(password),
                            Email: email
                            );
                        db.Researchers.Add(researcher);
                        db.SaveChanges();

                        ResearcherForm rf = new ResearcherForm();
                        rf.Show();
                        rf.setBuyerData(researcher);
                        this.Visible = false;
                }
            } else MessageBox.Show("Необходимо заполнить все поля!");

        }
    }
}
