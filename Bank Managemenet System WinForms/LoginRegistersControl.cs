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
    public partial class LoginRegistersControl : UserControl
    {
        public LoginRegistersControl()
        {
            InitializeComponent();
        }

        private void _RefreshLoginRegistersList() {

            dgvLoginRegisters.EnableHeadersVisualStyles = false;
            dgvLoginRegisters.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(21, 101, 192);   // background color
            dgvLoginRegisters.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(224, 224, 224);  // text color
            dgvLoginRegisters.DataSource = clsLoginRegisters.GetAllLoginRegisters();
        }

        private void LoginRegistersControl_Load(object sender, EventArgs e)
        {
            _RefreshLoginRegistersList();
        }
    }
}
