using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoWHMgmAdmin
{
    public partial class SetUsers : Form
    {
        private long IDUSER = 0;
        private long IDFUNCTION = 0;
        private int ACC_LEVEL = 0;
        private string VALID_FROM = "";
        private string VALID_TO="";
        public SetUsers()
        {
            InitializeComponent();
        }

        private void SetUsers_Load(object sender, EventArgs e)
        {
            ColumnHeader colHead;
            this.MyListView.Clear();
            this.MyListView.Columns.Clear();

            colHead = new ColumnHeader();
            colHead.Text = "ID";
            colHead.Width = 60;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "UserName";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Password";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "RealName";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "RealSurname";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Org.Role";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "AccesLevel";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "ValidDeLa";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "ValidPanaLa";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            this.MyListView.GridLines = true;
            this.MyListView.FullRowSelect = true;
            this.MyListView.View = View.Details;
            
            this.MyListFuncRight.Clear();
            this.MyListFuncRight.Columns.Clear();
            colHead = new ColumnHeader();
            colHead.Text = "ID";
            colHead.Width = 60;
            this.MyListFuncRight.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Scope";
            colHead.Width = 60;
            this.MyListFuncRight.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "FuncSymbol";
            colHead.Width = 80;
            this.MyListFuncRight.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Description";
            colHead.Width = 200;
            this.MyListFuncRight.Columns.Add(colHead);

            this.MyListFuncRight.GridLines = true;
            this.MyListFuncRight.FullRowSelect = true;
            this.MyListFuncRight.View = View.Details;

            this.MyListAvailableFunc.Clear();
            this.MyListAvailableFunc.Columns.Clear();

            colHead = new ColumnHeader();
            colHead.Text = "ID";
            colHead.Width = 40;
            this.MyListAvailableFunc.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "FuncSymbol";
            colHead.Width = 80;
            this.MyListAvailableFunc.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "FuncGroup";
            colHead.Width = 80;
            this.MyListAvailableFunc.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Module";
            colHead.Width = 80;
            this.MyListAvailableFunc.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Description";
            colHead.Width = 200;
            this.MyListAvailableFunc.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Scop";
            colHead.Width = 80;
            this.MyListAvailableFunc.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "AccessLevel";
            colHead.Width = 80;
            this.MyListAvailableFunc.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "ValidDeLa";
            colHead.Width = 160;
            this.MyListAvailableFunc.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "ValidPanaLa";
            colHead.Width = 160;
            this.MyListAvailableFunc.Columns.Add(colHead);

            this.MyListAvailableFunc.GridLines = true;
            this.MyListAvailableFunc.FullRowSelect = true;
            this.MyListAvailableFunc.View = View.Details;
            LoadUsers();
            LoadAvailableFunctions();
        }

        private void CmdExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                //MyGlobal.mFrmSetUsers = null;
            }
            finally
            {
                GC.Collect();
            }
        }

        private void SetUsers_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                //this.Close();
                IDUSER = -1;
                IDFUNCTION = -1;
                ACC_LEVEL = -1;
                MyGlobal.mFrmSetUsers = null;
            }
            finally
            {
                GC.Collect();
            }
        }
        private void LoadUsers()
        {
            ListViewItem k = null;
            long x = 0;
            string mq = "";

            MyListView.Items.Clear();

            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
                        
            //mq = "select * from go_users_def order by ID";
            mq = "SELECT [ID],[UserID],[Passwd],[RealName],[RealSurname],[RoleInOrg],[AccessLevel],CONVERT(VARCHAR(10), [ValidFrom], 103) + ' ' + CONVERT(VARCHAR(8), [ValidFrom], 108) AS [DD/MM/YYYY],CONVERT(VARCHAR(10), [ValidTo], 103) + ' ' + CONVERT(VARCHAR(8), [ValidTo], 108) FROM [GoWH].[dbo].[go_users_def];";
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {

                k = new ListViewItem(dataread[0].ToString().Trim());
                k.SubItems.Add(dataread[1].ToString().Trim());
                k.SubItems.Add(dataread[2].ToString().Trim());
                k.SubItems.Add(dataread[3].ToString().Trim());
                k.SubItems.Add(dataread[4].ToString().Trim());
                k.SubItems.Add(dataread[5].ToString().Trim());
                k.SubItems.Add(dataread[6].ToString().Trim());
                k.SubItems.Add(dataread[7].ToString().Trim());
                k.SubItems.Add(dataread[8].ToString().Trim());
                this.MyListView.Items.Add(k);
                x++;
            }
            dataread.Close();
            mcmd = null;
        }

        private void MyListView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                IDUSER = long.Parse(MyListView.SelectedItems[0].Text.Trim());
            }
            catch
            {
                IDUSER = -1;
                MessageBox.Show("ID USER este invalid.", "GoWHManagementAdmin");
                return;
            }
            txtUserName.Text = MyListView.SelectedItems[0].SubItems[1].Text.Trim();
            txtPassword.Text = MyListView.SelectedItems[0].SubItems[2].Text.Trim();
            txtRealName.Text = MyListView.SelectedItems[0].SubItems[3].Text.Trim();
            txtRealSurname.Text = MyListView.SelectedItems[0].SubItems[4].Text.Trim();
            txtOrgRole.Text = MyListView.SelectedItems[0].SubItems[5].Text.Trim();
            try
            {
                 ACC_LEVEL= int.Parse(MyListView.SelectedItems[0].SubItems[6].Text.Trim());
            }
            catch
            {
                MessageBox.Show("ACCESS_LEVEL este invalid.", "GoWHManagementAdmin");
            }
            txtAccessLevel.Text = ACC_LEVEL.ToString();
            
            VALID_FROM = string.Format("{0:MM/dd/yyyy HH:mm:ss}", MyListView.SelectedItems[0].SubItems[7].Text.Trim()); 
            txtValidFrom.Text = VALID_FROM;
            //VALID_TO = string.Format("D", MyListView.SelectedItems[0].SubItems[8].Text.Trim());
            VALID_TO = string.Format("{0:MM/dd/yyyy HH:mm:ss}", MyListView.SelectedItems[0].SubItems[8].Text.Trim()); 
            txtValidTo.Text = VALID_TO; 
            
            LoadFunctionRight(IDUSER);
        }
        private void LoadFunctionRight(long UserID)
        {
          
            ListViewItem k = null;
            long x = 0;
            string mq = "";

            MyListFuncRight.Items.Clear();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mq = "select go_functions_access.ID," +
                        "CASE WHEN go_functions_def.SCOPE=0 THEN 'PDA' ELSE 'PC' END as Scope," +
                        "go_functions_def.SYM_FUNC," +
                        "go_functions_def.FUNC_DESCR " +
                        "from go_users_Def,go_functions_def,go_functions_access " +
                        "where go_users_def.ID=" + UserID.ToString() +
                        "and go_users_def.ID=go_functions_access.IDUSER " +
                        "and getdate() between go_users_def.ValidFrom " +
                        "and go_users_def.ValidTo and getdate() " +
                        "between go_functions_def.ValidFrom and go_functions_def.ValidTo " +
                        "and getdate() between go_functions_access.ValidFrom " +
                        "and go_functions_access.ValidTo and go_functions_access.IDFUNC=go_functions_def.ID " +
                        "order by go_functions_def.MODULE,go_functions_def.GROUP_FUNC;";
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                k = new ListViewItem(dataread[0].ToString().Trim());
                k.SubItems.Add(dataread[1].ToString().Trim());
                k.SubItems.Add(dataread[2].ToString().Trim());
                k.SubItems.Add(dataread[3].ToString().Trim());
                this.MyListFuncRight.Items.Add(k);
                x++;
            }
            dataread.Close();
            mcmd = null;
            
        }

        private void CmdSave_Click(object sender, EventArgs e)
        {
            int acclevel = 0;
            string mq = "";
            if (txtUserName.Text.Trim() == "")
            {
                MessageBox.Show("Campul Nume Utilizator este gol.","GoWHManagementAdmin");
                return;
            }
            if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Campul Parola este gol.", "GoWHManagementAdmin");
                return;
            }
            if (txtRealName.Text.Trim() == "")
            {
                MessageBox.Show("Campul Nume este gol.", "GoWHManagementAdmin");
                return;
            }
            if(txtRealSurname.Text.Trim()=="")
            {
                MessageBox.Show("Campul Prenume este gol", "GoWHManagementAdmin");
                return;
            }
            if(txtOrgRole.Text.Trim()=="")
            {
                MessageBox.Show("Campul Functie este gol", "GoWHManagementAdmin");
                return;
            }
            if (txtAccessLevel.Text.Trim() == "")
            {
                MessageBox.Show("Campul Nivel Acces este gol", "GoWHManagementAdmin");
                return;
            }
            else
            {
                try
                {
                    acclevel = int.Parse(txtAccessLevel.Text.Trim());
                }
                catch 
                {
                    MessageBox.Show("Nivel Acces este reprezentat numeric", "GoWHManagementAdmin");
                    return;
                }
            }
            if(txtValidFrom.Text.Trim()=="/  /        :  :")
            {
                MessageBox.Show("Campul Validare De La este gol", "GoWHManagementAdmin");
                return;
            }
            if(txtValidTo.Text.Trim()=="/  /        :  :")
            {
                MessageBox.Show("Campul Validare Pana La este gol", "GoWHManagementAdmin");
                return;
            }
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            if (IDUSER <= 0)
            {
                mq = "insert into go_users_def(UserID,Passwd,RealName,RealSurname,RoleInOrg,AccessLevel,ValidFrom,ValidTo) VALUES('" + txtUserName.Text.Trim() + "','" + txtPassword.Text.Trim() + "','" + txtRealName.Text.Trim() + "','" + txtRealSurname.Text.Trim() + "','" + txtOrgRole.Text.Trim() + "'," + acclevel.ToString() + ",'" + string.Format("{0:yyyy-dd-MM HH:mm:ss}", txtValidFrom.Text.Trim()) + "','" + string.Format("{0:yyyy-dd-MM HH:mm:ss}", txtValidTo.Text.Trim()) + "');";
            }
            else 
            {
                mq = "update go_users_def SET UserID='" + txtUserName.Text.Trim() + "',Passwd='" + txtPassword.Text.Trim() + "',RealName='" + txtRealName.Text.Trim() + "',RealSurName='" + txtRealSurname.Text.Trim() + "',RoleInOrg='" + txtOrgRole.Text.Trim() + "',AccessLevel=" + acclevel.ToString() + ",ValidFrom='" + string.Format("{0:yyyy-dd-MM HH:mm:ss}", txtValidFrom.Text.Trim()) + "',ValidTo='" + string.Format("{0:yyyy-dd-MM HH:mm:ss}", txtValidTo.Text.Trim()) + "' where ID=" + IDUSER.ToString() + ";";    
            }
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            try
            {
                mcmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Nu pot salva date in DB", "GoWHManagementAdmin");
                goto MYEND;
            }
        MYEND:
            IDUSER = -1;
            IDFUNCTION = -1;
            ACC_LEVEL = -1;
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtRealName.Text = "";
            txtRealSurname.Text = "";
            txtOrgRole.Text = "";
            txtAccessLevel.Text = "";
            txtValidFrom.Text = "";
            txtValidTo.Text = "";
            mcmd = null;
            LoadUsers();
        }
        private void LoadAvailableFunctions()
        {
            ListViewItem k = null;
            long x = 0;
            string mq = "";

            MyListAvailableFunc.Items.Clear();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mq = "SELECT ID" +
                ",SYM_FUNC" +
                ",GROUP_FUNC" +
                ",MODULE" +
                ",FUNC_DESCR" +
                ",CASE WHEN SCOPE=0 THEN 'PDA' ELSE 'PC' END as Scope" +
                ",ACCESSLEV" +
                ",ValidFrom" +
                ",ValidTo " +
                "FROM go_functions_def order by Scope";
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {

                k = new ListViewItem(dataread[0].ToString().Trim());
                k.SubItems.Add(dataread[1].ToString().Trim());
                k.SubItems.Add(dataread[2].ToString().Trim());
                k.SubItems.Add(dataread[3].ToString().Trim());
                k.SubItems.Add(dataread[4].ToString().Trim());
                k.SubItems.Add(dataread[5].ToString().Trim());
                k.SubItems.Add(dataread[6].ToString().Trim());
                k.SubItems.Add(dataread[7].ToString().Trim());
                k.SubItems.Add(dataread[8].ToString().Trim());
                
                this.MyListAvailableFunc.Items.Add(k);
                x++;
            }

            dataread.Close();
            mcmd = null;
        }

        private void MyListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                IDUSER = -1;
                IDFUNCTION = -1;
                MyListFuncRight.Items.Clear();
                txtOrgRole.Text = "";
                txtPassword.Text = "";
                txtRealName.Text = "";
                txtRealSurname.Text = "";
                txtUserName.Text = "";
                txtAccessLevel.Text = "";
                txtValidFrom.Text = "";
                txtValidTo.Text = "";
            }
        }

        private void MyListFuncRight_KeyDown(object sender, KeyEventArgs e)
        {
            DialogResult m;
            if (e.KeyCode == System.Windows.Forms.Keys.Delete)
            {
                if (IDFUNCTION <= 0)
                {
                    MessageBox.Show("Nu este Selectat nimic.", "GoWHManagementAdmin");
                    return;
                }
                m = MessageBox.Show("Esti sigur ca vrei sa stergi ?", "GoWHManagementAdmin", MessageBoxButtons.YesNo);
                if (m == DialogResult.Yes)
                {
                    LoadDeleteFunctions(IDFUNCTION);
                    IDFUNCTION = -1;
                    //MessageBox.Show("Baza de Date a fost Actualizata.", "GoWHManagementAdmin");
                    LoadFunctionRight(IDUSER);
                }

            }
        }

        private void MyListAvailableFunc_DoubleClick(object sender, EventArgs e)
        {
            DialogResult m;
            string mq = "";
            if (IDUSER <= 0)
            {
                MessageBox.Show("Nu este selectat nici un user.", "GoWHManagementAdmin");
                return;
            }

            m = MessageBox.Show("Esti sigur ca vrei sa adaugi Functia " + MyListAvailableFunc.SelectedItems[0].SubItems[1].Text.Trim() + " ?", "GoWHManagementAdmin", MessageBoxButtons.YesNo);
            if (m == DialogResult.No)
            {
                return;
            }
                        
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;

            mq = "insert into go_functions_access(IDFUNC,IDUSER,ACCESSLEV,ValidFrom,ValidTo) VALUES(" + MyListAvailableFunc.SelectedItems[0].Text.Trim() + "," + IDUSER.ToString() + ","+ACC_LEVEL.ToString()+",'"+VALID_FROM+"','"+VALID_TO+"');";
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            try
            {
                mcmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Nu pot salva date in DB", "GoWHManagementAdmin");
                return;
            }
            MessageBox.Show("Baza de Date este Actualizata.", "Manopera");
            LoadFunctionRight(IDUSER);
        }

        private void MyListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MyListFuncRight_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                IDFUNCTION = long.Parse(MyListFuncRight.SelectedItems[0].Text.Trim());
            }
            catch
            {
                IDFUNCTION = -1;
                MessageBox.Show("ID_FUNCTION este invalid.", "GoWHManagementAdmin");
            }
            MessageBox.Show("Ai selectat Functia " + MyListFuncRight.SelectedItems[0].SubItems[2].Text.Trim(), "Manopera");
        }
        private void LoadDeleteFunctions(long IDF)
        {

            string mq = "";
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mq = "delete from go_functions_access where ID=" + IDFUNCTION.ToString();
            mcmd.CommandText = mq;
            try
            {
                mcmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Nu pot salva date in DB", "GoWHManagementAdmin");
                return;
            }
            MessageBox.Show("Baza de Date a fost Actualizata.", "GoWHManagementAdmin");
            mcmd = null;
        }

        private void MyListAvailableFunc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MyListFuncRight_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}