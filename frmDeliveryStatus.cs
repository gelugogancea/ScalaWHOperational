using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;



namespace GoWHMgmAdmin
{
    public partial class frmDeliveryStatus : Form
    {

        private Control[] Editors;
        public frmDeliveryStatus()
        {
            InitializeComponent();
        }

        private void frmDeliveryStatus_Load(object sender, EventArgs e)
        {
            LoadRoute();
            
            listViewEx1.Columns.Add("Cda", 80, HorizontalAlignment.Left);
            listViewEx1.Columns.Add("TipCda.", 60, HorizontalAlignment.Left);
            listViewEx1.Columns.Add("Stare", 40, HorizontalAlignment.Left);
            listViewEx1.Columns.Add("CodClnt.", 80, HorizontalAlignment.Left);
            listViewEx1.Columns.Add("NumeClnt.", 180, HorizontalAlignment.Left);
            listViewEx1.Columns.Add("AdresaLivr", 300, HorizontalAlignment.Left);
            listViewEx1.Columns.Add("Judet", 100, HorizontalAlignment.Left);
            listViewEx1.Columns.Add("CodPostal", 100, HorizontalAlignment.Left);
            listViewEx1.Columns.Add("CdaData", 100, HorizontalAlignment.Left);
            listViewEx1.Columns.Add("Traseu", 60, HorizontalAlignment.Left);
            listViewEx1.Columns.Add("DataLivr.", 60, HorizontalAlignment.Left);
            listViewEx1.Columns.Add("CS", 60, HorizontalAlignment.Left);
            listViewEx1.Columns.Add("RezervParcurs", 60, HorizontalAlignment.Left); //Aici trebui sa fie un ComboBox cu Da/Nu
            listViewEx1.Columns.Add("Prioritate", 60, HorizontalAlignment.Left);
 
            this.listViewEx1.GridLines = true;
            this.listViewEx1.FullRowSelect = true;
            this.listViewEx1.View = View.Details;
            Editors = new Control[] {
									textBox1,
                                    textBox1,	
									textBox1,	
									textBox1,	
									textBox2,	
									textBox3,		
                                    textBox1,
                                    textBox1,
                                    textBox1,
                                    comboBox1,
                                    textBox1,
                                    textBox1 
									};


            listViewEx1.DoubleClickActivation = true;
        }
        private void control_SelectedValueChanged(object sender, System.EventArgs e)
        {
            listViewEx1.EndEditing(true);
        }

        private void listViewEx1_SubItemClicked(object sender, SubItemEventArgs e)
        {
            try
            {
                if (e.SubItem == 3) // Password field
                {
                    e.Item.SubItems[e.SubItem].Text = e.Item.Tag.ToString();
                }
                else if (e.SubItem == 7 || e.SubItem == 9)
                {
                    listViewEx1.StartEditing(Editors[e.SubItem], e.Item, e.SubItem);    
                }
                else
                {
                    return;
                }
            }
            catch { GC.Collect(); return; } 
            

        }

        private void listViewEx1_SubItemBeginEditing(object sender, SubItemEventArgs e)
        {

        }

        private void listViewEx1_KeyDown(object sender, KeyEventArgs e)
        {
            string b1 = "";
            string b2 = "";
            string b3 = "";
            if (e.KeyValue == 13)
            {

                b1 = listViewEx1.SelectedItems[0].Text.Trim();

                b2 = listViewEx1.SelectedItems[0].SubItems[1].Text.Trim();
                b3 = listViewEx1.SelectedItems[0].SubItems[2].Text.Trim();
            }
        }
        private void LoadRoute()
        {
            string mq = "";
            comboBox1.Items.Add("");
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mq = "select CODTRASEU from iScalaDB.dbo.RUTA0000 order by CODTRASEU;";
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                comboBox1.Items.Add(MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"));
            }
            
            dataread.Close();
            mcmd = null;
        }
        private void LoadOpenOrderSP(int mStatus)
        {
            ListViewItem lvi = null;
            this.listViewEx1.Items.Clear();

            this.listViewEx1.Refresh();
            
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
                catch { MessageBox.Show("Nu pot restabili conexiunea", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1); GC.Collect(); return; }
            }

