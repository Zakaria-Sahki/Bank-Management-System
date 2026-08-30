using BankDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBusinessLayer
{
    public class clsPermissions {

        public int PermissionID { get; set; }
        public string PermissionName { get; set; }
        public int PermissionNumber { get; set; }

        public static DataTable GetAllPermissions() {

            return clsPermissionsDataAccess.GetAllPermissions();
        }
    }
}
