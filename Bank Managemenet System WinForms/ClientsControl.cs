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
    public partial class ClientsControl : UserControl
    {
        public ClientsControl()
        {
            InitializeComponent();
            
        }
        private bool CheckPermissions(int SectionPermission)
        {

            if (clsCurrentUser.CurrentUser.Permission == -1)
                return true;

            if ((clsCurrentUser.CurrentUser.Permission & SectionPermission) == SectionPermission)
                return true;

            return false;
        }
        private void _RefreshClientsList() {

            dgvClients.EnableHeadersVisualStyles = false;
            dgvClients.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(21, 101, 192);   // background color
            dgvClients.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(224, 224, 224);  // text color
            dgvClients.DataSource = clsClients.GetAllClients();
        }
        private void ClientsControl_Load(object sender, EventArgs e)
        {
            _RefreshClientsList();
        }
        private void btnAddClient_Click(object sender, EventArgs e)
        {
            if (!CheckPermissions((int)clsCurrentUser.enPermissions.eAddClients)) {

                MessageBox.Show("Access denied. You do not have permission to enter this section.", "Permission required.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmAddEditClient AddEditClient = new frmAddEditClient(-1);
            AddEditClient.ShowDialog();
            _RefreshClientsList();
        }
        private void updateClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckPermissions((int)clsCurrentUser.enPermissions.eUpdateClients))
            {

                MessageBox.Show("Access denied. You do not have permission to enter this section.", "Permission required.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmAddEditClient AddEditClient = new frmAddEditClient((int)dgvClients.CurrentRow.Cells[0].Value);
            AddEditClient.ShowDialog();
            _RefreshClientsList();
        }
        private void deleteClientToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!CheckPermissions((int)clsCurrentUser.enPermissions.eDeleteClients))
            {

                MessageBox.Show("Access denied. You do not have permission to enter this section.", "Permission required.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }



            if (MessageBox.Show($"Are you sure you want to delete Client with ID = {(int)dgvClients.CurrentRow.Cells[0].Value} ?", "Delete Client", MessageBoxButtons.YesNo) == DialogResult.No)
                return;


            if (clsClients.DeleteClient((int)dgvClients.CurrentRow.Cells[0].Value))
            {

                MessageBox.Show("The Client has been Deleted successfully..", "Successful Operation", MessageBoxButtons.OK);
                _RefreshClientsList();
            }
            else {

                MessageBox.Show("This record cannot be deleted because it is linked to other data in the system (Accounts) he has.", "Delete Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        private void btnFindClient_Click(object sender, EventArgs e)
        {
            FindClient FindClientForm = new FindClient();
            FindClientForm.ShowDialog();
        }
    }
}
