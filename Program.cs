using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

[assembly: SuppressIldasmAttribute()]

namespace GoWHMgmAdmin
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            System.OperatingSystem osInfo = System.Environment.OSVersion;
            //MessageBox.Show(osInfo.VersionString); 
            switch (osInfo.Platform)
            {
                case System.PlatformID.Win32Windows:
                    {
                        switch (osInfo.Version.Minor)
                        {
                            case 0:
                                Console.WriteLine("Windows 95");
                                break;
                            case 10:
                                if (osInfo.Version.Revision.ToString() == "2222A")
                                    Console.WriteLine("Windows 98 Second Edition");
                                else
                                    Console.WriteLine("Windows 98");
                                break;
                            case 90:
                                Console.WriteLine("Windows Me");
                                break;
                        } break;

                    }

                case System.PlatformID.Win32NT:
                    {
                        switch (osInfo.Version.Major)
                        {
                            case 3:
                                Console.WriteLine("Windows NT 3.51");
                                break;
                            case 4:
                                Console.WriteLine("Windows NT 4.0");
                                break;
                            case 5:
                                if (osInfo.Version.Minor == 0)
                                    Console.WriteLine("Windows 2000");
                                else
                                    Console.WriteLine("Windows XP");
                                break;
                            case 6:
                                MyGlobal.OS_W_S_R = true;
                                if (osInfo.Version.Minor == 0)
                                {
                                    //MessageBox.Show("Asta'i Vista");
                                }
                                else
                                {
                                    //MessageBox.Show("Asta'i  7");
                                }
                                  
                                break;
                        } break;

                    }

            }

             
            try
            {

                System.Globalization.CultureInfo ci = System.Threading.Thread.CurrentThread.CurrentCulture;
                MyGlobal.MY_LANGUAGE = ci.ToString().Trim();

                if (MyGlobal.GiveServersSettings() > 0)
                {
                    MyGlobal.mFrmSetSRVParam = new frmSetMainSVRParam();
                    Application.Run(MyGlobal.mFrmSetSRVParam);
                }
                else
                {
                    MyGlobal.mFrmLog = new frmLogin();
                    MyGlobal.GoWHSQLDBString = "server=" + CryptorEngine.Decrypt(MyGlobal.MY_MSSQL_IP.Trim(), true) + ";user id=" + CryptorEngine.Decrypt(MyGlobal.MY_MSSQL_USER.Trim(), true) + ";password=" + CryptorEngine.Decrypt(MyGlobal.MY_MSSQL_PASS.Trim(), true) + ";database=" + CryptorEngine.Decrypt(MyGlobal.MY_MSSQL_DB.Trim(), true) + ";connection timeout=30000;";
                    MyGlobal.GoWHSCALADBString = "server=" + CryptorEngine.Decrypt(MyGlobal.MY_ISCALA_IP.Trim(),true) + ";user id=" + CryptorEngine.Decrypt(MyGlobal.MY_ISCALA_USER.Trim(),true) + ";password=" + CryptorEngine.Decrypt(MyGlobal.MY_ISCALA_PASS.Trim(),true) + ";database=" + CryptorEngine.Decrypt(MyGlobal.MY_ISCALA_DB.Trim(),true) + ";connection timeout=30000";
                    MyGlobal.MY_SQL_CON = new System.Data.SqlClient.SqlConnection(MyGlobal.GoWHSQLDBString);
                    MyGlobal.MY_SCALA_CON = new System.Data.SqlClient.SqlConnection(MyGlobal.GoWHSCALADBString);
                    Application.Run(MyGlobal.mFrmLog);
                    
                    //Application.Run(MyGlobal.mFrmDeliveryStatus =new frmDeliveryStatus()  );   
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "GoWHAdmin", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}