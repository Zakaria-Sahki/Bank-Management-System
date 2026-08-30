using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Managemenet_System_WinForms
{
    public partial class HomeForm : Form
    {

        int ExitMark = 1;
        public HomeForm()
        {
            InitializeComponent();
            this.Size = new Size(1000, 600);
        }

        private bool CheckPermissions(int SectionPermission) {

            if (clsCurrentUser.CurrentUser.Permission == -1)
                return true;

            if ((clsCurrentUser.CurrentUser.Permission & SectionPermission) == SectionPermission)
                return true;

            return false;
        }

        private void ShowControl(UserControl Contorl) {

            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            Contorl.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(Contorl);
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {

            ShowControl(new DashboardControl());
        }



        private void button2_Click(object sender, EventArgs e)
        {

            if (!CheckPermissions((int)clsCurrentUser.enPermissions.eAccounts))
            {

                MessageBox.Show("Access denied. You do not have permission to enter this section.", "Permission required.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ShowControl(new AccountsControl());
        }



        private void btnUsers_Click(object sender, EventArgs e)
        {

            if (!CheckPermissions((int)clsCurrentUser.enPermissions.eUsers))
            {

                MessageBox.Show("Access denied. You do not have permission to enter this section.", "Permission required.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ShowControl(new UsersControl());
        }
        private void button6_Click(object sender, EventArgs e)
        {
            
            frmBankMSystem NewForm = new frmBankMSystem();
            ExitMark = -1;
            this.Close();
            NewForm.ShowDialog();
            
        }
        private void btnLoginRegister_Click(object sender, EventArgs e)
        {


            if (!CheckPermissions((int)clsCurrentUser.enPermissions.eLoginRegister))
            {

                MessageBox.Show("Access denied. You do not have permission to enter this section.", "Permission required.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ShowControl(new LoginRegistersControl());
        }
        private void btnClients_Click_1(object sender, EventArgs e)
        {

            if (!CheckPermissions((int)clsCurrentUser.enPermissions.eClients)) {

                MessageBox.Show("Access denied. You do not have permission to enter this section.", "Permission required.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ShowControl(new ClientsControl());
        }
        private void btnTransactions_Click(object sender, EventArgs e)
        {

            if (!CheckPermissions((int)clsCurrentUser.enPermissions.eTransactions))
            {

                MessageBox.Show("Access denied. You do not have permission to enter this section.", "Permission required.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ShowControl(new TransactionsControl());
        }
        private void HomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ExitMark != -1) { 

                Application.Exit();
            }
        }
        private void HomeForm_Load(object sender, EventArgs e)
        {
            ShowControl(new DashboardControl());
        }
    }
}
