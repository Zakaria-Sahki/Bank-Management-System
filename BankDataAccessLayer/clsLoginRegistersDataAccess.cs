using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDataAccessLayer
{
    public class clsLoginRegistersDataAccess {


        public static DataTable GetAllLoginRegisters() { 
            
            DataTable LoginRegistersTable = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"SELECT LoginRegisters.LogInID, LoginRegisters.Date_Time,
            Users.Username, Users.Password, Users.Permissions FROM   Users INNER JOIN
             LoginRegisters ON Users.UserID = LoginRegisters.UserID_FK";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try {

                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if(Reader.HasRows)
                    LoginRegistersTable.Load(Reader);

                Reader.Close();
            }

            catch (Exception Ex) {

                Console.WriteLine($"Error: {Ex.Message}.");
            }

            finally { 
            
                Connection.Close();
            }
            return LoginRegistersTable;
        }
        public static int AddNewLoginRegisters(int UserID) {

            int LoginID = -1;
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"
            INSERT INTO LoginRegisters (Date_Time, UserID_FK)
            VALUES (GETDATE(), @UserID);
            SELECT SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserID", UserID);

            try { 
            
                Connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {

                    LoginID = InsertedID;
                }
                else { 
                    
                    LoginID = -1;
                }
            }
            catch (Exception Ex) {

                LoginID = -1;
                Console.WriteLine($"Error: {Ex.Message}.");
            }
            finally { 
            
                Connection.Close();
            }

            return LoginID;
        }
        public static DataTable FindLoginRegistersByUsesrname(string Username) {

            DataTable LoginRegisters = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"SELECT LoginRegisters.LogInID, LoginRegisters.Date_Time, Users.Username, Users.Password, Users.Permissions
            FROM   Users INNER JOIN LoginRegisters 
            ON Users.UserID = LoginRegisters.UserID_FK
            WHERE Username = @Username;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Username", Username);

            try {

                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                    LoginRegisters.Load(Reader);

                Reader.Close();
            }
            catch (Exception Ex) {

                Console.WriteLine($"Error: {Ex.Message}.");
            }
            finally { 
                
                Connection.Close();
            }
            return LoginRegisters;
        }
    }
}
