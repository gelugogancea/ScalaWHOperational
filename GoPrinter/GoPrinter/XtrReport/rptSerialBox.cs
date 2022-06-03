using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;
using System.Text;

namespace GoPrinter.XtrReport
{
    public partial class rptSerialBox : DevExpress.XtraReports.UI.XtraReport
    {
        ~rptSerialBox() { }
        public rptSerialBox()
        {
            InitializeComponent();
            xrPictureBox1.ImageUrl = Application.StartupPath + "\\Pic1.jpg";
        }

    }
}
