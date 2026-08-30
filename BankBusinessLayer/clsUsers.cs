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
    public class clsUsers {

        enum enMode { AddNew, Update};
        enMode Mode = enMode.Update;

        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Permission { get; set; }


        public clsUsers() {

            UserID = -1;
            FirstName = "";
            LastName = "";
            Email = "";
            Phone = "";
            Username = "";
            Password = "";
            Permission = 0;
            Mode = enMode.AddNew;
        }
        private clsUsers(int UserID, string FirstName, string LastName, string Email, string Phone, string Username, string Password, int Permissions) {
        
            this.UserID = UserID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Username = Username;
            this.Password = Password;
            this.Permission = Permissions;
            Mode = enMode.Update;
        }


        public static DataTable GetAllUsers() {

            return clsUsersDataAccess.GetAllUsers();
        }
        public static clsUsers FindUser(int ID) {

            string FirstName = "", LastName = "", Email = "", Phone = "", Username = "", Password = "";
            int Permissions = 0;

            if (clsUsersDataAccess.FindUser(ID, ref FirstName, ref LastName, ref Email, ref Phone, ref Username, ref Password, ref Permissions))
            {

                return new clsUsers(ID, FirstName, LastName, Email, Phone, Username, Password, Permissions);
            }
            else {

                return null;
            }
        }
        public static clsUsers FindUser(string Username)
        {

            string FirstName = "", LastName = "", Email = "", Phone = "", Password = "";
            int UserID = 0, Permissions = 0;

            if (clsUsersDataAccess.FindUser(Username, ref UserID, ref FirstName, ref LastName, ref Email, ref Phone, ref Password, ref Permissions))
            {

                return new clsUsers(UserID, FirstName, LastName, Email, Phone, Username, Password, Permissions);
            }
            else
            {

                return null;
            }
        }
        public static bool IsUserExist(int ID) {
        
            return clsUsersDataAccess.IsExistUser(ID);
        }
        public static bool IsUserExist(string Username)
        {

            return clsUsersDataAccess.IsExistUser(Username);
        }
        private bool _AddNewUser() {

            this.UserID = clsUsersDataAccess.AddNewUser(this.FirstName, this.LastName, this.Email, this.Phone, this.Username, this.Password, this.Permission);
            return (UserID != -1);
        }
        private bool _UpdateUser() {

            return clsUsersDataAccess.UpdateUser(this.UserID, this.FirstName, this.LastName, this.Email, this.Phone, this.Username, this.Password, this.Permission);
        }
        public bool Save() {

            switch (Mode) {

                case enMode.AddNew:

                    if (_AddNewUser()) {

                        Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _UpdateUser();
            }
            return false;
        }
        public static bool DeleteUser(int ID) {

            return clsUsersDataAccess.DeleteUser(ID);
        }

        public static int CountAllUsers() { 
            
            return clsUsersDataAccess.CountAllUsers();
        }
    }
}
