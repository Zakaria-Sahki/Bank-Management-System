using BankDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BankBusinessLayer
{
    public class clsLoginRegisters {


        public int LoginID { get; set; }
        public DateTime Date_Time { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Permissions { get; set; }

        public clsLoginRegisters() {

            this.LoginID = 0;
            this.Date_Time = DateTime.Now;
            this.Username = string.Empty;
            this.Password = string.Empty;
            this.Permissions = 0;
        }
        private clsLoginRegisters(int LogInID, DateTime Date, string Username, string Password, int Permissions) {
        
            this.LoginID = LogInID;
            this.Date_Time = Date;
            this.Username = Username;
            this.Password = Password;
            this.Permissions = Permissions;
        }

        public static DataTable GetAllLoginRegisters() { 
            
            return clsLoginRegistersDataAccess.GetAllLoginRegisters();
        }
        public static bool AddNewLoginRegister(int UserID) {

            int LogInID = -1;
            LogInID = clsLoginRegistersDataAccess.AddNewLoginRegisters(UserID);
            return (LogInID != -1);
        }
        public static DataTable FindLoginRegisterByUsername(string Username)
        {

            return clsLoginRegistersDataAccess.FindLoginRegistersByUsesrname(Username);
        }
    }
}
