using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;
using System.Text;

namespace GoPrinter.XtrReport
{
    public partial class MyReport : DevExpress.XtraReports.UI.XtraReport
    {
        ~MyReport() { }
        public MyReport()
        {
            InitializeComponent();
            xrPictureBox1.ImageUrl = Application.StartupPath+ "\\Pic1.jpg";
            
        }
        
    }
}
