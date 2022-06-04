using System;
using System.Collections.Generic;
using System.Globalization; 
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoWHMgmAdmin
{
    public partial class frmDeliveryTransp : Form
    {
        
        private long ID_REC = 0;
        private bool IS_UPDATE = false; 
        public frmDeliveryTransp()
        {
            InitializeComponent();
        }

        private void frmDeliveryTransp_Load(object sender, EventArgs e)
        {


            this.MyListView.Clear();
            this.MyListView.Columns.Clear();

            MyListView.Columns.Add("UniqID", 80, HorizontalAlignment.Left);
            MyListView.Columns.Add("Companie", 90, HorizontalAlignment.Left);
            MyListView.Columns.Add("Ruta", 60, HorizontalAlignment.Left);
            MyListView.Columns.Add("TransportID", 90, HorizontalAlignment.Left);
            MyListView.Columns.Add("Delegat", 100, HorizontalAlignment.Left);
            MyListView.Columns.Add("SubContract", 150, HorizontalAlignment.Left);
            MyListView.Columns.Add("CateCMD", 80, HorizontalAlignment.Left);
            MyListView.Columns.Add("GreutateT", 100, HorizontalAlignment.Left);
            MyListView.Columns.Add("PackT", 100, HorizontalAlignment.Left);
            MyListView.Columns.Add("Status", 80, HorizontalAlignment.Left);
            MyListView.Columns.Add("CdaData", 80, HorizontalAlignment.Left);
            MyListView.Columns.Add("Data", 80, HorizontalAlignment.Left);

            this.MyListView.GridLines = true;
            this.MyListView.FullRowSelect = true;
            this.MyListView.View = View.Details;

            this.txtValidFrom.Text  = DateTime.Now.ToString("dd/MM/yyyy");
            this.txtValidTo.Text = DateTime.Now.ToString("dd/MM/yyyy");   
            CkOnlyTask.Checked = true;  
            txtDataCmd.Visible = false;
            //CheckBox mCk = new CheckBox(); 
            //this.CmbOrders.Controls.Add(mCk);    

            //LoadMyZIP();
         }

        private void frmDeliveryTransp_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                
                MyGlobal.mFrmDeliveryTransp = null;  
            }
            catch { }
        }
        private void CmbOrders_CheckedChanged(object sender, System.EventArgs e)
        {

            
        }

        private void CkSrchOrder_CheckedChanged(object sender, EventArgs e)
        {
            if (CkSrchOrder.Checked == false)
            {
                txtDataCmd.Visible = false ;  
            }
            else
            {
                txtDataCmd.Visible = true;  
            }
        }
        private void CmdCauta_Click(object sender, EventArgs e)
        {
            string myStatus = "";
            //if (this.checkBox1.Checked == false)
            //{ myStatus = "2"; }
            //else
            //{ myStatus = "5"; }
            myStatus = "5";
            if (this.txtValidFrom.Text.Trim() == "__/__/____" || this.txtValidFrom.Text.Trim() == "/  /")
            {
                MessageBox.Show("Nu este setata validarea De La");
                return;
            }
            if (this.txtValidTo.Text.Trim() == "__/__/____" || this.txtValidTo.Text.Trim() == "/  /")
            {
                MessageBox.Show("Nu este setata validarea Pana La");
                return;
            }
            //if (CkSrchOrder.Checked == true)
            if(CkBoxSkip.Checked==true)
            {
                

                //LoadOrderInXBox("", myStatus, txtValidFrom.Text.Trim(), txtValidTo.Text.Trim());
                //LoadMyOrder("",myStatus , txtValidFrom.Text.Trim(), txtValidTo.Text.Trim());
                
                //frmShowOrder4Delivery m = new frmShowOrder4Delivery();
                this.Cursor = Cursors.No;
                this.Refresh();
                //if(this.CkBoxSkip.Checked ==false ){
                    if (MyGlobal.mFrmShowOrder4Delivery == null)
                    {
                        MyGlobal.mFrmShowOrder4Delivery = new frmShowOrder4Delivery();
                        MyGlobal.mFrmShowOrder4Delivery.LoadMyCar1();
                        MyGlobal.mFrmShowOrder4Delivery.O_IS_UPDATE = false;  
                        MyGlobal.mFrmShowOrder4Delivery.LoadMyOrder("", myStatus, txtValidFrom.Text.Trim(), txtValidTo.Text.Trim());
                        MyGlobal.mFrmShowOrder4Delivery.DATE_FROM = txtValidFrom.Text.Trim();
                        MyGlobal.mFrmShowOrder4Delivery.DATE_TO = txtValidTo.Text.Trim();
                        MyGlobal.mFrmShowOrder4Delivery.MY_STATUS = myStatus;
                    
                    }
                    MyGlobal.mFrmShowOrder4Delivery.BringToFront();
                    MyGlobal.mFrmShowOrder4Delivery.Show();
                    LoadData("", myStatus, txtValidFrom.Text.Trim(), txtValidTo.Text.Trim());
                    this.Cursor = Cursors.Default;
                    this.Refresh();
                //}
            }
            else
            {
                
                //LoadData(txtDataCmd.Text.Trim(),myStatus , "", "");
                LoadData(txtDataCmd.Text.Trim(), myStatus, txtValidFrom.Text.Trim(), txtValidTo.Text.Trim());
            }
            this.Cursor = Cursors.Default;
            this.Refresh();
        }
        
        
        
        private void txtDelegate_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtDelegate_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtDelegate_Leave(object sender, EventArgs e)
        {
            
        }
        public void RefreshListData()
        {
            LoadData("","5",this.txtValidFrom.Text.Trim () ,this.txtValidTo.Text.Trim ());
        }
        public void LoadData(string mCriteria,string myStatus,string DateFrom,string DateTo)
        {
            string mq = "";
            long x = 0;
            ListViewItem k = null;
            this.Cursor = Cursors.WaitCursor;
            this.MyListView.Items.Clear();

            this.MyListView.Refresh();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            System.Data.SqlClient.SqlDataReader dataread = null;
            
            if (mCriteria.Trim() == "")
            {
                if (CkOnlyTask.Checked == false)
                {
                    mq = "select go_lgst_task.VehicleID,[iScalaDB].[dbo].[OR010100].OR01001," +
                        "[iScalaDB].[dbo].[OR010100].OR01003,[iScalaDB].[dbo].[SL010100].SL01002," +
                        "[iScalaDB].[dbo].[OR010100].OR01056,[iScalaDB].[dbo].[OR010100].OR01091," +
                        "[iScalaDB].[dbo].[OR010100].OR01017,[iScalaDB].[dbo].[OR010100].OR01050," +
                        "CONVERT(VARCHAR(10), [iScalaDB].[dbo].[OR010100].OR01015, 103) AS [DD/MM/YYYY]," +
                        "CASE ISNULL(go_lgst_task.Status,0) " +
                        "WHEN 0 THEN 'LIBER' " +
                        "WHEN 1 THEN 'ISTASK' " +
                        "WHEN 2 THEN 'INPROCESS' " +
                        "WHEN 3 THEN 'ISFINISH' " +
                        "END,go_lgst_task.Delegate,go_lgst_task.IDLG " +
                        "from [iScalaDB].[dbo].[SL010100],[iScalaDB].[dbo].[OR010100] WITH(NOLOCK) " +
                        "LEFT JOIN go_lgst_task ON go_lgst_task.KeyCmdScala COLLATE SQL_Latin1_General_CP1_CI_AS= [iScalaDB].[dbo].[OR010100].OR01001 " +
                        "where " +
                        "iScalaDB.dbo.OR010100.OR01045=iScalaDB.dbo.SL010100.SL01001 " +
                        "AND [iScalaDB].[dbo].[OR010100].OR01091>="+ myStatus.Trim()   +" " +
                        //"AND [iScalaDB].[dbo].[OR010100].OR01091<7 " +
                        "and CONVERT(VARCHAR(10), [iScalaDB].[dbo].[OR010100].OR01015, 103) " +
                        "between '" + DateFrom.Trim() + "' AND '" + DateTo.Trim() + "';";
                }
                else
                {
                    /*
                    mq = "select go_lgst_task.VehicleID,[iScalaDB].[dbo].[OR010100].OR01001,[iScalaDB].[dbo].[OR010100].OR01003," +
                        "[iScalaDB].[dbo].[SL010100].SL01002,[iScalaDB].[dbo].[OR010100].OR01056,[iScalaDB].[dbo].[OR010100].OR01091,[iScalaDB].[dbo].[OR010100].OR01017," +
                        "[iScalaDB].[dbo].[OR010100].OR01050,CONVERT(VARCHAR(10), [iScalaDB].[dbo].[OR010100].OR01015, 103) AS [DD/MM/YYYY]," +
                        "CASE ISNULL(go_lgst_task.Status,0) WHEN 0 THEN 'LIBER' WHEN 1 THEN 'ISTASK' WHEN 2 THEN 'INPROCESS' WHEN 3 THEN 'ISFINISH' END," +
                        "go_lgst_task.Delegate,go_lgst_task.IDLG " +
                        "from [iScalaDB].[dbo].[SL010100],[iScalaDB].[dbo].[OR010100] WITH(NOLOCK),go_lgst_task " +
                        "where go_lgst_task.KeyCmdScala COLLATE SQL_Latin1_General_CP1_CI_AS= [iScalaDB].[dbo].[OR010100].OR01001 " +
                        "AND iScalaDB.dbo.OR010100.OR01045=iScalaDB.dbo.SL010100.SL01001 " +
                        "AND [iScalaDB].[dbo].[OR010100].OR01091>=" + myStatus.Trim() + " " + 
                        //"AND [iScalaDB].[dbo].[OR010100].OR01091<7 " +
                        "and CONVERT(VARCHAR(10), [iScalaDB].[dbo].[OR010100].OR01015, 103) between '" + DateFrom.Trim() + "' AND '" + DateTo.Trim() + "';";
                     */
                    mq = "select UniqueId,CompanyName,Route,VehicleID,Delegate,SubCompanyTransport,COUNT(*),SUM(TWeight),SUM(TPacking), " +
                        "CASE ISNULL(go_lgst_task.Status,0) " +
                        "WHEN 0 THEN 'LIBER' " +
                        "WHEN 1 THEN 'ISTASK' " +
                        "WHEN 2 THEN 'INPROCESS' " +
                        "WHEN 3 THEN 'ISFINISH' END, " +
                        "CONVERT(VARCHAR(10),OrderDate, 103)," +
                        "CONVERT(VARCHAR(10),InDate, 103) AS [DD/MM/YYYY] " +
                        "from go_lgst_task " +
                        "where CONVERT(VARCHAR(10), OrderDate, 103) " +
                        "between '" + DateFrom.Trim() + "' AND '" + DateTo.Trim() + "' " +
                        "group by UniqueId,CompanyName,Route,VehicleID,Delegate,Status,CONVERT(VARCHAR(10),InDate, 103),CONVERT(VARCHAR(10),OrderDate, 103),SubCompanyTransport";
                }
            }
            else
            {
                /*
                mq = "select go_lgst_task.VehicleID,[iScalaDB].[dbo].[OR010100].OR01001," +
                    "[iScalaDB].[dbo].[OR010100].OR01003,[iScalaDB].[dbo].[SL010100].SL01002," +
                    "[iScalaDB].[dbo].[OR010100].OR01056,[iScalaDB].[dbo].[OR010100].OR01091," +
                    "[iScalaDB].[dbo].[OR010100].OR01017,[iScalaDB].[dbo].[OR010100].OR01050," +
                    "CONVERT(VARCHAR(10), [iScalaDB].[dbo].[OR010100].OR01015, 103) AS [DD/MM/YYYY]," +
                    "CASE ISNULL(go_lgst_task.Status,0) " +
                    "WHEN 0 THEN 'LIBER' " +
                    "WHEN 1 THEN 'ISTASK' " +
                    "WHEN 2 THEN 'INPROCESS' " +
                    "WHEN 3 THEN 'ISFINISH' " +
                    "END,go_lgst_task.Delegate,go_lgst_task.IDLG " +
                    "from [iScalaDB].[dbo].[SL010100],[iScalaDB].[dbo].[OR010100] WITH(NOLOCK) " +
                    "LEFT JOIN go_lgst_task ON go_lgst_task.KeyCmdScala COLLATE SQL_Latin1_General_CP1_CI_AS= [iScalaDB].[dbo].[OR010100].OR01001 " +
                    "where " +
                    "iScalaDB.dbo.OR010100.OR01045=iScalaDB.dbo.SL010100.SL01001 " +
                    "AND [iScalaDB].[dbo].[OR010100].OR01091>=" + myStatus.Trim() + " " +
                    //"AND [iScalaDB].[dbo].[OR010100].OR01091<7 " +
                    "and [iScalaDB].[dbo].[OR010100].OR01001='"+ mCriteria.Trim()+"';";
                   */
                mq = "select UniqueId,CompanyName,Route,VehicleID,Delegate,SubCompanyTransport,COUNT(*),SUM(TWeight),SUM(TPacking), " +
                       "CASE ISNULL(go_lgst_task.Status,0) " +
                       "WHEN 0 THEN 'LIBER' " +
                       "WHEN 1 THEN 'ISTASK' " +
                       "WHEN 2 THEN 'INPROCESS' " +
                       "WHEN 3 THEN 'ISFINISH' END," +
                       "CONVERT(VARCHAR(10),OrderDate, 103)," +
                       "CONVERT(VARCHAR(10),InDate, 103) AS [DD/MM/YYYY] " +
                       "from go_lgst_task " +
                       "where KeyCmdScala='" + mCriteria.Trim() + "' " +
                       "group by UniqueId,CompanyName,Route,VehicleID,Delegate,Status,CONVERT(VARCHAR(10),InDate, 103),CONVERT(VARCHAR(10),OrderDate, 103),SubCompanyTransport";
           }
            try
            {

                mcmd.CommandText = mq;
                mcmd.CommandType = System.Data.CommandType.Text;
                dataread = mcmd.ExecuteReader();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message.Trim());
            }
            MyListView.BeginUpdate();
            while (dataread.Read())
            {
                k = new ListViewItem(MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[5].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[8].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[9].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[10].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[11].ToString().Trim(), "'"));

                MyListView.Items.Add(k);
                x++;
            }
            MyListView.EndUpdate();
            try
            {
                dataread.Close();
            }
            catch { };
            mcmd = null;
            this.Cursor = Cursors.Default;
        }
        /*
        private void CmdSave_Click(object sender, EventArgs e)
        {
            int myret;
            string myStatus = "";
            if (this.checkBox1.Checked == false)
            { myStatus = "2"; }
            else
            { myStatus = "5"; }
            if (CmbOrders.Text.Trim()=="")
            {
                MessageBox.Show("Nu exista Comanda");
                return; 
            }
            if (multiColumnComboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Nu exista Numar Inmatriculare Vehicul");
                return; 
            }
            if (txtDelegate.Text.Trim()=="")
            {
                MessageBox.Show("Nu exista Nume Delegat");
                return; 
            }
            if (IS_UPDATE == false)
            {
                myret=SaveData(CmbOrders.Text.Trim(), multiColumnComboBox1.Text.Trim(), txtDelegate.Text.Trim(), 0);
            }
            else
            {
                if (ID_REC == 0)
                {
                    MessageBox.Show("ID RECORD este invalid\r\nNu se poate face update");
                    return; 
                }
                myret=SaveData(CmbOrders.Text.Trim(), multiColumnComboBox1.Text.Trim(), txtDelegate.Text.Trim(), ID_REC);
            
            }
            if (myret < 0)
            {
                MessageBox.Show("Datele nu se pot salva");
            }
            else
            {
                MessageBox.Show("Datele s-au salvat cu succes");
                LoadData("",myStatus , txtValidFrom.Text.Trim(), txtValidTo.Text.Trim());         
            
            }

            ID_REC = 0;
            IS_UPDATE = false;
            CmbOrders.Text = "";
            multiColumnComboBox1.Text = "";
            txtDelegate.Text = "";
            try
            {
                txtDataCmd.Text = "";
            }
            catch { }

        }
         */ 
        int SaveData(string mOrder,string VehicleID,string Delegate,long IDREC)
        {
            string mq = "";
            int ret = 0;
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            if (IDREC == 0)
            {
                mq = "INSERT INTO [GoWH].[dbo].[go_lgst_task] "+
                    "([KeyCmdScala],[VehicleID],[Delegate],[Status],[InDate],[UpToDate]) "+
                    "VALUES ('"+ mOrder.Trim()  +"','"+ VehicleID.Trim() +"','"+ Delegate.Trim()   +"',1,getdate(),NULL)";
            }
            else
            {
                mq = "update [GoWH].[dbo].[go_lgst_task] SET KeyCmdScala='" + mOrder + "',VehicleID='" + VehicleID.Trim() + "',Delegate='" + Delegate.Trim() +"' where IDLG="+ IDREC.ToString() +";";
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

        private void MyListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string m = "";
            string r = "";
            try
            {
                
                //ID_REC=long.Parse (MyListView.SelectedItems[0].SubItems[11].Text.Trim());
                ID_REC = long.Parse(MyListView.SelectedItems[0].Text.Trim());
                r = MyListView.SelectedItems[0].SubItems[2].Text.Trim();
            }
            catch
            {
                MessageBox.Show("CRITIC_ERR ! Invalid ID_SESSION_TRANSPORT");
                return;
            }
            DialogResult b = MessageBox.Show("Esti sigur ca vrei sa efectuezi operatii pt : " + ID_REC.ToString() + " ?\r\n\r\n Yes : Adaugare Comenzi Disponibile\r\n No : Sterge din comenzi alocate\r\n\r\n\r\n", "", MessageBoxButtons.YesNoCancel , MessageBoxIcon.Question);
            if (b == DialogResult.Yes)
            {
                IS_UPDATE = true;
                if (MyGlobal.mFrmShowOrder4Delivery == null)
                {
                    MyGlobal.mFrmShowOrder4Delivery = new frmShowOrder4Delivery();
                    MyGlobal.mFrmShowOrder4Delivery.LoadMyCar1();
                    MyGlobal.mFrmShowOrder4Delivery.O_IS_UPDATE = IS_UPDATE;
                    MyGlobal.mFrmShowOrder4Delivery.S_SESSION_ID = ID_REC;
                    MyGlobal.mFrmShowOrder4Delivery.S_COMPANYNAME = MyListView.SelectedItems[0].SubItems[1].Text.Trim();
                    MyGlobal.mFrmShowOrder4Delivery.S_ROUTE = MyListView.SelectedItems[0].SubItems[2].Text.Trim();
                    MyGlobal.mFrmShowOrder4Delivery.S_TRANSPORT_ID = MyListView.SelectedItems[0].SubItems[3].Text.Trim();
                    MyGlobal.mFrmShowOrder4Delivery.S_DELEGATE = MyListView.SelectedItems[0].SubItems[4].Text.Trim();
                    MyGlobal.mFrmShowOrder4Delivery.S_SUBCONTRACT = MyListView.SelectedItems[0].SubItems[5].Text.Trim();
                    MyGlobal.mFrmShowOrder4Delivery.LoadMyOrder("", "5", this.txtValidFrom.Text.Trim(), this.txtValidTo.Text.Trim());
                    MyGlobal.mFrmShowOrder4Delivery.CmbCompanyName.Enabled=false ;
                    MyGlobal.mFrmShowOrder4Delivery.comboBox1.Enabled=false ;
                    MyGlobal.mFrmShowOrder4Delivery.multiColumnComboBox1.Enabled=false;
                    MyGlobal.mFrmShowOrder4Delivery.DATE_FROM = txtValidFrom.Text.Trim();
                    MyGlobal.mFrmShowOrder4Delivery.DATE_TO = txtValidTo.Text.Trim();
                    MyGlobal.mFrmShowOrder4Delivery.MY_STATUS = "5";

                }
                MyGlobal.mFrmShowOrder4Delivery.BringToFront();
                MyGlobal.mFrmShowOrder4Delivery.Show();
            }
            else
            {
                if (b == DialogResult.Cancel )
                {
                    return;        
                }
                //ID_REC = 0; //resetez ID_REC ca nu am ce sa fac cu el
                IS_UPDATE = false ;
                if (MyGlobal.mFrmShowOrderInTask == null)
                {
                    MyGlobal.mFrmShowOrderInTask = new frmShowOrderInTask();
                    MyGlobal.mFrmShowOrderInTask.LoadMyOrder(ID_REC.ToString(), r, txtValidFrom.Text.Trim(), txtValidTo.Text.Trim());
                    MyGlobal.mFrmShowOrderInTask.BringToFront();
                    MyGlobal.mFrmShowOrderInTask.Show();
                }
            }
            
            /*
            m=MyListView.SelectedItems[0].Text.Trim();
            multiColumnComboBox1.Text = m; 

            CmbOrders.SelectAll();
            CmbOrders.Text = MyListView.SelectedItems[0].SubItems[1].Text.Trim();
            txtDelegate.Text = MyListView.SelectedItems[0].SubItems[10].Text.Trim();
            
             */
            

        }

        private void multiColumnComboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void multiColumnComboBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void multiColumnComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void CmdExit_Click(object sender, EventArgs e)
        {
            
            ID_REC = 0;
            IS_UPDATE = false;
            this.Close(); 
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                checkBox1.Text = "Stare 2"; 
            }
            else
            {
                checkBox1.Text = "Stare 5"; 
            }
        }

        private void LoadMyZIP()
        {
 
             USE [iScalaDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER VIEW [dbo].[getPickingList]
as
SELECT     OR03001, OR03002, SC01012, OR03005, PRODUS, ESTITMATV, OR03011, OR03012, OR03046, SUBLINIE
FROM (

SELECT OR03001,OR03002, OR03003, SC01012, OR03005,OR03006 + OR03007 AS PRODUS, SC03003 - SC03004 AS ESTITMATV, 
       OR03011,OR03012, OR03046, NULL AS SUBLINIE
FROM   OR030100 INNER JOIN SC010100 ON OR03005 = SC01001 
       INNER JOIN SC030100 ON OR03005 = SC03001 AND OR03046 = SC03002
UNION ALL
SELECT OR17001, OR17002, NULL AS Expr1, SC01012, '' AS Expr3, OR17005 + OR17006 AS Expr4,
	   NULL AS X, NULL AS XX, NULL AS Expr5, NULL AS Expr6, OR17004
FROM   OR170100 LEFT JOIN OR030100 ON OR17001=OR03001 AND OR17002=OR03002
	   LEFT JOIN SC010100 ON OR03005=SC01001

) AS R
             */ 
              
            string mq = "";
            DataTable dataTable = new DataTable("MyZIPCode");
            dataTable.Columns.Add("CZIP", typeof(String));
            dataTable.Columns.Add("CCode", typeof(String));
            dataTable.Columns.Add("CName", typeof(String));
            dataTable.Columns.Add("CAdresa", typeof(String));
            //dataTable.Columns.Add("CJudet", typeof(String));
            this.Cursor = Cursors.WaitCursor;
            this.CmbZipCode.Text = "";
            this.CmbZipCode.DataSource = null;
            this.CmbZipCode.Items.Clear();

            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            //mq = "select RTRIM(SL14001),RTRIM(SL14003),RTRIM(SL14004),RTRIM(SL14005),RTRIM(SL14006),SL14011 from iScalaDB.dbo.SL140100;";
            mq = "select SL14011,RTRIM(SL14001),RTRIM(SL14004)+' '+RTRIM(SL14003),RTRIM(SL14005) from iScalaDB.dbo.SL140100 where SL14003<>'';";

            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                dataTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"), 
                    MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"),
                    MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"),
                    MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'")
                    //MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'")
                    //MyGlobal.Srch2Escape(dataread[5].ToString().Trim(), "'")
                    });
            }
            dataread.Close();

            
            CmbZipCode.DataSource = dataTable;
            CmbZipCode.DisplayMember = "CZIP";
            CmbZipCode.ValueMember = "CCode";

            mcmd = null;
            this.Cursor = Cursors.Default;
        }

        private void CmdSave_Click(object sender, EventArgs e)
        {
            long SessID = 0;
            try
            {
                //ID_REC=long.Parse (MyListView.SelectedItems[0].SubItems[11].Text.Trim());
                SessID  = long.Parse(MyListView.SelectedItems[0].Text.Trim());
            }
            catch
            {
                MessageBox.Show("Nu este nimic selectat");
                return;
            }
            PrintDelivery(SessID); 
        }
        private void PrintDelivery(long SessID)
        {
            
            int x = 0;
            int TP = 0;
            int A4DC = 0;
            int A4SV=0;
            int A4EX=0;
            int A3DC=0;
            int A3SV=0;
            int A3EX=0;
            int TotalColete = 0;
            string NrAvizB = "";

            if (MyGlobal.MY_SQL_CON.State == ConnectionState.Broken || MyGlobal.MY_SQL_CON.State == ConnectionState.Closed)
            {
                try
                {
                    MyGlobal.MY_SQL_CON.Close();

                }
                catch { GC.Collect(); }
                try
                {
                    MyGlobal.MY_SQL_CON.Open();
                }
                catch { MessageBox.Show("Nu pot restabili conexiunea", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1); GC.Collect(); return ; }
            }

            this.Cursor = Cursors.WaitCursor;
            Reports.xtrDeliveryForms mRep = new GoWHMgmAdmin.Reports.xtrDeliveryForms();


            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand("[lgst_PrintDelivery]");
            mcmd.Connection = MyGlobal.MY_SQL_CON;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SESS_ID", SqlDbType.BigInt));
            mcmd.Parameters["@SESS_ID"].Value = SessID;

            mcmd.CommandType = System.Data.CommandType.StoredProcedure;
            System.Data.SqlClient.SqlDataReader reader = mcmd.ExecuteReader();

            do
            {
                while (reader.Read())
                {

                    NrAvizB=MyGlobal.Srch2Escape(reader[7].ToString().Trim(), "'");
                    try
                    {
                        TP += (int)double.Parse(MyGlobal.Srch2Escape(reader[27].ToString().Trim(), "'"));
                    }catch (Exception mr) {
                        string xxxxxx = "";
                        xxxxxx = mr.Message.Trim(); 
                    }
                    try
                    {
                        TotalColete += (int)double.Parse(MyGlobal.Srch2Escape(reader[28].ToString().Trim(), "'"));
                    }
                    catch { }
                    try
                    {
                        A4DC += int.Parse(MyGlobal.Srch2Escape(reader[21].ToString().Trim(), "'")); 
                    }catch { }
                    try
                    {
                        A4SV += int.Parse(MyGlobal.Srch2Escape(reader[22].ToString().Trim(), "'")); 
                    }catch { }
                    try
                    {
                        A4EX += int.Parse(MyGlobal.Srch2Escape(reader[23].ToString().Trim(), "'"));  
                    }catch { }
                    try
                    {
                        A3DC += int.Parse(MyGlobal.Srch2Escape(reader[24].ToString().Trim(), "'"));       
                    }
                    catch { }
                    try
                    {
                        A3EX += int.Parse(MyGlobal.Srch2Escape(reader[25].ToString().Trim(), "'"));       
                    }
                    catch { }

                    mRep.dsDeliveryForms1.tblDeliveryForms.AddtblDeliveryFormsRow(
                                    MyGlobal.Srch2Escape(reader[0].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[1].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[2].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[3].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[4].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[5].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[6].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[7].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[8].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[9].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[10].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[11].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[12].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[13].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[14].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[15].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[16].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[17].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[18].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[19].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[20].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[21].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[22].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[23].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[24].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[25].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[26].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[27].ToString().Trim(), "'") ,
                                    MyGlobal.Srch2Escape(reader[28].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[29].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[30].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[31].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[32].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[33].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[34].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[35].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[36].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[37].ToString().Trim(), "'")
                                    );    
                    x++;
                }
                
            } while (reader.NextResult());
            if (x > 0)
            {
                mRep.xrLblTip.Text = NrAvizB.Trim() == "0" ? "" : NrAvizB.Trim(); //{ NrAvizB = ""; };
                mRep.xrLblTotalColete.Text = TP.ToString();
                mRep.xrLblA4DC.Text = A4DC.ToString() ;
                mRep.xrLblA3DC.Text = A3DC.ToString();
                mRep.xrLblA4SV.Text = A4SV.ToString()  ;
                mRep.xrLblA3SV.Text = A3SV.ToString()  ;
                mRep.xrLblA4EX.Text = A4EX.ToString()  ;
                mRep.xrLblA3EX.Text = A3EX.ToString()  ;
                mRep.xrLblA4DCX.Text ="0";
                mRep.xrLblA3DCX.Text ="0";
                mRep.xrLblTotalColete.Text = TotalColete.ToString();
                 
                mRep.CreateDocument();
                mRep.ShowPreview();
            }
            reader.Close();
            mcmd = null;
            this.Cursor = Cursors.Default;

        }
        private void PrintDeliveryAsyn(long SessID)
        {
            int count = 0;
            int x=0;
            

            this.Cursor = Cursors.WaitCursor;
            Reports.xtrDeliveryForms mRep = new GoWHMgmAdmin.Reports.xtrDeliveryForms();


            System.Data.SqlClient.SqlDataReader reader = null;
            System.Data.SqlClient.SqlCommand command = null;
            System.Data.SqlClient.SqlConnection connection = null;

            using (connection = new System.Data.SqlClient.SqlConnection(MyGlobal.GoWHSQLDBString))
            {
                //System.Diagnostics.EventLog.WriteEntry("[lgst_PrintDelivery]", SessID.ToString() + " " + OrderNo.Length.ToString(), System.Diagnostics.EventLogEntryType.Error, 101, 7);
                try
                {
                    command = new System.Data.SqlClient.SqlCommand("[lgst_PrintDelivery]", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SESS_ID", SqlDbType.BigInt));
                    command.Parameters["@SESS_ID"].Value = SessID;
                    
                    connection.Open();
                    IAsyncResult result = command.BeginExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    
                    while (!result.IsCompleted)
                    {
                        count += 1;
                        //System.Threading.Thread.Sleep(100);
                    }
                    using (reader = command.EndExecuteReader(result))
                    {
                        do
                        {
                            while (reader.Read())
                            {
                                
                                x++;
                                
                                mRep.dsDeliveryForms1.tblDeliveryForms.AddtblDeliveryFormsRow(
                                    MyGlobal.Srch2Escape(reader[0].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[1].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[2].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[3].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[4].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[5].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[6].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[7].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[8].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[9].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[10].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[11].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[12].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[13].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[14].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[15].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[16].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[17].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[18].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[19].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[20].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[21].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[22].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[23].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[24].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[25].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[26].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[27].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[28].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[29].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[30].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[31].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[32].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[33].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[34].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[35].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[36].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(reader[37].ToString().Trim(), "'")
                                    );     
                            }
                        } while (reader.NextResult());

                    }
                    if (x > 0)
                    {
                        mRep.CreateDocument();
                        mRep.ShowPreview(); 
                    }
                    
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    //System.Diagnostics.EventLog.WriteEntry("SqlException", string.Format("Error ({0}): {1}", ex.Number, ex.Message), System.Diagnostics.EventLogEntryType.Error, 101, 7);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.ToString());
                    //System.Diagnostics.EventLog.WriteEntry("InvalidOperationException", string.Format("Error: {0}", ex.Message), System.Diagnostics.EventLogEntryType.Error, 101, 7);
                }
                catch (Exception ex)
                {
                    //System.Diagnostics.EventLog.WriteEntry("Exception", string.Format("Error: {0}", ex.Message), System.Diagnostics.EventLogEntryType.Error, 101, 7);
                }
                finally
                {
                    reader.Dispose();
                    //Thread.Sleep(100);
                    command.Dispose();
                    command = null;
                    connection.Dispose();
                    connection = null;
                }

            }








            this.Cursor = Cursors.Default;
        }

        
    }
}