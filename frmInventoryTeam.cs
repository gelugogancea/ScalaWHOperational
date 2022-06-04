using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoWHMgmAdmin
{
    public partial class frmInventoryTeam : Form
    {
        private long ID_REC = 0;
        public long ID_INVENTAR = 0;
        public frmInventoryTeam()
        {
            InitializeComponent();
        }

        private void frmInventoryTeam_Load(object sender, EventArgs e)
        {
            ColumnHeader colHead;
            this.MyListView.Clear();
            this.MyListView.Columns.Clear();

            colHead = new ColumnHeader();
            colHead.Text = "ID";
            colHead.Width = 60;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "InventarNr";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "SuperVisor";
            colHead.Width = 50;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "UserLog";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Oper 1";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Oper 2";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Oper 3";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Oper 4";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Oper 5";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Oper 6";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            this.MyListView.GridLines = true;
            this.MyListView.FullRowSelect = true;
            this.MyListView.View = View.Details;
            LoadMyUser("");
            LoadInventoryTeam();
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
                mq = "select go_users_Def.ID,go_users_Def.UserID,go_users_Def.RealName +' '+ go_users_Def.RealSurname," +
                    "go_users_Def.RoleInOrg,go_users_def.ValidFrom , go_users_def.ValidTo " +
                    "from " +
                    "go_users_Def " +
                    "where  getdate() between go_users_def.ValidFrom and go_users_def.ValidTo " +
                    "order by go_users_Def.UserID;";
            }
            else
            {
                mq = "select go_users_Def.ID,go_users_Def.UserID,go_users_Def.RealName +' '+ go_users_Def.RealSurname," +
                    "go_users_Def.RoleInOrg,go_users_def.ValidFrom , go_users_def.ValidTo " +
                    "from " +
                    "go_users_Def " +
                    "where go_users_Def.UserID like '" + mCriteria.Trim() + "%' getdate() between go_users_def.ValidFrom and go_users_def.ValidTo " +
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

        private void CmdExit_Click(object sender, EventArgs e)
        {
            ID_INVENTAR = 0;
            this.Close();
        }

        private void frmInventoryTeam_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                MyGlobal.mFrmInventoryTeam = null;
            }
            catch { }
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

        private void CmbUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                ResetCtrl();
            }
        }
        private void ResetCtrl()
        {
            ID_REC = 0;
            
            CmbUser.Text = "";
            LblOrgRole.Text = "";
            LblRealName.Text = "";
            LblUser.Text = "";
            LblValid.Text = "";
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txt6.Text = "";

        }
        private void LoadInventoryTeam()
        {
            ListViewItem k = null;
            string mq = "";
            long x = 0;
            this.Cursor = Cursors.WaitCursor;
            this.MyListView.Items.Clear();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            
            /*
            mq = "SELECT go_invent_team.ID, go_invent_team.IDMainInventory, go_invent_team.IDSupervisor, go_users_def.UserID, go_invent_team.Oper1,"+
                 "go_invent_team.Oper2, go_invent_team.Oper3, go_invent_team.Oper4, go_invent_team.Oper5, go_invent_team.Oper6 "+
                 "FROM go_users_def INNER JOIN "+
                 "go_invent_team ON go_users_def.ID = go_invent_team.IDSupervisor INNER JOIN "+
                 "go_invent_main ON go_invent_team.IDMainInventory = go_invent_main.ID INNER JOIN "+
                 "go_sys_lock ON go_invent_main.IDSysLock = go_sys_lock.ID and getdate() between "+
				 "go_invent_main.PeriodFrom and go_invent_main.PeriodTo ;";
            */
            mq = "SELECT go_invent_team.ID, go_invent_team.IDMainInventory, go_invent_team.IDSupervisor, go_users_def.UserID, go_invent_team.Oper1,"+
                 "go_invent_team.Oper2, go_invent_team.Oper3, go_invent_team.Oper4, go_invent_team.Oper5, go_invent_team.Oper6 "+
                 "FROM go_users_def INNER JOIN "+
                 "go_invent_team ON go_users_def.ID = go_invent_team.IDSupervisor INNER JOIN "+
                 "go_invent_main ON go_invent_team.IDMainInventory = go_invent_main.ID INNER JOIN "+
                 "go_sys_lock ON go_invent_main.IDSysLock = go_sys_lock.ID AND CONVERT(VARCHAR,getdate(),101) between CONVERT(VARCHAR,go_invent_main.PeriodFrom,101) AND CONVERT(VARCHAR,go_invent_main.PeriodTo,101);";

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
                
                this.MyListView.Items.Add(k);

                x++;
            }
            this.MyListView.EndUpdate();
            this.MyListView.Refresh();
            dataread.Close();
            mcmd = null;
            this.Cursor = Cursors.Default;
            
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


            CmbUser.Text = MyListView.SelectedItems[0].SubItems[2].Text.Trim();
            txt1.Text = MyListView.SelectedItems[0].SubItems[4].Text.Trim();
            txt2.Text = MyListView.SelectedItems[0].SubItems[5].Text.Trim();
            txt3.Text = MyListView.SelectedItems[0].SubItems[6].Text.Trim();
            txt4.Text = MyListView.SelectedItems[0].SubItems[7].Text.Trim();
            txt5.Text = MyListView.SelectedItems[0].SubItems[8].Text.Trim();
            txt6.Text = MyListView.SelectedItems[0].SubItems[9].Text.Trim();
        }

        private void CmdSave_Click(object sender, EventArgs e)
        {
            int iduser = 0;
            string mq = "";
  
            try
            {
                iduser = int.Parse(CmbUser.Text.Trim());
            }
            catch { MessageBox.Show("ID USER invalid.\r\nProbabil nu ati selectat nici un Utilizator."); return; }
            
            if (ID_REC ==0)
            {
                mq = "INSERT INTO go_invent_team(IDMainInventory,IDSupervisor,Oper1,Oper2,Oper3,Oper4,Oper5,Oper6) "+
                    "VALUES("+ID_INVENTAR.ToString()+","+CmbUser.Text.ToString()+",'"+txt1.Text.ToString()+"','"+txt2.Text.ToString()+"',"+
                    "'"+txt3.Text.ToString()+"','"+txt4.Text.ToString()+"','"+txt5.Text.ToString()+"','"+txt6.Text.ToString()+"');";
            }
            else if(ID_REC>0)
            {
                mq ="UPDATE go_invent_team SET IDSupervisor="+CmbUser.Text.ToString()+","+
                    "Oper1 ='"+txt1.Text.ToString()+"',"+
                    "Oper2 ='"+txt2.Text.ToString()+"',"+
                    "Oper3 ='"+txt3.Text.ToString()+"',"+
                    "Oper4 ='"+txt4.Text.ToString()+"',"+
                    "Oper5 ='"+txt5.Text.ToString()+"',"+
                    "Oper6 ='"+txt6.Text.ToString()+"' "+
                    "WHERE ID="+ID_REC.ToString()+";"; 
            }

            if (SaveData(mq) == 0)
            {
                MessageBox.Show("Datele au fost salvate cu succes.");
                LoadInventoryTeam();
            }
            else
            {
                MessageBox.Show("Nu pot salva date.");
            }
            ResetCtrl();
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
    }
}