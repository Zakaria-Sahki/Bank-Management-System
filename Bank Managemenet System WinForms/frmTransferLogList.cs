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
    public partial class frmTransferLogList : Form
    {
        public frmTransferLogList()
        {
            
            InitializeComponent();
            this.Size = new Size(780, 550);
        }

        private void _RefreshTransferLogList()
        {

            dgvTransferLog.DataSource = clsTransactions.GetAllTransferLog();
        }

        private void frmTransferLogList_Load(object sender, EventArgs e)
        {
            _RefreshTransferLogList();
        }
    }
}
