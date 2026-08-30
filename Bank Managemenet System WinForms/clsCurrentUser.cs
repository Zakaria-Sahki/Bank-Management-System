using BankBusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Managemenet_System_WinForms
{
    public static class clsCurrentUser {


        public static clsUsers CurrentUser = new clsUsers();    
        public enum enPermissions { 
            eClients = 1,
            eAddClients = 2,
            eUpdateClients = 4,
            eDeleteClients = 8,
            eAccounts = 16,
            eAddAccount = 32,
            eUpdateAccount = 64,
            eDeleteAccount = 128,
            eUsers = 256,
            eAddUser = 512,
            eUpdateUser = 1024,
            eDeleteUser = 2048,
            eTransactions = 4096,
            eLoginRegister = 8192,
            eAll = -1
        }

        public static int NewSelectedPermissions = 0;
    }
}
