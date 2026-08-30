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
    public partial class TransactionsControl : UserControl
    {
        public TransactionsControl()
        {
            InitializeComponent();
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            frmDeposit DepositForm = new frmDeposit();
            DepositForm.ShowDialog();
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            frmWithdraw WithdrawForm = new frmWithdraw();
            WithdrawForm.ShowDialog();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            frmTransfer TransferForm = new frmTransfer();
            TransferForm.ShowDialog();
        }

        private void btnTransferLog_Click(object sender, EventArgs e)
        {
            frmTransferLogList TransferLogListForm = new frmTransferLogList();
            TransferLogListForm.ShowDialog();
        }

        private void btnCurrencies_Click(object sender, EventArgs e)
        {
            frmCurrencies CurrenciesForm = new frmCurrencies();
            CurrenciesForm.ShowDialog();
        }
    }
}
