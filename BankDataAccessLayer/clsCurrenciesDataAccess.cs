using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDataAccessLayer
{
    public class clsCurrenciesDataAccess {


        public static DataTable GetAllCurrencies() { 
            
            DataTable CurrenciesTable = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"SELECT * FROM Currencies;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try {

                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows) { 
                    
                    CurrenciesTable.Load(Reader);
                }
                Reader.Close();
            }

            catch (Exception Ex) {

                Console.WriteLine($"Error: {Ex.Message}.");
            }

            finally {

                Connection.Close();
            }
            return CurrenciesTable;
        }
        public static bool FindCurrency(int CurrencyID, ref string Country, ref string Code, ref string CurrencyName, ref decimal Rate) {

            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"SELECT * FROM Currencies WHERE CurrencyID = @CurrencyID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CurrencyID", CurrencyID);

            try
            {

                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    isFound = true;

                    Country = (string)Reader["Country"];
                    Code = (string)Reader["Code"];
                    CurrencyName = (string)Reader["CurrencyName"];
                    Rate = (decimal)Reader["Rate"];
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

            finally { 
                
                Connection.Close();
            }

            return isFound;
        }
        public static bool FindCurrency(string Country, string Code, ref int CurrencyID, ref string CurrencyName, ref decimal Rate)
        {

            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"SELECT * FROM Currencies WHERE Country = @Country AND Code = @Code;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Country", Country);
            Command.Parameters.AddWithValue("@Code", Code);

            try
            {

                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    isFound = true;

                    CurrencyID = (int)Reader["CurrencyID"];
                    CurrencyName = (string)Reader["CurrencyName"];
                    Rate = (decimal)Reader["Rate"];
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


        public static bool FindCurrency(string Country, ref string Code, ref int CurrencyID, ref string CurrencyName, ref decimal Rate)
        {

            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"SELECT * FROM Currencies WHERE Country = @Country;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Country", Country);

            try
            {

                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    isFound = true;

                    Code = (string)Reader["Code"];
                    CurrencyID = (int)Reader["CurrencyID"];
                    CurrencyName = (string)Reader["CurrencyName"];
                    Rate = (decimal)Reader["Rate"];
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



        public static bool IsCurrencyExist(int CurrencyID) {

            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"SELECT Found = 1 FROM Currencies WHERE CurrencyID = @CurrencyID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CurrencyID", CurrencyID);

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
        public static bool IsCurrencyExist(string Country, string Code)
        {

            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"SELECT Found = 1 FROM Currencies WHERE Country = @Country AND Code = @Code;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Country", Country);
            Command.Parameters.AddWithValue("@Code", Code);

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
        public static bool DeleteCurrency(int CurrencyID) {

            int AffectedRow = 0;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"DELETE FROM Currencies WHERE CurrencyID = @CurrencyID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CurrencyID", CurrencyID);

            try { 
            
                Connection.Open();
                AffectedRow = Command.ExecuteNonQuery();

            }
            catch (Exception Ex) { 
            
                AffectedRow = -1;
                Console.WriteLine($"Error: {Ex.Message}.");
            }
            finally { 
                
                Connection.Close();
            }
            return (AffectedRow > 0);
        }
        public static bool DeleteCurrency(string Country, string Code)
        {

            int AffectedRow = 0;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"DELETE FROM Currencies WHERE Country = @Country AND Code = @Code;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Country", Country);
            Command.Parameters.AddWithValue("@Code", Code);

            try
            {

                Connection.Open();
                AffectedRow = Command.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {

                AffectedRow = -1;
                Console.WriteLine($"Error: {Ex.Message}.");
            }
            finally
            {

                Connection.Close();
            }
            return (AffectedRow > 0);
        }


        public static int AddNewCurrency(string Country, string Code, string CurrencyName, decimal Rate) {

            int CurrencyID = -1;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"INSERT INTO Currencies (Country, Code, CurrencyName, Rate)
            VALUES (@Country, @Code, @CurrencyName, @Rate);
            SELECT SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@Country", Country);
            Command.Parameters.AddWithValue("@Code", Code);
            Command.Parameters.AddWithValue("@CurrencyName", CurrencyName);
            Command.Parameters.AddWithValue("@Rate", Rate);

            try { 
            
                Connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {

                    CurrencyID = InsertedID;
                }
                else {

                    CurrencyID = -1;
                }
            }
            catch (Exception Ex) {

                CurrencyID = -1;
                Console.WriteLine($"Error: {Ex.Message}.");
            }
            finally { 
            
                Connection.Close();
            }
            return CurrencyID;
        }
        public static bool UpdateCurrency(int CurrencyID, string Country, string Code, string CurrencyName, decimal Rate) {

            int AffectedRows = 0;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"UPDATE Currencies
            SET Country = @Country, Code = @Code, CurrencyName = @CurrencyName, Rate = @Rate
            WHERE CurrencyID = @CurrencyID;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@CurrencyID", CurrencyID);
            Command.Parameters.AddWithValue("@Country", Country);
            Command.Parameters.AddWithValue("@Code", Code);
            Command.Parameters.AddWithValue("@CurrencyName", CurrencyName);
            Command.Parameters.AddWithValue("@Rate", Rate);

            try { 
            
                Connection.Open();
                AffectedRows = Command.ExecuteNonQuery();
            }

            catch (Exception Ex) {

                AffectedRows = -1;
                Console.WriteLine($"Error: {Ex.Message}.");
            }

            finally { 

                Connection.Close();
            }
            return (AffectedRows > 0);
        }
    
    }
}
