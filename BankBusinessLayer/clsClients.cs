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
    public class clsClients
    {
        enum enMode { AddNew, Update};
        enMode Mode = enMode.Update;
        public int ClientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }


        public clsClients() { 
        
            ClientID = -1;
            FirstName = "";
            LastName = "";
            Email = "";
            Phone = "";
            Mode = enMode.AddNew;
        }
        private clsClients(int ClientID, string FirstName, string LastName, string Email, string Phone) {
            
            this.ClientID = ClientID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            Mode = enMode.Update;
        }
        

        static public clsClients FindClient(int ClientID) { 
            
            string FirstName = "", LastName = "", Email = "", Phone = "";

            if (clsClientsDataAccess.FindClient(ClientID, ref FirstName, ref LastName, ref Email, ref Phone))
                return new clsClients(ClientID, FirstName, LastName, Email, Phone);
            else
                return null;
        }
        static public clsClients FindClient(string FirstName, string LastName)
        {
            int ClientID = 0;
            string Email = "", Phone = "";

            if (clsClientsDataAccess.FindClient(FirstName, LastName, ref ClientID, ref Email, ref Phone))
                return new clsClients(ClientID, FirstName, LastName, Email, Phone);
            else
                return null;
        }
        private bool _AddNewClient() {

            this.ClientID = clsClientsDataAccess.AddNewClient(this.FirstName, this.LastName, this.Email, this.Phone);
            return (ClientID != -1);
        }
        private bool _UpdateClient() {

            return clsClientsDataAccess.UpdateClient(this.ClientID, this.FirstName, this.LastName, this.Email, this.Phone);
        }
        static public DataTable GetAllClients()
        {

            return clsClientsDataAccess.GetAllClients();
        }
        public bool save() {

            switch (Mode) { 
                
                case enMode.AddNew:

                    if (_AddNewClient()) {

                        Mode = enMode.Update;
                        return true;
                    }
                    break;

                case enMode.Update:
                    return _UpdateClient();

            }
            return false;
        }
        static public bool DeleteClient(int ID) { 
            
            return clsClientsDataAccess.DeleteClient(ID);
        }
        static public bool IsClientExist(int ID) {
            
            return clsClientsDataAccess.IsExistClient(ID);
        }
        static public bool IsClientExist(string FirstName, string LastName)
        {

            return clsClientsDataAccess.IsExistClient(FirstName, LastName);
        }


        static public int CountAllClients() {

            return clsClientsDataAccess.CountAllClients();
        }
    }

}