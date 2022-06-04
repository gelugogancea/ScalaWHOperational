using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Security;
using Microsoft.Win32;


namespace GoWHMgmAdmin
{
    class MyGlobal
    {
        public struct MY_USER
        {
            long IDUSER;
            long ACC_LEVEL;
            string muser;
            string mrealname;
            string mrealsname;
            string morgrole;


            public long MyID
            {
                get
                {
                    return IDUSER;
                }
                set
                {
                    IDUSER = value;
                }
            }

            public string MyUser
            {
                get
                {
                    return muser;
                }
                set
                {
                    muser = value;
                }
            }
            public string MyRealName
            {
                get
                {
                    return mrealname;
                }
                set
                {
                    mrealname = value;
                }
            }
            public string MyRealSurName
            {
                get
                {
                    return mrealsname;
                }
                set
                {
                    mrealsname = value;
                }
            }
            public string MyOrgRole
            {
                get
                {
                    return morgrole;
                }
                set
                {
                    morgrole = value;
                }
            }
            public long MyAccessLevel
            {
                get
                {
                    return ACC_LEVEL;
                }
                set
                {
                    ACC_LEVEL = value;
                }
            }
        }

        public static bool OS_W_S_R=false;

        public static System.Data.SqlClient.SqlConnection MY_SQL_CON = null;
        public static System.Data.SqlClient.SqlConnection MY_SCALA_CON = null;
        
        public static frmStorageProperties mFrmStorageProperties = null;
        public static frmInventoryOrder mFrmInventoryOrder = null;
        public static frmAuthorizationLocalMove mFrmAuthorizationLocalMove = null;
        public static frmAuthorizationStArea mFrmAuthorizationStArea = null;
        public static frmClassification mFrmClassification = null;
        public static frmPresentationFom mFrmPresentationForm = null;
        public static frmAddConf3DLoc mFrmAddConf3DLoc = null;
        public static frmAddConfAreaStorage mFrmAddConfAreaStorage = null;
        public static frmImportWareHouse mFrmImpWareHouse = null;
        public static ImportSupplierAndCustomer mFrmSupplCutom = null;
        public static frmImportArticle mFrmImpArt = null;
        public static frmLogin mFrmLog=null;
        public static frmSetMainSVRParam mFrmSetSRVParam=null;
        public static SetUsers mFrmSetUsers=null;
        public static frmMonitor mFrmMonitor = null;
        public static frmInventoryInit mFrmInventoryInit = null;
        public static frmInventoryTeam mFrmInventoryTeam = null;
        public static frmInvenoryAddCount mFrmInventoryAddCount = null;
        public static frmMonitorInventory mFrmMonitorInventory = null;
        public static frmViewInventory mFrmViewInventory = null;
        public static frmViewInventorySetParam mFrmInventorySetParam = null;
        public static frmDeliveryTransp mFrmDeliveryTransp = null;
        public static frmInventoryConfigBin mFrmInventoryConfigBin = null;
        public static frmInventoryGenerateList mFrmInventoryGenerateList = null;
        public static frmInventoryOperator mFrmInventoryOperator = null;
        public static frmDeliveryStatus mFrmDeliveryStatus = null;
        public static frmShowOrder4Delivery mFrmShowOrder4Delivery = null;
        public static frmShowOrderInTask mFrmShowOrderInTask = null;
        public static frmRegisterMoveArticle mFrmRegisterMoveArticle = null;
        public static frmReport mFrmReport = null;
        public static frmShowReport mFrmShowReport = null;


        public static DataSet.dsRptWHInternMove01 dsMRptWHInternMove01 = new GoWHMgmAdmin.DataSet.dsRptWHInternMove01();
        public static DataSet.dsStock dsRptStock = new GoWHMgmAdmin.DataSet.dsStock();

        public static string GoWHSQLDBString ="";
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
        public static MY_USER MyUserInfo;
        public static string MY_LANGUAGE = "";

