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
    public partial class BuyerForm : Form
    {
        public BuyerForm()
        {
            InitializeComponent();
        }

        public void setBuyerData(Buyer buyer)
        {
            this.NameLabel.Text += $" {buyer.Name}";
            this.SurnameLabel.Text += $" {buyer.Surname}";
            this.BDateLabel.Text += $" {buyer.BDate}";
            this.AdressLabel.Text += $" {buyer.Adress}";
            this.FirstBuyDateLabel.Text += $" {buyer.FirstBuyDate}";
            this.EmailLabel.Text += $" {buyer.Email}";
            this.PhoneNumberLabel.Text += $" {buyer.PhoneNumber}";
        }
    }
}
