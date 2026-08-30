using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDataAccessLayer
{
    public class clsUsersDataAccess {

        public static DataTable GetAllUsers() {

            DataTable UsersTable = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"SELECT Users.UserID, Persons.FirstName, Persons.LastName,
                             Persons.Email, Persons.Phone, Users.Username,
                             Users.Password, Users.Permissions
                             FROM   Persons INNER JOIN Users 
                             ON Persons.PersonID = Users.PersonID;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try { 
            
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                    UsersTable.Load(Reader);

                Reader.Close();
            }
            catch (Exception ex) {

                Console.WriteLine($"Error: {ex.Message}");
            }
            finally {

                Connection.Close();
            }
            return UsersTable;
        }
        public static bool FindUser(int UserID, ref string FirstName, ref string LastName, ref string Email, ref string Phone, ref string Username, ref string Password, ref int Permissions) {

            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"SELECT Users.UserID, Persons.FirstName, Persons.LastName,
                             Persons.Email, Persons.Phone, Users.Username,
                             Users.Password, Users.Permissions
                             FROM   Persons INNER JOIN Users 
                             ON Persons.PersonID = Users.PersonID
                             WHERE UserID = @UserID;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@UserID", UserID);

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
                    Username = (string)Reader["Username"];
                    Password = (string)Reader["Password"];
                    Permissions = (int)Reader["Permissions"];
                }
                else { 
                    
                    isFound = false;
                }
                Reader.Close();
            }
            catch (Exception ex) { 

                isFound = false;
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally { 
                
                Connection.Close(); 
            }
            return isFound;
        }
        public static bool FindUser(string Username, ref int UserID, ref string FirstName, ref string LastName, ref string Email, ref string Phone, ref string Password, ref int Permissions)
        {

            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"SELECT Users.UserID, Persons.FirstName, Persons.LastName,
                             Persons.Email, Persons.Phone, Users.Username,
                             Users.Password, Users.Permissions
                             FROM   Persons INNER JOIN Users 
                             ON Persons.PersonID = Users.PersonID
                             WHERE Username = @Username";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@Username", Username);

            try
            {

                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {

                    isFound = true;

                    UserID = (int)Reader["UserID"];
                    FirstName = (string)Reader["FirstName"];
                    LastName = (string)Reader["LastName"];
                    Email = (string)Reader["Email"];
                    Phone = (string)Reader["Phone"];
                    Password = (string)Reader["Password"];
                    Permissions = (int)Reader["Permissions"];
                }
                else
                {

                    isFound = false;
                }
                Reader.Close();
            }
            catch (Exception ex)
            {

                isFound = false;
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {

                Connection.Close();
            }
            return isFound;
        }
        public static bool IsExistUser(int ID) {

            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"SELECT Found = 1 FROM Users WHERE UserID = @UserID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserID", ID);

            try {

                Connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null)
                    isFound = true;
                else
                    isFound = false;
            }
            catch (Exception Ex) {

                Console.WriteLine($"Error: {Ex.Message}");
                isFound = false;
            }
            finally {

                Connection.Close();
            }
            return isFound;
        }
        public static bool IsExistUser(string Username)
        {

            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"SELECT Found = 1 FROM Users WHERE Username = @Username;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Username", Username);

            try
            {

                Connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null)
                    isFound = true;
                else
                    isFound = false;
            }
            catch (Exception Ex)
            {

                Console.WriteLine($"Error: {Ex.Message}");
                isFound = false;
            }
            finally
            {

                Connection.Close();
            }
            return isFound;
        }

        public static int AddNewUser(string FirstName, string LastName, string Email, string Phone, string Username, string Password, int Permissions) {

            int UserID = -1;

            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"INSERT INTO Persons (FirstName, LastName, Email, Phone)
                             VALUES (@FirstName, @LastName, @Email, @Phone);
                                                          
                             INSERT INTO Users(Username, Password, Permissions, PersonID)
                             VALUES (@Username, @Password, @Permissions, SCOPE_IDENTITY());
                             
                             SELECT SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@Email", Email);
            Command.Parameters.AddWithValue("@Phone", Phone);
            Command.Parameters.AddWithValue("@Username", Username);
            Command.Parameters.AddWithValue("@Password", Password);
            Command.Parameters.AddWithValue("@Permissions", Permissions);

            try {

                Connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID)) { 
                    
                    UserID = InsertedID;
                }
                else
                    UserID = -1;
            }

            catch (Exception Ex) {

                UserID = -1;
                Console.WriteLine($"Error: {Ex.Message}");
            }
            finally { 
            
                Connection.Close();
            }
            return UserID;
        }
        public static bool DeleteUser(int ID) {

            int AffectedRow = 0;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"DECLARE @PersonID INT;
                             SELECT @PersonID = Users.PersonID FROM Users WHERE UserID = @UserID;
                             DELETE FROM Users WHERE UserID = @UserID;
                             DELETE FROM Persons WHERE PersonID = @PersonID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserID", ID);

            try { 
            
                Connection.Open();
                AffectedRow = Command.ExecuteNonQuery();
            }
            catch (Exception Ex) {

                Console.WriteLine($"Error: {Ex.Message}");
            }
            finally { 
            
                Connection.Close();
            }
            return (AffectedRow > 0);
        }
        public static bool UpdateUser(int UserID, string FirstName, string LastName, string Email, string Phone, string Username, string Password, int Permissions) {

            int AffectedRow = 0;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"DECLARE @PersonID INT;
            SELECT @PersonID = PersonID FROM Users WHERE UserID = @UserID;
            
            UPDATE Users SET Username = @Username, Password = @Password, Permissions = @Permissions
            WHERE UserID = @UserID;
            
            UPDATE Persons SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone
            WHERE PersonID = @PersonID;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@UserID", UserID);
            Command.Parameters.AddWithValue("@Username", Username);
            Command.Parameters.AddWithValue("@Password", Password);
            Command.Parameters.AddWithValue("@Permissions", Permissions);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@Email", Email);
            Command.Parameters.AddWithValue("@Phone", Phone);

            try {

                Connection.Open();
                AffectedRow = Command.ExecuteNonQuery();
            }
            catch (Exception Ex) {

                Console.WriteLine($"Error: {Ex.Message}");
            }
            finally { 
            
                Connection.Close();
            }

            return (AffectedRow > 0);
        }


        public static int CountAllUsers()
        {

            int CountAllUsers = 0;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"SELECT COUNT(*) FROM Users;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {

                Connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int AllUsers))
                    CountAllUsers = AllUsers;
                
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {

                Connection.Close();
            }
            return CountAllUsers;
        }
    }
}
