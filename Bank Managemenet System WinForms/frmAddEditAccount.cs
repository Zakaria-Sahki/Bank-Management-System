using BankBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Bank_Managemenet_System_WinForms.AccountsControl;

namespace Bank_Managemenet_System_WinForms
{
    public partial class frmAddEditAccount : Form
    {

        public enum enMode { AddNew, Update };
        private enMode Mode;
        clsAccounts _Account;
        int _AccountID;
        public frmAddEditAccount(int AccountID)
        {
            InitializeComponent();
            _AccountID = AccountID;
            if (_AccountID == -1)
                Mode = enMode.AddNew;
            else
                Mode = enMode.Update;
        }
        private void _FillCurrenciesCodeInComboBox() {

            DataTable CurrenciesCode = clsCurrencies.GetAllCurrencies();

            foreach (DataRow Country in CurrenciesCode.Rows) {

                cbCode.Items.Add(Country["Code"]);
            }
        }
        private void frmAddEditAccount_Load(object sender, EventArgs e)
        {
            _FillCurrenciesCodeInComboBox();
            cbCode.SelectedIndex = 0;

            if (Mode == enMode.AddNew)
            {

                lblTitleOfFormAccount.Text = "Add New Contact";
                _Account = new clsAccounts();
                return;
            }


            _Account = clsAccounts.FindAccount(_AccountID);

            if (_Account == null)
            {

                MessageBox.Show("This form will be closed because no Account with this ID.");
                this.Close();
                return;
            }

            lblTitleOfFormAccount.Text = "Update Account";
            txtFirstName.Text = _Account.FirstName;
            txtLastName.Text = _Account.LastName;
            txtAccountNumber.Text = _Account.AccountNumber;
            txtBalance.Text = _Account.Balance.ToString();
            txtPinCode.Text = _Account.PinCode;

            cbCode.SelectedIndex = cbCode.FindString(_Account.CurrencyCode);

            txtFirstName.Enabled = false;
            txtLastName.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtAccountNumber.Text = string.Empty;
            txtPinCode.Text = string.Empty;
            txtBalance.Text = string.Empty;
            cbCode.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private bool _ValidatingAllInputs() {

            if (string.IsNullOrWhiteSpace(txtFirstName.Text)
                || string.IsNullOrWhiteSpace(txtLastName.Text)
                || string.IsNullOrWhiteSpace(txtAccountNumber.Text)
                || string.IsNullOrWhiteSpace(txtPinCode.Text)
                || string.IsNullOrWhiteSpace(txtBalance.Text)) {

                MessageBox.Show("Please complete your login information. !", "Login information is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if ((!clsClients.IsClientExist(txtFirstName.Text, txtLastName.Text) && (Mode == enMode.AddNew))) {

                MessageBox.Show("Client with this Name is not found, Please try again !", "Incorrect Inputs", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtPinCode.Text.Length < 4) {

                MessageBox.Show("PinCode must have at least 4 characters !", "PinCode incorrect", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (Convert.ToDouble(txtBalance.Text) < 1000) {

                MessageBox.Show("The minimum required balance is 1,000, Please enter a higher amount.", "Insufficient Balance", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (!_ValidatingAllInputs())
                return;



            _Account.FirstName = txtFirstName.Text;
            _Account.LastName = txtLastName.Text;
            _Account.AccountNumber = txtAccountNumber.Text;
            _Account.PinCode = txtPinCode.Text;
            _Account.Balance = Convert.ToDouble(txtBalance.Text);
            _Account.CurrencyCode = cbCode.Text;


            if (_Account.Save())
            {

                MessageBox.Show($"Account Added/Updated Successfully.", "Record Added/Updated Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show($"Account Added/Updated faild.", "Failed to Add/Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbCountries_1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