    public static int GiveServersSettings()
        {
            int ret = 0;



                mRegistry mreg = new mRegistry();

                try
                {
                    MY_MSSQL_USER = mreg.QueryValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoWHAdmin", "MSSQL_USER", "");
                    MY_MSSQL_PASS = mreg.QueryValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoWHAdmin", "MSSQL_PASS", "");
                    MY_MSSQL_IP = mreg.QueryValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoWHAdmin", "MSSQL_IP", "");
                    MY_MSSQL_DB = mreg.QueryValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoWHAdmin", "MSSQL_DB", "");
                    MY_ISCALA_USER = mreg.QueryValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoWHAdmin", "SCALA_USER", "");
                    MY_ISCALA_PASS = mreg.QueryValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoWHAdmin", "SCALA_PASS", "");
                    MY_ISCALA_IP = mreg.QueryValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoWHAdmin", "SCALA_IP", "");
                    MY_ISCALA_DB = mreg.QueryValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoWHAdmin", "SCALA_DB", "");
                    MY_IP_PRINTSVR = mreg.QueryValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoWHAdmin", "IP_PRINT", "");
                    MY_AUTH_KEY = mreg.QueryValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoWHAdmin", "AUTH_KEY", "");

                }
                catch
                {
                    ret++;
                }
                if (MY_MSSQL_USER.Trim() == "")
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
                if (MY_IP_PRINTSVR.Trim() == "")
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
        public static string Srch2Escape(string mStr,string mChar)
        {
            int x=0;
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
        public static System.Array ResizeArray(System.Array oldArray, int newSize)
        {
            int oldSize = oldArray.Length;
            System.Type elementType = oldArray.GetType().GetElementType();
            System.Array newArray = System.Array.CreateInstance(elementType, newSize);
            int preserveLength = System.Math.Min(oldSize, newSize);
            if (preserveLength > 0)
                System.Array.Copy(oldArray, newArray, preserveLength);
            return newArray;
        }
        public static bool IsForUpdate(string mStatement,int HowManyResult,ref string[] mRes)
        {
            int x = 0;
            int z = 0;
            bool mRet = false;

            mRes = new string[HowManyResult]; 

            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mcmd.CommandText = mStatement;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                z = 0;
                /*
                if (dataread[x].ToString().Trim() != "")
                {
                    for (z = 0; z < HowManyResult; z++)
                    {
                        mRes[z] = dataread[z].ToString().Trim();
                    }
 
                }
                else
                {
                    for (z = 0; z < HowManyResult; z++)
                    {
                        mRes[z] = " ";
                    }
                }
                */
                for (z = 0; z < HowManyResult; z++)
                {
                    if (dataread[z].ToString().Trim() != "")
                    {
                        mRes[z] = dataread[z].ToString().Trim();
                    }
                    else
                    {
                        mRes[z] = " ";
                    }
                }
                x++;
                if (x > 1)
                {
                    break;
                }
            }
           
            if (x > 0)
            {
                mRet = true;
            }
            else
            {
                mRet = false;
                for (z = 0; z < HowManyResult; z++)
                {
                    mRes[z] = " ";
                }
            }
            dataread.Close();
            mcmd = null;
            
            return mRet;
        }
        public static string ConvertDate2ISO(string mDate, string mLanguageCulture)
        {
            string ret = "";
            if (mLanguageCulture.Trim() == "en-US")
            {
                ret = mDate.Trim().Substring(6, 4) + mDate.Trim().Substring(0, 2) + mDate.Trim().Substring(3, 2);
            }
            else
            {
                ret = mDate.Trim().Substring(6, 4) + mDate.Trim().Substring(3, 2) + mDate.Trim().Substring(0, 2);
            }
            return ret;
        }
        public static string SwitchDate4Sys(string mDate, string mLanguageCulture)
        {
            string tmp = "";
            string tmph = "";
            string ret = "";
            if (mDate.Trim().Length > 10)   //contine si timp nu numai data
            {
                if (MyGlobal.MY_LANGUAGE == "en-US")
                {
                    tmp = mDate.Trim().Substring(3, 2) + "/" + mDate.Trim().Substring(0, 2) + "/" + mDate.Trim().Substring(6, 4);
                    tmph = mDate.Trim().Substring(10, mDate.Trim().Length - 10);
                    ret = tmp + tmph;
                }
                else
                {
                    ret = mDate;
                }

            }
            else
            {
                if (MyGlobal.MY_LANGUAGE == "en-US")
                {
                    ret = mDate.Trim().Substring(3, 2) + "/" + mDate.Trim().Substring(0, 2) + "/" + mDate.Trim().Substring(6, 4);
                }
                else
                {
                    ret = mDate;
                }
            }
            return ret;
        }
        public static String Write2NemoXML(string Destinatar,string Localitate,
            string Judet,string CodPostal,string Platitor,string NumarDePlicuri,
            string NumarDeColete,string NumarDePaleti,string TotalGreutate)
        {
            
            System.Xml.XmlWriterSettings wSettings = new System.Xml.XmlWriterSettings();
            wSettings.Indent = true;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.Xml.XmlWriter xw = System.Xml.XmlWriter.Create(ms, wSettings);// Write Declaration
            xw.WriteStartDocument();
            xw.WriteStartElement("export");
            string [,] mArrTest=new string[3,7];

            mArrTest[0, 1] = "testu meu....aici am ramas";
            xw.WriteEndElement();
            xw.WriteEndDocument();
            xw.Flush();
            
            Byte[] buffer = new Byte[ms.Length];
            buffer = ms.ToArray();
            string xmlOutput = System.Text.Encoding.UTF8.GetString(buffer);
            wSettings = null;
            ms = null;
            xw = null;
            return xmlOutput;
        }
        private System.Xml.XmlWriter AddNemoElement(System.Xml.XmlWriter xz,
            string Destinatar,string Strada,string NrStrada ,string Localitate,
            string Judet, string CodPostal, string Platitor, string NumarDePlicuri,
            string NumarDeColete, string NumarDePaleti, string TotalGreutate,string AusSerialNo)
        {
            string sBuffer = "";
            xz.WriteStartElement("string");
            sBuffer = "CodDestinatar=\"\" ";
            sBuffer += "Destinatar=\"" + Destinatar.Trim()   + "\" "; 
            sBuffer+="Strada=\""+ Strada.Trim()  +"\" ";
            sBuffer +="Numar=\""+ NrStrada.Trim()   +"\" ";
            sBuffer+="PersoanaContact=\"\" ";
            sBuffer+="Tel=\"\" ";
            sBuffer+="Localitate=\""+ Localitate +"\" ";
            sBuffer+="Judet=\""+ Judet.Trim()  +"\" ";
            sBuffer+="CodPostal=\""+ CodPostal.Trim()  +"\" ";
            sBuffer+="Observatii=\"\" ";
            sBuffer+="ConditiiSpeciale=\"\" ";
            sBuffer+="Indicatii=\"\" ";
            sBuffer+="Platitor=\"0\" "; 
            sBuffer+="PlicNo=\"0\" ";
            sBuffer+="ColetNo=\""+ NumarDeColete.Trim() +"\" "; 
            sBuffer+="PaletNo=\"0\" ";
            sBuffer+="Kg=\""+ TotalGreutate.Trim()   +"\" ";
            sBuffer+="ValoareDeclarata=\"\" ";
            sBuffer+="Ramburs=\"\" ";
            sBuffer+="Continut=\"\" ";
            sBuffer += "BcNoMan=\""+  AusSerialNo.Trim() +"\" "; 

            xz.WriteString(sBuffer);
            xz.WriteEndAttribute();
            return xz;
        }
    }

}
