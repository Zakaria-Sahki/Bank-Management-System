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
    public partial class TransferLogControl : UserControl
    {
        public TransferLogControl()
        {
            InitializeComponent();
        }

        private void _RefreshTransferLogList() {

            dgvTransferLog.DataSource = clsTransactions.GetAllTransferLog();
        }

        private void TransferLogControl_Load(object sender, EventArgs e)
        {
            _RefreshTransferLogList();
        }
    }
}
