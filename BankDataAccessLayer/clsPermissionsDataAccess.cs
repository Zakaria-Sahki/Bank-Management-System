using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDataAccessLayer
{
    public class clsPermissionsDataAccess {

        public static DataTable GetAllPermissions() { 
            
            DataTable PermissionsTable = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);
            string Query = @"SELECT * FROM PermissionsTable;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try {

                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                    PermissionsTable.Load(Reader);

                Reader.Close();
            }
            catch (Exception Ex)
            {

                Console.WriteLine($"Error: {Ex.Message}.");
            }
            finally {

                Connection.Close();
            }
            return PermissionsTable;
        }

    }
}
