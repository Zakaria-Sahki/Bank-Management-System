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
    public partial class frmCurrencies : Form
    {
        public frmCurrencies()
        {
            InitializeComponent();
            this.Size = new Size(900, 525);
        }

        private void _RefreshCurrenciesList() {

            dgvCurrencies.DataSource = clsCurrencies.GetAllCurrencies();
        }
        private void frmCurrencies_Load(object sender, EventArgs e)
        {
            _RefreshCurrenciesList();
        }
        private void btnFindClient_Click(object sender, EventArgs e)
        {
            frmFindCurrency FindCurrencyForm = new frmFindCurrency();
            FindCurrencyForm.ShowDialog();
        }
        private void btnAddClient_Click(object sender, EventArgs e)
        {
            frmAddEditCurrency CurrencyEditForm = new frmAddEditCurrency(-1);
            CurrencyEditForm.ShowDialog();
            _RefreshCurrenciesList();
        }
        private void updateCurrencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditCurrency CurrencyEditForm = new frmAddEditCurrency((int)dgvCurrencies.CurrentRow.Cells[0].Value);
            CurrencyEditForm.ShowDialog();
            _RefreshCurrenciesList();
        }
        private void deleteCurrencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure you want to delete Currency with ID = {(int)dgvCurrencies.CurrentRow.Cells[0].Value} ?", "Delete Currency", MessageBoxButtons.YesNo) == DialogResult.No)
                return;


            if (clsCurrencies.DeleteCurrency((int)dgvCurrencies.CurrentRow.Cells[0].Value))
            {

                MessageBox.Show("The Currency has been Deleted successfully..", "Successful Operation", MessageBoxButtons.OK);
                _RefreshCurrenciesList();
            }
            else
            {

                MessageBox.Show("This record cannot be deleted because it is linked to other data in the system.", "Delete Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    }
}
