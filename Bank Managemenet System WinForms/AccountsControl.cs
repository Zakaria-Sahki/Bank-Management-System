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
    public partial class AccountsControl : UserControl
    {
        

        public AccountsControl()
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


        private void _RefreshAccountList()
        {
            dgvAccounts.EnableHeadersVisualStyles = false;
            dgvAccounts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(21, 101, 192);   // background color
            dgvAccounts.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(224, 224, 224);  // text color
            dgvAccounts.DataSource = clsAccounts.GetAllAccounts();
        }
        private void AccountsControl_Load(object sender, EventArgs e)
        {
            _RefreshAccountList();

        }
        private void btnAddAccount_Click(object sender, EventArgs e)
        {

            if (!CheckPermissions((int)clsCurrentUser.enPermissions.eAddAccount))
            {

                MessageBox.Show("Access denied. You do not have permission to enter this section.", "Permission required.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmAddEditAccount AddEditAccountForm = new frmAddEditAccount(-1);
            AddEditAccountForm.ShowDialog();

            _RefreshAccountList();
        }

        private void updateAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!CheckPermissions((int)clsCurrentUser.enPermissions.eUpdateAccount))
            {

                MessageBox.Show("Access denied. You do not have permission to enter this section.", "Permission required.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmAddEditAccount AddEditAccountForm = new frmAddEditAccount((int)dgvAccounts.CurrentRow.Cells[0].Value);
            AddEditAccountForm.ShowDialog();

            _RefreshAccountList();
        }

        private void btnFindAccount_Click(object sender, EventArgs e)
        {
            FindAccount FindAccountForm = new FindAccount();
            FindAccountForm.ShowDialog();

        }

        private void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!CheckPermissions((int)clsCurrentUser.enPermissions.eDeleteAccount))
            {

                MessageBox.Show("Access denied. You do not have permission to enter this section.", "Permission required.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (MessageBox.Show($"You want to Delete this Account with AccountID = {(int)dgvAccounts.CurrentRow.Cells[0].Value} ?", "Delete Account", MessageBoxButtons.YesNo) == DialogResult.No)
                return;


            if (clsAccounts.DeleteAccount((int)dgvAccounts.CurrentRow.Cells[0].Value)) {

                MessageBox.Show("The account has been Deleted successfully..", "Successful Operation", MessageBoxButtons.OK);
                _RefreshAccountList();
            }
            else {

                MessageBox.Show("This record cannot be deleted because it is linked to other data in the system.", "Delete Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}
