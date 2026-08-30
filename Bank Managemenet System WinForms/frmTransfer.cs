using BankBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Managemenet_System_WinForms
{
    public partial class frmTransfer : Form
    {

        clsAccounts SourceAccount;
        clsAccounts DestinationAccount;
        public frmTransfer()
        {
            
            InitializeComponent();
            this.Size = new Size(910, 520);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidationOfAccounts() {

            if (string.IsNullOrWhiteSpace(txtAccountNumberFrom.Text) && string.IsNullOrWhiteSpace(txtAccountNumberTo.Text))
            {

                MessageBox.Show("Please Enter the two Account Numbers.", "Information is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAccountNumberTo.Text))
            {

                MessageBox.Show("Please Enter the Destination Account Numbers.", "Information is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAccountNumberFrom.Text)) {

                MessageBox.Show("Please Enter the Source Account Numbers.", "Information is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void FillDataIntoTextBoxes() {

            txtFirstNameFrom.Text = SourceAccount.FirstName;
            txtLastNameFrom.Text = SourceAccount.LastName;
            txtBalanceFrom.Text = SourceAccount.Balance.ToString();
            txtEmailFrom.Text = SourceAccount.Email;
            txtPhoneFrom.Text = SourceAccount.Phone;


            txtFirstNameTo.Text = DestinationAccount.FirstName;
            txtLastNameTo.Text = DestinationAccount.LastName;
            txtBalanceTo.Text = DestinationAccount.Balance.ToString();
            txtEmailTo.Text = DestinationAccount.Email;
            txtPhoneTo.Text = DestinationAccount.Phone;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!ValidationOfAccounts())
                return;

            SourceAccount = clsAccounts.FindAccount(txtAccountNumberFrom.Text);
            DestinationAccount = clsAccounts.FindAccount(txtAccountNumberTo.Text);

            if (SourceAccount == null)
            {

                MessageBox.Show("Source Account with this Account Number is not found, Please try again!", "Incorrect Inputs", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (DestinationAccount == null)
            {

                MessageBox.Show("Destination Account with this Account Number is not found, Please try again!", "Incorrect Inputs", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (SourceAccount.AccountNumber == DestinationAccount.AccountNumber) {

                MessageBox.Show("You can't transfer money to the same account.", "Transfer not allowed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (SourceAccount.CurrencyCode != DestinationAccount.CurrencyCode) {

                MessageBox.Show("This transfer can’t be completed because the source and destination accounts use different currencies.", "Transfer not allowed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            FillDataIntoTextBoxes();

            btnTransfer.Visible = true;
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtAmountToTransfer.Text)) {

                MessageBox.Show("Please Enter the Amount You want to Transfer.", "Information is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            double AmountToTransfer = Convert.ToDouble(txtAmountToTransfer.Text);

            if (AmountToTransfer < 0)
            {

                MessageBox.Show("Amount to transfer must be positive.", "Amount Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (AmountToTransfer > SourceAccount.Balance) {

                MessageBox.Show("Insufficient balance. The amount you entered exceeds Source Account balance.", "Amount Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (clsAccounts.Transfer(SourceAccount.AccountNumber, DestinationAccount.AccountNumber, AmountToTransfer, clsCurrentUser.CurrentUser))
            {

                MessageBox.Show($"Your transfer of Amount {AmountToTransfer} {SourceAccount.CurrencyCode} From \"{SourceAccount.AccountNumber}\" To \"{DestinationAccount.AccountNumber}\" was completed Successfully", "Transfer Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else {

                MessageBox.Show($"The transfer could not be completed. Please check your account balance, network connection, or contact support if the problem persists.", "Transfer Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void frmTransfer_Load(object sender, EventArgs e)
        {

        }
    }
}
