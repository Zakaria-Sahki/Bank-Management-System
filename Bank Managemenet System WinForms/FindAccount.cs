using BankBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Managemenet_System_WinForms
{
    public partial class FindAccount : Form
    {
        public FindAccount()
        {
            InitializeComponent();
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtAccountNumber.Text) || string.IsNullOrWhiteSpace(txtPinCode.Text)) {

                MessageBox.Show("Please complete Account information. !", "Information is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            clsAccounts Account = clsAccounts.FindAccount(txtAccountNumber.Text, txtPinCode.Text);

            if (Account == null) {

                MessageBox.Show("Account with this Account Number and PinCode is not found, Please try again!", "Incorrect Inputs", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            txtFirstName.Text = Account.FirstName;
            txtLastName.Text = Account.LastName;
            txtBalance.Text = Account.Balance.ToString();
            txtCurrencyCode.Text = Account.CurrencyCode.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
