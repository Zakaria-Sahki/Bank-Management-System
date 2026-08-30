using BankDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBusinessLayer
{
    public class clsTransactions {

        public static DataTable GetAllTransferLog() { 
            
            return clsTransactionsDataAccess.GetAllTransferLog();
        }
        public static DataTable GetAllTotalBalances()
        {

            return clsTransactionsDataAccess.GetAllTotalBalances();
        }
        public static bool RegisterTransferLog(clsAccounts SourceAccount, clsAccounts DestinationAccount, double Amount, clsUsers User) {


            return clsTransactionsDataAccess.RegisterTransferLog(SourceAccount.AccountID, DestinationAccount.AccountID, Amount, User.UserID, SourceAccount.CurrencyCode);
        }
    }
}
