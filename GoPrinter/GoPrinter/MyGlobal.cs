using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace GoPrinter
{
    public enum GO_PRINTER_CMD
    {
        GO_PRINT_CONNECT=1,
        GO_PRINT_PRINT=2,
        GO_PRINT_AGAIN=3,
        GO_PRINT_CLOSE=4,
        GO_PRINT_PACKINGLIST=5
    }
    
    class MyGlobal
    {
        
        public struct MY_JOB
        {
            int idjob;
            int howmany;
            string orderno;
            int status;
            public int ID_JOB
            {
                get { return idjob; }
                set { idjob = value; }
            }
            public int HOW_MANY_PRINT
            {
                get { return howmany; }
                set { howmany = value; }
            }
            public string ORDER_NUMBER
            {
                get { return orderno; }
                set { orderno = value; }
            }
            public int STATUS_JOB
            {
                get { return status; }
                set { status = value; }
            }
        }
        public struct MY_PROTOCOL_DATA
        {
            long id_user ;
            long cmd_user;
            long cmderr;
            string cmddata;

            public long SID_USER
            {
                get
                {
                    return id_user;
                }
                set
                {
                    id_user = value;
                }
            }
            public long CMD_USER
            {
                get
                {
                    return cmd_user;
                }
                set
                {
                    cmd_user = value;
                }
            }
            public string CMD_DATA
            {
                get
                {
                    return cmddata;
                }
                set
                {
                    cmddata = value;
                }
            }
            public long CMD_ERR
            {
                get
                {
                    return cmderr;
                }
                set
                {
                    cmderr = value;
                }
            }
        }
        
        public static bool I_CAN_STOP = false; 

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

        public static string MY_FIELDS = "`";
        public static string MY_TERMINATOR = "~";

        public static MY_JOB[] MY_JOB_QUE = null;
        public static string MY_CLIENT_USERNAME="";

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
            if (MY_PRINTER.Trim() == "")
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
        public static int GiveMeAvailableJobID()
        {
            int i = 0;
            int x = 0;
            for (i = 0; i < MY_JOB_QUE.GetUpperBound(0)+1; i++)
            {
                if (MY_JOB_QUE[i].ID_JOB == 0)
                {
                    x = i+1;
                    break;
                }
            }
            return x;
        }
        public static void InitializeJobQue(int idjob)
        {
            int i = 0;
            
            if (idjob == 0)
            {
                for (i = 0; i < MY_JOB_QUE.GetUpperBound(0) + 1; i++)
                {
                    MY_JOB_QUE[i].ID_JOB = 0;
                    MY_JOB_QUE[i].HOW_MANY_PRINT = 0;
                    MY_JOB_QUE[i].ORDER_NUMBER = "";
                    MY_JOB_QUE[i].STATUS_JOB = 0;
                }
            }
            else
            {
                MY_JOB_QUE[idjob].ID_JOB = 0;
                MY_JOB_QUE[idjob].HOW_MANY_PRINT = 0;
                MY_JOB_QUE[idjob].ORDER_NUMBER = "";
                MY_JOB_QUE[idjob].STATUS_JOB = 0;
            }
        }
        public static string Srch2Escape(string mStr, string mChar)
        {
            int x = 0;
            string tmp = "";
            string newstr = "";
            string cs = "";
            do
            {
                x = mStr.IndexOf(mChar);
                if (x != -1)
                {
                    if (x == 0)
                    {
                        mStr = mStr.Substring(x + 1, mStr.Length - (x + 1));
                    }
                    else
                    {
                        tmp = mStr.Substring(0, x + 1);
                        newstr += tmp + mChar;
                        mStr = mStr.Substring(x + 1, mStr.Length - (x + 1));
                    }
                }

            } while (x != -1);
            cs = newstr + mStr;
            return cs;
        }
    }
}