            this.Cursor = Cursors.WaitCursor;
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand("[lgst_ShowOrderInStatus]");
            mcmd.Connection = MyGlobal.MY_SQL_CON;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iSTATUS", SqlDbType.Int ));
            mcmd.Parameters["@iSTATUS"].Value = mStatus;

            mcmd.CommandType = System.Data.CommandType.StoredProcedure;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            
            do
            {
                while (dataread.Read())
                {
                    lvi = new ListViewItem(MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"));
                    lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"));
                    lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"));
                    lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'"));	
                    lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'"));
                    lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[5].ToString().Trim(), "'"));
                    lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'"));
                    lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'"));
                    lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[8].ToString().Trim(), "'"));
                    lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[9].ToString().Trim(), "'"));
                    lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[10].ToString().Trim(), "'"));
                    lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[11].ToString().Trim(), "'"));
                    lvi.SubItems.Add("");
                    lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[12].ToString().Trim(), "'"));
                    this.listViewEx1.Items.Add(lvi);
                }
            } while (dataread.NextResult());
            dataread.Close();
            mcmd = null;
            this.Cursor = Cursors.Default;
        }
        private void LoadOpenOrder(int mStatus)
        {
            string mq = "";
            ListViewItem lvi=null;
            this.listViewEx1.Items.Clear();

            this.listViewEx1.Refresh();
  
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mq = "select iScalaDB.dbo.OR010100.OR01001,iScalaDB.dbo.OR010100.OR01002,iScalaDB.dbo.OR010100.OR01091," +
	            "CASE WHEN LEN(LTRIM(SL14001))<=0 OR SL14001 IS NULL THEN SL01001 ELSE SL14001 END a,"+
	            "CASE WHEN LEN(LTRIM(OR04002))<=0 OR OR04002 IS NULL THEN SL01002 ELSE OR04002 END b,"+
 	            "CASE WHEN OR04002+OR04003+OR04004+OR04005<> space(140) THEN OR04004 "+
	            "ELSE CASE WHEN SL14004+SL14005+SL14006<> space(105) THEN SL14005 "+
	            "ELSE SL01004 END END + '  '+ 	CASE WHEN OR04002+OR04003+OR04004+OR04005<>space(140) THEN OR04003 "+
	            "ELSE CASE WHEN SL14004+SL14005+SL14006<>space(105) THEN SL14004 "+
	            "ELSE SL01003 END END c, "+
	            "CASE WHEN OR04002+OR04003+OR04004+OR04005<> space(140) THEN OR04005 "+
	            "ELSE CASE WHEN SL14004+SL14005+SL14006<> space(105) THEN SL14006 "+
	            "ELSE SL01005 END END e,iScalaDB.dbo.SL140100.SL14011,iScalaDB.dbo.OR010100.OR01015,"+
                "[iScalaDB].[dbo].[OR010100].OR01056,iScalaDB.dbo.OR010100.OR01016,iScalaDB.dbo.OR010100.OR01017 " +
	            "from "+
	            "iScalaDB.dbo.OR010100 LEFT JOIN iScalaDB.dbo.OR040100 ON OR01001=OR04001 "+
	            "join iScalaDB.dbo.SL010100 on (iScalaDB.dbo.SL010100.SL01001=iScalaDB.dbo.OR010100.OR01003) "+
	            "LEFT JOIN iScalaDB.dbo.SL140100 ON iScalaDB.dbo.OR010100.OR01045=iScalaDB.dbo.SL140100.SL14001 "+
                " AND iScalaDB.dbo.SL140100.SL14002=CASE WHEN LEN(LTRIM(OR04002))<=0 OR OR04002 IS NULL THEN SL01002 ELSE OR04002 END " +
                " where iScalaDB.dbo.OR010100.OR01091="+ mStatus +";";
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                
                lvi = new ListViewItem(MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"));
                lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"));
                lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"));
                lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'"));	
                lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'"));
                lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[5].ToString().Trim(), "'"));
                lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'"));
                lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'"));
                lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[8].ToString().Trim(), "'"));
                lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[9].ToString().Trim(), "'"));
                lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[10].ToString().Trim(), "'"));
                lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[11].ToString().Trim(), "'"));
                lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[12].ToString().Trim(), "'"));
                this.listViewEx1.Items.Add(lvi);
            }
            
            dataread.Close();
            mcmd = null;
        }

        private void CmdExit_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void frmDeliveryStatus_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                MyGlobal.mFrmDeliveryStatus = null;  
            }
            catch
            {
            
            }
            GC.Collect();
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            string b1 = "";
            string b3 = "";
            int i=0;
            int IsFoundOnList = 0;
            if (e.KeyValue == 13)
            {
                b1 = listViewEx1.SelectedItems[0].Text.Trim();
                b3 = listViewEx1.SelectedItems[0].SubItems[7].Text.Trim();
                for (i = 0; i < comboBox1.Items.Count; i++)
                {
                    if (comboBox1.Items[i].ToString() == comboBox1.Text.Trim())
                    {
                        IsFoundOnList++; 
                        break;
                    }
                }
                if (IsFoundOnList == 0)
                {
                    MessageBox.Show("Ruta inexistenta.\r\nNu ati selectat Ruta din Lista ???","EROARE",MessageBoxButtons.OK ,MessageBoxIcon.Error   );  
                    return;
                }
                if (b3.Trim() == "")
                {
                    MessageBox.Show("Nu este completat Cod Zip/Postal", "EROARE", MessageBoxButtons.OK, MessageBoxIcon.Error);  
                    return;
                }
                if(SaveStatus(b1,b3, comboBox1.Text.Trim())==1)
                {
                    EventArgs ee = new EventArgs(); 
                    CmdSearch_Click(CmdSearch,ee);
                }
            }
        }
        private int SaveStatus(string OrderNo,string ZipCode, string sRoute)
        {
            int MyErr = 0;

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
                catch { MessageBox.Show("Nu pot restabili conexiunea", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1); GC.Collect(); return -1; }
            }

            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand("UpdateStatusOR01");
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrderNo", SqlDbType.NVarChar,OrderNo.Trim().Length));
            mcmd.Parameters["@OrderNo"].Value = OrderNo.Trim()  ;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@mRoute", SqlDbType.NVarChar,sRoute.Trim().Length   ));
            mcmd.Parameters["@mRoute"].Value = sRoute.Trim () ;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ZIPCode", SqlDbType.NVarChar,ZipCode.Trim().Length));
            mcmd.Parameters["@ZIPCode"].Value = ZipCode.Trim();

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MERR", SqlDbType.Int));
            mcmd.Parameters["@MERR"].Direction = ParameterDirection.Output;

            mcmd.CommandType = System.Data.CommandType.StoredProcedure;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();

            do
            {
                while (dataread.Read())
                {

                }
            } while (dataread.NextResult());

            try
            {
                MyErr = (int)mcmd.Parameters["@MERR"].Value;
            }
            catch(Exception mer) {
                string kk = "";
                kk = mer.ToString(); 
                MyErr = -100; 
            }

            if (MyErr == -100)
            {
                MessageBox.Show("SQL ERROR\r\nNu se pot salva date", "");
            }
            else if (MyErr == -1)
            {
                MessageBox.Show("Order No : " + OrderNo.Trim() + " nu se poate schimba status");
            }
            else if (MyErr == 1)
            {
                MessageBox.Show("Datele au fost salvate cu succes");
            }
            
                
            
            dataread.Close();
            mcmd = null;
            return MyErr;        
        }
        private void CmdSearch_Click(object sender, EventArgs e)
        {
            int iStatus = 0;
            try
            {
                iStatus = int.Parse(this.txtStatus.Text.Trim());    
            }
            catch
            {
                GC.Collect();
                MessageBox.Show("Status comanda este reprezentat numeric","Eroare",MessageBoxButtons.OK ,MessageBoxIcon.Error  ); 
                return;
            }
            //LoadOpenOrder(iStatus);
            LoadOpenOrderSP(iStatus);
        }
        private int PrintListSP(string mOrderNo,string TipCda,string CodClient,string NumeClient,string AddresaClient,string Judet,string CodPostal,string DataCmd,string Traseu,string DataLivrare,string CSReferinta,string Prioritate)
        {
            string mq = "";
            int x = 0;
            string OrderNo = "";
            string AddrLoc = "";
            string ProductCode = "";
            string ProductName = "";
            int EstimStock = 0;
            int OrderQty = 0;
            int DeliveryQty = 0;
            string WHDelivery = "";
            string SubLine = "";
            string ItemNo = "";
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
                catch { 
                    MessageBox.Show("Nu pot restabili conexiunea", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1); 
                    GC.Collect(); 
                    return 0; 
                }
            }
            this.Cursor = Cursors.WaitCursor;
            Reports.xtrPickingList mRep = new GoWHMgmAdmin.Reports.xtrPickingList();
            mRep.DataSource = mRep.dsPickingList1;
            mRep.DataMember = mRep.dsPickingList1.tblPickingList.ToString();

            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand("[lgst_PrintPickingList]");
            mcmd.Connection = MyGlobal.MY_SQL_CON;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sORDERNO", SqlDbType.NVarChar,mOrderNo.Trim().Length   ));
            mcmd.Parameters["@sORDERNO"].Value = mOrderNo;

            mcmd.CommandType = System.Data.CommandType.StoredProcedure;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();

            do
            {
                while (dataread.Read())
                {
                    OrderNo = MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'");

                    ItemNo = MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'");
                    AddrLoc = MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'");
                    ProductCode = MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'");
                    ProductName = MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'");
                    try
                    {
                        EstimStock = (int)double.Parse(MyGlobal.Srch2Escape(dataread[5].ToString().Trim(), "'"));
                    }
                    catch
                    {
                        EstimStock = 0;
                    }
                    try
                    {
                        OrderQty = (int)double.Parse(MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'"));
                    }
                    catch
                    {
                        OrderQty = 0;
                    }
                    try
                    {
                        DeliveryQty = (int)double.Parse(MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'"));
                    }
                    catch
                    {
                        DeliveryQty = 0;
                    }
                    WHDelivery = MyGlobal.Srch2Escape(dataread[8].ToString().Trim(), "'");
                    SubLine = MyGlobal.Srch2Escape(dataread[9].ToString().Trim(), "'");
                    //Date1 = MyGlobal.Srch2Escape(dataread[10].ToString().Trim(), "'");
                    //Date2 = MyGlobal.Srch2Escape(dataread[11].ToString().Trim(), "'");
                    //mRep.xrLabel14.Text = "AAAAAAAAAAAAAAAAAA";
                    //mRep.xrLabel8.Text = "BBBBBBBBB";
                    //mRep.dsInventoryList1.tblInventoryList.Rows.Add(new object[] { ID_INVENTAR.ToString(), MyListNo, MyKeyStock, MyDescription, MyLocator, MyInventArea });
                    mRep.xrLblCS.Text = CSReferinta.Trim();
                    mRep.xrLblTipLivrare.Text = TipCda.Trim();
                    mRep.xrLblCodClient.Text = CodClient.Trim();
                    mRep.xrLblCustomName.Text = NumeClient.Trim();
                    mRep.xrLblDeliveryAddress.Text = AddresaClient + " - \r\n" + Judet + " - \r\n" + CodPostal;
                    mRep.xrLblDateStatus1.Text = DataCmd.Trim();
                    mRep.xrLblRoute.Text = Traseu.Trim();
                    mRep.xrLabel35.Text = DataLivrare.Trim();
                    mRep.xrLblDeliveryHour.Text = Prioritate;
                    mRep.xrLblDataList.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
                    mRep.xrLabDispecer.Text = SystemInformation.UserName.ToString();
                    mRep.dsPickingList1.tblPickingList.Rows.Add(new object[] { OrderNo, ItemNo, AddrLoc, ProductCode, ProductName, EstimStock.ToString(), OrderQty.ToString(), DeliveryQty.ToString(), WHDelivery, SubLine });
                    x++;
                }
            } while (dataread.NextResult());
            if (x > 0)
            {
                mRep.CreateDocument();
                //mRep.Print();   
                //mRep.PrintDialog();
                mRep.ShowPreview();
            }
            else
            {
                x = -1;
            }
            //mRep.PrintingSystem.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.PrintDirect);
            //mRep.PrintingSystem.Print(MyGlobal.MY_PRINTER);
            try
            {
                dataread.Close();
            }
            catch { };
            mcmd = null;
            this.Cursor = Cursors.Default;
            return x;
        }
        private int PrintList(string mOrderNo,string TipCda,string CodClient,string NumeClient,string AddresaClient,string Judet,string CodPostal,string DataCmd,string Traseu,string DataLivrare,string CSReferinta,string Prioritate)
        {
            string mq = "";
            int x = 0;
            string OrderNo = "";
            string AddrLoc = "";
            string ProductCode = "";
            string ProductName = "";
            double  EstimStock = 0;
            double OrderQty = 0;
            double DeliveryQty = 0;
            string WHDelivery = "";
            string SubLine = "";
            string ItemNo = "";
            string Date1 = "";
            string Date2 = "";
            
            this.Cursor = Cursors.WaitCursor;

            
            //Reports.xtrInventoryList mRep = new GoWHMgmAdmin.Reports.xtrInventoryList();
            Reports.xtrPickingList mRep = new GoWHMgmAdmin.Reports.xtrPickingList();
            //Trebuie facut public membru DataSet pentru a puta fi accesat
            mRep.DataSource = mRep.dsPickingList1;
            mRep.DataMember = mRep.dsPickingList1.tblPickingList.ToString();      
            

            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            System.Data.SqlClient.SqlDataReader dataread = null;
            mq = "SELECT OR03001, OR03002, SC01012, OR03005, PRODUS, ESTITMATV, OR03011, OR03012, OR03046, SUBLINIE" +
                " FROM ( " +
                "SELECT OR03001,OR03002, OR03003, SC01012, OR03005,OR03006 + OR03007 AS PRODUS, SC03003 - SC03004 AS ESTITMATV, "+
                "OR03011,OR03012, OR03046, NULL AS SUBLINIE " +
                "FROM   iScalaDB.dbo.OR030100 INNER JOIN iScalaDB.dbo.SC010100 ON OR03005 = SC01001  " +
                "INNER JOIN iScalaDB.dbo.SC030100 ON OR03005 = SC03001 AND OR03046 = SC03002 " +
                "UNION ALL "+
                "SELECT OR17001, OR17002, NULL AS Expr1, SC01012, '' AS Expr3, OR17005 + OR17006 AS Expr4, "+
	            "NULL AS X, NULL AS XX, NULL AS Expr5, NULL AS Expr6, OR17004 " +
                "FROM   iScalaDB.dbo.OR170100 LEFT JOIN iScalaDB.dbo.OR030100 ON OR17001=OR03001 AND OR17002=OR03002 " +
                "LEFT JOIN iScalaDB.dbo.SC010100 ON OR03005=SC01001 " +
                ") AS R where OR03001='"+ mOrderNo +"';";
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

            while (dataread.Read())
            {
                OrderNo = MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'");

                ItemNo = MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'");
                AddrLoc = MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'");
                ProductCode = MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'");
                ProductName = MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'");
                try
                {
                    EstimStock = double.Parse(MyGlobal.Srch2Escape(dataread[5].ToString().Trim(), "'"));
                }
                catch
                {
                    EstimStock = 0;
                }
                try
                {
                    OrderQty = double.Parse(MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'"));
                }
                catch
                {
                    OrderQty = 0;
                }
                try
                {
                    DeliveryQty = double.Parse(MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'"));
                }
                catch
                {
                    DeliveryQty = 0;
                }
                WHDelivery = MyGlobal.Srch2Escape(dataread[8].ToString().Trim(), "'");
                SubLine = MyGlobal.Srch2Escape(dataread[9].ToString().Trim(), "'");
                //Date1 = MyGlobal.Srch2Escape(dataread[10].ToString().Trim(), "'");
                //Date2 = MyGlobal.Srch2Escape(dataread[11].ToString().Trim(), "'");
                //mRep.xrLabel14.Text = "AAAAAAAAAAAAAAAAAA";
                //mRep.xrLabel8.Text = "BBBBBBBBB";
                //mRep.dsInventoryList1.tblInventoryList.Rows.Add(new object[] { ID_INVENTAR.ToString(), MyListNo, MyKeyStock, MyDescription, MyLocator, MyInventArea });
                mRep.xrLblCS.Text = CSReferinta.Trim();
                mRep.xrLblTipLivrare.Text  = TipCda.Trim();
                mRep.xrLblCodClient.Text = CodClient.Trim();
                mRep.xrLblCustomName.Text  =  NumeClient.Trim();
                mRep.xrLblDeliveryAddress.Text = AddresaClient + " - \r\n" + Judet + " - \r\n" + CodPostal;
                mRep.xrLblDateStatus1.Text =DataCmd.Trim();
                mRep.xrLblRoute.Text =Traseu.Trim ();
                mRep.xrLabel35.Text = DataLivrare.Trim();
                mRep.xrLblDeliveryHour.Text = Prioritate;
                mRep.xrLblDataList.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm") ;
                mRep.xrLabDispecer.Text = SystemInformation.UserName.ToString();
                mRep.dsPickingList1.tblPickingList.Rows.Add(new object[] { OrderNo,ItemNo ,AddrLoc, ProductCode, ProductName, EstimStock.ToString() ,OrderQty.ToString() ,DeliveryQty.ToString(), WHDelivery, SubLine });     
                x++;
            }
            if (x > 0)
            {
                mRep.CreateDocument();
                //mRep.Print();   
                //mRep.PrintDialog();
                mRep.ShowPreview() ;  
            }
            else
            {
                x = -1;
            }
            //mRep.PrintingSystem.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.PrintDirect);
            //mRep.PrintingSystem.Print(MyGlobal.MY_PRINTER);
            try
            {
                dataread.Close();
            }
            catch { };
            mcmd = null;
            this.Cursor = Cursors.Default;
            return x;
        }

        private void CmdPrint_Click(object sender, EventArgs e)
        {
            string b1 = "";
            string TipCmd = "";
            string CodClient = "";
            string NumeClient = "";
            string AdresaClient = "";
            string Judet = "";
            string CodPostal = "";
            string DataCmd = "";
            string Traseu = "";
            string DataLivrare = "";
            string CSReferinta = "";
            string Prio = "";
            try
            {
                b1 = listViewEx1.SelectedItems[0].Text.Trim();
                TipCmd = listViewEx1.SelectedItems[0].SubItems[1].Text.Trim();
                CodClient = listViewEx1.SelectedItems[0].SubItems[3].Text.Trim();
                NumeClient = listViewEx1.SelectedItems[0].SubItems[4].Text.Trim();
                AdresaClient = listViewEx1.SelectedItems[0].SubItems[5].Text.Trim();
                Judet =listViewEx1.SelectedItems[0].SubItems[6].Text.Trim();
                CodPostal = listViewEx1.SelectedItems[0].SubItems[7].Text.Trim();
                DataCmd = listViewEx1.SelectedItems[0].SubItems[8].Text.Trim();
                Traseu = listViewEx1.SelectedItems[0].SubItems[9].Text.Trim();
                DataLivrare = listViewEx1.SelectedItems[0].SubItems[10].Text.Trim();
                CSReferinta = listViewEx1.SelectedItems[0].SubItems[11].Text.Trim();
                Prio = listViewEx1.SelectedItems[0].SubItems[13].Text.Trim();
            }
            catch {
                MessageBox.Show("Nu este nicio comanda selectata","EROARE",MessageBoxButtons.OK,MessageBoxIcon.Hand    );
                return; 
            }
            //PrintList(b1,TipCmd,CodClient,NumeClient,AdresaClient,Judet,CodPostal,DataCmd,Traseu,DataLivrare,CSReferinta,Prio);
            PrintListSP(b1, TipCmd, CodClient, NumeClient, AdresaClient, Judet, CodPostal, DataCmd, Traseu, DataLivrare, CSReferinta, Prio); 
        }

        private void listViewEx1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //System.Xml.XmlDocument mxl = new System.Xml.XmlDocument();
            //System.Xml.XmlDeclaration dec = mxl.CreateXmlDeclaration("1.0", null, null);

            System.Xml.XmlWriterSettings wSettings = new System.Xml.XmlWriterSettings();
            wSettings.Indent = true;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.Xml.XmlWriter xw = System.Xml.XmlWriter.Create(ms, wSettings);// Write Declaration
            xw.WriteStartDocument();

            // Write the root node
            xw.WriteStartElement("export");

            // Write the books and the book elements
            xw.WriteStartElement("Book");
            xw.WriteStartAttribute("BookType");
            xw.WriteString("Hardback");
            xw.WriteEndAttribute();

            xw.WriteStartElement("Title");
            xw.WriteString("Door Number Three");
            xw.WriteEndElement();
            xw.WriteStartElement("Author");
            xw.WriteString("O'Leary, Patrick");
            xw.WriteEndElement();

            xw.WriteEndElement();

            // Write another book
            xw.WriteStartElement("Book");
            xw.WriteStartAttribute("BookType");
            xw.WriteString("Paperback");
            xw.WriteEndAttribute();

            xw.WriteStartElement("Title");
            xw.WriteString("Lord of Light");
            xw.WriteEndElement();
            xw.WriteStartElement("Author");
            xw.WriteString("Zelanzy, Roger");
            xw.WriteEndElement();

            xw.WriteEndElement();

            // Close the document
            xw.WriteEndDocument();

            // Flush the write
            xw.Flush();
            

            Byte[] buffer = new Byte[ms.Length];
            buffer = ms.ToArray();
            string xmlOutput = System.Text.Encoding.UTF8.GetString(buffer);
            System.IO.Stream myStream;
            SaveFileDialog svdlg = new SaveFileDialog();
            svdlg.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            svdlg.FilterIndex = 1;
            svdlg.RestoreDirectory = true; 

            if (svdlg.ShowDialog() == DialogResult.OK)
            {
                if((myStream = svdlg.OpenFile()) != null) 
                  {
                      System.IO.StreamWriter n = new System.IO.StreamWriter(myStream);
                      n.Write(xmlOutput);
                      n.Flush();
                      n.Close();
                      n = null;
                      myStream.Close(); 
                  }


            }
            svdlg = null;
            myStream = null;

            MessageBox.Show(xmlOutput);

        }       

        
    }

}