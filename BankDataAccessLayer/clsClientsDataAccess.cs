using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDataAccessLayer
{

    public class clsClientsDataAccess
    {

        public static int AddNewClient(string FirstName, string LastName, string Email, string Phone) {

            int ClientID = 0;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);

            string Query = @"INSERT INTO Persons (FirstName, LastName, Email, Phone)
                             VALUES (@FirstName, @LastName, @Email, @Phone);
                             
                             INSERT INTO Clients(PersonID)
                             VALUES (SCOPE_IDENTITY());
                             SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@Email", Email);
            Command.Parameters.AddWithValue("@Phone", Phone);


            try {

                Connection.Open();

                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    ClientID = InsertedID;
                else
                    ClientID = -1;

            }
            catch (Exception Ex) {

                Console.WriteLine($"Error: " + Ex.Message);
            }
            finally {

                Connection.Close();
            }

            return ClientID;
        }
        public static bool FindClient(int ClientID, ref string FirstName, ref string LastName, ref string Email, ref string Phone) {

            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);

            string Query = @"SELECT Clients.ClientID, Persons.FirstName,
                            Persons.LastName, Persons.Email, Persons.Phone
                            FROM   Clients INNER JOIN Persons 
                            ON Clients.PersonID = Persons.PersonID
                            WHERE ClientID = @ClientID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ClientID", ClientID);

            try {

                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    isFound = true;
                    FirstName = (string)Reader["FirstName"];
                    LastName = (string)Reader["LastName"];
                    Email = (string)Reader["Email"];
                    Phone = (string)Reader["Phone"];
                }
                else {

                    return false;
                }
                    Reader.Close();
            }
            catch (Exception Ex) {

                isFound = false;
                Console.WriteLine($"Error: {Ex.Message}"); 
            }
            finally { 
            
                Connection.Close();
            }

            return isFound;
        }
        public static bool FindClient(string FirstName, string LastName, ref int ClientID, ref string Email, ref string Phone)
        {

            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);

            string Query = @"SELECT Clients.ClientID, Persons.FirstName,
                            Persons.LastName, Persons.Email, Persons.Phone
                            FROM   Clients INNER JOIN Persons 
                            ON Clients.PersonID = Persons.PersonID
                            WHERE Persons.FirstName = @FirstName AND Persons.LastName = @LastName;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@LastName", LastName);

            try
            {

                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    isFound = true;
                    ClientID = (int)Reader["ClientID"];
                    Email = (string)Reader["Email"];
                    Phone = (string)Reader["Phone"];
                }
                else {

                    return false;
                }
                    Reader.Close();
            }
            catch (Exception Ex)
            {

                isFound = false;
                Console.WriteLine($"Error: {Ex.Message}");
            }
            finally
            {

                Connection.Close();
            }

            return isFound;
        }
        public static DataTable GetAllClients()
        {

            DataTable ClientsTable = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);

            string Query = @"SELECT Clients.ClientID, Persons.FirstName,
                            Persons.LastName, Persons.Email, Persons.Phone
                            FROM   Clients INNER JOIN Persons 
                            ON Clients.PersonID = Persons.PersonID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {

                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                    ClientsTable.Load(Reader);

                Reader.Close();
            }
            catch (Exception Ex)
            {

                Console.WriteLine($"Error: " + Ex.Message);
            }
            finally
            {

                Connection.Close();
            }
            return ClientsTable;
        }
        public static bool DeleteClient(int ClientID) {

            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);

            string Query = @"DECLARE @PersonID INT;
                            SELECT @PersonID = PersonID FROM Clients WHERE ClientID = @ClientID;
                            
                            DELETE FROM Clients WHERE ClientID = @ClientID;
                            DELETE FROM Persons WHERE PersonID = @PersonID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ClientID", ClientID);

            try { 
            
                Connection.Open();
                RowAffected = Command.ExecuteNonQuery();

            }
            catch (Exception Ex) {

                Console.WriteLine($"Error: " + Ex.Message);
            }
            finally { 
            
                Connection.Close();
            }
            return (RowAffected > 0);
        }
        public static bool DeleteClient(string FirstName, string LastName)
        {

            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);

            string Query = @"DECLARE @ClientID INT;
            SELECT @ClientID = Clients.ClientID
            FROM   Clients INNER JOIN Persons 
            ON Clients.PersonID = Persons.PersonID
            WHERE Persons.FirstName = @FirstName AND Persons.LastName = @LastName;
            
            
            DECLARE @PersonID INT;
            SELECT @PersonID = PersonID FROM Clients WHERE ClientID = @ClientID;
            
            DELETE FROM Clients WHERE ClientID = @ClientID;
            DELETE FROM Persons WHERE PersonID = @PersonID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@LastName", LastName);

            try
            {

                Connection.Open();
                RowAffected = Command.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {

                Console.WriteLine($"Error: " + Ex.Message);
            }
            finally
            {

                Connection.Close();
            }
            return (RowAffected > 0);
        }
        public static bool UpdateClient(int ClientID, string FirstName, string LastName, string Email, string Phone) { 
            
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);

            string Query = @"UPDATE Persons
            SET FirstName = @FirstName, LastName = @LastName ,Email = @Email ,Phone = @Phone
            WHERE PersonID = (SELECT PersonID FROM Clients WHERE Clients.ClientID = @ClientID);";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ClientID", ClientID);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@Email", Email);
            Command.Parameters.AddWithValue("@Phone", Phone);

            try { 
            
                Connection.Open();
                RowAffected = Command.ExecuteNonQuery();

            }
            catch (Exception Ex) { 

                Console.WriteLine($"Error: " + Ex.Message);
                return false;
            }
            finally { 
            
                Connection.Close();
            }
            return (RowAffected > 0);
        }
        public static bool IsExistClient(int ID) {

            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"SELECT Found = 1 FROM Clients WHERE ClientID = @ClientID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ClientID", ID);

            try { 
            
                Connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null)
                    isFound = true;
                else
                    isFound = false;
            }
            catch (Exception Ex) { Console.WriteLine($"Error: {Ex.Message}"); isFound = false; }
            finally { 
            
                Connection.Close();
            }
            return isFound;
        }
        public static bool IsExistClient(string FirstName, string LastName)
        {

            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"SELECT Found = 1
                FROM   Clients INNER JOIN Persons 
                ON Clients.PersonID = Persons.PersonID
                WHERE Persons.FirstName = @FirstName AND Persons.LastName = @LastName;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@LastName", LastName);

            try
            {

                Connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null)
                    isFound = true;
                else
                    isFound = false;
            }
            catch (Exception Ex) { Console.WriteLine($"Error: {Ex.Message}"); isFound = false; }
            finally
            {

                Connection.Close();
            }
            return isFound;
        }


        public static int CountAllClients()
        {

            int CountOfClients = 0;

            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);

            string Query = @"SELECT COUNT(*) FROM Clients;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {

                Connection.Open();

                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int AllClients))
                    CountOfClients = AllClients;


            }
            catch (Exception Ex)
            {

                Console.WriteLine($"Error: " + Ex.Message);
            }
            finally
            {

                Connection.Close();
            }
            return CountOfClients;
        }

    }
}

