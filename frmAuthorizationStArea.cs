using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoWHMgmAdmin
{
    public partial class frmAuthorizationStArea : Form
    {
        private bool LOAD_WH=false;
        private bool LOAD_FROM_INIT = false;
        private long ID_REC=0;
        
        
        public frmAuthorizationStArea()
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

        private void frmAuthorizationStArea_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                MyGlobal.mFrmAuthorizationStArea = null;
            }
            finally
            {
                GC.Collect();
            }
        }
        private void LoadMyUser(string mCriteria)
        {
            string mq = "";
            DataTable dataTable = new DataTable("MyUser");
            dataTable.Columns.Add("ID", typeof(String));
            dataTable.Columns.Add("UserName", typeof(String));
            dataTable.Columns.Add("RealName", typeof(String));
            dataTable.Columns.Add("OrgRole", typeof(String));
            dataTable.Columns.Add("Valid", typeof(String));

            this.Cursor = Cursors.WaitCursor;
            this.CmbUser.Text = "";
            this.CmbUser.DataSource = null;
            this.CmbUser.Items.Clear();
            
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            if (mCriteria.Trim() == "")
            {
                mq = "select go_users_Def.ID,go_users_Def.UserID,go_users_Def.RealName +' '+ go_users_Def.RealSurname,"+ 
                    "go_users_Def.RoleInOrg,go_users_def.ValidFrom , go_users_def.ValidTo "+
                    "from "+
                    "go_users_Def "+
                    "where  getdate() between go_users_def.ValidFrom and go_users_def.ValidTo "+
                    "order by go_users_Def.UserID;";
            }
            else
            {
                mq = "select go_users_Def.ID,go_users_Def.UserID,go_users_Def.RealName +' '+ go_users_Def.RealSurname," +
                    "go_users_Def.RoleInOrg,go_users_def.ValidFrom , go_users_def.ValidTo " +
                    "from " +
                    "go_users_Def " +
                    "where go_users_Def.UserID like '"+mCriteria.Trim()+"%' getdate() between go_users_def.ValidFrom and go_users_def.ValidTo " +
                    "order by go_users_Def.UserID;";
            }


            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                dataTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"), 
                    MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"),
                    MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"),
                    MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'"),
                    MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'") +"\r\n"+MyGlobal.Srch2Escape(dataread[5].ToString().Trim(), "'")});
            }
            dataread.Close();

            CmbUser.DataSource = dataTable;
            CmbUser.DisplayMember = "ID";
            CmbUser.ValueMember = "UserName";
            
            mcmd = null;
            this.Cursor = Cursors.Default;
        }
        private void LoadWH(string mCriteria)
        {
            string mq = "";
            DataTable dataTable = new DataTable("Gestiuni");
            dataTable.Columns.Add("COD", typeof(String));
            dataTable.Columns.Add("Denumire", typeof(String));

            this.Cursor = Cursors.WaitCursor;
            LOAD_WH = false;
            this.CmbWH.Text = "";
            this.CmbWH.DataSource = null;
            this.CmbWH.Items.Clear();
            LOAD_WH = true;
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            if (mCriteria.Trim() == "")
            {
                mq = "SELECT ScWH,ScName FROM dbo.go_main_wh_def order by ScWH;";
            }
            else
            {
                mq = "SELECT ScWH,ScName FROM dbo.go_main_wh_def where ScWH='" + mCriteria.Trim() + "' order by ScWH;";
            }


            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                dataTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'") });
            }
            dataread.Close();

            CmbWH.DataSource = dataTable;
            CmbWH.DisplayMember = "COD";
            CmbWH.ValueMember = "Denumire";
            if (LOAD_FROM_INIT == false)
            {
                CmbWH.Text = "";
            }
            mcmd = null;
            this.Cursor = Cursors.Default;
        }
        private void LoadStorageAreDef(string mWH, string mCriteria)
        {
            string mq = "";
            DataTable dTable = null;
            long x = 0;
            dTable = new DataTable("ZoneStocare");
            dTable.Clear();
            dTable.Columns.Add("ID", typeof(String));
            dTable.Columns.Add("Cod", typeof(String));
            dTable.Columns.Add("Descriere", typeof(String));

            this.Cursor = Cursors.WaitCursor;
            this.CmbSTArea.Text = "";
            this.CmbSTArea.DataSource = null;
            this.CmbSTArea.Items.Clear();

            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            if (mCriteria.Trim() == "")
            {
                mq = "SELECT ID,AreaCode,AreaDescription FROM dbo.go_area_def where WHCode='" + mWH.Trim() + "';";
            }
            else
            {
                mq = "SELECT ID,AreaCode,AreaDescription FROM dbo.go_area_def where WHCode='" + mWH.Trim() + "' and AreaCode='" + mCriteria.Trim() + "';";
            }
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
            this.CmbSTArea.DisplayMember = "ID";
            this.CmbSTArea.ValueMember = "Cod";
			if (mCriteria.Trim() == "")
            {
                if (x > 0)
                {
                    this.CmbSTArea.Text = "Select...";
                }
                else
                {
                    this.CmbSTArea.Text = "Nu sunt date.";
                }
            }

            this.Cursor = Cursors.Default;
           
        }
        private void frmAuthorizationStArea_Load(object sender, EventArgs e)
        {
            rbCodStArea.Checked = true;
            ColumnHeader colHead;
            this.MyListView.Clear();
            this.MyListView.Columns.Clear();

            colHead = new ColumnHeader();
            colHead.Text = "ID";
            colHead.Width = 60;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "UserID";
            colHead.Width = 60;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "UserLog";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Nume";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Depozit";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Descr.Depo";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "ZonaStoc";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Descr.ZonaStoc";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);
                        
            colHead = new ColumnHeader();
            colHead.Text = "Operator";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Inserat";
            colHead.Width = 160;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Modificat";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            this.MyListView.GridLines = true;
            this.MyListView.FullRowSelect = true;
            this.MyListView.View = View.Details;

            LoadMyUser("");
            LoadWH("");
            LoadStAuth(0,"");
            LOAD_FROM_INIT = true;
            CmbUser.Focus();
        }

        private void CmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LblUser.Text = ((DataRowView)CmbUser.SelectedItem).Row.ItemArray[1].ToString();
                LblRealName.Text = ((DataRowView)CmbUser.SelectedItem).Row.ItemArray[2].ToString();
                LblOrgRole.Text = ((DataRowView)CmbUser.SelectedItem).Row.ItemArray[3].ToString();
                LblValid.Text = ((DataRowView)CmbUser.SelectedItem).Row.ItemArray[4].ToString();
            }
            catch { }
        }

        private void CmbWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ms = "";

            if (LOAD_WH == true && LOAD_FROM_INIT==true)
            {
                ms = ((DataRowView)CmbWH.SelectedItem).Row.ItemArray[0].ToString();   //Row.ItemArray[0];
                LoadStorageAreDef(ms.Trim(), "");
                LblWhDescription.Text = ((DataRowView)CmbWH.SelectedItem).Row.ItemArray[1].ToString();
               
            }
        }

        private void CmbSTArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LOAD_WH == true && LOAD_FROM_INIT == true)
            {
                try
                {
                    LblStAreaDescription.Text = ((DataRowView)CmbSTArea.SelectedItem).Row.ItemArray[2].ToString();
                }
                catch { }
                
            }
        }
        private long SaveAllArea(int ID_USER)
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
            System.Data.SqlClient.SqlCommand mcmd = null;
            mcmd = new System.Data.SqlClient.SqlCommand("SaveAuthAllWH");
            mcmd.Connection = MyGlobal.MY_SQL_CON;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IDUSER", SqlDbType.Int));
            mcmd.Parameters["@IDUSER"].Value = ID_USER;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MyUSER", SqlDbType.NVarChar, MyGlobal.MyUserInfo.MyUser.Length));
            mcmd.Parameters["@MyUSER"].Value = MyGlobal.MyUserInfo.MyUser.Trim() ;


            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@mErr", SqlDbType.Int));
            mcmd.Parameters["@mErr"].Direction = ParameterDirection.Output;

            mcmd.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                mcmd.ExecuteNonQuery();
            }
            catch { }


           
            try
            {
                MyErr = (int)mcmd.Parameters["@mErr"].Value;
            }
            catch { MyErr = -100; }
            
            if (MyErr < 0)
            {
                MessageBox.Show("SQL ERROR\r\nSQL Server nu este in Transaction Mode", "");
            }
            else if (MyErr > 0)
            {
                MessageBox.Show("SQL WARNING\r\nTranzactia nu s-a incheiat cu succes\r\nSunt " + MyErr.ToString() +" inregistrari neactualizate");
            }
            
            else if (MyErr == 0)
            {
                MessageBox.Show("Datele au fost salvate cu succes\r\n");
            }
            return MyErr;
        }
        private void CmdSalvez_Click(object sender, EventArgs e)
        {
            int iduser = 0;
            int idstarea = 0;
            string mq="";
            bool IsUpdate = false;
            try
            {
                iduser = int.Parse(CmbUser.Text.Trim());
            }
            catch { MessageBox.Show("ID USER invalid.\r\nProbabil nu ati selectat nici un Utilizator."); return; }
            if (CkAllArea.Checked == true)
            {
                if (SaveAllArea(iduser ) == -100)
                {
                    MessageBox.Show("SQL ERROR\r\nProcesul SQL nu poata trata erori","SQL ERROR",MessageBoxButtons.OK  ,MessageBoxIcon.Error  );  
                }
                ResetCtrl();
                LoadStAuth(0, "");
                return;
            }
            
            try
            {
                idstarea = int.Parse(CmbSTArea.Text.Trim());
            }
            catch { MessageBox.Show("ID AREA invalid.\r\nProbabil nu ati selectat nicio Zona de Stocare."); return; }
            string[] mfunc = new string[1];

            IsUpdate = MyGlobal.IsForUpdate("SELECT ID FROM go_area_auth where KeyIDUSER="+iduser.ToString().Trim()+" AND KeyIDSTAREA="+idstarea.ToString().Trim()+";", 1, ref mfunc);
            mfunc = null; 
            if (IsUpdate == false)
            {
                mq = "INSERT INTO go_area_auth (KeyIDUSER,KeyIDSTAREA,mUser,InDate,UpToDate) " +
                   "VALUES " +
                   "("+iduser.ToString().Trim()+"" +
                   ","+idstarea.ToString().Trim()+"" +
                   ",'"+MyGlobal.MyUserInfo.MyUser.Trim()+"'" +
                   ",getdate()" +
                   ",NULL);";        
            }
            else
            {
                if (ID_REC > 0)
                {
                    mq = "update go_area_auth SET KeyIDUSER=" + iduser.ToString().Trim() + "," +
                    "KeyIDSTAREA=" + idstarea.ToString().Trim() + "," +
                    "mUser='" + MyGlobal.MyUserInfo.MyUser.Trim() + "',UpToDate=getdate() where ID=" + ID_REC.ToString().Trim() + ";";
                }
                else
                {
                    MessageBox.Show("Datele alese sunt deja salvate.\r\nDaca doriti puteti modifica aceste date , alegand din lista.");
                    return;
                }
            }

            if (SaveData(mq) == 0)
            {

                MessageBox.Show("Datele au fost salvate cu succes.");
                ResetCtrl();
                LoadStAuth(0, "");
            }
            else
            {
                MessageBox.Show("Nu pot salva date.");
            }
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
        private void LoadStAuth(int iOption,string mCriteria)
        {
            ListViewItem k = null;
            string mq = "";
            long x = 0;
            this.Cursor = Cursors.WaitCursor;
            this.MyListView.Items.Clear();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            if (mCriteria.Trim() == "")
            {
                mq = "SELECT go_area_auth.ID,go_users_def.ID,go_users_def.UserID, go_users_def.RealName," + 
                    "go_main_wh_def.ScWH,go_main_wh_def.ScName,"+
                    "go_area_def.AreaCode,go_area_def.AreaDescription,"+ 
                    "go_area_auth.mUser, go_area_auth.InDate,go_area_auth.UpToDate "+
                    "FROM go_main_wh_def INNER JOIN "+
                    "go_area_def ON go_main_wh_def.ScWH = go_area_def.WHCode INNER JOIN "+
                    "go_area_auth INNER JOIN "+
                    "go_users_def ON go_area_auth.KeyIDUSER = go_users_def.ID ON go_area_def.ID = go_area_auth.KeyIDSTAREA order by go_users_def.UserID;";
            }
            else
            {
                if (iOption == 1)
                {
                    mq = "SELECT go_area_auth.ID,go_users_def.ID,go_users_def.UserID, go_users_def.RealName," + 
                    "go_main_wh_def.ScWH,go_main_wh_def.ScName,"+
                    "go_area_def.AreaCode,go_area_def.AreaDescription,"+ 
                    "go_area_auth.mUser, go_area_auth.InDate,go_area_auth.UpToDate "+
                    "FROM go_main_wh_def INNER JOIN "+
                    "go_area_def ON go_main_wh_def.ScWH = go_area_def.WHCode INNER JOIN "+
                    "go_area_auth INNER JOIN "+
                    "go_users_def ON go_area_auth.KeyIDUSER = go_users_def.ID ON go_area_def.ID = go_area_auth.KeyIDSTAREA AND go_area_def.AreaCode='"+mCriteria.Trim()+"';";
                }
                else if (iOption == 2)
                {
                    mq = "SELECT go_area_auth.ID,go_users_def.ID,go_users_def.UserID, go_users_def.RealName," +
                    "go_main_wh_def.ScWH,go_main_wh_def.ScName," +
                    "go_area_def.AreaCode,go_area_def.AreaDescription," +
                    "go_area_auth.mUser, go_area_auth.InDate,go_area_auth.UpToDate " +
                    "FROM go_main_wh_def INNER JOIN " +
                    "go_area_def ON go_main_wh_def.ScWH = go_area_def.WHCode INNER JOIN " +
                    "go_area_auth INNER JOIN " +
                    "go_users_def ON go_area_auth.KeyIDUSER = go_users_def.ID ON go_area_def.ID = go_area_auth.KeyIDSTAREA AND go_area_def.AreaDescription like '%" + mCriteria.Trim() + "%';";
                }
                
            }
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            this.MyListView.BeginUpdate();
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
                this.MyListView.Items.Add(k);
                
                x++;
            }
            this.MyListView.EndUpdate();
            this.MyListView.Refresh();
            dataread.Close();
            mcmd = null;
            this.Cursor = Cursors.Default;
            if (x == 0)
            {
                txtCauta.Text = "Nu sunt date...";
            }


        }

        private void CmdCauta_Click(object sender, EventArgs e)
        {
            if (txtCauta.Text.Trim() == "")
            {
                LoadStAuth(0, "");
            }
            else
            {
                if (rbCodStArea.Checked == true)
                {
                    LoadStAuth(1,txtCauta.Text.Trim());
                }
                else if(rbDescriere.Checked==true)
                {
                    LoadStAuth(2, txtCauta.Text.Trim());
                }
            }
        }
        private void ResetCtrl()
        {
            CkAllArea.Checked = false;  
            ID_REC=0;
            CmbUser.Text = "";
            CmbWH.Text = "";
            CmbSTArea.Text = "";
            LblOrgRole.Text = "";
            LblRealName.Text = "";
            LblStAreaDescription.Text = "";
            LblUser.Text = "";
            LblValid.Text = "";
            LblWhDescription.Text = "";

        }

        private void CmbUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                ResetCtrl();
            }
        }

        private void CmbWH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                ResetCtrl();
            }
        }

        private void CmbSTArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                ResetCtrl();
            }
        }

        private void MyListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                ResetCtrl();
            }
        }

        private void txtCauta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                ResetCtrl();
            }
        }

        private void MyListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                ID_REC = long.Parse(this.MyListView.SelectedItems[0].Text.Trim());
            }
            catch
            {
                MessageBox.Show("CRITIC_ERR ! ID Invalid ");
                return;
            }
            
            CmbUser.Text = MyListView.SelectedItems[0].SubItems[1].Text.Trim();
            CmbWH.Text = MyListView.SelectedItems[0].SubItems[4].Text.Trim();
            LoadStorageAreDef(CmbWH.Text.Trim(), MyListView.SelectedItems[0].SubItems[6].Text.Trim());
            CmbSTArea.Text = MyListView.SelectedItems[0].SubItems[6].Text.Trim();
        }

        

    }
}