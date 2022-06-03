using System;
using System.Collections.Generic;
using System.Text;

namespace GoPrinterSettings
{
    class MyGlobal
    {
        public static frmSetMainSVRParam mFrmSetSRVParam = null;
        
        public static System.Data.SqlClient.SqlConnection MY_SQL_CON = null;
        public static System.Data.SqlClient.SqlConnection MY_SCALA_CON = null;

        public static string GoWHSQLDBString = "";
        public static string GoWHSCALADBString = "";
        public static int MY_USER_ID = 0;
        public static string MY_MSSQL_USER = "";
        public static string MY_MSSQL_PASS = "";
        public static string MY_MSSQL_IP = "";
        public static string MY_MSSQL_DB = "";
        public static int MY_USER_ACC_LEVEL = 0;
        public static string MY_IP_PRINTSVR = "";
        public static string MY_AUTH_KEY = "";
        public static string MY_ISCALA_USER = "";
        public static string MY_ISCALA_PASS = "";
        public static string MY_ISCALA_IP = "";
        public static string MY_ISCALA_DB = "";
        public static string MY_PRINTER = "";
        public static string MY_PRINTER1 = "";

        public static int GiveServersSettings()
        {
            int ret = 0;
            mRegistry mreg = new mRegistry();
        
            try
            {
                MY_MSSQL_USER = mreg.QueryValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoPrinter", "MSSQL_USER", "");
                MY_MSSQL_PASS = mreg.QueryValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoPrinter", "MSSQL_PASS", "");
                MY_MSSQL_IP = mreg.QueryValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoPrinter", "MSSQL_IP", "");
                MY_MSSQL_DB = mreg.QueryValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoPrinter", "MSSQL_DB", "");
                MY_PRINTER = mreg.QueryValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoPrinter", "PRINTER_DEF", "");
                MY_PRINTER1 = mreg.QueryValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoPrinter", "PRINTER_DEF1", "");
                MY_AUTH_KEY = mreg.QueryValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoPrinter", "AUTH_KEY", "");
            
            }
            catch
            {
                ret++;
            }
            if (MY_MSSQL_USER.Trim()=="")
            {
                ret++;
            }
            if (MY_MSSQL_PASS.Trim() == "")
            {
                ret++;
            }
            if (MY_MSSQL_IP.Trim() == "")
            {
                ret++;
            }
            if (MY_MSSQL_DB.Trim() == "")
            {
                ret++;
            }
            if (MY_ISCALA_USER.Trim() == "")
            {
                ret++;
            }
            if (MY_ISCALA_PASS.Trim() == "")
            {
                ret++;
            }
            if (MY_ISCALA_IP.Trim() == "")
            {
                ret++;
            }
            if (MY_ISCALA_DB.Trim() == "")
            {
                ret++;
            }
            if (MY_AUTH_KEY.Trim() == "")
            {
                ret++;
            }
            
            mreg = null;
            return ret;
        }

    }
}
