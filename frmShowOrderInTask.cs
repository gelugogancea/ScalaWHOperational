using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoWHMgmAdmin
{
    public partial class frmShowOrderInTask : Form
    {
        public int SESSION_ID=0;
        public string MY_ROUTE = "";
        public frmShowOrderInTask()
        {
            InitializeComponent();
        }

        private void frmShowOrderInTask_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("UniqID", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("Cda", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("CodClient.", 60, HorizontalAlignment.Left);
            listView1.Columns.Add("NumeClient", 140, HorizontalAlignment.Left);
            listView1.Columns.Add("Ruta", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("Status", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("Responsabil", 300, HorizontalAlignment.Left);
            listView1.Columns.Add("WH", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("GreutateT", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("PackT", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Date", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("ID", 1, HorizontalAlignment.Left);
            this.listView1.GridLines = true;
            this.listView1.FullRowSelect = true;
            this.listView1.View = View.Details;


        }
        int DeleteData(long IDREC)
        {
            string mq = "";
            int ret = 0;
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mq = "DELETE FROM go_lgst_task WHERE IDLG=" + IDREC.ToString() + ";";
            /*
            if (IDREC == 0)
            {
                mq = "INSERT INTO [GoWH].[dbo].[go_lgst_task] " +
                    "([KeyCmdScala],[VehicleID],[Delegate],[Status],[InDate],[UpToDate]) " +
                    "VALUES ('" + mOrder.Trim() + "','" + VehicleID.Trim() + "','" + Delegate.Trim() + "',1,getdate(),NULL)";
            }
            else
            {
                mq = "update [GoWH].[dbo].[go_lgst_task] SET KeyCmdScala='" + mOrder + "',VehicleID='" + VehicleID.Trim() + "',Delegate='" + Delegate.Trim() + "' where IDLG=" + IDREC.ToString() + ";";
            }
             */ 
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
        public void LoadMyOrder(string mCriteria,string mRoute, string DateFrom, string DateTo)
        {
            string mq = "";
            ListViewItem lvi = null;
            this.listView1.Items.Clear();

            this.listView1.Refresh();
            this.Cursor = Cursors.WaitCursor;

            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mq = "select go_lgst_task.UniqueID,[iScalaDB].[dbo].[OR010100].OR01001,[iScalaDB].[dbo].[OR010100].OR01003," +
                "[iScalaDB].[dbo].[SL010100].SL01002,[iScalaDB].[dbo].[OR010100].OR01056,"+
                "[iScalaDB].[dbo].[OR010100].OR01091,[iScalaDB].[dbo].[OR010100].OR01017,"+
                "[iScalaDB].[dbo].[OR010100].OR01050,go_lgst_task.TWeight,go_lgst_task.TPacking,"+
                "CONVERT(VARCHAR(10), [iScalaDB].[dbo].[OR010100].OR01015, 103) AS [DD/MM/YYYY],IDLG "+
                "from [iScalaDB].[dbo].[SL010100],[iScalaDB].[dbo].[OR010100] WITH(NOLOCK) "+
                "INNER JOIN go_lgst_task ON "+
                "go_lgst_task.KeyCmdScala COLLATE SQL_Latin1_General_CP1_CI_AS= [iScalaDB].[dbo].[OR010100].OR01001 AND go_lgst_task.UniqueID="+ mCriteria.Trim()  +" "+
                "where iScalaDB.dbo.OR010100.OR01045=iScalaDB.dbo.SL010100.SL01001 "+
                "AND [iScalaDB].[dbo].[OR010100].OR01056='"+ mRoute.Trim() +"' "+
                "AND [iScalaDB].[dbo].[OR010100].OR01091>=5 and CONVERT(VARCHAR(10), [iScalaDB].[dbo].[OR010100].OR01015, 103) "+
                "between '"+ DateFrom.Trim()   +"' AND '"+ DateTo.Trim() +"' ";
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                lvi = new ListViewItem(MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"));
                lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"));
                lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"));	// This is what's displayed in the password column
                lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'"));
                lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'"));
                lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[5].ToString().Trim(), "'"));
                lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'"));
                lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'"));
                lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[8].ToString().Trim(), "'"));
                lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[9].ToString().Trim(), "'"));
                lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[10].ToString().Trim(), "'"));
                lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[11].ToString().Trim(), "'"));
                
                this.listView1.Items.Add(lvi);

            }
            dataread.Close();
            mcmd = null;
            this.Cursor = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void frmShowOrderInTask_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                SESSION_ID=0;
                MY_ROUTE = "";
                MyGlobal.mFrmShowOrderInTask = null;
            }
            catch { GC.Collect(); }
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            int i = 0;
            long ID_REC = 0;
            if (e.KeyData == Keys.Delete)
            {
                                try
                {
                    //ID_REC=long.Parse (MyListView.SelectedItems[0].SubItems[11].Text.Trim());
                    ID_REC = long.Parse(listView1.SelectedItems[0].SubItems[11].Text.Trim());
                }
                catch
                {
                    MessageBox.Show("CRITIC_ERR ! Invalid ID_REC");
                    return;
                }
                DialogResult b = MessageBox.Show("Esti sigur ca vrei sa stergi Comanda " + listView1.SelectedItems[0].SubItems[1].Text.Trim() + " ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (b == DialogResult.No)
                {
                    ID_REC = 0;
                    return;
                }

                if (DeleteData(ID_REC) == 0)
                {
                    MessageBox.Show("Datele au fost actualizate", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Nu se pot reactualiza datele", "ERR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                MyGlobal.mFrmDeliveryTransp.RefreshListData();   
                this.Close(); 
            }
        }
    }
}