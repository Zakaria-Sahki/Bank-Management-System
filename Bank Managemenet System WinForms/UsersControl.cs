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
    public partial class UsersControl : UserControl
    {
        public UsersControl()
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


        private void _RefreshUsersList() {

            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(21, 101, 192);   // background color
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(224, 224, 224);  // text color
            dgvUsers.DataSource = clsUsers.GetAllUsers();
        }

        private void UsersControl_Load(object sender, EventArgs e)
        {


            _RefreshUsersList();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {

            if (!CheckPermissions((int)clsCurrentUser.enPermissions.eAddUser))
            {

                MessageBox.Show("Access denied. You do not have permission to enter this section.", "Permission required.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmAddEditUser AddEditUserForm = new frmAddEditUser(-1);
            AddEditUserForm.ShowDialog();
            _RefreshUsersList();
        }

        private void updateUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckPermissions((int)clsCurrentUser.enPermissions.eUpdateUser))
            {

                MessageBox.Show("Access denied. You do not have permission to enter this section.", "Permission required.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmAddEditUser AddEditUserForm = new frmAddEditUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            AddEditUserForm.ShowDialog();
            _RefreshUsersList();
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!CheckPermissions((int)clsCurrentUser.enPermissions.eDeleteUser))
            {

                MessageBox.Show("Access denied. You do not have permission to enter this section.", "Permission required.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }



            if (MessageBox.Show($"You want to Delete this User with UserID = {(int)dgvUsers.CurrentRow.Cells[0].Value} ?", "Delete User", MessageBoxButtons.YesNo) == DialogResult.No)
                return;


            if (clsUsers.DeleteUser((int)dgvUsers.CurrentRow.Cells[0].Value))
            {

                MessageBox.Show("The User has been Deleted successfully..", "Successful Operation", MessageBoxButtons.OK);
                _RefreshUsersList();
            }
            else
            {

                MessageBox.Show("This record cannot be deleted because it is linked to other data in the system.", "Delete Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnFindUser_Click(object sender, EventArgs e)
        {
            FindUser frmFindUser = new FindUser();
            frmFindUser.ShowDialog();
        }
    }
}
