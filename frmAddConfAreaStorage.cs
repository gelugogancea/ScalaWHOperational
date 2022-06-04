using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoWHMgmAdmin
{
    public partial class frmAddConfAreaStorage : Form
    {
        private long ID_STORAGE_AREA=0;
        public frmAddConfAreaStorage()
        {
            InitializeComponent();
        }

        private void CmdExit_Click(object sender, EventArgs e)
        {
            ID_STORAGE_AREA = 0;
            try
            {
                this.Close();
            }
            finally
            {
                GC.Collect();
            }
        }

        private void frmAddConfAreaStorage_FormClosed(object sender, FormClosedEventArgs e)
        {
            ID_STORAGE_AREA = 0;
            try
            {
                MyGlobal.mFrmAddConfAreaStorage = null;
            }
            finally
            {
                GC.Collect();
            }
        }

        private void frmAddConfAreaStorage_Load(object sender, EventArgs e)
        {
            ColumnHeader colHead;
            this.MyListView.Clear();
            this.MyListView.Columns.Clear();

            colHead = new ColumnHeader();
            colHead.Text = "ID";
            colHead.Width = 60;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "WHCod";
            colHead.Width = 60;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "CodZona";
            colHead.Width = 60;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Descriere";
            colHead.Width = 280;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Picking";
            colHead.Width = 60;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "QtyMIN";
            colHead.Width = 60;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "QtyMAX";
            colHead.Width = 60;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Lungime";
            colHead.Width = 60;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Latime";
            colHead.Width = 60;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Inaltime";
            colHead.Width = 60;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Max Kg";
            colHead.Width = 60;
            this.MyListView.Columns.Add(colHead);

            

            colHead = new ColumnHeader();
            colHead.Text = "User";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Introdus";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Modificat";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            this.MyListView.GridLines = true;
            this.MyListView.FullRowSelect = true;
            this.MyListView.View = View.Details;

            LoadStorageAreaDef("");
            LoadWH();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable("Employees");

            CmbWH.DataSource = dataTable;
            CmbWH.DisplayMember = "Employee ID";
            CmbWH.ValueMember = "Name";

        }
        private void LoadWH()
        {
            string mq = "";
            DataTable dataTable = new DataTable("Gestiuni");
            dataTable.Columns.Add("COD", typeof(String));
            dataTable.Columns.Add("Denumire", typeof(String));
            
            this.Cursor = Cursors.WaitCursor;
            this.CmbWH.Text="";
            this.CmbWH.Items.Clear();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mq = "SELECT ScWH,ScName FROM dbo.go_main_wh_def order by ScWH;";
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                dataTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"),MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'") });
            }
            CmbWH.DataSource = dataTable;
            CmbWH.DisplayMember = "COD";
            CmbWH.ValueMember = "Denumire";
            CmbWH.Text = "";
            this.LblWHDescriere.Text = "";
            dataread.Close();
            mcmd = null;
            this.Cursor = Cursors.Default;
        }

        private void CmdSalvez_Click(object sender, EventArgs e)
        {
            long lungime = 0;
            long latime = 0;
            long inaltime = 0;
            long gmax = 0;
            double qmin = 0;
            double qmax = 0;

            string pick = "";
            if (CmbWH.Text.Trim() == "")
            {
                MessageBox.Show("Trebuie selectata o Gestiune");
                return;
            }
            if (txtAreaCode.Text.Trim()=="")
            {
                MessageBox.Show("Trebuie specificat COD Zona de Stocare");
                return;
            }
            if (CkPickingAllow.Checked == true)
            {
                pick = "True";
            }
            else
            {
                pick = "False";
            }
            if (txtLungime.Text.Trim() != "")
            {
                try
                {
                    lungime = long.Parse(txtLungime.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("Lungimea este reprezentata numeric.");
                    return;
                }
            }
            if(this.txtLatime.Text.Trim()!="")
            {
                try
                {
                    latime = long.Parse(this.txtLatime.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("Latimea este reprezentata numeric.");
                    return;
                }
            }
            if(this.txtInaltime.Text.Trim()!="")
            {
                try
                {
                    inaltime = long.Parse(this.txtInaltime.Text.Trim()); 
                }
                catch
                {
                    MessageBox.Show("Inaltimea este reprezentata numeric.");
                    return;
                }
            }
            if(this.txtGreutate.Text.Trim()!="")
            {
                try
                {
                    gmax = long.Parse(this.txtGreutate.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("Greutatea Maxima Admisa este reprezentata numeric.");
                    return;
                }
            }
            if (ID_STORAGE_AREA <= 0)   //verific doar pentru insert si NU pentru update
            {
                string[] mfunc = new string[1];
                if (MyGlobal.IsForUpdate("select AreaCode from dbo.go_area_def where AreaCode='" + this.txtAreaCode.Text.Trim() + "' and WHCode='" + this.CmbWH.Text.Trim() + "'",1,ref mfunc) == true)
                {
                    MessageBox.Show("COD Zona de Stocare " + this.txtAreaCode.Text.Trim() + " deja exista setat pentru Gestiunea " + this.CmbWH.Text.Trim());
                    mfunc = null;
                    return;
                }
                mfunc = null;
            }
            try
            {
                qmin = double.Parse(txtQtyMIN.Text.Trim());
            }
            catch { MessageBox.Show("Canitatea Minima este reprezentata numeric."); return; }
            try
            {
                qmax=double.Parse(txtQtyMAX.Text.Trim());
            }
            catch { MessageBox.Show("Canitatea Maxima este reprezentata numeric."); return; }

            if (WriteInDB(this.CmbWH.Text.Trim(), this.txtAreaCode.Text.Trim(), this.txtDescription.Text.Trim(), pick.Trim(), lungime, latime, inaltime, gmax,qmin,qmax) == 0)
            {
                LoadStorageAreaDef("");
                MessageBox.Show("Am salvat cu succes.");
            }
        }
        private int WriteInDB(string WHCode, string AreaCode, string AreaDescription, string PickingAllow, long ALength, long AWidth, long AHeigth, long AWeigth,double qmin,double qmax)
        {
            string mq = "";
            int ret = 0;
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            if (ID_STORAGE_AREA <= 0)
            {
                mq = "INSERT INTO dbo.go_area_def "+
                    "(WHCode"+
                    ",AreaCode"+
                    ",AreaDescription"+
                    ",PickingAllow"+
                    ",QtyMIN"+
                    ",QtyMAX"+
                    ",ALength"+
                    ",AWidth"+
                    ",AHeigth"+
                    ",AWeigth"+
                    ",mUser"+
                    ",InDate"+
                    ",UpToDate) VALUES"+
                    "('"+WHCode+"'"+
                    ",'"+AreaCode+"'"+
                    ",'"+AreaDescription+"'"+
                    ",'"+PickingAllow+"'"+
                    ","+qmin.ToString().Trim()+""+
                    ","+qmax.ToString().Trim()+""+
                    ","+ALength+""+
                    ","+AWidth+""+
                    ","+AHeigth+""+
                    ","+AWeigth+""+
                    ",'"+MyGlobal.MyUserInfo.MyUser.Trim()+"'"+
                    ",getdate()"+
                    ",NULL);";
            }
            else
            {
                mq = "update dbo.go_area_def set " +
                    "WHCode='" + WHCode + "'" +
                    ",AreaCode='" + AreaCode + "'" +
                    ",AreaDescription='" + AreaDescription + "'" +
                    ",PickingAllow='" + PickingAllow + "'" +
                    ",QtyMIN="+qmin.ToString().Trim()+""+
                    ",QtyMAX="+qmax.ToString().Trim()+""+
                    ",ALength=" + ALength + "" +
                    ",AWidth=" + AWidth + "" +
                    ",AHeigth=" + AHeigth + "" +
                    ",AWeigth=" + AWeigth + "" +
                    ",mUser='" + MyGlobal.MyUserInfo.MyUser.Trim() + "'" +
                    ",UpToDate=getdate() where ID="+ID_STORAGE_AREA+";" ;
            }
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            try
            {
                mcmd.ExecuteNonQuery();
            }
            catch(Exception emsg)
            {
                MessageBox.Show("ERROR : " + emsg.Message.Trim(), "GoWHManagementAdmin");
                ret = -1;
                goto MYEND;
            }
        MYEND:
            mcmd = null;
            ID_STORAGE_AREA = 0;
            this.txtAreaCode.Text = "";
            this.txtDescription.Text = "";
            this.txtGreutate.Text = "0";
            this.txtInaltime.Text = "0";
            this.txtLatime.Text = "0";
            this.txtLungime.Text = "0";
            this.CmbWH.Text = "";
            this.LblWHDescriere.Text = "";
            this.txtQtyMAX.Text = "0";
            this.txtQtyMIN.Text = "0";
            return ret;
        }

        private void MyListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            long lungime=0;
            long latime=0;
            long inaltime=0;
            long gmax=0;
            double qmin = 0;
            double qmax = 0;
            try
            {
                ID_STORAGE_AREA = long.Parse(MyListView.SelectedItems[0].Text.Trim());
            }
            catch
            {
                MessageBox.Show("CRITIC_ERR ! Invalid ID_STORAGE");
                return;
            }
            this.CmbWH.Text = MyListView.SelectedItems[0].SubItems[1].Text.Trim();
            this.txtAreaCode.Text= MyListView.SelectedItems[0].SubItems[2].Text.Trim(); 
            this.txtDescription.Text = MyListView.SelectedItems[0].SubItems[3].Text.Trim();
            if (MyListView.SelectedItems[0].SubItems[4].Text.Trim() == "True")
            {
                this.CkPickingAllow.Checked = true;
            }
            else
            {
                this.CkPickingAllow.Checked = false;
            }
            try
            {
                qmin = double.Parse(MyListView.SelectedItems[0].SubItems[5].Text.Trim());
            }
            catch { }
            try 
            {
                qmax = double.Parse(MyListView.SelectedItems[0].SubItems[6].Text.Trim());
            }
            catch { }
            try
            {
                lungime = long.Parse(MyListView.SelectedItems[0].SubItems[7].Text.Trim());
            }
            catch { }
            try
            {
                latime = long.Parse(MyListView.SelectedItems[0].SubItems[8].Text.Trim());
            }
            catch { }
            try
            {
                inaltime = long.Parse(MyListView.SelectedItems[0].SubItems[9].Text.Trim());
            }
            catch { }
            try
            {
                gmax = long.Parse(MyListView.SelectedItems[0].SubItems[10].Text.Trim());
            }
            catch { }
            this.txtLungime.Text = lungime.ToString();
            this.txtLatime.Text = latime.ToString();
            this.txtInaltime.Text = inaltime.ToString();
            this.txtGreutate.Text = gmax.ToString();
            this.txtQtyMIN.Text = qmin.ToString().Trim();
            this.txtQtyMAX.Text = qmax.ToString().Trim();
            //WriteInDB(, , MyListView.SelectedItems[0].SubItems[3].Text.Trim(), MyListView.SelectedItems[0].SubItems[4].Text.Trim(),lungime,latime,inaltime,gmax);
        }
        private void LoadStorageAreaDef(string mCriteria)
        {
            ListViewItem k = null;
            string mq = "";
            this.Cursor = Cursors.WaitCursor;
            this.MyListView.Items.Clear();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            if (mCriteria.Trim() == "")
            {
                mq = "SELECT ID,WHCode,AreaCode,AreaDescription,PickingAllow,QtyMIN,QtyMAX,ALength,AWidth,AHeigth,AWeigth,mUser,InDate,UpToDate from dbo.go_area_def order by ID;";
            }
            else
            {
                mq = "SELECT ID,WHCode,AreaCode,AreaDescription,PickingAllow,QtyMIN,QtyMAX,ALength,AWidth,AHeigth,AWeigth,mUser,InDate,UpToDate from dbo.go_area_def where AreaCode like '%" + mCriteria.Trim() + "%'order by ID;";
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
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[11].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[12].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[13].ToString().Trim(), "'"));
                this.MyListView.Items.Add(k);
                
            }
            this.MyListView.EndUpdate();
            this.MyListView.Refresh();
            dataread.Close();
            mcmd = null;
            this.Cursor = Cursors.Default;
            

        }

        private void CmbWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ms = "";
            try
            {
                ms = ((DataRowView)CmbWH.SelectedItem).Row.ItemArray[1].ToString();
                this.LblWHDescriere.ForeColor = System.Drawing.Color.DarkBlue;
                this.LblWHDescriere.Text = ms.Trim();
            }
            catch { }
            
        }

        private void MyListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                ID_STORAGE_AREA = 0;
                this.txtAreaCode.Text = "";
                this.txtDescription.Text = "";
                this.txtGreutate.Text = "";
                this.txtInaltime.Text = "";
                this.txtLatime.Text = "";
                this.txtLungime.Text = "";
                this.CmbWH.Text = "";
                this.LblWHDescriere.Text = "";
            }
        }
    }
}