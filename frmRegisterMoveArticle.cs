using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoWHMgmAdmin
{
    public partial class frmRegisterMoveArticle : Form
    {
        public int IS_QTY_REGULATION = 0;
        public frmRegisterMoveArticle()
        {
            InitializeComponent();
        }
        public void SetCtrl()
        {
            if (IS_QTY_REGULATION == 1)
            {
                label2.Visible = false;
                CmbMoveTo.Visible = false;
                txtArticol.Visible = false;
                txtDesc.Visible = false;
                label5.Visible = true;
                txtDocNo.Visible = true;
                LoadMasterData();
            }
            else
            {
                CmbArticol.Visible = false;
                label5.Visible = false;
                txtDocNo.Visible = false ;
            }
        }
        private void LoadMasterData()
        {
            string mq = "";
            DataTable dataTable = new DataTable("MasterData");
            dataTable.Columns.Add("COD", typeof(String));
            dataTable.Columns.Add("Denumire", typeof(String));

            this.Cursor = Cursors.WaitCursor;
            this.CmbArticol.Text = "";
            CmbArticol.DataSource = null;
            this.CmbArticol.Items.Clear();
            this.CmbArticol.BeginUpdate();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mq = "SELECT StockCode,Description1+Description2 FROM dbo.go_article_masterdata order by StockCode;";
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                dataTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'") });
            }
            CmbArticol.DataSource = dataTable;
            CmbArticol.DisplayMember = "COD";
            CmbArticol.ValueMember = "Denumire";
            CmbArticol.Text = "";
            //LblARDescrieri.Text = "";
            this.CmbArticol.EndUpdate();
            dataread.Close();
            mcmd = null;
            this.Cursor = Cursors.Default;
        }
        private int ShowMeStock(string LocatorSymbol)
        {
            ListViewItem k = null;
            double qty = 0;
            int x = 0;

            string mq = "";
            System.Data.SqlClient.SqlCommand mcmd = null;
            System.Data.SqlClient.SqlDataReader dataread = null;

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
            MyListView.Items.Clear();
            mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mq = "SELECT go_article_stock.KeyStockCode, go_article_masterdata.Description1 ,go_article_masterdata.Description2,SUM(go_article_stock.QtyIN)-SUM(go_article_stock.QtyOUT) as ActualStock, go_locator_def.LocatorSymbol," +
                 "go_area_def.AreaCode, go_area_def.WHCode " +
                 "FROM go_article_stock INNER JOIN " +
                 "go_article_masterdata ON go_article_stock.KeyStockCode = go_article_masterdata.StockCode AND go_article_stock.IsOpen=0 " +
                 "INNER JOIN go_locator_def ON go_article_stock.ID_3DLOC = go_locator_def.ID INNER JOIN " +
                 "go_area_def ON go_locator_def.ID_STORAGE_AREA = go_area_def.ID and " +
                 "go_locator_def.LocatorSymbol='" + LocatorSymbol.Trim() + "' " +
                 "group by go_article_stock.KeyStockCode,go_article_stock.ID_3DLOC," +
                 "go_article_masterdata.Description1,go_article_masterdata.Description2," +
                 "go_locator_def.LocatorSymbol,go_area_def.AreaCode,go_area_def.WHCode " +
                 "having SUM(go_article_stock.QtyIN)-SUM(go_article_stock.QtyOUT)<>0 " +
                 "order by go_article_masterdata.Description1";
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            dataread = mcmd.ExecuteReader();
            MyListView.BeginUpdate();
            while (dataread.Read())
            {
                k = new ListViewItem(MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'") + MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"));
                //k.SubItems.Add(ClassPublic.Srch2Escape(dataread[2].ToString().Trim(), "'"));
                try
                {
                    qty = double.Parse(MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'"));
                }
                catch
                {
                    qty = 0;
                }
                k.SubItems.Add(qty.ToString());
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[5].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'"));
                this.MyListView.Items.Add(k);
                x++;
            }
            MyListView.EndUpdate();
            dataread.Close();
            mcmd = null;
            return x;
        }
        private void LoadStorageAreDef()
        {
            string mq = "";
            DataTable dTable = null;
            long x = 0;
            dTable = new DataTable("ZoneStocare1");
            dTable.Clear();
            dTable.Columns.Add("Locator", typeof(String));
            dTable.Columns.Add("Aria", typeof(String));
            dTable.Columns.Add("WHCode", typeof(String));

            this.Cursor = Cursors.WaitCursor;
            this.CmbSTArea.Text = "";
            this.CmbSTArea.DataSource = null;
            this.CmbSTArea.Items.Clear();

            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            
            //mq = "SELECT ID,AreaCode,AreaDescription FROM dbo.go_area_def where WHCode='" + mWH.Trim() + "';";
            mq = " SELECT go_locator_def.LocatorSymbol,go_area_def.AreaCode,go_area_def.WHCode " +
                 "FROM go_locator_def " + 
                 "INNER JOIN go_area_def ON go_locator_def.ID_STORAGE_AREA = go_area_def.ID;";

            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                dTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'") });
                x++;
            }
            dataread.Close();
            mcmd = null;

            this.CmbSTArea.DataSource = dTable;
            this.CmbSTArea.DisplayMember = "Locator";
            this.CmbSTArea.ValueMember = "Aria";
            
            {
                if (x > 0)
                {
                    this.CmbSTArea.Text = "";
                }
                else
                {
                    this.CmbSTArea.Text = "Nu sunt date.";
                }
            }

            this.Cursor = Cursors.Default;

        }
        private void LoadStorageAreDef1()
        {
            string mq = "";
            DataTable dTable = null;
            long x = 0;
            dTable = new DataTable("ZoneStocare2");
            dTable.Clear();
            dTable.Columns.Add("Locator", typeof(String));
            dTable.Columns.Add("Aria", typeof(String));
            dTable.Columns.Add("WHCode", typeof(String));

            this.Cursor = Cursors.WaitCursor;
            this.CmbMoveTo.Text = "";
            this.CmbMoveTo.DataSource = null;
            this.CmbMoveTo.Items.Clear();

            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            
            //mq = "SELECT ID,AreaCode,AreaDescription FROM dbo.go_area_def where WHCode='" + mWH.Trim() + "';";
            mq = " SELECT go_locator_def.LocatorSymbol,go_area_def.AreaCode,go_area_def.WHCode " +
                 "FROM go_locator_def " + 
                 "INNER JOIN go_area_def ON go_locator_def.ID_STORAGE_AREA = go_area_def.ID;";

            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                dTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'") });
                x++;
            }
            dataread.Close();
            mcmd = null;

            this.CmbMoveTo.DataSource = dTable;
            this.CmbMoveTo.DisplayMember = "Locator";
            this.CmbMoveTo.ValueMember = "Aria";
            
            {
                if (x > 0)
                {
                    this.CmbMoveTo.Text = "";
                }
                else
                {
                    this.CmbMoveTo.Text = "Nu sunt date.";
                }
            }

            this.Cursor = Cursors.Default;
        }

        private void frmRegisterMoveArticle_Load(object sender, EventArgs e)
        {
            ColumnHeader colHead;
            this.MyListView.Clear();
            this.MyListView.Columns.Clear();

            colHead = new ColumnHeader();
            colHead.Text = "Art";
            colHead.Width = 90;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Desc";
            colHead.Width = 240;
            this.MyListView.Columns.Add(colHead);

            //colHead = new ColumnHeader();
            //colHead.Text = "Desc2";
            //colHead.Width = 90;
            //this.MyListViewPart.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Stoc";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Loc";
            colHead.Width = 85;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "AR";
            colHead.Width = 85;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "WH";
            colHead.Width = 85;
            this.MyListView.Columns.Add(colHead);

            this.MyListView.GridLines = true;
            this.MyListView.FullRowSelect = true;
            this.MyListView.View = View.Details;

            LoadStorageAreDef();
            LoadStorageAreDef1();
            LoadUsers();
        }

        private void CmbSTArea_KeyDown(object sender, KeyEventArgs e)
        {
            
            if(e.KeyCode ==Keys.Return  )
            {
                ShowMeStock(CmbSTArea.Text.Trim());       
            }
        }

        private void MyListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtArticol.Text= MyListView.SelectedItems[0].Text.Trim();
            txtDesc.Text   = MyListView.SelectedItems[0].SubItems[1].Text.Trim();
            txtQty.Text = MyListView.SelectedItems[0].SubItems[2].Text.Trim();

        }

        private void CmdSave_Click(object sender, EventArgs e)
        {
            int Qty = 0;
            if (CmbSTArea.Text.Trim()=="")
            {
                MessageBox.Show("Trebuie completat Locator Sursa","Eroare",MessageBoxButtons.OK,MessageBoxIcon.Error); 
                return; 
            }
            if (IS_QTY_REGULATION == 0)
            {
                if (CmbMoveTo.Text.Trim() == "")
                {
                    MessageBox.Show("Trebuie completat Locator Destinatie", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtArticol.Text.Trim() == "")
                {
                    MessageBox.Show("Trebuie completat Cod Articol", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (txtDocNo.Text.Trim() == "")
                {
                    MessageBox.Show("Trebuie completat un numar document de autorizare ", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    CmbMoveTo.Text = txtDocNo.Text.Trim();   
                }
                if (CmbArticol.Text.Trim() == "")
                {
                    MessageBox.Show("Trebuie completat Cod Articol", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    txtArticol.Text = CmbArticol.Text.Trim() ;    
                }
                
            }
            if (CmbUser.Text.Trim() == "")
            {
                MessageBox.Show("Trebuie ales un Operator din lista", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            
            try
            {
                Qty = int.Parse(txtQty.Text.Trim());
            }
            catch { MessageBox.Show("Cantitatea este reprezentata numeric.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            if (SaveMyMove(CmbSTArea.Text.Trim(), CmbMoveTo.Text.Trim(), txtArticol.Text.Trim(), Qty,IS_QTY_REGULATION,CmbUser.Text.Trim()) < 0)
            {
                MessageBox.Show("EROARE MSSQL\r\nNu se pot salva date", "", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                this.CmbSTArea.Text = "";
                this.CmbMoveTo.Text = "";
                this.txtArticol.Text = "";
                this.txtDesc.Text = "";
                this.txtQty.Text = "";
                this.CmbUser.Text = "";
                this.CmbArticol.Text = ""; 
 
                MessageBox.Show("Am salvat date cu succes", "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
            }

        }
        private void MyListViewPart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private int SaveMyMove(string LocOut, string LocIn, string StockCode, double Qty,int IsReg ,string sOpUser)
        {
            int MyErr = 0;
            string m = "";
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

            System.Data.SqlClient.SqlCommand mcmd = null;
            mcmd = new System.Data.SqlClient.SqlCommand("MoveProductPC");
            mcmd.Connection = MyGlobal.MY_SQL_CON;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LOCOUT", SqlDbType.NChar, LocOut.Length));
            mcmd.Parameters["@LOCOUT"].Value = LocOut.Trim();

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LOCIN", SqlDbType.NChar, LocIn.Length));
            mcmd.Parameters["@LOCIN"].Value = LocIn;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@STOCKCODE", SqlDbType.NChar, StockCode.Length));
            mcmd.Parameters["@STOCKCODE"].Value = StockCode;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@QTY", SqlDbType.Decimal));
            mcmd.Parameters["@QTY"].Value = Qty;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MyUser", SqlDbType.NVarChar, sOpUser.Trim().Length));
            mcmd.Parameters["@MyUser"].Value = sOpUser.Trim()  ;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MyUser1", SqlDbType.NVarChar, MyGlobal.MyUserInfo.MyUser.Length));
            mcmd.Parameters["@MyUser1"].Value = MyGlobal.MyUserInfo.MyUser;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsQtyReg", SqlDbType.Int));
            mcmd.Parameters["@IsQtyReg"].Value = IS_QTY_REGULATION ;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MErr", SqlDbType.Int));
            mcmd.Parameters["@MErr"].Direction = ParameterDirection.Output;

            mcmd.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                mcmd.ExecuteNonQuery();
            }
            catch (Exception ermsg)
            {
                m = ermsg.ToString();
            }
            MyErr = (int)mcmd.Parameters["@MErr"].Value;
            return MyErr;
        }

        private void frmRegisterMoveArticle_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                MyGlobal.mFrmRegisterMoveArticle = null;
            }
            catch { }; 
        }
        private void LoadUsers()
        {
            string mq = "";
            DataTable dTable = null;
            long x = 0;
            dTable = new DataTable("tblUser");
            dTable.Clear();
            dTable.Columns.Add("UserID", typeof(String));
            dTable.Columns.Add("RealName", typeof(String));
            dTable.Columns.Add("RealSurname", typeof(String));

            this.Cursor = Cursors.WaitCursor;
            this.CmbUser .Text = "";
            this.CmbUser.DataSource = null;
            this.CmbUser.Items.Clear();

            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;

            mq = "SELECT [UserID],[RealName],[RealSurname] FROM [GoWH].[dbo].[go_users_def];";

            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                dTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'") });
                x++;
            }
            dataread.Close();
            mcmd = null;

            this.CmbUser.DataSource = dTable;
            this.CmbUser.DisplayMember = "UserID";
            this.CmbUser.ValueMember = "RealName";

            {
                if (x > 0)
                {
                    this.CmbSTArea.Text = "";
                }
                else
                {
                    this.CmbSTArea.Text = "Nu sunt date.";
                }
            }

            this.Cursor = Cursors.Default;

            
        }
    }
}
