using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoWHMgmAdmin
{
    public partial class frmCkPasswd : Form
    {
        public frmCkPasswd()
        {
            InitializeComponent();
        }

        private void txtConfirmPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                try
                {
                    MyGlobal.mFrmInventoryAddCount.CK_PASSWD = txtConfirmPass.Text.Trim();
                }
                catch { GC.Collect(); }
                try
                {
                    MyGlobal.mFrmMonitorInventory.CK_PASSWD = txtConfirmPass.Text.Trim();
                }
                catch
                {
                    GC.Collect();
                }
                this.Close();
            }
            else if (e.KeyValue == 27)
            {
                try
                {
                    MyGlobal.mFrmInventoryAddCount.CK_PASSWD = "";
                }
                catch { GC.Collect(); }
                try
                {
                    MyGlobal.mFrmMonitorInventory.CK_PASSWD = txtConfirmPass.Text.Trim();
                }
                catch
                {
                    GC.Collect();
                }
                this.Close();
            }
        }
    }
}