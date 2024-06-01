using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class ResearcherForm : Form
    {
        public ResearcherForm()
        {
            InitializeComponent();
        }

        public void setBuyerData(Researcher researcher)
        {
            this.NameLabel.Text += $" {researcher.Name}";
            this.SurnameLabel.Text += $" {researcher.Surname}";
            this.BDateLabel.Text += $" {researcher.BDate}";
            this.AdressLabel.Text += $" {researcher.ResearchLocation}";
            this.FirstBuyDateLabel.Text += $" {researcher.FirstPublicDate}";
            this.EmailLabel.Text += $" {researcher.Email}";
            this.PhoneNumberLabel.Text += $" {researcher.PhoneNumber}";
        }
    }
}
