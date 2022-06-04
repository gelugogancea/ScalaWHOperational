using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoWHMgmAdmin
{
    
    public partial class frmAddConf3DLoc : Form
    {
        private long ID_3D_LOCATOR = 0;
        public frmAddConf3DLoc()
        {
            InitializeComponent();

        }

        private void CmdExit_Click(object sender, EventArgs e)
        {
            ID_3D_LOCATOR = 0;
            try
            {
                this.Close();
            }
            finally
            {
                GC.Collect();
            }
        }

        private void frmAddConf3DLoc_FormClosed(object sender, FormClosedEventArgs e)
        {
            ID_3D_LOCATOR = 0;
            try
            {
                MyGlobal.mFrmAddConf3DLoc = null;
            }
            finally
            {
                GC.Collect();
            }
        }
        private void LoadStorageAreDef(string mWH)
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
            mq = "SELECT ID,AreaCode,AreaDescription FROM dbo.go_area_def where WHCode='"+mWH.Trim()+"';";
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                dTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'")});
                x++;
            }
            dataread.Close();
            mcmd = null;
            
            this.CmbSTArea.DataSource = dTable;
            this.CmbSTArea.DisplayMember = "ID";
            this.CmbSTArea.ValueMember = "Cod";
            this.LblZSDescriere.Text = "";
            if (x > 0)
            {
                this.CmbSTArea.Text = "Select...";
            }
            else
            {
                this.CmbSTArea.Text = "Nu sunt date.";
            }
            this.Cursor = Cursors.Default;
            CmbSTArea.DataBindings.Clear();
        }

        private void frmAddConf3DLoc_Load(object sender, EventArgs e)
        {
            txtAccLevel.Text = "1";
            
            
            ColumnHeader colHead;
            this.MyListView.Clear();
            this.MyListView.Columns.Clear();

            colHead = new ColumnHeader();
            colHead.Text = "ID";
            colHead.Width = 60;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "ID_STORAGE_AREA";
            colHead.Width = 60;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "SimbolLocat";
            colHead.Width = 60;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Descriere";
            colHead.Width = 280;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "NivelAcces";
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
            colHead.Text = "VLocStanga";
            colHead.Width = 60;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "VLocDreapta";
            colHead.Width = 60;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "VLocSus";
            colHead.Width = 60;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "VLocJos";
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
            
            LoadWH();

        }
        private void LoadWH()
        {
            string mq = "";
            DataTable dataTable = new DataTable("Gestiuni");
            dataTable.Columns.Add("COD", typeof(String));
            dataTable.Columns.Add("Denumire", typeof(String));

            this.Cursor = Cursors.WaitCursor;
            this.CmbWH.Items.Clear();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mq = "SELECT ScWH,ScName FROM dbo.go_main_wh_def order by ScWH;";
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                dataTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'") });
            }
            dataread.Close();
            mcmd = null;
            this.CmbWH.DataSource = dataTable;
            this.CmbWH.DisplayMember =  "COD";
            this.CmbWH.ValueMember = "Denumire";
            //dataTable.Clear();
            //CmbWH.Text = "";
            this.Cursor = Cursors.Default;
            
        }
                

        private void CmdCauta_Click(object sender, EventArgs e)
        {
            long IDStArea = 0;
            /*
            try
            {
                IDStArea = long.Parse(this.CmbSTArea.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Zona De Stocare este invalida");
                return;
            }
             */ 
            if (txtCauta.Text.Trim() == "Nu sunt date...")
            {
                Load3DLocator("", IDStArea);
            }
            else
            {
                Load3DLocator(txtCauta.Text.Trim(), IDStArea);
            }
        }
        
        private void CmbSTArea_Click(object sender, EventArgs e)
        {
            
        }

        private void CmbWH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                LoadStorageAreDef(CmbWH.Text.Trim());
            }
        }

        private void CmbWH_Click(object sender, EventArgs e)
        {
            
        }

        private void CmbWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ms = "";
            ms =((DataRowView)CmbWH.SelectedItem).Row.ItemArray[0].ToString();   //Row.ItemArray[0];
            LoadStorageAreDef(ms.Trim());
        }

        private void CmdSalvez_Click(object sender, EventArgs e)
        {
            long IDStArea = 0;
            int AccLevel = 0;
            long lungime = 0;
            long latime = 0;
            long inaltime = 0;
            long gmax=0;

            try
            {
                IDStArea = long.Parse(this.CmbSTArea.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Zona De Stocare este invalida"); 
                return;
            }
            
            if (this.txtSymbol.Text.Trim() == "")
            {
                MessageBox.Show("Nu este setat Simbol Locator");
                return;
            }
            else
            {
                if (this.txtSymbol.Text.Trim() == "000")
                {
                    MessageBox.Show("Simbol Locator este invalid.");
                    return;
                }
            }
            try
            {
                AccLevel = int.Parse(this.txtAccLevel.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Nivel Acces este reprezentat numeric."); 
                return;
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
            if (this.txtLatime.Text.Trim() != "")
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
            if (this.txtInaltime.Text.Trim() != "")
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
            if (this.txtGreutate.Text.Trim() != "")
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
            if(ID_3D_LOCATOR==0)
            {
                string[] mfunc = new string[1];
                //if (MyGlobal.IsForUpdate("select ID from dbo.go_locator_def where LocatorSymbol='" + this.txtSymbol.Text.Trim() + "' and ID_STORAGE_AREA=" + IDStArea.ToString() + "",1,ref mfunc) == true)
                if (MyGlobal.IsForUpdate("select ID from dbo.go_locator_def where LocatorSymbol='" + this.txtSymbol.Text.Trim() + "'", 1, ref mfunc) == true)
                {
                    MessageBox.Show("Locatorul "+ this.txtSymbol.Text.Trim() +" este deja setat.");
                    mfunc = null;
                    return;
                }
                mfunc = null; 
            }
            if (WriteInDB(IDStArea, this.txtSymbol.Text.Trim(), this.txtDescription.Text.Trim(), AccLevel, lungime, latime, inaltime, gmax, this.txtNLocLeft.Text.Trim(), this.txtNLocRight.Text.Trim(), this.txtNLocUp.Text.Trim(), this.txtNLocDown.Text.Trim()) == 0)
            {
                Load3DLocator("",IDStArea);
                MessageBox.Show("Am salvat cu succes.");
            }

        }
        private int WriteInDB(long ID_STORAGE_AREA, string LocatorSymbol, string DescriptionLocator, int LocatorAccLevel, long LLength, long LWidth, long LHeight, long LWeightMAX, string OLeftLocator, string ORigthLocator, string OUpLocator, string ODownLocator)
        {
            string mq = "";
            int ret = 0;
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            if (ID_3D_LOCATOR <= 0)
            {
                mq = "INSERT INTO dbo.go_locator_def "+
                    "(ID_STORAGE_AREA,LocatorSymbol,DescriptionLocator,LocatorAccLevel,LLength"+
                    ",LWidth,LHeight,LWeightMAX,OLeftLocator,ORigthLocator,OUpLocator,ODownLocator"+
                    ",mUser,InDate,UpToDate) VALUES"+
                    "("+ID_STORAGE_AREA.ToString()+",'"+LocatorSymbol+"','"+DescriptionLocator+"'"+
                    ","+LocatorAccLevel.ToString()+","+LLength.ToString()+","+LWidth.ToString()+","+LHeight.ToString()+""+
                    ","+LWeightMAX.ToString()+",'"+OLeftLocator+"','"+ORigthLocator+"'"+
                    ",'"+OUpLocator+"','"+"','" + MyGlobal.MyUserInfo.MyUser.Trim() + "'"+
                    ",getdate(),NULL);"; 
            }
            else
            {
                mq = "UPDATE dbo.go_locator_def SET ID_STORAGE_AREA =" + ID_STORAGE_AREA.ToString() + "" +
                    ",LocatorSymbol ='" + LocatorSymbol + "'" +
                    ",DescriptionLocator ='" + DescriptionLocator + "'" +
                    ",LocatorAccLevel = " + LocatorAccLevel.ToString() + "" +
                    ",LLength =" + LLength.ToString() + "" +
                    ",LWidth =" + LWidth.ToString() + "" +
                    ",LHeight =" + LHeight.ToString() + "" +
                    ",LWeightMAX =" + LWeightMAX.ToString() + "" +
                    ",OLeftLocator = '" + OLeftLocator + "'" +
                    ",ORigthLocator ='" + ORigthLocator + "'" +
                    ",OUpLocator ='" + OUpLocator + "'" +
                    ",ODownLocator ='" + ODownLocator + "'" +
                    ",mUser ='" + MyGlobal.MyUserInfo.MyUser.Trim() + "'" +
                    ",UpToDate = getdate() " +
                    "WHERE ID=" + ID_3D_LOCATOR.ToString() + ";";
                    
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
                goto MYEND;
            }
        MYEND:
            mcmd = null;
            ID_3D_LOCATOR = 0;
            ID_STORAGE_AREA = 0;
            this.txtSymbol.Text  = "";
            this.txtDescription.Text = "";
            this.txtAccLevel.Text = "1";
            this.txtNLocDown.Text = "";
            this.txtNLocLeft.Text = "";
            this.txtNLocRight.Text = "";
            this.txtNLocUp.Text = "";
            this.txtInaltime.Text = "";
            this.txtLatime.Text = "";
            this.txtLungime.Text = "";
            this.txtGreutate.Text = "";
            this.CmbWH.Text = "";
            return ret;
        }
        private void Load3DLocator(string mCriteria,long ID_ST_AREA)
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
                mq = "select * from dbo.go_locator_def where ID_STORAGE_AREA="+ID_ST_AREA.ToString()+" order by ID;";
            }
            else
            {
                //mq = "select * from dbo.go_locator_def where LocatorSymbol like '%" + mCriteria.Trim() + "%' and ID_STORAGE_AREA=" + ID_ST_AREA.ToString() + " order by ID;";
                mq = "select * from dbo.go_locator_def where LocatorSymbol like '%" + mCriteria.Trim() + "%' order by ID;";
            }
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            this.MyListView.BeginUpdate();
            while (dataread.Read())
            {
                k = new ListViewItem(MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"));
                CmbSTArea.Text =MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'");
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
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[14].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[15].ToString().Trim(), "'"));
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

        private void MyListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            long lungime = 0;
            long latime = 0;
            long inaltime = 0;
            long gmax = 0;
            try
            {
                ID_3D_LOCATOR = long.Parse(MyListView.SelectedItems[0].Text.Trim());
            }
            catch
            {
                MessageBox.Show("CRITIC_ERR ! Invalid ID_3DLOCATOR");
                return;
            }
            this.CmbSTArea.Text = MyListView.SelectedItems[0].SubItems[1].Text.Trim();
            this.txtSymbol.Text = MyListView.SelectedItems[0].SubItems[2].Text.Trim();
            this.txtDescription.Text = MyListView.SelectedItems[0].SubItems[3].Text.Trim();
            this.txtAccLevel.Text= MyListView.SelectedItems[0].SubItems[4].Text.Trim();
            try
            {
                lungime = long.Parse(MyListView.SelectedItems[0].SubItems[5].Text.Trim());
            }
            catch { }
            try
            {
                latime = long.Parse(MyListView.SelectedItems[0].SubItems[6].Text.Trim());
            }
            catch { }
            try
            {
                inaltime = long.Parse(MyListView.SelectedItems[0].SubItems[7].Text.Trim());
            }
            catch { }
            try
            {
                gmax = long.Parse(MyListView.SelectedItems[0].SubItems[8].Text.Trim());
            }
            catch { }
            this.txtLungime.Text = lungime.ToString();
            this.txtLatime.Text = latime.ToString();
            this.txtInaltime.Text = inaltime.ToString();
            this.txtGreutate.Text = gmax.ToString();
            this.txtNLocLeft.Text = MyListView.SelectedItems[0].SubItems[9].Text.Trim();
            this.txtNLocRight.Text = MyListView.SelectedItems[0].SubItems[10].Text.Trim();
            this.txtNLocUp.Text = MyListView.SelectedItems[0].SubItems[11].Text.Trim();
            this.txtNLocDown.Text = MyListView.SelectedItems[0].SubItems[12].Text.Trim(); 
        }

        private void CmbSTArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ms = "";
            try
            {
                ms = ((DataRowView)CmbSTArea.SelectedItem).Row.ItemArray[0].ToString();
                this.LblZSDescriere.ForeColor = System.Drawing.Color.DarkBlue;
                this.LblZSDescriere.Text = ((DataRowView)CmbSTArea.SelectedItem).Row.ItemArray[1].ToString() + " | " + ((DataRowView)CmbSTArea.SelectedItem).Row.ItemArray[2].ToString();
                Load3DLocator("", long.Parse(ms.Trim()));
            }
            catch { }
        }
        private string FillZero(string mBuff)
        {
            int i=0;
            string tmp = "";
            if (mBuff.Length > 3)
            {
                return mBuff.Substring(1, 3);
            }
            else
            {
                for (i = 0; i < (3-mBuff.Length); i++)
                {
                    tmp += "0";
                }
                return tmp + mBuff;
            }
        }

        private void txtSymbol_Leave(object sender, EventArgs e)
        {
            txtSymbol.Text=FillZero(txtSymbol.Text.Trim());
        }

        private void txtNLocLeft_Leave(object sender, EventArgs e)
        {
            txtNLocLeft.Text = FillZero(txtNLocLeft.Text.Trim());
        }

        private void txtNLocRight_Leave(object sender, EventArgs e)
        {
            txtNLocRight.Text = FillZero(txtNLocRight.Text.Trim());
        }

        private void txtNLocUp_Leave(object sender, EventArgs e)
        {
            txtNLocUp.Text = FillZero(txtNLocUp.Text.Trim());

        }

        private void txtNLocDown_Leave(object sender, EventArgs e)
        {
            txtNLocDown.Text = FillZero(txtNLocDown.Text.Trim());
        }

        private void MyListView_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue==27)
            {
                CmbSTArea.Text = "";
                LblZSDescriere.Text = "";
                txtSymbol.Text = "";
                txtDescription.Text = "";
                txtLungime.Text = "";
                txtLatime.Text = "";
                txtInaltime.Text = "";
                txtGreutate.Text = "";
                txtNLocLeft.Text = "";
                txtNLocRight.Text = "";
                txtNLocUp.Text = "";
                txtNLocDown.Text = "";
                txtAccLevel.Text = "";
                ID_3D_LOCATOR = 0;
            }
        }
    }
}