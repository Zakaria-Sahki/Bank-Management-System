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
    public partial class frmAddEditPermissions : Form
    {
        int _PermissionsOfUser = 0;

        public frmAddEditPermissions( ref clsUsers User)
        {
            InitializeComponent();
            _PermissionsOfUser = User.Permission;
        }

        private void RefreshPermissionsCheck() {

            if (_PermissionsOfUser == -1) {

                chkAllPermissions.Checked = true;
                return;
            }


            if((_PermissionsOfUser & (int)clsCurrentUser.enPermissions.eClients) == (int)clsCurrentUser.enPermissions.eClients)
                chkClients.Checked = true;

            if ((_PermissionsOfUser & (int)clsCurrentUser.enPermissions.eAddClients) == (int)clsCurrentUser.enPermissions.eAddClients)
                chkAddClient.Checked = true;

            if ((_PermissionsOfUser & (int)clsCurrentUser.enPermissions.eUpdateClients) == (int)clsCurrentUser.enPermissions.eUpdateClients)
                chkUpdateClient.Checked = true;

            if ((_PermissionsOfUser & (int)clsCurrentUser.enPermissions.eDeleteClients) == (int)clsCurrentUser.enPermissions.eDeleteClients)
                chkDeleteClient.Checked = true;




            if ((_PermissionsOfUser & (int)clsCurrentUser.enPermissions.eAccounts) == (int)clsCurrentUser.enPermissions.eAccounts)
                chkAccounts.Checked = true;

            if ((_PermissionsOfUser & (int)clsCurrentUser.enPermissions.eAddAccount) == (int)clsCurrentUser.enPermissions.eAddAccount)
                chkAddAccount.Checked = true;

            if ((_PermissionsOfUser & (int)clsCurrentUser.enPermissions.eUpdateAccount) == (int)clsCurrentUser.enPermissions.eUpdateAccount)
                chkUpdateAccount.Checked = true;

            if ((_PermissionsOfUser & (int)clsCurrentUser.enPermissions.eDeleteAccount) == (int)clsCurrentUser.enPermissions.eDeleteAccount)
                chkDeleteAccount.Checked = true;


            if ((_PermissionsOfUser & (int)clsCurrentUser.enPermissions.eUsers) == (int)clsCurrentUser.enPermissions.eUsers)
                chkUsers.Checked = true;

            if ((_PermissionsOfUser & (int)clsCurrentUser.enPermissions.eAddUser) == (int)clsCurrentUser.enPermissions.eAddUser)
                chkAddUser.Checked = true;

            if ((_PermissionsOfUser & (int)clsCurrentUser.enPermissions.eUpdateUser) == (int)clsCurrentUser.enPermissions.eUpdateUser)
                chkUpdateUser.Checked = true;

            if ((_PermissionsOfUser & (int)clsCurrentUser.enPermissions.eDeleteUser) == (int)clsCurrentUser.enPermissions.eDeleteUser)
                chkDeleteUser.Checked = true;


            if ((_PermissionsOfUser & (int)clsCurrentUser.enPermissions.eTransactions) == (int)clsCurrentUser.enPermissions.eTransactions)
                chkTransactionsOperations.Checked = true;

            if ((_PermissionsOfUser & (int)clsCurrentUser.enPermissions.eLoginRegister) == (int)clsCurrentUser.enPermissions.eLoginRegister)
                chkLoginRegister.Checked = true;
        }

        private int CalculatePermission() {

            int NewPermissionsSet = 0;

            if (chkAllPermissions.Checked == true) {

                NewPermissionsSet = -1;
                return NewPermissionsSet;
            }

            // Clients Permissions Check.

            if (chkClients.Checked == true)
                NewPermissionsSet += Convert.ToInt32(chkClients.Tag);

            if (chkAddClient.Checked == true)
                NewPermissionsSet += Convert.ToInt32(chkAddClient.Tag);

            if (chkUpdateClient.Checked == true)
                NewPermissionsSet += Convert.ToInt32(chkUpdateClient.Tag);

            if (chkDeleteClient.Checked == true)
                NewPermissionsSet += Convert.ToInt32(chkDeleteClient.Tag);

            // Accounts Permissions Check.

            if (chkAccounts.Checked == true)
                NewPermissionsSet += Convert.ToInt32(chkAccounts.Tag);

            if (chkAddAccount.Checked == true)
                NewPermissionsSet += Convert.ToInt32(chkAddAccount.Tag);

            if (chkUpdateAccount.Checked == true)
                NewPermissionsSet += Convert.ToInt32(chkUpdateAccount.Tag);

            if (chkDeleteAccount.Checked == true)
                NewPermissionsSet += Convert.ToInt32(chkDeleteAccount.Tag);


            // Users Permissions Check.

            if (chkUsers.Checked == true)
                NewPermissionsSet += Convert.ToInt32(chkUsers.Tag);

            if (chkAddUser.Checked == true)
                NewPermissionsSet += Convert.ToInt32(chkAddUser.Tag);

            if (chkUpdateUser.Checked == true)
                NewPermissionsSet += Convert.ToInt32(chkUpdateUser.Tag);

            if (chkDeleteUser.Checked == true)
                NewPermissionsSet += Convert.ToInt32(chkDeleteUser.Tag);


            // Transactions Permission Check.

            if (chkTransactionsOperations.Checked == true)
                NewPermissionsSet += Convert.ToInt32(chkTransactionsOperations.Tag);

            // Login Regsister Permission Check.

            if (chkLoginRegister.Checked == true)
                NewPermissionsSet += Convert.ToInt32(chkLoginRegister.Tag);


            return NewPermissionsSet;
        }

        private void frmAddEditPermissions_Load(object sender, EventArgs e)
        {
            
            RefreshPermissionsCheck();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            int UpdatedPermissionsSet = CalculatePermission();
            clsCurrentUser.NewSelectedPermissions = UpdatedPermissionsSet;
            
        }
    }
}
