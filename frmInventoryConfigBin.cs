using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoWHMgmAdmin
{
    public partial class frmInventoryConfigBin : Form
    {
        private long ID_REC=0;
        public frmInventoryConfigBin()
        {
            InitializeComponent();
        }

        private void CmdExit_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void frmInventoryConfigBin_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                MyGlobal.mFrmInventoryConfigBin = null; 
            }
            catch { }
        }
        private void LoadInitialLocators()
        {
            string mq = "";
            DataTable dataTable = new DataTable("InitialLocators");
            dataTable.Clear();
            dataTable.Columns.Add("Locator", typeof(String));
            dataTable.Columns.Add("Descriere", typeof(String));
            dataTable.Columns.Add("AccessLevel",typeof(String));     
            dataTable.Columns.Add("ID", typeof(String));

            this.Cursor = Cursors.WaitCursor;

            this.CmbLocatii.Text = "";
            this.CmbLocatii.DataSource = null;
            this.CmbLocatii.Items.Clear();
            this.CmbLocatii.BeginUpdate();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mq = "SELECT [LocatorSymbol] "+
                    ",[DescriptionLocator]"+
                    ",[LocatorAccLevel]"+
                    ",[ID] "+
                    "FROM [GoWH].[dbo].[go_locator_def] order by LocatorSymbol";

            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                //dataTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'")});
                dataTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'") });
            }
            this.CmbLocatii.EndUpdate();
            dataread.Close();
            mcmd = null;
            CmbLocatii.DataSource = dataTable;
            CmbLocatii.DisplayMember = "ID";
            CmbLocatii.ValueMember = "Locator";

            this.Cursor = Cursors.Default;
            CmbLocatii.DataBindings.Clear();
            CmbLocatii.Text = ""; 
        }

        private void frmInventoryConfigBin_Load(object sender, EventArgs e)
        {

            ColumnHeader colHead;
            this.MyListView.Clear();
            this.MyListView.Columns.Clear();

            colHead = new ColumnHeader();
            colHead.Text = "ID";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Locator";
            colHead.Width = 100;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Zona";
            colHead.Width = 100;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Depozit";
            colHead.Width = 180;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Descriere";
            colHead.Width = 180;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "ID_3DLOC";
            colHead.Width = 0;
            this.MyListView.Columns.Add(colHead);


            this.MyListView.GridLines = true;
            this.MyListView.FullRowSelect = true;
            this.MyListView.View = View.Details;
            LoadData();
            LoadInitialLocators();
        }

        private void txtArea_Leave(object sender, EventArgs e)
        {
            this.txtArea.Text = this.txtArea.Text.ToUpper();

        }

        private void txtWH_Leave(object sender, EventArgs e)
        {
            this.txtWH.Text = this.txtWH.Text.ToUpper();

        }

        private void MyListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                txtWH.Text = "";
                txtArea.Text = "";
                CmbLocatii.Text = "";
                ID_REC = 0;
            }
        }

        private void CmdSave_Click(object sender, EventArgs e)
        {
            string mq = "";
            bool IfExist = false;
            string mmm = "";
            string[] mres = new string[1];
            if(CmbLocatii.Text.Trim()==""   )
            {
                MessageBox.Show("Trebuie selectat locator","",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1       );  
                return; 
            }
            if (txtArea.Text.Trim() == "")
            {
                MessageBox.Show("Trebuie completata Zona", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);  
                return; 
            }
            if(txtWH.Text.Trim()==""   )
            {
                MessageBox.Show("Trebuie completat Depozit", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);  
                return; 
            }
            

            
            mres = null; 
            if (ID_REC == 0)
            {
                mmm = "SELECT [InventArea] FROM [GoWH].[dbo].[go_invent_config_locators] where [ID_3DLOC]=" + CmbLocatii.Text.Trim() + ";";
                IfExist = MyGlobal.IsForUpdate(mmm, 1, ref mres);

                if (IfExist == true)
                {

                    MessageBox.Show("Exista deja configurat acest locator pentru " + mres[0].Trim());
                    mres = null;
                    return;
                }
                mq="INSERT INTO [dbo].[go_invent_config_locators] "+
                    "([ID_3DLOC],[InventArea],[InventWH]) "+
                    "VALUES ("+ CmbLocatii.Text.Trim()+",'"+ txtArea.Text.Trim()+"','"+ txtWH.Text.Trim()+"');";
            }
            else
            {
                if (ID_REC > 0)
                {
                    if (CkDelete.Checked == false)
                    {
                        mq = "UPDATE [dbo].[go_invent_config_locators] " +
                        "SET [ID_3DLOC] = " + CmbLocatii.Text.Trim() + " " +
                        ",[InventArea] = '" + txtArea.Text.Trim() + "'" +
                        ",[InventWH] = '" + txtWH.Text.Trim() + "' " +
                        "WHERE ID=" + ID_REC.ToString() + ";";
                    }
                    else
                    {
                        mq = "delete from [dbo].[go_invent_config_locators] " +
                             "WHERE ID=" + ID_REC.ToString() + ";";
                    }
                }
                else
                {
                    MessageBox.Show("Ivalid ID_REC", "Critical Error",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);   
                    return; 
                }
            }
            if (SaveData(mq) == 0)
            {
                MessageBox.Show("Datele au fost salvate cu succes", "", MessageBoxButtons.OK, MessageBoxIcon.Information , MessageBoxDefaultButton.Button1);
                txtWH.Text = "";
                txtArea.Text = "";
                CmbLocatii.Text = "";
                ID_REC = 0;
            }
            else
            {
                ID_REC = 0; 
                MessageBox.Show("Nu se pot salva date.", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);   
            }
            LoadData(); 
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

        private void MyListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string m = "";
            try
            {

                ID_REC = long.Parse(MyListView.SelectedItems[0].Text.Trim());
            }
            catch
            {
                MessageBox.Show("CRITIC_ERR ! Invalid ID_ARTICLE");
                return;
            }
            this.CmbLocatii.Text = MyListView.SelectedItems[0].SubItems[5].Text.Trim();
            this.txtArea.Text = MyListView.SelectedItems[0].SubItems[2].Text.Trim();
            this.txtWH.Text = MyListView.SelectedItems[0].SubItems[3].Text.Trim(); 
            //m = MyListView.SelectedItems[0].Text.Trim();
        }
        private void LoadData()
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
            mq = "SELECT  go_invent_config_locators.ID, go_locator_def.LocatorSymbol, go_invent_config_locators.InventArea, go_invent_config_locators.InventWH, "+ 
                "go_locator_def.DescriptionLocator, go_locator_def.ID AS ID_3DLOC "+
                "FROM go_invent_config_locators "+
                "INNER JOIN go_locator_def ON go_invent_config_locators.ID_3DLOC = go_locator_def.ID order by go_invent_config_locators.InventArea,go_locator_def.LocatorSymbol";
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
    }
}