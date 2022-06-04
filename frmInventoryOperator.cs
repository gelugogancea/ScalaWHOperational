using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors;

namespace GoWHMgmAdmin
{
    public partial class frmInventoryOperator : Form
    {
        public int ID_INVENTORY = 0;
        private string MY_KEY_STOCK = "";
        private string MY_LOCATOR = "";
        private double MY_QTY = 0;
        private bool GRID_VALUE_CHANGE = false;
        private long ID_3DLOC = 0;

        public frmInventoryOperator()
        {
            InitializeComponent();
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(gridView1_ValidateRow);
            this.gridView1.CellValueChanged+=new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gridView1_CellValueChanged);  
            
        }
        
        private void frmInventoryOperator_Load(object sender, EventArgs e)
        {
            LoadOperator();
            gridView1.BestFitColumns();
        }

        private void CmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInventoryOperator_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                MyGlobal.mFrmInventoryOperator = null;  
                        
            }
            catch { }
        }
        private void LoadOperator()
        {
            string mq = "";
            DataTable dataTable = new DataTable("CountOperator");
            dataTable.Clear();
            dataTable.Columns.Add("Operator", typeof(String));
            dataTable.Columns.Add("RespEchipa", typeof(String));
            dataTable.Columns.Add("InventarNo", typeof(String));
            dataTable.Columns.Add("EchipaNr", typeof(String));

            this.Cursor = Cursors.WaitCursor;

            this.CmbCountOper.Text = "";
            this.CmbCountOper.DataSource = null;
            this.CmbCountOper.Items.Clear();
            this.CmbCountOper.BeginUpdate();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;


            mq = "SELECT go_invent_team.Oper1," +
                 "go_invent_team.Oper2, go_invent_team.Oper3, go_invent_team.Oper4, go_invent_team.Oper5, go_invent_team.Oper6,go_users_def.UserID,go_invent_team.ID, go_invent_team.IDMainInventory " +
                 "FROM go_users_def INNER JOIN " +
                 "go_invent_team ON go_users_def.ID = go_invent_team.IDSupervisor INNER JOIN " +
                 "go_invent_main ON go_invent_team.IDMainInventory = go_invent_main.ID INNER JOIN " +
                 "go_sys_lock ON go_invent_main.IDSysLock = go_sys_lock.ID and CONVERT(VARCHAR,getdate(),101) between CONVERT(VARCHAR,go_invent_main.PeriodFrom,101) AND CONVERT(VARCHAR,go_invent_main.PeriodTo,101);";
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                if (MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'") != "")
                {
                    dataTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[8].ToString().Trim(), "'") });
                }
                if (MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'") != "")
                {
                    dataTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[8].ToString().Trim(), "'") });
                }
                if (MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'") != "")
                {
                    dataTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[8].ToString().Trim(), "'") });
                }
                if (MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'") != "")
                {
                    dataTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[8].ToString().Trim(), "'") });
                }
                if (MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'") != "")
                {
                    dataTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[8].ToString().Trim(), "'") });
                }
                if (MyGlobal.Srch2Escape(dataread[5].ToString().Trim(), "'") != "")
                {
                    dataTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[5].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[8].ToString().Trim(), "'") });
                }

            }
            this.CmbCountOper.EndUpdate();
            dataread.Close();
            mcmd = null;
            CmbCountOper.DataSource = dataTable;
            CmbCountOper.DisplayMember = "Operator";
            CmbCountOper.ValueMember = "RespEchipa";

            this.Cursor = Cursors.Default;
            CmbCountOper.DataBindings.Clear();
        }
        private void LoadData(int ListNo)
        {
            string mq = "";

            string MyKeyStock = "";
            string MyDescription = "";
            string MyLocator = "";
            string MyInventArea = "";
            double MyQty = 0;

            this.Cursor = Cursors.WaitCursor;

            
            dsInventoryList.tblInventoryListOperator.Clear();   
            
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            System.Data.SqlClient.SqlDataReader dataread = null;
            mq = "SELECT go_invent_list_detail.KeyStock, "+
                "go_invent_list_detail.Description, t.kq,go_invent_list_detail.Locator, "+
                "t.kcno " +
                "FROM go_invent_list "+ 
                "INNER JOIN go_invent_list_detail ON go_invent_list.ID = go_invent_list_detail.IDListNo "+
                "and go_invent_list.InventoryNo="+ ID_INVENTORY.ToString()   +" AND go_invent_list.ListNo="+ ListNo.ToString()   +" "+
                "LEFT JOIN(SELECT go_invent_work.KeyArticleStock kst, go_invent_work_d.CountQty kq, "+ 
                "go_invent_work_d.CountNo kcno, go_invent_work_d.ListNo klst, go_invent_work.ID_INVENTORY ky, "+
                "go_invent_work_d.ThisQTYOK "+
                "FROM go_invent_work "+
                "INNER JOIN go_invent_work_d ON go_invent_work_d.ThisQTYOK=1 AND go_invent_work.ID = go_invent_work_d.ID_WORK) t ON " +
                "t.ky=go_invent_list.InventoryNo and t.kst=go_invent_list_detail.KeyStock AND t.klst=go_invent_list.ListNo "+
                "order by go_invent_list_detail.Locator,go_invent_list_detail.Description;";
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

            gridControl1.BeginUpdate();  
            while (dataread.Read())
            {
                MyKeyStock = MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'");
                MyDescription = MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'");
                try
                {
                    MyQty = double.Parse (MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"));
                }
                catch { MyQty = 0; }
                MyLocator = MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'");
                MyInventArea = MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'");

                dsInventoryList.tblInventoryListOperator.Rows.Add(new object[] { MyKeyStock, MyDescription, String.Format("{0:0.##}", MyQty.ToString().Trim()), MyLocator, MyInventArea });    
            }
            gridControl1.EndUpdate();  
            try
            {
                dataread.Close();
            }
            catch { };
            mcmd = null;
            this.Cursor = Cursors.Default;
        }

        private void CmdCauta_Click(object sender, EventArgs e)
        {
            int ListNo = 0;
            try
            {
                ListNo = int.Parse(txtListNo.Text.Trim()); 
            }
            catch
            {
                MessageBox.Show("Numarul Listei este reprezentat numeric","ERROR"); 
            }
            LoadData(ListNo);
        }

        private void gridControl1_EditorKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {

                //GRID_IS_ENTER = true;
                
                
                //MessageBox.Show(cellValueID + " - " + fieldName);
            }
        }
        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {

            this.Cursor = Cursors.Hand ;
            System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            try
            {
                MY_QTY = double.Parse(row[2].ToString().Trim());
            }
            catch
            {
                MY_KEY_STOCK = "";
                MY_LOCATOR = "";
                MY_QTY = 0;
                GRID_VALUE_CHANGE = false;
                ID_3DLOC = 0;
                MessageBox.Show("Cantitatea este reprezentata numeric", "Eroare");
            }
            if (SaveQtyReport(MY_KEY_STOCK, MY_QTY, ID_3DLOC, CmbCountOper.Text.Trim(), txtListNo.Text.Trim(), "") < 0)
            {
                int ListNo = 0;
                try
                {
                    ListNo = int.Parse(txtListNo.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("Numarul Listei este reprezentat numeric", "ERROR");
                }
                LoadData(ListNo);   
            }
            this.Cursor = Cursors.Default;
        }
        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            GRID_VALUE_CHANGE = true;
            System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            MY_KEY_STOCK = row[0].ToString();
            MY_LOCATOR = row[3].ToString();
            ID_3DLOC = GiveMeLocationID(MY_LOCATOR);
            if (ID_3DLOC == 0)
            {
                MY_KEY_STOCK = "";
                MY_LOCATOR = "";
                MY_QTY = 0;
                GRID_VALUE_CHANGE = false;
                ID_3DLOC = 0;
                MessageBox.Show("Locator este invalid", "Eroare");
            }
        }
        private long GiveMeLocationID(string Locator)
        {
            long mRet=0;
            string mq = "";
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mq = "SELECT go_locator_def.ID " +
                 "FROM go_area_def INNER JOIN " +
                 "go_main_wh_def ON go_area_def.WHCode = go_main_wh_def.ScWH INNER JOIN " +
                 "go_locator_def ON go_locator_def.LocatorSymbol='" + Locator.Trim() + "' AND go_area_def.ID = go_locator_def.ID_STORAGE_AREA;";

            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                try
                {
                    mRet = long.Parse (MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"));
                }
                catch { }
            }
            dataread.Close();
            mcmd = null;
            return mRet;
        }
        private long SaveQtyReport(string ArticleCode, double mQty, long IDLOC, string OperCode, string mListNo, string mpass)
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

            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand("AddCountingData");
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IDINVENTORY", SqlDbType.BigInt));
            mcmd.Parameters["@IDINVENTORY"].Value = ID_INVENTORY;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ARTICLECODE", SqlDbType.NVarChar, ArticleCode.Length));
            mcmd.Parameters["@ARTICLECODE"].Value = ArticleCode;
            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COUNTQTY", SqlDbType.Decimal));
            mcmd.Parameters["@COUNTQTY"].Value = mQty;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID3DLOC", SqlDbType.BigInt));
            mcmd.Parameters["@ID3DLOC"].Value = IDLOC;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OPERATORCODE", SqlDbType.NVarChar, OperCode.Length));
            mcmd.Parameters["@OPERATORCODE"].Value = OperCode;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LISTNO", SqlDbType.NVarChar, mListNo.Length));
            mcmd.Parameters["@LISTNO"].Value = mListNo;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CKPASSWD", SqlDbType.NVarChar, mpass.Length));
            mcmd.Parameters["@CKPASSWD"].Value = mpass;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MUSER", SqlDbType.NVarChar, MyGlobal.MyUserInfo.MyUser.Length));
            mcmd.Parameters["@MUSER"].Value = MyGlobal.MyUserInfo.MyUser; ;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PCNAME", SqlDbType.NVarChar, SystemInformation.ComputerName.ToString().Length));
            mcmd.Parameters["@PCNAME"].Value = SystemInformation.ComputerName.ToString();

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PCUSERNAME", SqlDbType.NVarChar, SystemInformation.UserName.ToString().Length));
            mcmd.Parameters["@PCUSERNAME"].Value = SystemInformation.UserName.ToString();

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
            catch { MyErr = -100; }

            if (MyErr == -100)
            {
                MessageBox.Show("SQL ERROR\r\nNu se pot salva date", "");
            }
            else if (MyErr == -1)
            {
                MessageBox.Show("Nu regasesc in WMS Cod Articol : " + ArticleCode);
            }
            else if (MyErr == -2)
            {
                MessageBox.Show("Cantitatea " + mQty.ToString() + " pentru Articolul " + ArticleCode + "\r\na fost deja numarata");
            }
            else if (MyErr == -3)
            {
                MessageBox.Show("Cantitatea raportata este deja salvata dar difera\r\nProbabil este gresit Numarul de Ordine al numaratorii");
            }
            else if (MyErr == -4)
            {
                MessageBox.Show("Nu se mai pot raporta cantitati numarate\r\nProcedura s-a incheiat");
            }
            else if (MyErr == -5)
            {
                MessageBox.Show("Parola pentru inchiderea procedurii de numarare este gresita\r\nsau nu apartine inventarului cu numarul : " + ID_INVENTORY.ToString());
            }
            else if (MyErr == -6)
            {
                MessageBox.Show("SQL CRITICAL ERR\r\nInvalid ID pentru go_invent work");
            }
            else if (MyErr == -7)
            {
                MessageBox.Show("SQL CRITICAL ERR\r\nInvalid ID pentru go_invent work_d");
            }
            else if (MyErr == -9)
            {
                MessageBox.Show("ERROR\r\nNumar Lista de Inventar este invalid");
            }
            else if (MyErr == 0)
            {
                //MessageBox.Show("Datele au fost salvate cu succes");
            }
            else if (MyErr == 1)
            {
                mRegistry mreg = new mRegistry();
                if (mreg.CreateValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoWHAdmin", "INVENT_CL_COUNT_" + ID_INVENTORY.ToString(), "1") == false)
                {
                    MessageBox.Show("Nu pot salva CloseCounting in registry.", "GoWHManagamenetAdmin");
                }
                mreg = null;
                MessageBox.Show("Datele au fost salvate cu succes\r\nProcedura de numarare a fost inchisa cu succes");
            }
            dataread.Close();
            mcmd = null;
            return MyErr;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}