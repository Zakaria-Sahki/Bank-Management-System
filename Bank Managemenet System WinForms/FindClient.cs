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
    public partial class FindClient : Form
    {
        public FindClient()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text)) {

                MessageBox.Show("You have to Complete your infromation.", "Input Missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            clsClients Client = clsClients.FindClient(txtFirstName.Text, txtLastName.Text);

            if (Client == null) {

                MessageBox.Show("Client not found. Please make sure the first name and last name are correct.", "Client Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtFirstName.Text = Client.FirstName;
            txtLastName.Text = Client.LastName;
            txtEmail.Text = Client.Email;
            txtPhone.Text = Client.Phone;
        }
    }
}
