using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

[assembly: SuppressIldasmAttribute()]
namespace GoPrinterSettings
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MyGlobal.mFrmSetSRVParam = new frmSetMainSVRParam();
            Application.Run(MyGlobal.mFrmSetSRVParam);
        }
    }
}