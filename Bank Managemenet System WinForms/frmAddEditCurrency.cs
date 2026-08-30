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
    public partial class frmAddEditCurrency : Form
    {
        enum enMode { AddNew, Update};
        enMode Mode = enMode.AddNew;

        clsCurrencies _Currency;
        int _CurrencyID;

        public frmAddEditCurrency(int CurrencyID)
        {
            InitializeComponent();
            _CurrencyID = CurrencyID;
            if (_CurrencyID == -1)
                Mode = enMode.AddNew;
            else
                Mode = enMode.Update;
        }

        private void _LoadData() {

            if (Mode == enMode.AddNew) {

                lblTitleOfForm.Text = "Add New Currency";
                _Currency = new clsCurrencies();
                return;
            }

            _Currency = clsCurrencies.FindCurrency(_CurrencyID);

            if (_Currency == null) {

                MessageBox.Show("This form will be closed because no Currency with this ID.");
                this.Close();
                return;
            }

            lblTitleOfForm.Text = "Update Currency";
            txtCountry.Text = _Currency.Country;
            txtCode.Text = _Currency.Code;
            txtCurrencyName.Text = _Currency.CurrencyName;
            txtRate.Text = _Currency.Rate.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCountry.Text = string.Empty;
            txtCode.Text = string.Empty;
            txtCurrencyName.Text = string.Empty;
            txtRate.Text = string.Empty;
        }

        private void frmAddEditCurrency_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private bool ValidatingInputs() {

            if (string.IsNullOrWhiteSpace(txtCountry.Text) 
                || string.IsNullOrWhiteSpace(txtCode.Text) 
                || string.IsNullOrWhiteSpace(txtCurrencyName.Text) 
                || string.IsNullOrWhiteSpace(txtRate.Text)) {


                MessageBox.Show("Please fill in all required fields before continuing.", "Missing Information",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtCode.Text.Length > 10) {

                MessageBox.Show("Currency code must be a maximum of 5 characters.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidatingInputs())
                return;

            _Currency.Country = txtCountry.Text;
            _Currency.Code = txtCode.Text;
            _Currency.CurrencyName = txtCurrencyName.Text;
            _Currency.Rate = Convert.ToDecimal(txtRate.Text);

            if (_Currency.Save())
            {

                MessageBox.Show("The Record Add/Update Succssfully.", "Add/Update Record Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {

                MessageBox.Show("The Record Add/Update Faild.", "Add/Update Record Faild", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
