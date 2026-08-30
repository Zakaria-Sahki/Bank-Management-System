using BankDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBusinessLayer
{
    public class clsCurrencies {

        enum enMode { AddNew, Update};
        enMode Mode = enMode.Update;

        public int CurrencyID { get; set; }
        public string Code { get; set; }
        public string Country { get; set; }
        public string CurrencyName { get; set; }
        public decimal Rate { get; set; }


        public clsCurrencies() {


            this.CurrencyID = 0;
            this.Country = "";
            this.Code = "";
            this.CurrencyName = "";
            this.Rate = 0;

            Mode = enMode.AddNew;
        }
        private clsCurrencies(int CurrencyID, string Country, string Code, string CurrencyName, decimal Rate) {
        
            this.CurrencyID = CurrencyID;
            this.Country = Country;
            this.Code = Code;
            this.CurrencyName = CurrencyName;
            this.Rate = Rate;

            Mode = enMode.Update;
        }



        public static DataTable GetAllCurrencies() {

            return clsCurrenciesDataAccess.GetAllCurrencies();
        }
        public static clsCurrencies FindCurrency(int CurrencyID) {

            string Country = "", Code = "", CurrencyName = "";
            decimal Rate = 0;
            if (clsCurrenciesDataAccess.FindCurrency(CurrencyID, ref Country, ref Code, ref CurrencyName, ref Rate))
            {

                return new clsCurrencies(CurrencyID, Country, Code, CurrencyName, Rate);
            }
            else {

                return null;
            }

        }

        public static clsCurrencies FindCurrency(string Country, string Code)
        {
            int CurrencyID = 0;
            string CurrencyName = "";
            decimal Rate = 0;
            if (clsCurrenciesDataAccess.FindCurrency(Country, Code.ToUpper(), ref CurrencyID, ref CurrencyName, ref Rate))
            {

                return new clsCurrencies(CurrencyID, Country, Code, CurrencyName, Rate);
            }
            else
            {

                return null;
            }

        }


        public static clsCurrencies FindCurrency(string Country)
        {
            int CurrencyID = 0;
            string CurrencyName = "";
            string Code = "";
            decimal Rate = 0;

            if (clsCurrenciesDataAccess.FindCurrency(Country, ref Code, ref CurrencyID, ref CurrencyName, ref Rate))
            {

                return new clsCurrencies(CurrencyID, Country, Code, CurrencyName, Rate);
            }
            else
            {

                return null;
            }

        }



        public static bool IsCurrencyExist(int CurrencyID) { 
            
            return clsCurrenciesDataAccess.IsCurrencyExist(CurrencyID);
        }
        public static bool IsCurrencyExist(string Country, string Code)
        {

            return clsCurrenciesDataAccess.IsCurrencyExist(Country, Code.ToUpper());
        }
        public static bool DeleteCurrency(int CurrencyID) { 
        
            return clsCurrenciesDataAccess.DeleteCurrency(CurrencyID);
        }
        public static bool DeleteCurrency(string Country, string Code)
        {

            return clsCurrenciesDataAccess.DeleteCurrency(Country, Code.ToUpper());
        }


        private bool _AddNewCurrency() {

            this.CurrencyID = clsCurrenciesDataAccess.AddNewCurrency(this.Country, this.Code, this.CurrencyName, this.Rate);
            return (this.CurrencyID != -1);
        }
        private bool _UpdateCurrency() {

            return clsCurrenciesDataAccess.UpdateCurrency(this.CurrencyID, this.Country, this.Code, this.CurrencyName, this.Rate);
        }
        public bool Save() {

            switch (Mode) {

                case enMode.AddNew:
                    if (_AddNewCurrency()) {

                        Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _UpdateCurrency();
            }
            return false;
        }

    }
}
