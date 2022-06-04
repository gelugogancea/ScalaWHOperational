using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoWHMgmAdmin
{
    public partial class frmImportWareHouse : Form
    {
        public frmImportWareHouse()
        {
            InitializeComponent();
        }

        private void CmdExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            finally
            {
                GC.Collect();
            }
        }

        private void frmImportWareHouse_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                MyGlobal.mFrmImpWareHouse = null; 
            }
            finally
            {
                GC.Collect();
            }
        }

        private void frmImportWareHouse_Load(object sender, EventArgs e)
        {
            ColumnHeader colHead;
            this.MyListView.Clear();
            this.MyListView.Columns.Clear();

            colHead = new ColumnHeader();
            colHead.Text = "WHSymbol";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "WHName";
            colHead.Width = 280;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "AddrLine1";
            colHead.Width = 180;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "AddrLine2";
            colHead.Width = 180;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "AddrLine3";
            colHead.Width = 180;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "AddrLine4";
            colHead.Width = 180;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "AddrLine5";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);
            
            this.MyListView.GridLines = true;
            this.MyListView.FullRowSelect = true;
            this.MyListView.View = View.Details;
        }
        private int ImportWH()
        {

            ListViewItem k = null;
            long x = 0;
            int z = 0;
            string mq = "";
            int mret = 0;
            string[] mres = new string[7];

            bool mreturn = false;
            long xinsert = 0;
            long xupdate = 0;
            long xtotal = 0;
            LblTotalInsert.Text = "0";
            LblTotalUpdate.Text = "0";
            LblTotalRecords.Text = "0";

            try
            {
                MyGlobal.MY_SCALA_CON.Open();

            }
            catch
            {
                MessageBox.Show("Nu ma pot conecta la " + MyGlobal.MY_ISCALA_IP, "GoWHManagementAdmin");
                return -1;
            }
            this.Cursor = Cursors.WaitCursor;
            this.MyListView.Items.Clear();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SCALA_CON;
            mq = "SELECT SC23001,SC23002,SC23003,SC23004,SC23005,SC23006,SC23007 FROM dbo.SC230100;";
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            this.MyListView.BeginUpdate();
            while (dataread.Read())
            {

                mres[0] = MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'");
                mres[1] = MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'");
                mres[2] = MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'");
                mres[3] = MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'");
                mres[4] = MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'");
                mres[5] = MyGlobal.Srch2Escape(dataread[5].ToString().Trim(), "'");
                mres[6] = MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'");
                string[] mfunc = new string[1];
                mreturn = MyGlobal.IsForUpdate("SELECT ScWH FROM dbo.go_main_wh_def where ScWH='" + mres[0].Trim() + "';",1,ref mfunc);
                mfunc = null;
                if (mreturn == false)
                {

                    if (ImportInWHDef(mres, false) < 0)
                    {
                        mret = -1;
                        goto MYEND;
                    }
                    else
                    {
                        xinsert++;
                        LblTotalInsert.Text = xinsert.ToString().Trim();
                        LblTotalInsert.Refresh();
                    }
                }
                else
                {
                    if (ImportInWHDef(mres, true) < 0)
                    {
                        mret = -1;
                        goto MYEND;
                    }
                    else
                    {
                        xupdate++;
                        LblTotalUpdate.Text = xupdate.ToString().Trim();
                        LblTotalUpdate.Refresh();
                    }
                }
                xtotal++;
                LblTotalRecords.Text = xtotal.ToString().Trim();
                LblTotalRecords.Refresh();

                k = new ListViewItem(mres[0].Trim());
                k.SubItems.Add(mres[1].Trim());
                k.SubItems.Add(mres[2].Trim());
                k.SubItems.Add(mres[3].Trim());
                k.SubItems.Add(mres[4].Trim());
                k.SubItems.Add(mres[5].Trim());
                k.SubItems.Add(mres[6].Trim());
                
                this.MyListView.Items.Add(k);
                
                x++;
                for (z = 0; z < 7; z++)
                {
                    mres[z] = "";
                }
            }
        MYEND:
            this.MyListView.EndUpdate();
            this.MyListView.Refresh();
            dataread.Close();
            mcmd = null;
            try
            {
                MyGlobal.MY_SCALA_CON.Close();
            }
            finally
            {
                GC.Collect();
            }
            this.Cursor = Cursors.Default;
            return mret;
        }
        int ImportInWHDef(string[] mData, bool IsUpdate)
        {
            string mq = "";
            int ret = 0;
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            if (IsUpdate == false)
            {
                mq = "INSERT INTO dbo.go_main_wh_def "+
                    "(ScWH,ScName,ScAddr1,ScAddr2,ScAddr3,ScAddr4,ScAddr5,mUser,InDate,UpToDate) VALUES"+
                    "('" + mData[0].Trim() + "'," +
                    "'" + mData[1].Trim() + "'," +
                    "'" + mData[2].Trim() + "'," +
                    "'" + mData[3].Trim() + "'," +
                    "'" + mData[4].Trim() + "'," +
                    "'" + mData[5].Trim() + "'," +
                    "'" + mData[6].Trim() + "'," +
                    "'" + MyGlobal.MyUserInfo.MyUser.Trim() + "'," +
                    "getdate()," +
                    "NULL);";
                
            }
            else
            {
                mq = "UPDATE dbo.go_main_wh_def SET "+
                    "ScName ='" + mData[1].Trim() + "'" + 
                    ",ScAddr1 ='"+ mData[2].Trim() + "'" + 
                    ",ScAddr2 ='" + mData[3].Trim() + "'" + 
                    ",ScAddr3 ='" + mData[4].Trim() + "'" + 
                    ",ScAddr4 ='" + mData[5].Trim() + "'" + 
                    ",ScAddr5 ='" + mData[6].Trim() + "'" +
                    ",mUser ='" + MyGlobal.MyUserInfo.MyUser.Trim() + "'" + 
                    ",UpToDate = getdate() "+
                    "WHERE ScWH ='" + mData[0].Trim() + "';";
                
            }
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            try
            {
                mcmd.ExecuteNonQuery();
            }
            catch (Exception emsg)
            {
                MessageBox.Show("ERROR : " + emsg.Message.Trim(), "GoWHManagementAdmin");
                ret = -1;
            }
            mcmd = null;
            return ret;
        }

        private void CmdImport_Click(object sender, EventArgs e)
        {
            ImportWH();
            
        }
    }
}