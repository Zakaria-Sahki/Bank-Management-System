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
    public partial class FindUser : Form
    {
        public FindUser()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtUsername.Text)) {

                MessageBox.Show("You have to enter Username", "Input Missing", MessageBoxButtons.OK);
                return;
            }

            clsUsers User = clsUsers.FindUser(txtUsername.Text);

            if (User == null) {

                MessageBox.Show("This Username not found.", "Username Not Found", MessageBoxButtons.OK);
                return;
            }

            txtFirstName.Text = User.FirstName;
            txtLastName.Text = User.LastName;
            txtEmail.Text = User.Email;
            txtPassword.Text = User.Password;
            txtUsername.Text = User.Username;
            txtPhone.Text = User.Phone;

        }

        private void FindUser_Load(object sender, EventArgs e)
        {

        }
    }
}
