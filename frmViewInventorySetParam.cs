using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoWHMgmAdmin
{
    public partial class frmViewInventorySetParam : Form
    {
        public frmViewInventorySetParam()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtValidFrom_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtInitPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void CmdView_Click(object sender, EventArgs e)
        {
            long invtno = 0;
            string MyDate = "";
            string mmm = "";
            bool IfExist = false;
            string[] mres = new string[1];
            
            if (txtInventoryNo.Text.Trim() != "")
            {
                try
                {
                    invtno = long.Parse(txtInventoryNo.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("Numarul de Inventar este reprezentat numeric.", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }

            }
            else
            {
                if (this.txtValidFrom.Text.Trim() == "__/__/____")
                {
                    MessageBox.Show("Nu este setata Data","",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1      );
                    return;
                }
                this.Cursor = Cursors.No;
                
                MyDate = this.txtValidFrom.Text.Substring(3, 2) + "/" + this.txtValidFrom.Text.Substring(0, 2) + "/" + this.txtValidFrom.Text.Substring(6, 4);
                mmm = "select go_invent_main.ID FROM go_invent_main WHERE CONVERT(VARCHAR,'" + MyDate.Trim() + "',101) between CONVERT(VARCHAR,go_invent_main.PeriodFrom,101) AND CONVERT(VARCHAR,go_invent_main.PeriodTo,101);";
                //mmm = "select go_invent_main.ID FROM go_invent_main INNER JOIN go_sys_lock ON go_invent_main.ID = go_sys_lock.InventoryID AND CONVERT(VARCHAR,getdate(),112) between CONVERT(VARCHAR,go_invent_main.PeriodFrom,112) AND CONVERT(VARCHAR,go_invent_main.PeriodTo,112);";
                IfExist = MyGlobal.IsForUpdate(mmm, 1, ref mres);
                if (IfExist == false)
                {

                    MessageBox.Show("Nu exista acest Inventar");
                    mres = null;
                    //MyGlobal.mFrmViewInventory = null;
                    return;
                }
                try
                {
                    invtno=long.Parse(mres[0].Trim());
                    
                }
                catch
                {
                    MessageBox.Show("Numarul de Inventar este invalid.");
                    //MyGlobal.mFrmViewInventory = null;
                    return;
                }
                
                this.Cursor = Cursors.Default;
                 
   
            }
            MyGlobal.mFrmViewInventory = new frmViewInventory();
            MyGlobal.mFrmViewInventory.ID_INVENTORY = invtno;
            MyGlobal.mFrmViewInventory.MdiParent = this.MdiParent;
            MyGlobal.mFrmViewInventory.BringToFront();
            MyGlobal.mFrmViewInventory.Show();
            MyGlobal.mFrmInventorySetParam = null;  
            this.Close();
        }

        private void frmViewInventorySetParam_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                MyGlobal.mFrmViewInventory = null;  
            }
            catch { GC.Collect(); } 
        }

        private void CmdExit_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}