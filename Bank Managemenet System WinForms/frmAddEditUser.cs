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
using static Bank_Managemenet_System_WinForms.frmAddEditAccount;

namespace Bank_Managemenet_System_WinForms
{
    public partial class frmAddEditUser : Form
    {
        enum enMode { AddNew, Update};
        enMode Mode;
        clsUsers _User;
        int _UserID;


        public frmAddEditUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            if (_UserID == -1)
                Mode = enMode.AddNew;
            else
                Mode = enMode.Update;
        }

        private bool _ValidatingAllInputs()
        {

            if (string.IsNullOrWhiteSpace(txtFirstName.Text)
                || string.IsNullOrWhiteSpace(txtLastName.Text)
                || string.IsNullOrWhiteSpace(txtEmail.Text)
                || string.IsNullOrWhiteSpace(txtPhone.Text)
                || string.IsNullOrWhiteSpace(txtUsername.Text)
                || string.IsNullOrWhiteSpace(txtPassword.Text))
            {

                MessageBox.Show("Please complete your information. !", "Information is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtPhone.Text.Length < 10) {

                MessageBox.Show("Phone Number must have at least 10 characters !", "Phone Number incorrect", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtPassword.Text.Length < 4)
            {

                MessageBox.Show("Password must have at least 4 characters !", "Password incorrect", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtEmail.Text.Length < 10)
            {

                MessageBox.Show("The Email must have the @ and at least 10 characters.", "Email incorrect", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }



        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!_ValidatingAllInputs())
                return;

            _User.FirstName = txtFirstName.Text;
            _User.LastName = txtLastName.Text;
            _User.Email = txtEmail.Text;
            _User.Phone = txtPhone.Text;
            _User.Username = txtUsername.Text;
            _User.Password = txtPassword.Text;            

            if (_User.Save())
            {

                MessageBox.Show($"User Added/Updated Successfully.", "Record Added/Updated Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {

                MessageBox.Show($"User Added/Updated faild.", "Failed to Add/Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {

            if (Mode == enMode.AddNew) {

                lblTitleOfFormAddEditUser.Text = "Add New User";
                _User = new clsUsers();
                return;
            }

            _User = clsUsers.FindUser(_UserID);

            if (_User == null) {

                MessageBox.Show("This form will be closed because no User with this ID.");
                this.Close();
                return;
            }

            lblTitleOfFormAddEditUser.Text = "Update User";

            txtFirstName.Text = _User.FirstName;
            txtLastName.Text = _User.LastName;
            txtEmail.Text = _User.Email;
            txtPhone.Text = _User.Phone;
            txtUsername.Text = _User.Username;
            txtPassword.Text = _User.Password;
            

        }

        private void btnPermissions_Click(object sender, EventArgs e)
        {
            frmAddEditPermissions AddEditPermissions = new frmAddEditPermissions(ref _User);
            AddEditPermissions.ShowDialog();
            _User.Permission = clsCurrentUser.NewSelectedPermissions;
        }
    }
}
