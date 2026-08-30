using BankDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BankBusinessLayer
{
    public class clsAccounts {

        enum enMode { AddNewAccount, UpdateAccount};
        enMode Mode = enMode.UpdateAccount;

        public int AccountID { get; set; }
        public string AccountNumber { get; set; }
        public string PinCode { get; set; }
        public double Balance { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CurrencyCode { get; set; }
        public int ClientID { get; set; }


        public clsAccounts() {

            AccountID = 0;
            AccountNumber = "";
            PinCode = "";
            Balance = 0;
            FirstName = "";
            LastName = "";
            Email = "";
            Phone = "";
            CurrencyCode = "";

            Mode = enMode.AddNewAccount;
        }
        private clsAccounts(int AccountID, string AccountNumber, string PinCode, string FirstName, string LastName, string Email, string Phone, double Balance, string CurrencyCode) {


            this.AccountID = AccountID;
            this.AccountNumber = AccountNumber;
            this.PinCode = PinCode;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.CurrencyCode = CurrencyCode;
            this.Balance = Balance;

            Mode = enMode.UpdateAccount;
        }



        public static DataTable GetAllAccounts() {

            return clsAccountsDataAccess.GetAllAccounts();
        }

        // the FindAccount with Id is wrong choice.
        public static clsAccounts FindAccount(int ID) {

            double Balance = 0;
            string AccountNumber = "", PinCode = "", FirstName = "", LastName = "", Email = "", Phone = "", CurrencyCode = "";

            if (clsAccountsDataAccess.FindAccount(ID, ref AccountNumber, ref PinCode, ref FirstName, ref LastName, ref Email, ref Phone, ref Balance, ref CurrencyCode))
            {

                return new clsAccounts(ID, AccountNumber, PinCode, FirstName, LastName, Email, Phone, Balance, CurrencyCode);
            }
            else {

                return null;
            }
        }
        public static clsAccounts FindAccount(string AccountNumber, string PinCode) {

            int AccountID = 0;
            double Balance = 0;
            string FirstName = "", LastName = "", Email = "", Phone = "", CurrencyCode = "";

            if (clsAccountsDataAccess.FindAccount(AccountNumber, PinCode, ref AccountID, ref FirstName, ref LastName, ref Email, ref Phone, ref Balance, ref CurrencyCode))
            {

                return new clsAccounts(AccountID, AccountNumber, PinCode, FirstName, LastName, Email, Phone, Balance, CurrencyCode);
            }
            else
            {

                return null;
            }

        }
        public static clsAccounts FindAccount(string AccountNumber)
        {

            int AccountID = 0;
            double Balance = 0;
            string FirstName = "", LastName = "", Email = "", Phone = "", CurrencyCode = "", PinCode = "";

            if (clsAccountsDataAccess.FindAccount(AccountNumber, ref PinCode, ref AccountID, ref FirstName, ref LastName, ref Email, ref Phone, ref Balance, ref CurrencyCode))
            {

                return new clsAccounts(AccountID, AccountNumber, PinCode, FirstName, LastName, Email, Phone, Balance, CurrencyCode);
            }
            else
            {

                return null;
            }

        }
        public static bool IsExistAccount(int AccountID) { 
            
            return clsAccountsDataAccess.IsExistAccount(AccountID);
        }
        public static bool IsExistAccount(string AccountNumber)
        {

            return clsAccountsDataAccess.IsExistAccount(AccountNumber);
        }
        public static bool IsExistAccount(string AccountNumber, string PinCode)
        {

            return clsAccountsDataAccess.IsExistAccount(AccountNumber, PinCode);
        }



        private bool _AddNewAccount() {


            clsClients Client = clsClients.FindClient(this.FirstName, this.LastName);
            if (Client != null)
            {

                this.AccountID = clsAccountsDataAccess.AddNewAccount(this.AccountNumber, this.PinCode, this.Balance, this.CurrencyCode, Client.ClientID);
                return (this.AccountID != -1);
            }
            else {

                return false;
            }
            
        }
        private bool _UpdateAccount() {

            return clsAccountsDataAccess.UpdateAccount(this.AccountID, this.PinCode, this.CurrencyCode, this.Balance);
        }
        public bool Save() {

            switch (Mode) {

                case enMode.AddNewAccount:
                    if (_AddNewAccount()) {

                        Mode = enMode.UpdateAccount;
                        return true;
                    }
                    break;
                case enMode.UpdateAccount:
                    return _UpdateAccount();

            }
            return false;
        }
        public static bool DeleteAccount(int ID) { 
            
            return clsAccountsDataAccess.DeleteAccount(ID);
        }


        // Transactions Operations

        public bool Deposit(double Amount) {

            this.Balance += Amount;
            return _UpdateAccount();
        }
        public bool Withdraw(double Amount) {

            if (this.Balance < Amount)
            {

                return false;
            }
            else { 
                
                this.Balance -= Amount;
                return _UpdateAccount();
            }
        }
        public static bool Transfer(string SourceAccountNumber, string DestinationAccountNumber, double Amount, clsUsers CurrentUser)
        {


            clsAccounts SourceAccount = clsAccounts.FindAccount(SourceAccountNumber);
            clsAccounts DestinationAccount = clsAccounts.FindAccount(DestinationAccountNumber);


            if (SourceAccount == null || DestinationAccount == null)
                return false;

            if (SourceAccount.AccountNumber == DestinationAccount.AccountNumber)
                return false;

            if (SourceAccount.CurrencyCode != DestinationAccount.CurrencyCode)
                return false;

            if (Amount <= 0)
                return false;

            if (!SourceAccount.Withdraw(Amount))
                return false;

            DestinationAccount.Deposit(Amount);



            
            return clsTransactions.RegisterTransferLog(SourceAccount, DestinationAccount, Amount, CurrentUser);
        }

        static public int CountAllAccounts() {

            return clsAccountsDataAccess.CountAccounts();
        }
    }
}
