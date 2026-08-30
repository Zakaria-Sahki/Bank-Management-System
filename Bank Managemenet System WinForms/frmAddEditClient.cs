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
    public partial class frmAddEditClient : Form
    {

        enum enMode { AddNew, Update};
        enMode Mode = enMode.AddNew;

        clsClients _Client;
        int _ClientID;

        public frmAddEditClient(int ClientID)
        {
            InitializeComponent();
            _ClientID = ClientID;
            if (_ClientID == -1)
                Mode = enMode.AddNew;
            else
                Mode = enMode.Update;
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
        }
        private bool _ValidatingAllInputs() {

            if (string.IsNullOrWhiteSpace(txtFirstName.Text)
                || string.IsNullOrWhiteSpace(txtLastName.Text)
                || string.IsNullOrWhiteSpace(txtEmail.Text)
                || string.IsNullOrWhiteSpace(txtPhone.Text))
            {

                MessageBox.Show("Please Complete Your Information.", "Information is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtPhone.Text.Length < 10)
            {

                MessageBox.Show("Phone must have at least 10 characters !", "Phone Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtEmail.Text.Length < 10)
            {

                MessageBox.Show("Email must have a \'@\' and at least 10 characters ! Please try again.", "Email Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!_ValidatingAllInputs())
                return;

            _Client.FirstName = txtFirstName.Text;
            _Client.LastName = txtLastName.Text;
            _Client.Email = txtEmail.Text;
            _Client.Phone = txtPhone.Text;

            if (_Client.save())
            {

                MessageBox.Show($"Client Added/Updated Successfully.", "Record Added/Updated Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {

                MessageBox.Show($"Client Added/Updated faild.", "Failed to Add/Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void frmAddEditClient_Load(object sender, EventArgs e)
        {

            if (Mode == enMode.AddNew) {

                lblAddEditClientForm.Text = "Add New Client";
                _Client = new clsClients();
                return;
            }

            _Client = clsClients.FindClient(_ClientID);

            if (_Client == null) {

                MessageBox.Show("This form will be closed because no User with this ID.");
                this.Close();
                return;
            }

            lblAddEditClientForm.Text = "Update Client";
            txtFirstName.Text = _Client.FirstName;
            txtLastName.Text = _Client.LastName;
            txtEmail.Text = _Client.Email;
            txtPhone.Text = _Client.Phone;
        }
    }
}
