using BankBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Managemenet_System_WinForms
{
    public partial class frmDeposit : Form
    {

        clsAccounts Account;
        public frmDeposit()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAccountNumber.Text))
            {

                MessageBox.Show("Please Enter the Account Number.", "Information is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Account = clsAccounts.FindAccount(txtAccountNumber.Text);

            if (Account == null)
            {

                MessageBox.Show("Account with this Account Number is not found, Please try again!", "Incorrect Inputs", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            txtFirstName.Text = Account.FirstName;
            txtLastName.Text = Account.LastName;
            txtBalance.Text = Account.Balance.ToString();
            txtPinCode.Text = Account.PinCode;
            txtEmail.Text = Account.Email;
            txtPhone.Text = Account.Phone;
            txtCurrencyCode.Text = Account.CurrencyCode.ToString();
        }

        private void ClearAllInputs() {

            txtAccountNumber.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtBalance.Text = string.Empty;
            txtPinCode.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtCurrencyCode.Text = string.Empty;
            txtDepositAmount.Text = string.Empty;
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDepositAmount.Text)) {

                MessageBox.Show("Please Enter the Deposit Amount.", "Information is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            double DepositAmount = Convert.ToDouble(txtDepositAmount.Text);

            if (DepositAmount < 0) {

                MessageBox.Show("Deposit Amount must be positive.", "Deposit Amount Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Account.Deposit(DepositAmount)) {

                MessageBox.Show("Amount Deposit Successfully.", "Deposit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ClearAllInputs();
        }
    }
}
