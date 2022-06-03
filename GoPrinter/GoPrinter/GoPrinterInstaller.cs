using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;
namespace GoPrinter
{
    [RunInstaller(true)]
    public partial class GoPrinterInstaller : Installer
    {
        
        //private System.ServiceProcess.ServiceProcessInstaller GoPrintProcessInstaller;
        //private System.ServiceProcess.ServiceInstaller GoPrintInstaller;
        public GoPrinterInstaller()
        {
            InitializeComponent();
            ServiceInstaller si = new ServiceInstaller();
            ServiceProcessInstaller spi = new ServiceProcessInstaller();

            si.ServiceName = "GoPrinterService"; // this must match the ServiceName specified in WindowsService1.
            si.DisplayName = "GoWH Printer Server " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); // this will be displayed in the Services Manager.
            this.Installers.Add(si);

            spi.Account = System.ServiceProcess.ServiceAccount.LocalSystem; // run under the system account.
            spi.Password = null;
            spi.Username = null;
            this.Installers.Add(spi);
            
        }
        

    }
}