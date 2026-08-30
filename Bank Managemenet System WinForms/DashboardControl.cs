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
    public partial class DashboardControl : UserControl
    {
        public DashboardControl()
        {
            InitializeComponent();
        }

        private void DashboardControl_Load(object sender, EventArgs e)
        {
            lblNumberOfAccounts.Text = clsAccounts.CountAllAccounts().ToString();
            lblNumberOfUsers.Text = clsUsers.CountAllUsers().ToString();
            lblNumberOfClients.Text = clsClients.CountAllClients().ToString();

            lblFirstName.Text = clsCurrentUser.CurrentUser.FirstName;
            lblLastName.Text = clsCurrentUser.CurrentUser.LastName;
            lblEmail.Text = clsCurrentUser.CurrentUser.Email;
            lblUsername.Text = clsCurrentUser.CurrentUser.Username;
        }
    }
}
