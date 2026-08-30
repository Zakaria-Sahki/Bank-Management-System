using BankDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BankDataAccessLayer
{
    public class clsAccountsDataAccess {


        public static DataTable GetAllAccounts() { 
            
            DataTable AccountsTable = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"SELECT Accounts.AccountID, Accounts.AccountNumber, Accounts.PinCode, Persons.FirstName,
            Persons.LastName, Persons.Email, Persons.Phone, Accounts.Balance, Currencies.Code
            FROM   Accounts INNER JOIN Clients ON Accounts.ClientID_FK = Clients.ClientID 
            INNER JOIN Persons ON Clients.PersonID = Persons.PersonID 
            INNER JOIN Currencies ON Accounts.CurrencyID_FK = Currencies.CurrencyID";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try {

                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows) { 
                    
                    AccountsTable.Load(Reader);
                }
                Reader.Close();
            }
            catch (Exception Ex) {

                Console.WriteLine($"Error: {Ex.Message}.");
            }
            finally { 
                
                Connection.Close();
            }
            return AccountsTable;
        }
        public static bool FindAccount(int AccountID, ref string AccountNumber, ref string PinCode, ref string FirstName, ref string LastName, ref string Email, ref string Phone, ref double Balance, ref string CurrencyCode) {

            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"SELECT Accounts.AccountID, Accounts.AccountNumber, Accounts.PinCode, Persons.FirstName,
            Persons.LastName, Persons.Email, Persons.Phone, Accounts.Balance, Currencies.Code
            FROM   Accounts INNER JOIN Clients ON Accounts.ClientID_FK = Clients.ClientID 
            INNER JOIN Persons ON Clients.PersonID = Persons.PersonID 
            INNER JOIN Currencies ON Accounts.CurrencyID_FK = Currencies.CurrencyID
            WHERE AccountID = @AccountID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AccountID", AccountID);

            try { 
            
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {

                    isFound = true;

                    AccountNumber = (string)Reader["AccountNumber"];
                    PinCode = (string)Reader["PinCode"];
                    FirstName = (string)Reader["FirstName"];
                    LastName = (string)Reader["LastName"];
                    Email = (string)Reader["Email"];
                    Phone = (string)Reader["Phone"];
                    Balance = Convert.ToDouble(Reader["Balance"]);
                    CurrencyCode = (string)Reader["Code"];
                }
                else { 
                
                    isFound = false;
                }
                    Reader.Close();
            }
            catch (Exception Ex) {

                isFound = false;
                Console.WriteLine($"Error: {Ex.Message}.");
            }
            finally { 
            
                Connection.Close();
            }
            return isFound;
        }
        public static bool FindAccount(string AccountNumber, string PinCode, ref int AccountID, ref string FirstName, ref string LastName, ref string Email, ref string Phone, ref double Balance, ref string CurrencyCode)
        {

            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"SELECT Accounts.AccountID, Accounts.AccountNumber, Accounts.PinCode, Persons.FirstName,
            Persons.LastName, Persons.Email, Persons.Phone, Accounts.Balance, Currencies.Code
            FROM   Accounts INNER JOIN Clients ON Accounts.ClientID_FK = Clients.ClientID 
            INNER JOIN Persons ON Clients.PersonID = Persons.PersonID 
            INNER JOIN Currencies ON Accounts.CurrencyID_FK = Currencies.CurrencyID
            WHERE AccountNumber = @AccountNumber AND PinCode = @PinCode;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AccountNumber", AccountNumber);
            Command.Parameters.AddWithValue("@PinCode", PinCode);

            try
            {

                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {

                    isFound = true;

                    AccountID = (int)Reader["AccountID"];
                    FirstName = (string)Reader["FirstName"];
                    LastName = (string)Reader["LastName"];
                    Email = (string)Reader["Email"];
                    Phone = (string)Reader["Phone"];
                    Balance = Convert.ToDouble(Reader["Balance"]);
                    CurrencyCode = (string)Reader["Code"];
                }
                else
                {

                    isFound = false;
                }
                Reader.Close();
            }
            catch (Exception Ex)
            {

                isFound = false;
                Console.WriteLine($"Error: {Ex.Message}.");
            }
            finally
            {

                Connection.Close();
            }
            return isFound;
        }
        public static bool FindAccount(string AccountNumber, ref string PinCode, ref int AccountID, ref string FirstName, ref string LastName, ref string Email, ref string Phone, ref double Balance, ref string CurrencyCode)
        {

            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"SELECT Accounts.AccountID, Accounts.AccountNumber, Accounts.PinCode, Persons.FirstName,
            Persons.LastName, Persons.Email, Persons.Phone, Accounts.Balance, Currencies.Code
            FROM   Accounts INNER JOIN Clients ON Accounts.ClientID_FK = Clients.ClientID 
            INNER JOIN Persons ON Clients.PersonID = Persons.PersonID 
            INNER JOIN Currencies ON Accounts.CurrencyID_FK = Currencies.CurrencyID
            WHERE AccountNumber = @AccountNumber;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AccountNumber", AccountNumber);
            Command.Parameters.AddWithValue("@PinCode", PinCode);

            try
            {

                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {

                    isFound = true;

                    AccountID = (int)Reader["AccountID"];
                    PinCode = (string)Reader["PinCode"]; 
                    FirstName = (string)Reader["FirstName"];
                    LastName = (string)Reader["LastName"];
                    Email = (string)Reader["Email"];
                    Phone = (string)Reader["Phone"];
                    Balance = Convert.ToDouble(Reader["Balance"]);
                    CurrencyCode = (string)Reader["Code"];
                }
                else
                {

                    isFound = false;
                }
                Reader.Close();
            }
            catch (Exception Ex)
            {

                isFound = false;
                Console.WriteLine($"Error: {Ex.Message}.");
            }
            finally
            {

                Connection.Close();
            }
            return isFound;
        }
        public static bool IsExistAccount(int AccountID) {

            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"SELECT Found = 1 FROM Accounts WHERE AccountID = @AccountID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AccountID", AccountID);

            try { 
                
                Connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null)
                {
                    isFound = true;
                }
                else { 
                    
                    isFound = false;
                }
            }
            catch (Exception Ex) { 
            
                isFound = false;
                Console.WriteLine($"Error: {Ex.Message}.");
            }
            finally { 
            
                Connection.Close();
            }
            return isFound;
        }
        public static bool IsExistAccount(string AccountNumber)
        {

            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"SELECT Found = 1 FROM Accounts WHERE AccountNumber = @AccountNumber;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AccountNumber", AccountNumber);

            try
            {

                Connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null)
                {
                    isFound = true;
                }
                else
                {

                    isFound = false;
                }
            }
            catch (Exception Ex)
            {

                isFound = false;
                Console.WriteLine($"Error: {Ex.Message}.");
            }
            finally
            {

                Connection.Close();
            }
            return isFound;
        }
        public static bool IsExistAccount(string AccountNumber, string PinCode)
        {

            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"SELECT Found = 1 FROM Accounts WHERE AccountNumber = @AccountNumber AND PinCode = @PinCode;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AccountNumber", AccountNumber);
            Command.Parameters.AddWithValue("@PinCode", PinCode);

            try
            {

                Connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null)
                {
                    isFound = true;
                }
                else
                {

                    isFound = false;
                }
            }
            catch (Exception Ex)
            {

                isFound = false;
                Console.WriteLine($"Error: {Ex.Message}.");
            }
            finally
            {

                Connection.Close();
            }
            return isFound;
        }
        public static int AddNewAccount(string AccountNumber, string PinCode, double Balance, string Currency, int ClientID)
        {

            int AccountID = -1;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"INSERT INTO Accounts (AccountNumber, PinCode, Balance, CurrencyID_FK, ClientID_FK)
                            VALUES (@AccountNumber, @PinCode, @Balance, (SELECT TOP 1 CurrencyID FROM Currencies WHERE Code = @Currency), @clientID);
                            SELECT SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AccountNumber", AccountNumber);
            Command.Parameters.AddWithValue("@PinCode", PinCode);
            Command.Parameters.AddWithValue("@Balance", Balance);
            Command.Parameters.AddWithValue("@Currency", Currency);
            Command.Parameters.AddWithValue("@clientID", ClientID);

            try { 
            
                Connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {

                    AccountID = InsertedID;
                }
                else { 
                    
                    AccountID = -1;
                }
            }

            catch (Exception Ex) {

                AccountID = -1;
                Console.WriteLine($"Error: {Ex.Message}.");
            }

            finally { 
            
                Connection.Close();
            }
            return AccountID;
        }
        public static bool UpdateAccount(int AccountID, string PinCode, string CurrencyCode, double Balance) {

            int AffectedRows = 0;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"DECLARE @CurrencyID INT;
            SELECT @CurrencyID = (SELECT TOP 1 CurrencyID FROM Currencies WHERE Code = @CurrencyCode);
            
            UPDATE Accounts SET 
            PinCode = @PinCode, Balance = @Balance, CurrencyID_FK = @CurrencyID
            WHERE AccountID = @AccountID;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@AccountID", AccountID);
            Command.Parameters.AddWithValue("@PinCode", PinCode);
            Command.Parameters.AddWithValue("@Balance", Balance);
            Command.Parameters.AddWithValue("@CurrencyCode", CurrencyCode);

            try { 
            
                Connection.Open();
                AffectedRows = Command.ExecuteNonQuery();
            
            }
            catch (Exception Ex) {

                Console.WriteLine($"Error: {Ex.Message}.");
            }

            finally { 
            
                Connection.Close();
            }
            return (AffectedRows > 0);
        }
        public static bool DeleteAccount(int ID) {

            int AffectedRow = 0;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"DELETE FROM Accounts WHERE AccountID = @AccountID;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@AccountID", ID);

            try { 
            
                Connection.Open();
                AffectedRow = Command.ExecuteNonQuery();
            }

            catch (Exception Ex) { 

                Console.WriteLine($"Error: {Ex.Message}."); 
            }

            finally { 
            
                Connection.Close();
            }
            return (AffectedRow > 0);
        }
        public static bool DeleteAccount(string AccountNumber)
        {

            int AffectedRow = 0;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"DELETE FROM Accounts WHERE AccountNumber = @AccountNumber;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@AccountNumber", AccountNumber);

            try
            {

                Connection.Open();
                AffectedRow = Command.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {

                Console.WriteLine($"Error: {Ex.Message}.");
            }

            finally
            {

                Connection.Close();
            }
            return (AffectedRow > 0);
        }

        public static int CountAccounts()
        {

            int AccountCounter = 0;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"SELECT COUNT(*) FROM Accounts;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {

                Connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int AllAccounts)) { 
                    
                    AccountCounter = AllAccounts;
                }
                
            }
            catch (Exception Ex)
            {

                Console.WriteLine($"Error: {Ex.Message}.");
            }
            finally
            {

                Connection.Close();
            }
            return AccountCounter;
        }
    }
}


//SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
//string Query = @"";
//SqlCommand Command = new SqlCommand(Query, Connection);