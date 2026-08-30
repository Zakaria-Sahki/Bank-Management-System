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
    public partial class frmFindCurrency : Form
    {
        clsCurrencies Currency;

        public frmFindCurrency()
        {
            InitializeComponent();
        }

        private void FillCountriesInComboBox() {

            DataTable Countries = clsCurrencies.GetAllCurrencies();

            foreach (DataRow Row in Countries.Rows) {

                cbCountries.Items.Add(Row["Country"]);
            }
        }
        private void frmFindCurrency_Load(object sender, EventArgs e)
        {
            FillCountriesInComboBox();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cbCountries.SelectedIndex = -1;
            txtCode.Text = string.Empty;
            txtCurrencyName.Text = string.Empty;
            txtRate.Text = string.Empty;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            Currency = clsCurrencies.FindCurrency(cbCountries.SelectedItem.ToString());

            if (Currency == null) {

                MessageBox.Show("Currency of this country with this code not found, Please try another Code.", "Currency Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            txtCode.Text = Currency.Code;
            txtCurrencyName.Text = Currency.CurrencyName;
            txtRate.Text = Currency.Rate.ToString();
        }
    }
}
