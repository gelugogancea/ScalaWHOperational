using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoWHMgmAdmin
{
    public partial class frmInvenoryAddCount : Form
    {
        public long ID_INVENTORY=0;

        public string CK_PASSWD = "";
        private long ID_3DLOC = 0;
        private long ID_REC = 0;
        private bool IS_SAVE = false;
        public frmInvenoryAddCount()
        {
            InitializeComponent();
        }
        private void LoadWH()
        {
            string mq = "";
            DataTable dataTable = new DataTable("Gestiuni");
            dataTable.Clear();
            dataTable.Columns.Add("3DLOC", typeof(String));
            dataTable.Columns.Add("AreaCode", typeof(String));
            dataTable.Columns.Add("Depo", typeof(String));
            dataTable.Columns.Add("ID", typeof(String));

            this.Cursor = Cursors.WaitCursor;

            this.Cmd3DLoc.Text = "";
            this.Cmd3DLoc.DataSource = null;
            this.Cmd3DLoc.Items.Clear();
            this.Cmd3DLoc.BeginUpdate();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mq = "SELECT go_locator_def.LocatorSymbol, go_area_def.AreaCode,go_main_wh_def.ScWH,go_locator_def.ID " +
                 "FROM go_area_def INNER JOIN "+
                 "go_main_wh_def ON go_area_def.WHCode = go_main_wh_def.ScWH INNER JOIN "+
                 "go_locator_def ON go_area_def.ID = go_locator_def.ID_STORAGE_AREA;";
            
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                dataTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'") });
            }
            this.Cmd3DLoc.EndUpdate();
            dataread.Close();
            mcmd = null;
            Cmd3DLoc.DataSource = dataTable;
            Cmd3DLoc.DisplayMember = "3DLOC";
            Cmd3DLoc.ValueMember = "AreaCode";
            
            this.Cursor = Cursors.Default;
            Cmd3DLoc.DataBindings.Clear();
        }

        private void frmInvenoryAddCount_Load(object sender, EventArgs e)
        {
            mRegistry mreg = new mRegistry();
            string IfIsCloseCount = "";
            try
            {
                IfIsCloseCount = mreg.QueryValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoWHAdmin", "INVENT_CL_COUNT_" + ID_INVENTORY.ToString(), "");
                if (IfIsCloseCount == "1")
                {
                    grpAddCount.Text += " - Procedura Inchisa";
                    grpAddCount.Enabled = false;
                    if (CkInventoryValidationStatus() == -1)
                    {
                        grpFinalizeCounting.Text += " - Procedura Inchisa";
                        grpFinalizeCounting.Enabled = false;
                    }
                    else
                    {
                        grpFinalizeCounting.Enabled = true;
                        SetListColumns(2);
                        LoadData(2, "");
                    }
                }
                else
                {
                        LoadWH();
                        LoadOperator();
                        LoadArticle();
                        SetListColumns(1);
                        LoadData(1, "");
                        grpAddCount.Enabled = true;
                        grpFinalizeCounting.Enabled = false;
                    
                }
            }
            finally
            {
                mreg = null;
            }

            CK_PASSWD = "";
            CkCloseCounting.Checked = false;
            CMbArticole.Text = "";
            Cmd3DLoc.Text = "";
            txtQty.Text = "";
            //txtCountNo.Text = "";
            CmbCountOper.Text = "";
            LblArea.Text = "";
            LblWH.Text = "";

          
        }

        private void Cmd3DLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ms = "";
            try
            {
                IS_SAVE = false;
                ms = ((DataRowView)Cmd3DLoc.SelectedItem).Row.ItemArray[0].ToString();
                this.LblArea.Text = ((DataRowView)Cmd3DLoc.SelectedItem).Row.ItemArray[1].ToString();
                this.LblWH.Text = ((DataRowView)Cmd3DLoc.SelectedItem).Row.ItemArray[2].ToString();
                try
                {
                    ID_3DLOC = long.Parse(((DataRowView)Cmd3DLoc.SelectedItem).Row.ItemArray[3].ToString());
                }
                catch {
                    MessageBox.Show("ID_3DLOC invalid");
                    ID_3DLOC = -1;
                }
                
            }
            catch { }
        }
        private void LoadArticle()
        {
            string mq = "";
            DataTable dataTable = new DataTable("ArticleCode");
            dataTable.Clear();
            dataTable.Columns.Add("Cod", typeof(String));
            dataTable.Columns.Add("Descriere", typeof(String));
            //dataTable.Columns.Add("Extinsa", typeof(String));
            
            this.Cursor = Cursors.WaitCursor;

            this.CMbArticole.Text = "";
            this.CMbArticole.DataSource = null;
            this.CMbArticole.Items.Clear();
            this.CMbArticole.BeginUpdate();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mq = "select go_invent_import.KeyArticleStockCode,go_article_masterdata.Description1 + go_article_masterdata.Description2 " +
                 "from go_invent_import " +
                 "LEFT JOIN go_article_masterdata ON go_article_masterdata.StockCode=go_invent_import.KeyArticleStockCode " +
                 "WHERE go_invent_import.InventoryID=" + ID_INVENTORY.ToString() + " " +
                 "group by go_invent_import.KeyArticleStockCode,go_article_masterdata.Description1,go_article_masterdata.Description2 order by go_invent_import.KeyArticleStockCode;";

            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                //dataTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'")});
                dataTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'") });
            }
            this.CMbArticole.EndUpdate();
            dataread.Close();
            mcmd = null;
            CMbArticole.DataSource = dataTable;
            CMbArticole.DisplayMember = "Cod";
            CMbArticole.ValueMember = "Descriere";

            this.Cursor = Cursors.Default;
            CMbArticole.DataBindings.Clear();
        }

        private void frmInvenoryAddCount_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                MyGlobal.mFrmInventoryAddCount = null;
            }
            catch
            {
            }
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
            
            /*
            mq = "SELECT go_invent_team.Oper1," +
                 "go_invent_team.Oper2, go_invent_team.Oper3, go_invent_team.Oper4, go_invent_team.Oper5, go_invent_team.Oper6,go_users_def.UserID,go_invent_team.ID, go_invent_team.IDMainInventory " +
                 "FROM go_users_def INNER JOIN " +
                 "go_invent_team ON go_users_def.ID = go_invent_team.IDSupervisor INNER JOIN " +
                 "go_invent_main ON go_invent_team.IDMainInventory = go_invent_main.ID INNER JOIN " +
                 "go_sys_lock ON go_invent_main.IDSysLock = go_sys_lock.ID and getdate() between " +
                 "go_invent_main.PeriodFrom and go_invent_main.PeriodTo;";
            */
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
                if(MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'")!="")
                {
                    dataTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'"),MyGlobal.Srch2Escape(dataread[8].ToString().Trim(), "'") });
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

        private void CmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmdSaveQty_Click(object sender, EventArgs e)
        {
            double mQty = 0;
            string pencrypt = "";

            if (CMbArticole.Text.Trim() == "")
            {
                MessageBox.Show("Nu este selectat nici un Articol.");
                return; 
            }
            if (ID_3DLOC <= 0)
            {
                MessageBox.Show("Nu este selectata nicio Adresa La Raft");
                return;
            }
            try
            {
                mQty = double.Parse(txtQty.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Cantitatea este reprezentata numeric.");
                return;
            }
            
            if(CmbCountOper.Text.Trim()=="")
            {
                MessageBox.Show("Nu este selectat nici un operator numarator.");
                return;
            }
            if (txtListNo.Text.Trim()=="")
            {
                MessageBox.Show("Trebuie completat un Numar de Lista.");
                return;
            }
            if (CkCloseCounting.Checked == true)
            {
                if (CK_PASSWD.Trim() != "")
                {
                    pencrypt=CryptorEngine.Encrypt(CK_PASSWD.Trim(), true);
                    CkCloseCounting.Checked = false;
                }
                
            }
            
            SaveQtyReport(CMbArticole.Text.Trim(), mQty, ID_3DLOC, CmbCountOper.Text.Trim(),txtListNo.Text.Trim(),pencrypt);

            LoadData(1, CMbArticole.Text.Trim());
            CK_PASSWD = "";
            CkCloseCounting.Checked = false;
            CMbArticole.Text = "";
            Cmd3DLoc.Text = "";
            txtQty.Text = "";
            //txtCountNo.Text = "";
            //CmbCountOper.Text = "";
            LblArea.Text = "";
            LblWH.Text = "";
            IS_SAVE = true;
            //txtListNo.Text = "";
        }
        private long SaveQtyReport(string ArticleCode,double mQty,long IDLOC,string OperCode,string mListNo,string mpass)
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

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ARTICLECODE", SqlDbType.NVarChar,ArticleCode.Length));
            mcmd.Parameters["@ARTICLECODE"].Value = ArticleCode;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COUNTQTY", SqlDbType.Decimal));
            mcmd.Parameters["@COUNTQTY"].Value = mQty;

            //mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COUNTNO", SqlDbType.Int));
            //mcmd.Parameters["@COUNTNO"].Value = CountNo;

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
                MessageBox.Show("Nu regasesc in WMS Cod Articol : "+ArticleCode);
            }
            else if (MyErr == -2)
            {
                MessageBox.Show("Cantitatea " + mQty.ToString() +" pentru Articolul "+ArticleCode+"\r\na fost deja numarata");
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
                MessageBox.Show("Parola pentru inchiderea procedurii de numarare este gresita\r\nsau nu apartine inventarului cu numarul : "+ID_INVENTORY.ToString());
            }
            else if (MyErr == -6)
            {
                MessageBox.Show("SQL CRITICAL ERR\r\nInvalid ID pentru go_invent work");
            }
            else if (MyErr == -7)
            {
                MessageBox.Show("SQL CRITICAL ERR\r\nInvalid ID pentru go_invent work_d");
            }
            else if(MyErr==0)
            {
                MessageBox.Show("Datele au fost salvate cu succes");
            }
            else if (MyErr == 1)
            {
                mRegistry mreg = new mRegistry();
                if (mreg.CreateValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoWHAdmin", "INVENT_CL_COUNT_"+ID_INVENTORY.ToString(), "1") == false)
                {
                    MessageBox.Show("Nu pot salva CloseCounting in registry.", "GoWHManagamenetAdmin");

                }
                mreg = null; 
                MessageBox.Show("Datele au fost salvate cu succes\r\nProcedura de numarare a fost inchisa cu succes");
                grpAddCount.Text += " - Procedura Inchisa";
                grpAddCount.Enabled = false;
                grpFinalizeCounting.Enabled = true;
            }
            dataread.Close();
            mcmd = null;
            return MyErr;
        }

        private void CkCloseCounting_Click(object sender, EventArgs e)
        {
            if (CkCloseCounting.Checked == true)
            {
                frmCkPasswd mfrm = new frmCkPasswd();
                mfrm.Show();
                mfrm.BringToFront();
            }
        }

        private void CMbArticole_GotFocus(object sender, EventArgs e)
        {

            CMbArticole.DroppedDown = true;
        }
        
        private void CMbArticole_Leave(object sender, EventArgs e)
        {
            CMbArticole.DroppedDown=false;
        }

        private void Cmd3DLoc_GotFocus(object sender, EventArgs e)
        {
            Cmd3DLoc.DroppedDown = true;
        }
        private void Cmd3DLoc_Leave(object sender, EventArgs e)
        {
            Cmd3DLoc.DroppedDown = false;
        }

        private void CmbCountOper_GotFocus(object sender, EventArgs e)
        {
            CmbCountOper.DroppedDown = true;
        }

        private void CmbCountOper_Leave(object sender, EventArgs e)
        {
            CmbCountOper.DroppedDown = false;
        }
        private void SetListColumns(int i)
        {
            ColumnHeader colHead;
            this.MyListView.Clear();
            this.MyListView.Columns.Clear();

            if (i == 1)
            {
                colHead = new ColumnHeader();
                colHead.Text = "NrInventar";
                colHead.Width = 40;
                this.MyListView.Columns.Add(colHead);

                colHead = new ColumnHeader();
                colHead.Text = "CodArticol";
                colHead.Width = 180;
                this.MyListView.Columns.Add(colHead);

                colHead = new ColumnHeader();
                colHead.Text = "Cantitate";
                colHead.Width = 80;
                this.MyListView.Columns.Add(colHead);

                colHead = new ColumnHeader();
                colHead.Text = "Numarat";
                colHead.Width = 60;
                this.MyListView.Columns.Add(colHead);

                colHead = new ColumnHeader();
                colHead.Text = "Operator";
                colHead.Width = 80;
                this.MyListView.Columns.Add(colHead);

                colHead = new ColumnHeader();
                colHead.Text = "Locator";
                colHead.Width = 50;
                this.MyListView.Columns.Add(colHead);

                colHead = new ColumnHeader();
                colHead.Text = "Zona";
                colHead.Width = 50;
                this.MyListView.Columns.Add(colHead);

                colHead = new ColumnHeader();
                colHead.Text = "Depozit";
                colHead.Width = 50;
                this.MyListView.Columns.Add(colHead);

                colHead = new ColumnHeader();
                colHead.Text = "Data/Ora";
                colHead.Width = 120;
                this.MyListView.Columns.Add(colHead);
            }
            else
            {
                colHead = new ColumnHeader();
                colHead.Text = "ID_REC";
                colHead.Width = 40;
                this.MyListView.Columns.Add(colHead);
            
                colHead = new ColumnHeader();
                colHead.Text = "CodArticol";
                colHead.Width = 180;
                this.MyListView.Columns.Add(colHead);
                
                colHead = new ColumnHeader();
                colHead.Text = "Cantitate";
                colHead.Width = 80;
                this.MyListView.Columns.Add(colHead);
            
                colHead = new ColumnHeader();
                colHead.Text = "Numarat";
                colHead.Width = 60;
                this.MyListView.Columns.Add(colHead);
            
                colHead = new ColumnHeader();
                colHead.Text = "Operator";
                colHead.Width = 80;
                this.MyListView.Columns.Add(colHead);
            
                colHead = new ColumnHeader();
                colHead.Text = "Locator";
                colHead.Width = 50;
                this.MyListView.Columns.Add(colHead);
            
                colHead = new ColumnHeader();
                colHead.Text = "Zona";
                colHead.Width = 50;
                this.MyListView.Columns.Add(colHead);
            
                colHead = new ColumnHeader();
                colHead.Text = "Depozit";
                colHead.Width = 50;
                this.MyListView.Columns.Add(colHead);
            
                colHead = new ColumnHeader();
                colHead.Text = "Status";
                colHead.Width = 100;
                this.MyListView.Columns.Add(colHead);
            
            }

            this.MyListView.GridLines = true;
            this.MyListView.FullRowSelect = true;
            this.MyListView.View = View.Details;
        }

        private void MyListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            try
            {
                ID_REC = long.Parse(MyListView.SelectedItems[0].Text.Trim());
            }
            catch
            {
                MessageBox.Show("CRITIC_ERR ! Invalid ID_REC");
                return;
            }
            if(MyListView.SelectedItems[0].SubItems[8].Text.Trim()!="NEVALIDAT")
            {
                MessageBox.Show("Canitatea este deja Validata");
                ID_REC = 0;
                return;
            }
            this.txtArticleCode.Text = MyListView.SelectedItems[0].SubItems[1].Text.Trim();
            this.LblQty.Text = MyListView.SelectedItems[0].SubItems[2].Text.Trim();
            this.LblCountNo.Text = MyListView.SelectedItems[0].SubItems[3].Text.Trim();
            this.LblInfo.Text = MyListView.SelectedItems[0].SubItems[4].Text.Trim() + " / " + MyListView.SelectedItems[0].SubItems[5].Text.Trim() + " / " + MyListView.SelectedItems[0].SubItems[6].Text.Trim() + " / " + MyListView.SelectedItems[0].SubItems[8].Text.Trim();
            this.LblWHCODE.Text =MyListView.SelectedItems[0].SubItems[7].Text.Trim();
            //this.txtAreaCode.Text = MyListView.SelectedItems[0].SubItems[2].Text.Trim();

        }
        private void LoadData(int mOption, string mCriteria)
        {
            string mq = "";
            long x = 0;
            ListViewItem k = null;
            double mQty = 0;

            this.Cursor = Cursors.WaitCursor;
            this.MyListView.Items.Clear();

            this.MyListView.Refresh();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            System.Data.SqlClient.SqlDataReader dataread = null;
            if (mOption == 1)
            {
                if (mCriteria.Trim() == "")
                {
                    mq = "SELECT go_invent_main.ID, go_invent_work.KeyArticleStock, go_invent_work_d.CountQty, go_invent_work_d.CountNo," +
                    "go_invent_work_d.OperatorCode," +
                    "go_locator_def.LocatorSymbol, go_area_def.AreaCode,go_area_def.WHCode,go_invent_work_d.InDate " +
                    "FROM go_invent_main INNER JOIN " +
                    "go_invent_work ON go_invent_main.ID=" + ID_INVENTORY.ToString() + " AND go_invent_main.ID = go_invent_work.ID_INVENTORY INNER JOIN " +
                    "go_invent_work_d ON go_invent_work.ID = go_invent_work_d.ID_WORK INNER JOIN " +
                    "go_locator_def ON go_invent_work_d.ID_3DLOC = go_locator_def.ID INNER JOIN " +
                    "go_area_def ON go_locator_def.ID_STORAGE_AREA = go_area_def.ID";
                }
                else
                {
                    mq = "SELECT go_invent_main.ID, go_invent_work.KeyArticleStock, go_invent_work_d.CountQty, go_invent_work_d.CountNo," +
                    "go_invent_work_d.OperatorCode," +
                    "go_locator_def.LocatorSymbol, go_area_def.AreaCode,go_area_def.WHCode,go_invent_work_d.InDate " +
                    "FROM go_invent_main INNER JOIN " +
                    "go_invent_work ON go_invent_main.ID=" + ID_INVENTORY.ToString() + " AND go_invent_main.ID = go_invent_work.ID_INVENTORY INNER JOIN " +
                    "go_invent_work_d ON go_invent_work.KeyArticleStock='"+mCriteria.Trim()+"' AND go_invent_work.ID = go_invent_work_d.ID_WORK INNER JOIN " +
                    "go_locator_def ON go_invent_work_d.ID_3DLOC = go_locator_def.ID INNER JOIN " +
                    "go_area_def ON go_locator_def.ID_STORAGE_AREA = go_area_def.ID";
                }
            }
            else if(mOption==2)
            {
                if (mCriteria == "")
                {
                    mq = "SELECT go_invent_work_d.ID,go_invent_work.KeyArticleStock, go_invent_work_d.CountQty, go_invent_work_d.CountNo, go_invent_work_d.OperatorCode," +
                    "go_locator_def.LocatorSymbol, go_area_def.AreaCode, go_area_def.WHCode," +
                    "CASE go_invent_work_d.ThisQTYOK WHEN 1 THEN 'Validat' ELSE 'NEVALIDAT' END " +
                    "FROM go_invent_work INNER JOIN " +
                    "go_invent_work_d ON go_invent_work.ID_INVENTORY=" + ID_INVENTORY.ToString() + "" +
                    "AND go_invent_work.ID = go_invent_work_d.ID_WORK INNER JOIN " +
                    "go_locator_def ON go_invent_work_d.ID_3DLOC = go_locator_def.ID INNER JOIN " +
                    "go_area_def ON go_locator_def.ID_STORAGE_AREA = go_area_def.ID ;";
                }
                else
                {
                    mq = "SELECT go_invent_work_d.ID,go_invent_work.KeyArticleStock, go_invent_work_d.CountQty, go_invent_work_d.CountNo, go_invent_work_d.OperatorCode," +
                    "go_locator_def.LocatorSymbol, go_area_def.AreaCode, go_area_def.WHCode," +
                    "CASE go_invent_work_d.ThisQTYOK WHEN 1 THEN 'Validat' ELSE 'NEVALIDAT' END " +
                    "FROM go_invent_work INNER JOIN " +
                    "go_invent_work_d ON go_invent_work.KeyArticleStock='" + mCriteria.Trim() + "' AND go_invent_work.ID_INVENTORY=" + ID_INVENTORY.ToString() + "" +
                    "AND go_invent_work.ID = go_invent_work_d.ID_WORK INNER JOIN " +
                    "go_locator_def ON go_invent_work_d.ID_3DLOC = go_locator_def.ID INNER JOIN " +
                    "go_area_def ON go_locator_def.ID_STORAGE_AREA = go_area_def.ID ;";
                }
            }
            else if (mOption == 3)
            {
                if (mCriteria == "")
                {
                    mq = "SELECT go_invent_work_d.ID,go_invent_work.KeyArticleStock, go_invent_work_d.CountQty, go_invent_work_d.CountNo, go_invent_work_d.OperatorCode," +
                    "go_locator_def.LocatorSymbol, go_area_def.AreaCode, go_area_def.WHCode," +
                    "CASE go_invent_work_d.ThisQTYOK WHEN 1 THEN 'Validat' ELSE 'NEVALIDAT' END " +
                    "FROM go_invent_work INNER JOIN " +
                    "go_invent_work_d ON go_invent_work.ID_INVENTORY=" + ID_INVENTORY.ToString() + "" +
                    "AND go_invent_work.ID = go_invent_work_d.ID_WORK AND go_invent_work_d.ThisQTYOK=0 INNER JOIN " +
                    "go_locator_def ON go_invent_work_d.ID_3DLOC = go_locator_def.ID INNER JOIN " +
                    "go_area_def ON go_locator_def.ID_STORAGE_AREA = go_area_def.ID ;";
                }
                else
                {
                    mq = "SELECT go_invent_work_d.ID,go_invent_work.KeyArticleStock, go_invent_work_d.CountQty, go_invent_work_d.CountNo, go_invent_work_d.OperatorCode," +
                    "go_locator_def.LocatorSymbol, go_area_def.AreaCode, go_area_def.WHCode," +
                    "CASE go_invent_work_d.ThisQTYOK WHEN 1 THEN 'Validat' ELSE 'NEVALIDAT' END " +
                    "FROM go_invent_work INNER JOIN " +
                    "go_invent_work_d ON go_invent_work.KeyArticleStock='" + mCriteria.Trim() + "' AND go_invent_work.ID_INVENTORY=" + ID_INVENTORY.ToString() + "" +
                    "AND go_invent_work.ID = go_invent_work_d.ID_WORK AND go_invent_work_d.ThisQTYOK=0 INNER JOIN " +
                    "go_locator_def ON go_invent_work_d.ID_3DLOC = go_locator_def.ID INNER JOIN " +
                    "go_area_def ON go_locator_def.ID_STORAGE_AREA = go_area_def.ID ;";
                }    
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
                //k.SubItems.Add(MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"));
                try
                {
                    mQty = double.Parse(MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"));  
                }
                catch
                {
                    mQty = 0;
                }
                k.SubItems.Add(mQty.ToString());
                //k.SubItems.Add(String.Format("{0:0.##}", MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'")));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[5].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[8].ToString().Trim(), "'"));
              
                MyListView.Items.Add(k);
                x++;
            }
            MyListView.EndUpdate();
            //this.MyListView.Refresh();
            
            try
            {
                dataread.Close();
            }
            catch { };
            mcmd = null;
            this.Cursor = Cursors.Default;
        }

        private void CmdCaut_Click(object sender, EventArgs e)
        {
            if (CMbArticole.Text.Trim() == "")
            {
                MessageBox.Show("Nu exista criteriu de cautare");
                return;
            }
            LoadData(1, CMbArticole.Text.Trim());
        }

        private void CmdCautareValidare_Click(object sender, EventArgs e)
        {
            LoadData(2, txtArticleCode.Text.Trim());
        }
        private int SaveData(string mq)
        {

            int ret = 0;
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mcmd.CommandType = System.Data.CommandType.Text;

            mcmd.CommandText = mq;
            try
            {
                mcmd.ExecuteNonQuery();
            }
            catch (Exception emsg)
            {
                MessageBox.Show("ERROR : " + emsg.Message.Trim(), "GoWHManagementAdmin");
                ret = -1;
                goto MYEND;
            }
        MYEND:
            mcmd = null;

            return ret;
        }

        private void CmdValidare_Click(object sender, EventArgs e)
        {
            string mq = "";
            string mq1 = "";
            string mq2 = "";
            string pencrypt = "";
            int countno = 0;
            int ckret=0;
            double mQty=0;
            if(CkAutoValidate.Checked==true)
            {
                SaveAutoValidate(ID_INVENTORY);
                LoadData(3, "");
                return;
            }
           if (ID_REC == 0)
            {
                MessageBox.Show("Nu pot salva date\r\nID_REC este invalid");
                return;
            }
            try
            {
                mQty = double.Parse(LblQty.Text.Trim());
            }
            catch
            {
                mQty = -1;
                MessageBox.Show("Cantitatea este reprezentata numeric.");
            }
            
            if(txtArticleCode.Text.Trim()=="")
            {
                MessageBox.Show("Nu este selectat nici un Articol.");
                return;
            }
            try
            {
                countno = int.Parse(LblCountNo.Text.Trim());
            }
            catch {
                MessageBox.Show("Numarul de Ordine al Numaratorii este reprezentat numeric");
                return;
            }
            if (CkCloseValidation.Checked == true)
            {
                if (CK_PASSWD.Trim() != "")
                {
                    pencrypt = CryptorEngine.Encrypt(CK_PASSWD.Trim(), true);
                    ckret = CkPassword(pencrypt);
                    if (ckret == -1)
                    {
                        MessageBox.Show("Parola incorecta");
                        return;
                    }
                    else if(ckret==-2)
                    {
                        MessageBox.Show("Parola nu se potriveste acestui inventar");
                        return;
                    }
                    
                }
            }
            mq = "UPDATE go_invent_work_d SET ThisQTYOK=1 WHERE ID="+ID_REC.ToString()+";";
            mq1 = "update go_invent_main SET CloseValidation=1 where ID=" + ID_INVENTORY.ToString() + ";";
            mq2 = "update go_invent_work SET InventReportQty=InventReportQty+" + mQty.ToString() + " where ID_INVENTORY="+ ID_INVENTORY.ToString() +" AND KeyArticleStock='" + txtArticleCode.Text.Trim() + "' AND WHCODE='"+LblWHCODE.Text.Trim()+"';";
            if (SaveData(mq) == 0)
            {
                if (SaveData(mq2) != 0)
                {
                    MessageBox.Show("Nu pot salva date in Inventory Work\r\n(Validarea cantitatii)");
                    return; 
                }
                
                if (CkCloseValidation.Checked == true)
                {
                    if (SaveData(mq1) != 0)
                    {
                        MessageBox.Show("Nu pot salva date in Inventory Main");
                        return;
                    }
                }
                MessageBox.Show("Datele au fost salvate cu succes.");
                LoadData(2, txtArticleCode.Text.Trim());
            }
            else
            {
                MessageBox.Show("Nu pot salva date.");
            }
            ID_REC = 0;
            txtArticleCode.Text = "";
            LblQty.Text = "";
            LblCountNo.Text = "";
            LblInfo.Text = "";
        }
        private int CkPassword(string mCriteria)
        {
            string mq = "";
            long x = 0;
            int ret = 0;
            long ckid=0;
            
            this.Cursor = Cursors.WaitCursor;

            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            System.Data.SqlClient.SqlDataReader dataread = null;
            mq = "select ID from go_invent_main where RPassword='"+mCriteria.Trim()+"'";
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
                try{
                    ckid=long.Parse(MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"));
                }
                catch{ckid=-1;}
                x++;
            }
            try
            {
                dataread.Close();
            }
            catch { };
            if (x == 0)
            {
                ret = -1;   /*Nu gasesc nimic*/               
            }
            else if (x > 0 && ckid != ID_INVENTORY)
            {
                ret = -2;   /*Parola nu este a inventarului curent*/
            }
            mcmd = null;
            this.Cursor = Cursors.Default;
            return ret;
        }

        private void CkCloseValidation_Click(object sender, EventArgs e)
        {
            if (CkCloseValidation.Checked == true)
            {
                CkAutoValidate.Checked = false;
                frmCkPasswd mfrm = new frmCkPasswd();
                mfrm.Show();
                mfrm.BringToFront();
            }
        }
        private int CkInventoryValidationStatus()
        {
            string mq = "";
            long x = 0;
            int ret = 0;
            long ckid = 0;

            this.Cursor = Cursors.WaitCursor;

            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            System.Data.SqlClient.SqlDataReader dataread = null;
            mq = "select CloseValidation from go_invent_main where ID='"+ID_INVENTORY.ToString()+"'";
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
                try
                {
                    ckid = long.Parse(MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"));
                }
                catch { ckid = -1; }
                x++;
            }
            try
            {
                dataread.Close();
            }
            catch { };
            if (x > 0 && ckid == 1)
            {
                ret = -1;   /*Validarea este inchisa pentru inventarul curent*/
            }
            mcmd = null;
            this.Cursor = Cursors.Default;
            return ret;
        }
        private long SaveAutoValidate(long IDInventory)
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

            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand("ValidateInventQty");
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IDINVENTORY", SqlDbType.BigInt));
            mcmd.Parameters["@IDINVENTORY"].Value = ID_INVENTORY;

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
            else if (MyErr == -2)
            {
                MessageBox.Show("Validare Automata a fost deja procesata\r\nEste permisa doar Validare manuala", "");
            }
            else if (MyErr == -3)
            {
                MessageBox.Show("Procedura de validare este inchisa", "");
            }
            else if (MyErr == -1)
            {
                MessageBox.Show("SQL ERROR\r\nNu se pot salva date", "");
            }
            else if (MyErr == 0)
            {
                MessageBox.Show("Datele au fost validate cu succes", "");
            }
            dataread.Close();
            mcmd = null;
            return MyErr;
        }

        private void CMbArticole_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ms = "";
            try
            {
                IS_SAVE = false;
                ms = ((DataRowView)CMbArticole.SelectedItem).Row.ItemArray[1].ToString();
                //this.LblDescOption.ForeColor = System.Drawing.Color.DarkBlue;
                
                this.LblArtDescription.Text = ms.Trim();
            }
            catch { }
        }

        private void CmdSaveQty_Leave(object sender, EventArgs e)
        {

            if (CkNeuron.Checked == true)
            {
                if (IS_SAVE == false)
                {
                    if (MessageBox.Show("Ai uitat sa salvezi ?", "You have knowledge about PC ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        CmdSaveQty.Focus();
                    }
                    else
                    {
                        IS_SAVE = false;
                    }
                }
            }
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            IS_SAVE = false;
        }

        private void CmbCountOper_TextChanged(object sender, EventArgs e)
        {
            IS_SAVE = false;
        }

        private void MyListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }

}