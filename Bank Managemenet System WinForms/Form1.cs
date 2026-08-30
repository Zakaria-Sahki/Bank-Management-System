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
    public partial class frmBankMSystem : Form
    {
        int ExitMark = 1;

        public frmBankMSystem()
        {
            InitializeComponent();
        }

        private void FillCurrentClientInfo(string Username) {

            clsCurrentUser.CurrentUser = clsUsers.FindUser(Username);
            clsLoginRegisters.AddNewLoginRegister(clsCurrentUser.CurrentUser.UserID);
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
             
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text)) {

                MessageBox.Show("Please complete your login information. !", "Login information is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            clsUsers User = clsUsers.FindUser(txtUsername.Text);

            if (User == null) {
                
                MessageBox.Show("Username Incorrect !", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (User.Password == txtPassword.Text) {

                FillCurrentClientInfo(txtUsername.Text);

                this.Hide();
                HomeForm Home = new HomeForm();
                ExitMark = -1;
                Home.Show();
                
            }
            else {

                MessageBox.Show("Password Incorrect !", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {

            //if (string.IsNullOrWhiteSpace(txtUsername.Text))
            //{

            //    e.Cancel = true;
            //    txtUsername.Focus();
            //    errorProvider1.SetError(txtUsername, "Username Should Have a value !");
            //}
            //else
            //{

            //    e.Cancel = false;
            //    errorProvider1.SetError(txtUsername, "");
            //}
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {

            //if (string.IsNullOrWhiteSpace(txtPassword.Text))
            //{

            //    e.Cancel = true;
            //    txtPassword.Focus();
            //    errorProvider1.SetError(txtPassword, "Password Should Have a value !");
            //}
            //else
            //{

            //    e.Cancel = false;
            //    errorProvider1.SetError(txtPassword, "");
            //}
        }








































        private void txtUsername_Validated(object sender, EventArgs e)
        {
        }

        private void frmBankMSystem_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ExitMark != -1) { 

                Application.Exit();
            }
        }
    }
}
