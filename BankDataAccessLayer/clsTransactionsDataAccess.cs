using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDataAccessLayer
{
    public class clsTransactionsDataAccess {

        public static bool RegisterTransferLog(int SourceAccountID, int DestinationAccountID, double Amount, int UserID, string CurrencyCode) {

            bool RegisteredSuccessfully = false;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"DECLARE @CurrencyID INT;
            SELECT @CurrencyID = (SELECT TOP 1 CurrencyID FROM Currencies WHERE Code = @CurrencyCode);
            
            INSERT INTO TransferLog (DateOfTransfer, SourceAccount,
            DestinationAccount, PerformedBy, CurrencyID_FK, Amount)
            VALUES (GETDATE(), @SourceAccount, @DestinationAccount, @PerformedBy,
            @CurrencyID, @Amount);
            SELECT SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@SourceAccount", SourceAccountID);
            Command.Parameters.AddWithValue("@DestinationAccount", DestinationAccountID);
            Command.Parameters.AddWithValue("@PerformedBy", UserID);
            Command.Parameters.AddWithValue("@CurrencyCode", CurrencyCode);
            Command.Parameters.AddWithValue("@Amount", Amount);


            try {

                Connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null) {

                    RegisteredSuccessfully = true;
                }
                else {

                    RegisteredSuccessfully = false;
                }
            }
            catch (Exception Ex) {

                RegisteredSuccessfully = false;
                Console.WriteLine($"Error: {Ex.Message}.");
            }
            finally {

                Connection.Close();
            }
            return RegisteredSuccessfully;
        }
        public static DataTable GetAllTransferLog() { 
            
            DataTable TransferLogTable = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"SELECT TransferLog.TransferID, TransferLog.DateOfTransfer, 
            (SELECT AccountNumber FROM Accounts WHERE AccountID = SourceAccount) AS SourceAccount, 
            (SELECT AccountNumber FROM Accounts WHERE AccountID = DestinationAccount) AS DestinationAccount, 
            Users.Username AS PerformedBy, Currencies.Code, TransferLog.Amount
            FROM  TransferLog  INNER JOIN Users ON TransferLog.PerformedBy = Users.UserID
            INNER JOIN Currencies ON TransferLog.CurrencyID_FK = Currencies.CurrencyID;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try { 
            
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows) {

                    TransferLogTable.Load(Reader);
                }
                Reader.Close();
            }
            catch (Exception Ex) {

                Console.WriteLine($"Error: {Ex.Message}.");
            }
            finally { 
            
                Connection.Close();
            }
            return TransferLogTable;
        }
        public static DataTable GetAllTotalBalances()
        {

            DataTable TotalBalancesTable = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"SELECT Sum(Balance) As TotalBalance, Currencies.Code 
                            FROM Accounts INNER JOIN Currencies 
                            ON Accounts.CurrencyID_FK = Currencies.CurrencyID
                            GROUP BY Currencies.Code;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {

                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {

                    TotalBalancesTable.Load(Reader);
                }
                Reader.Close();
            }
            catch (Exception Ex)
            {

                Console.WriteLine($"Error: {Ex.Message}.");
            }
            finally
            {

                Connection.Close();
            }
            return TotalBalancesTable;
        }
    }
}
