using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;
using System.Runtime.CompilerServices;

[assembly: SuppressIldasmAttribute()]
namespace GoPrinter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()

        {
            /*
            string ggg = "";
            GNETFCSLIBLib.FCS16Class mk = new GNETFCSLIBLib.FCS16Class();

            ggg = mk.Pegasus_CkSum("ABC987");
             System.Windows.Forms.MessageBox.Show(ggg);
             return;
             */
            System.Diagnostics.EventInstance minst = new System.Diagnostics.EventInstance(1, 1);
            if (MyGlobal.GiveServersSettings() > 0)
            {
                
                System.Diagnostics.EventLog.WriteEntry("GoPrinterServerSettings", "Nu exista setari conexiune iScala & GoWH server\r\nFolositi modulul GoPrinterSettings pentru completarea setarilor necesare conexiunii", System.Diagnostics.EventLogEntryType.Error, 101, 7); //7-Network;6-System Event;5-Shell;4-Services;3-Printers;2-Disk;1-Device
                
                return;

            }
            else
            {

                MyGlobal.GoWHSQLDBString = "server=" + CryptorEngine.Decrypt(MyGlobal.MY_MSSQL_IP.Trim(), true) + ";user id=" + CryptorEngine.Decrypt(MyGlobal.MY_MSSQL_USER.Trim(), true) + ";password=" + CryptorEngine.Decrypt(MyGlobal.MY_MSSQL_PASS.Trim(), true) + ";database=" + CryptorEngine.Decrypt(MyGlobal.MY_MSSQL_DB.Trim(), true) + ";connection timeout=30;Asynchronous Processing=true";
                MyGlobal.MY_PRINTER = CryptorEngine.Decrypt(MyGlobal.MY_PRINTER.Trim(), true);
                //MyGlobal.GoWHSCALADBString = "server=" + CryptorEngine.Decrypt(MyGlobal.MY_ISCALA_IP.Trim(), true) + ";user id=" + CryptorEngine.Decrypt(MyGlobal.MY_ISCALA_USER.Trim(), true) + ";password=" + CryptorEngine.Decrypt(MyGlobal.MY_ISCALA_PASS.Trim(), true) + ";database=" + CryptorEngine.Decrypt(MyGlobal.MY_ISCALA_DB.Trim(), true) + ";connection timeout=30;Asynchronous Processing=true";
            }
 
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] { new GoPrinterService() };
            ServiceBase.Run(ServicesToRun);
        }
    }
}