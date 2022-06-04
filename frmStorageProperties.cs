using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoWHMgmAdmin
{
    public partial class frmStorageProperties : Form
    {
        private bool LOAD_WH = false;
        private long ID_3D_LOCATOR = 0;
        private string AREA_STORAGE = "";
        private string ID_ARTICLE = "";
        private string ID_CLASSIFY = "";
        private long ID_STORAGE=0;
        private bool MY_CANCEL = false;
        private bool LOAD_FROM_INIT = false;
       
        public frmStorageProperties()
        {
            InitializeComponent();
        }

        private void frmStorageProperties_Load(object sender, EventArgs e)
        {
            
            ColumnHeader colHead1;
            this.MyListLocator.Clear();
            this.MyListLocator.Columns.Clear();

            colHead1 = new ColumnHeader();
            colHead1.Text = "ID";
            colHead1.Width = 60;
            this.MyListLocator.Columns.Add(colHead1);

            colHead1 = new ColumnHeader();
            colHead1.Text = "3DLoc";
            colHead1.Width = 80;
            this.MyListLocator.Columns.Add(colHead1);

            colHead1 = new ColumnHeader();
            colHead1.Text = "Descriere";
            colHead1.Width = 180;
            this.MyListLocator.Columns.Add(colHead1);

            this.MyListLocator.GridLines = true;
            this.MyListLocator.FullRowSelect = true;
            this.MyListLocator.View = View.Details;

            LblSelectLocator.Visible = false;
            LoadWH("");
            LOAD_WH = true;

            LoadFromMasterData(0, "");
            //LoadFromStorageProp(0,"");
            rbStatic.Checked = true;
            rbArticol.Checked = true;
            LOAD_FROM_INIT = true;
            
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
            if(mCriteria.Trim()=="")
            {
                mq = "SELECT ScWH,ScName FROM dbo.go_main_wh_def order by ScWH;";
            }
            else
            {
                mq = "SELECT ScWH,ScName FROM dbo.go_main_wh_def where ScWH='"+mCriteria.Trim()+"' order by ScWH;";
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
        private void LoadStorageAreDef(string mWH,string mCriteria)
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
                mq = "SELECT ID,AreaCode,AreaDescription FROM dbo.go_area_def where WHCode='" + mWH.Trim() + "' and AreaCode='"+mCriteria.Trim()+"';";
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
            //CmbSTArea.DataBindings.Clear();
        }

        private void CmbWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ms = "";

            if (LOAD_WH == true && LOAD_FROM_INIT==true)
            {
                ms = ((DataRowView)CmbWH.SelectedItem).Row.ItemArray[0].ToString();   //Row.ItemArray[0];
                LoadStorageAreDef(ms.Trim(),"");
                LblSelectLocator.Visible = true;
                AREA_STORAGE = "";
                LblSelectLocator.Text = "";
                LblSelectLocator.Text = ms + "  ";
            }
        }
        private void Load3DLocator(string mCriteria, long ID_ST_AREA)
        {
            ListViewItem k = null;
            string mq = "";
            long x = 0;
            this.Cursor = Cursors.WaitCursor;
            this.MyListLocator.Items.Clear();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            if (mCriteria.Trim() == "")
            {
                mq = "select ID,LocatorSymbol,DescriptionLocator from dbo.go_locator_def where ID_STORAGE_AREA=" + ID_ST_AREA.ToString() + " order by ID;";
            }
            else
            {
                mq = "select ID,LocatorSymbol,DescriptionLocator from dbo.go_locator_def where LocatorSymbol like '%" + mCriteria.Trim() + "%' and ID_STORAGE_AREA=" + ID_ST_AREA.ToString() + " order by ID;";
            }
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            this.MyListLocator.BeginUpdate();
            while (dataread.Read())
            {
                k = new ListViewItem(MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"));
                this.MyListLocator.Items.Add(k);
                
                x++;
            }
            this.MyListLocator.EndUpdate();
            this.MyListLocator.Refresh();
            dataread.Close();
            mcmd = null;
            this.Cursor = Cursors.Default;


        }

        private void CmbSTArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ms = "";

            try
            {
                ms = ((DataRowView)CmbSTArea.SelectedItem).Row.ItemArray[0].ToString();
                AREA_STORAGE = ((DataRowView)CmbSTArea.SelectedItem).Row.ItemArray[1].ToString();
                Load3DLocator("", long.Parse(ms.Trim()));
                LblSelectLocator.Text = CmbWH.Text + "  " + AREA_STORAGE;
            }
            catch { }
        }

        private void MyListLocator_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                ID_3D_LOCATOR = long.Parse(this.MyListLocator.SelectedItems[0].Text.Trim());
            }
            catch
            {
                MessageBox.Show("CRITIC_ERR ! Invalid ID_3DLOCATOR");
                return;
            }
            //this.CmbSTArea.Text = this.MyListLocator.SelectedItems[0].SubItems[1].Text.Trim();
            this.LblSelectLocator.Text = CmbWH.Text + "  " + AREA_STORAGE + "  " + this.MyListLocator.SelectedItems[0].SubItems[1].Text.Trim();
            this.LblSelectLocator.Refresh();
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

        private void frmStorageProperties_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                MyGlobal.mFrmStorageProperties = null;
            }
            finally
            {
                GC.Collect();
            }
        }
        private void SetColumns4Static()
        {
            ColumnHeader colHead;
            this.MyListView.Clear();
            this.MyListView.Columns.Clear();

            colHead = new ColumnHeader();
            colHead.Text = "ArtCode";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Descr1";
            colHead.Width = 180;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Descr2";
            colHead.Width = 180;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "ExtGroup";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Group";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Clasificare";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Desc.Clasa";
            colHead.Width = 180;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Desc.Categ";
            colHead.Width = 180;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Desc.Grupa";
            colHead.Width = 180;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Desc.Tip";
            colHead.Width = 180;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "User";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Inserat";
            colHead.Width = 160;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Modificat";
            colHead.Width = 160;
            this.MyListView.Columns.Add(colHead);

            this.MyListView.GridLines = true;
            this.MyListView.FullRowSelect = true;
            this.MyListView.View = View.Details;

        }

        private void CmdSalvez_Click(object sender, EventArgs e)
        {
            int Stacking = 0;
            int ByRow = 0;
            string mq = "";
            string IsDinamic = "";
            double qmin = 0;
            double qmax = 0;
            int MyStatus = 0;

            if(CkLock.Checked==true)
            {
                MyStatus = 1;
            }
            else
            {
                MyStatus = 0;
            }
            if (rbDynamic.Checked == true)
            {
                IsDinamic = "True";
            }
            else
            {
                IsDinamic = "False";
            }
            
            if (ID_3D_LOCATOR<=0)
            {
                MessageBox.Show("Nu este selectat nici un locator.");
                return;
            }
            if (txtStack.Text.Trim()!="")
            {
                try
                {
                    Stacking = int.Parse(txtStack.Text.Trim());
                }
                catch { MessageBox.Show("In Stiva este reprezentat numeric."); return; }
            }
            if(txtByRow.Text.Trim()!="")
            {
                try
                {
                    ByRow = int.Parse(txtByRow.Text.Trim());
                }
                catch{MessageBox.Show("Pe Rand este reprezentat numeric.");return;}
            }
            try
            {
                qmin = double.Parse(txtQtyMIN.Text.Trim());
            }
            catch { MessageBox.Show("Canitatea Minima este reprezentata numeric."); return; }
            try
            {
                qmax = double.Parse(txtQtyMAX.Text.Trim());
            }
            catch { MessageBox.Show("Canitatea Maxima este reprezentata numeric"); return; }
            string[] mfunc = new string[3];
            if (rbDynamic.Checked == true)
            {
                if (MyGlobal.IsForUpdate("SELECT IsDynamic, KeyArticle, KeyClass FROM go_article_storage_prop WHERE Key3DLoc=" + ID_3D_LOCATOR.ToString().Trim() + " and IsDynamic='False';", 3, ref mfunc) == true)
                {
                    MessageBox.Show("Locatorul este deja Alocat Static pentru cel putin un Cod Articol " + mfunc[1].Trim() + " .");
                    mfunc = null;
                    return;
                }

            }
            else
            {
                if (MyGlobal.IsForUpdate("SELECT IsDynamic, KeyArticle, KeyClass FROM go_article_storage_prop WHERE Key3DLoc=" + ID_3D_LOCATOR.ToString().Trim() + " and IsDynamic='True';", 3, ref mfunc) == true)
                {
                    MessageBox.Show("Locatorul este deja Alocat Dinamic pentru Clasa " + mfunc[2].Trim() + " .");
                    mfunc = null;
                    return;
                }
            }
             
            if (ID_STORAGE == 0)
            {

                if (rbDynamic.Checked == true)
                {

                    if (MyGlobal.IsForUpdate("SELECT IsDynamic, KeyArticle, KeyClass FROM go_article_storage_prop WHERE KeyClass='" + ID_CLASSIFY.Trim() + "' and IsDynamic='True';", 3, ref mfunc) == true)
                    {
                        MessageBox.Show("Locatorul este deja Configurat pentru Clasa " + ID_CLASSIFY.Trim() + " .");
                        mfunc = null;
                        return;
                    }
                }
                else
                {
                    if (MyGlobal.IsForUpdate("SELECT IsDynamic, KeyArticle, KeyClass FROM go_article_storage_prop WHERE KeyArticle='" + ID_ARTICLE.Trim() + "' and IsDynamic='False';", 3, ref mfunc) == true)
                    {
                        MessageBox.Show("Locatorul este deja Alocat Static pentru Articolul " + ID_ARTICLE.Trim() + " .");
                        mfunc = null;
                        return;
                    }
                    
                }
                if (ID_ARTICLE.Trim() == "" && ID_CLASSIFY.Trim() == "")
                {
                    MessageBox.Show("Nu ati selectat nici un Item din lista(Dinamic/Static).");
                    return;
                }
                if (rbStatic.Checked == true)
                {
                    mq = "INSERT INTO [GoWH].[dbo].[go_article_storage_prop]" +
                    "([IsDynamic]" +
                    ",[KeyArticle]" +
                    ",[KeyClass]" +
                    ",[Key3DLoc]" +
                    ",[QtyMIN]" +
                    ",[QtyMAX]"+
                    ",[OnStack]" +
                    ",[OnRow]" +
                    ",[Status]" +
                    ",[mUser]" +
                    ",[InDate]" +
                    ",[UpToDate])" +
                    "VALUES " +
                    "('" + IsDinamic.Trim() + "'" +
                    ",'" + ID_ARTICLE.Trim() + "'" +
                    ",NULL" +
                    "," + ID_3D_LOCATOR.ToString().Trim() + "" +
                    ","+qmin.ToString().Trim()+""+
                    ","+qmax.ToString().Trim()+""+
                    "," + Stacking.ToString().Trim() + "" +
                    "," + ByRow.ToString().Trim() + "" +
                    "," + MyStatus.ToString().Trim() + "" +
                    ",'" + MyGlobal.MyUserInfo.MyUser.Trim() + "'" +
                    ",getdate()" +
                    ",NULL);";
                }
                else
                {
                    mq = "INSERT INTO [GoWH].[dbo].[go_article_storage_prop]" +
                    "([IsDynamic]" +
                    ",[KeyArticle]" +
                    ",[KeyClass]" +
                    ",[Key3DLoc]" +
                    ",[QtyMIN]" +
                    ",[QtyMAX]" +
                    ",[OnStack]" +
                    ",[OnRow]" +
                    ",[Status]" +
                    ",[mUser]" +
                    ",[InDate]" +
                    ",[UpToDate])" +
                    "VALUES " +
                    "('" + IsDinamic.Trim() + "'" +
                    ",NULL" +
                    ",'" + ID_CLASSIFY.Trim() + "'" +
                    "," + ID_3D_LOCATOR.ToString().Trim() + "" +
                    "," + qmin.ToString().Trim() + "" +
                    "," + qmax.ToString().Trim() + "" +
                    "," + Stacking.ToString().Trim() + "" +
                    "," + ByRow.ToString().Trim() + "" +
                    "," + MyStatus.ToString().Trim() + "" +
                    ",'" + MyGlobal.MyUserInfo.MyUser.Trim() + "'" +
                    ",getdate()" +
                    ",NULL);";
                }
            }
            else
            {
                if (rbStatic.Checked == true)
                {
                    mq = "update go_article_storage_prop set " +
                    "[IsDynamic]='" + IsDinamic.Trim() + "'" +
                    ",[KeyArticle]='" + ID_ARTICLE.Trim() + "'" +
                    ",[KeyClass]=NULL" +
                    ",[Key3DLoc]=" + ID_3D_LOCATOR.ToString().Trim() + "" +
                    ",[QtyMIN]=" + qmin.ToString().Trim() + "" +
                    ",[QtyMAX]=" + qmax.ToString().Trim() + "" +
                    ",[OnStack]=" + Stacking.ToString().Trim() + "" +
                    ",[OnRow]=" + ByRow.ToString().Trim() + "" +
                    ",[Status]=" + MyStatus.ToString().Trim() + "" +
                    ",[mUser]='" + MyGlobal.MyUserInfo.MyUser.Trim() + "'" +
                    ",[UpToDate]=getdate() where ID=" + ID_STORAGE.ToString().Trim() + ";";
                }
                else
                {
                    mq = "update go_article_storage_prop set " +
                    "[IsDynamic]='" + IsDinamic.Trim() + "'" +
                    ",[KeyArticle]=NULL" +
                    ",[KeyClass]='" + ID_CLASSIFY.Trim() + "'" +
                    ",[Key3DLoc]=" + ID_3D_LOCATOR.ToString().Trim() + "" +
                    ",[QtyMIN]=" + qmin.ToString().Trim() + "" +
                    ",[QtyMAX]=" + qmax.ToString().Trim() + "" +
                    ",[OnStack]=" + Stacking.ToString().Trim() + "" +
                    ",[OnRow]=" + ByRow.ToString().Trim() + "" +
                    ",[Status]=" + MyStatus.ToString().Trim() + "" +
                    ",[mUser]='" + MyGlobal.MyUserInfo.MyUser.Trim() + "'" +
                    ",[UpToDate]=getdate() where ID=" + ID_STORAGE.ToString().Trim() + ";";
                }
            }
            if (SaveData(mq) == 0)
            {

                MessageBox.Show("Datele au fost salvate cu succes.");
                ID_3D_LOCATOR = 0;
                ID_ARTICLE = "";
                ID_CLASSIFY = "";
                ID_STORAGE = 0;
                ResetCtrl();
                LoadFromStorageProp(0, "");
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
        private void SetColumns4Article()
        {
            ColumnHeader colHead;
            this.MyListStore.Clear();
            this.MyListStore.Columns.Clear();

            colHead = new ColumnHeader();
            colHead.Text = "ArtCode";
            colHead.Width = 80;
            this.MyListStore.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Descr1";
            colHead.Width = 180;
            this.MyListStore.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Descr2";
            colHead.Width = 180;
            this.MyListStore.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "ExtGroup";
            colHead.Width = 80;
            this.MyListStore.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Group";
            colHead.Width = 80;
            this.MyListStore.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Clasificare";
            colHead.Width = 120;
            this.MyListStore.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Desc.Clasa";
            colHead.Width = 180;
            this.MyListStore.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Desc.Categ";
            colHead.Width = 180;
            this.MyListStore.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Desc.Grupa";
            colHead.Width = 180;
            this.MyListStore.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Desc.Tip";
            colHead.Width = 180;
            this.MyListStore.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "User";
            colHead.Width = 80;
            this.MyListStore.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Inserat";
            colHead.Width = 160;
            this.MyListStore.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Modificat";
            colHead.Width = 160;
            this.MyListStore.Columns.Add(colHead);

            this.MyListStore.GridLines = true;
            this.MyListStore.FullRowSelect = true;
            this.MyListStore.View = View.Details;

        }
        private void SetColumns4Clasify()
        {
            ColumnHeader colHead;
            this.MyListView.Clear();
            this.MyListView.Columns.Clear();

            colHead = new ColumnHeader();
            colHead.Text = "CodClasificare";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "NivelClasificare";
            colHead.Width = 180;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Descr.Clasa";
            colHead.Width = 180;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Descr.Categ.";
            colHead.Width = 180;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Descr.Grupa";
            colHead.Width = 180;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Descr.Tip";
            colHead.Width = 180;
            this.MyListView.Columns.Add(colHead);
            
            this.MyListView.GridLines = true;
            this.MyListView.FullRowSelect = true;
            this.MyListView.View = View.Details;

        }
        private void LoadFromMasterData(int mOption, string mCriteria)
        {
            string mq = "";
            long x = 0;
            ListViewItem k = null;
            SetColumns4Static();
            this.Cursor = Cursors.WaitCursor;
            this.MyListView.Items.Clear();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            System.Data.SqlClient.SqlDataReader dataread = null;
            if (mCriteria.Trim() == "")
            {
                mq = "select StockCode,Description1,Description2,ExtProdGroup,ProductGroup,GoWHClass," +
                    "(select go_article_class.Description from go_article_class where go_article_class.IDCLASS = substring(go_article_masterdata.GoWHClass, 1, 5))," +
                    "(select go_article_category.Description from go_article_category,go_article_class where go_article_class.IDCLASS=substring(go_article_masterdata.GoWHClass,1,5) AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) AND go_article_category.CLASSRef=go_article_class.IDCLASS)," +
                    "(select go_article_group.Description from go_article_group,go_article_class,go_article_category where go_article_class.IDCLASS=substring(go_article_masterdata.GoWHClass, 1, 5) " +
                    "AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) " +
                    "AND go_article_category.CLASSRef=go_article_class.IDCLASS " +
                    "AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) " +
                    "AND go_article_category.CLASSRef=go_article_class.IDCLASS " +
                    "AND go_article_group.IDGROUP = substring(go_article_masterdata.GoWHClass, 11, 5) " +
                    "AND go_article_group.CATEGORYRef=go_article_category.IDCategory)," +
                    "(select go_article_type.Description from go_article_class,go_article_category,go_article_group,go_article_type where go_article_class.IDCLASS=substring(go_article_masterdata.GoWHClass, 1, 5) " +
                    "AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) " +
                    "AND go_article_category.CLASSRef=go_article_class.IDCLASS " +
                    "AND go_article_group.IDGROUP = substring(go_article_masterdata.GoWHClass, 11, 5) " +
                    "AND go_article_group.CATEGORYRef=go_article_category.IDCategory " +
                    "AND go_article_type.IDTYPE = substring(go_article_masterdata.GoWHClass, 16, 5) " +
                    "AND go_article_type.GROUPRef=go_article_group.IDGROUP)," +
                    "mUser,InDate,UpToDate from go_article_masterdata order by StockCode;";
            }
            else
            {
                if (mOption == 1)   //Cod Articol
                {
                    mq = "select StockCode,Description1,Description2,ExtProdGroup,ProductGroup,GoWHClass," +
                        "(select go_article_class.Description from go_article_class where go_article_class.IDCLASS = substring(go_article_masterdata.GoWHClass, 1, 5))," +
                        "(select go_article_category.Description from go_article_category,go_article_class where go_article_class.IDCLASS=substring(go_article_masterdata.GoWHClass,1,5) AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) AND go_article_category.CLASSRef=go_article_class.IDCLASS)," +
                        "(select go_article_group.Description from go_article_group,go_article_class,go_article_category where go_article_class.IDCLASS=substring(go_article_masterdata.GoWHClass, 1, 5) " +
                        "AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) " +
                        "AND go_article_category.CLASSRef=go_article_class.IDCLASS " +
                        "AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) " +
                        "AND go_article_category.CLASSRef=go_article_class.IDCLASS " +
                        "AND go_article_group.IDGROUP = substring(go_article_masterdata.GoWHClass, 11, 5) " +
                        "AND go_article_group.CATEGORYRef=go_article_category.IDCategory)," +
                        "(select go_article_type.Description from go_article_class,go_article_category,go_article_group,go_article_type where go_article_class.IDCLASS=substring(go_article_masterdata.GoWHClass, 1, 5) " +
                        "AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) " +
                        "AND go_article_category.CLASSRef=go_article_class.IDCLASS " +
                        "AND go_article_group.IDGROUP = substring(go_article_masterdata.GoWHClass, 11, 5) " +
                        "AND go_article_group.CATEGORYRef=go_article_category.IDCategory " +
                        "AND go_article_type.IDTYPE = substring(go_article_masterdata.GoWHClass, 16, 5) " +
                        "AND go_article_type.GROUPRef=go_article_group.IDGROUP)," +
                        "mUser,InDate,UpToDate from go_article_masterdata where StockCode like '" + mCriteria.Trim() + "%' order by StockCode;";
                }
                else if (mOption == 2) //Descriere1
                {
                    mq = "select StockCode,Description1,Description2,ExtProdGroup,ProductGroup,GoWHClass," +
                        "(select go_article_class.Description from go_article_class where go_article_class.IDCLASS = substring(go_article_masterdata.GoWHClass, 1, 5))," +
                        "(select go_article_category.Description from go_article_category,go_article_class where go_article_class.IDCLASS=substring(go_article_masterdata.GoWHClass,1,5) AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) AND go_article_category.CLASSRef=go_article_class.IDCLASS)," +
                        "(select go_article_group.Description from go_article_group,go_article_class,go_article_category where go_article_class.IDCLASS=substring(go_article_masterdata.GoWHClass, 1, 5) " +
                        "AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) " +
                        "AND go_article_category.CLASSRef=go_article_class.IDCLASS " +
                        "AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) " +
                        "AND go_article_category.CLASSRef=go_article_class.IDCLASS " +
                        "AND go_article_group.IDGROUP = substring(go_article_masterdata.GoWHClass, 11, 5) " +
                        "AND go_article_group.CATEGORYRef=go_article_category.IDCategory)," +
                        "(select go_article_type.Description from go_article_class,go_article_category,go_article_group,go_article_type where go_article_class.IDCLASS=substring(go_article_masterdata.GoWHClass, 1, 5) " +
                        "AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) " +
                        "AND go_article_category.CLASSRef=go_article_class.IDCLASS " +
                        "AND go_article_group.IDGROUP = substring(go_article_masterdata.GoWHClass, 11, 5) " +
                        "AND go_article_group.CATEGORYRef=go_article_category.IDCategory " +
                        "AND go_article_type.IDTYPE = substring(go_article_masterdata.GoWHClass, 16, 5) " +
                        "AND go_article_type.GROUPRef=go_article_group.IDGROUP)," +
                        "mUser,InDate,UpToDate from go_article_masterdata where Description1 like '%" + mCriteria.Trim() + "%' order by StockCode;";
                }
                else if (mOption == 3) //Gruoup
                {
                    mq = "select StockCode,Description1,Description2,ExtProdGroup,ProductGroup,GoWHClass," +
                        "(select go_article_class.Description from go_article_class where go_article_class.IDCLASS = substring(go_article_masterdata.GoWHClass, 1, 5))," +
                        "(select go_article_category.Description from go_article_category,go_article_class where go_article_class.IDCLASS=substring(go_article_masterdata.GoWHClass,1,5) AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) AND go_article_category.CLASSRef=go_article_class.IDCLASS)," +
                        "(select go_article_group.Description from go_article_group,go_article_class,go_article_category where go_article_class.IDCLASS=substring(go_article_masterdata.GoWHClass, 1, 5) " +
                        "AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) " +
                        "AND go_article_category.CLASSRef=go_article_class.IDCLASS " +
                        "AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) " +
                        "AND go_article_category.CLASSRef=go_article_class.IDCLASS " +
                        "AND go_article_group.IDGROUP = substring(go_article_masterdata.GoWHClass, 11, 5) " +
                        "AND go_article_group.CATEGORYRef=go_article_category.IDCategory)," +
                        "(select go_article_type.Description from go_article_class,go_article_category,go_article_group,go_article_type where go_article_class.IDCLASS=substring(go_article_masterdata.GoWHClass, 1, 5) " +
                        "AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) " +
                        "AND go_article_category.CLASSRef=go_article_class.IDCLASS " +
                        "AND go_article_group.IDGROUP = substring(go_article_masterdata.GoWHClass, 11, 5) " +
                        "AND go_article_group.CATEGORYRef=go_article_category.IDCategory " +
                        "AND go_article_type.IDTYPE = substring(go_article_masterdata.GoWHClass, 16, 5) " +
                        "AND go_article_type.GROUPRef=go_article_group.IDGROUP)," +
                        "mUser,InDate,UpToDate from go_article_masterdata where ProductGroup='" + mCriteria.Trim() + "' order by StockCode;";
                }
                else if (mOption == 4) //Gruoup Extended
                {
                    mq = "select StockCode,Description1,Description2,ExtProdGroup,ProductGroup,GoWHClass," +
                        "(select go_article_class.Description from go_article_class where go_article_class.IDCLASS = substring(go_article_masterdata.GoWHClass, 1, 5))," +
                        "(select go_article_category.Description from go_article_category,go_article_class where go_article_class.IDCLASS=substring(go_article_masterdata.GoWHClass,1,5) AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) AND go_article_category.CLASSRef=go_article_class.IDCLASS)," +
                        "(select go_article_group.Description from go_article_group,go_article_class,go_article_category where go_article_class.IDCLASS=substring(go_article_masterdata.GoWHClass, 1, 5) " +
                        "AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) " +
                        "AND go_article_category.CLASSRef=go_article_class.IDCLASS " +
                        "AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) " +
                        "AND go_article_category.CLASSRef=go_article_class.IDCLASS " +
                        "AND go_article_group.IDGROUP = substring(go_article_masterdata.GoWHClass, 11, 5) " +
                        "AND go_article_group.CATEGORYRef=go_article_category.IDCategory)," +
                        "(select go_article_type.Description from go_article_class,go_article_category,go_article_group,go_article_type where go_article_class.IDCLASS=substring(go_article_masterdata.GoWHClass, 1, 5) " +
                        "AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) " +
                        "AND go_article_category.CLASSRef=go_article_class.IDCLASS " +
                        "AND go_article_group.IDGROUP = substring(go_article_masterdata.GoWHClass, 11, 5) " +
                        "AND go_article_group.CATEGORYRef=go_article_category.IDCategory " +
                        "AND go_article_type.IDTYPE = substring(go_article_masterdata.GoWHClass, 16, 5) " +
                        "AND go_article_type.GROUPRef=go_article_group.IDGROUP)," +
                        "mUser,InDate,UpToDate from go_article_masterdata where ExtProdGroup='" + mCriteria.Trim() + "' order by StockCode;";
                }
                else if (mOption == 5) //Clasificare GoWH
                {
                    mq = "select StockCode,Description1,Description2,ExtProdGroup,ProductGroup,GoWHClass," +
                        "(select go_article_class.Description from go_article_class where go_article_class.IDCLASS = substring(go_article_masterdata.GoWHClass, 1, 5))," +
                        "(select go_article_category.Description from go_article_category,go_article_class where go_article_class.IDCLASS=substring(go_article_masterdata.GoWHClass,1,5) AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) AND go_article_category.CLASSRef=go_article_class.IDCLASS)," +
                        "(select go_article_group.Description from go_article_group,go_article_class,go_article_category where go_article_class.IDCLASS=substring(go_article_masterdata.GoWHClass, 1, 5) " +
                        "AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) " +
                        "AND go_article_category.CLASSRef=go_article_class.IDCLASS " +
                        "AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) " +
                        "AND go_article_category.CLASSRef=go_article_class.IDCLASS " +
                        "AND go_article_group.IDGROUP = substring(go_article_masterdata.GoWHClass, 11, 5) " +
                        "AND go_article_group.CATEGORYRef=go_article_category.IDCategory)," +
                        "(select go_article_type.Description from go_article_class,go_article_category,go_article_group,go_article_type where go_article_class.IDCLASS=substring(go_article_masterdata.GoWHClass, 1, 5) " +
                        "AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) " +
                        "AND go_article_category.CLASSRef=go_article_class.IDCLASS " +
                        "AND go_article_group.IDGROUP = substring(go_article_masterdata.GoWHClass, 11, 5) " +
                        "AND go_article_group.CATEGORYRef=go_article_category.IDCategory " +
                        "AND go_article_type.IDTYPE = substring(go_article_masterdata.GoWHClass, 16, 5) " +
                        "AND go_article_type.GROUPRef=go_article_group.IDGROUP)," +
                        "mUser,InDate,UpToDate from go_article_masterdata where GoWHClass like '" + mCriteria.Trim() + "%' order by GoWHClass;";
                }
                else if(mOption==6)
                {
                    mq = "select StockCode,Description1,Description2,ExtProdGroup,ProductGroup,GoWHClass," +
                        "(select go_article_class.Description from go_article_class where go_article_class.IDCLASS = substring(go_article_masterdata.GoWHClass, 1, 5))," +
                        "(select go_article_category.Description from go_article_category,go_article_class where go_article_class.IDCLASS=substring(go_article_masterdata.GoWHClass,1,5) AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) AND go_article_category.CLASSRef=go_article_class.IDCLASS)," +
                        "(select go_article_group.Description from go_article_group,go_article_class,go_article_category where go_article_class.IDCLASS=substring(go_article_masterdata.GoWHClass, 1, 5) " +
                        "AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) " +
                        "AND go_article_category.CLASSRef=go_article_class.IDCLASS " +
                        "AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) " +
                        "AND go_article_category.CLASSRef=go_article_class.IDCLASS " +
                        "AND go_article_group.IDGROUP = substring(go_article_masterdata.GoWHClass, 11, 5) " +
                        "AND go_article_group.CATEGORYRef=go_article_category.IDCategory)," +
                        "(select go_article_type.Description from go_article_class,go_article_category,go_article_group,go_article_type where go_article_class.IDCLASS=substring(go_article_masterdata.GoWHClass, 1, 5) " +
                        "AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) " +
                        "AND go_article_category.CLASSRef=go_article_class.IDCLASS " +
                        "AND go_article_group.IDGROUP = substring(go_article_masterdata.GoWHClass, 11, 5) " +
                        "AND go_article_group.CATEGORYRef=go_article_category.IDCategory " +
                        "AND go_article_type.IDTYPE = substring(go_article_masterdata.GoWHClass, 16, 5) " +
                        "AND go_article_type.GROUPRef=go_article_group.IDGROUP)," +
                        "go_article_storage_prop.mUser,go_article_storage_prop.InDate,go_article_storage_prop.UpToDate "+
                        "from go_article_masterdata,go_article_storage_prop where go_article_storage_prop.Key3DLoc=" + mCriteria.Trim() + " AND go_article_storage_prop.KeyArticle=go_article_masterdata.StockCode order by go_article_masterdata.StockCode;";
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
            this.MyListView.BeginUpdate();
            while (dataread.Read())
            {

                if (MY_CANCEL == true)
                {
                    goto MYEND;
                }
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
                this.MyListView.Items.Add(k);
                
                Application.DoEvents();
                x++;

            }
        MYEND:
            this.MyListView.EndUpdate();
            this.MyListView.Refresh();
            MY_CANCEL = false;
            LblTotalInList.Text = x.ToString().Trim();
            LblTotalInList.Refresh();
            try
            {
                dataread.Close();
            }
            catch { };
            mcmd = null;
            this.Cursor = Cursors.Default;
        }
        private void LoadFromStorageProp(int mOption, string mCriteria)
        {
            
            string mq = "";
            long x = 0;
            ListViewItem k = null;
            SetColStorage4Static();
            this.Cursor = Cursors.WaitCursor;
            this.MyListStore.Items.Clear();
            
            if (rbStatic.Checked == true)
            {
                
                if (mCriteria.Trim() == "")
                {

                    mq = "SELECT go_article_storage_prop.ID, go_article_storage_prop.IsDynamic, go_article_storage_prop.KeyArticle," +
                        "go_area_def.WHCode,go_area_def.AreaCode, go_locator_def.LocatorSymbol,go_article_storage_prop.QtyMIN,go_article_storage_prop.QtyMAX," +
                        "go_article_storage_prop.OnStack," +
                        "go_article_storage_prop.OnRow, go_article_storage_prop.Status, go_article_storage_prop.mUser, go_article_storage_prop.InDate," +
                        "go_article_storage_prop.UpToDate " +
                        "FROM go_main_wh_def " +
                        "INNER JOIN go_area_def ON go_main_wh_def.ScWH = go_area_def.WHCode " +
                        "INNER JOIN go_locator_def ON go_area_def.ID = go_locator_def.ID_STORAGE_AREA " +
                        "INNER JOIN go_article_storage_prop ON go_locator_def.ID = go_article_storage_prop.Key3DLoc " +
                        "INNER JOIN go_article_masterdata ON go_article_storage_prop.KeyArticle = go_article_masterdata.StockCode;";
                }
                else
                {
                    if (mOption == 1)   //Cod Articol
                    {
                        mq = "SELECT go_article_storage_prop.ID, go_article_storage_prop.IsDynamic, go_article_storage_prop.KeyArticle," +
                        "go_area_def.WHCode,go_area_def.AreaCode, go_locator_def.LocatorSymbol,go_article_storage_prop.QtyMIN,go_article_storage_prop.QtyMAX," +
                        "go_article_storage_prop.OnStack," +
                        "go_article_storage_prop.OnRow, go_article_storage_prop.Status, go_article_storage_prop.mUser, go_article_storage_prop.InDate," +
                        "go_article_storage_prop.UpToDate " +
                        "FROM go_main_wh_def " +
                        "INNER JOIN go_area_def ON go_main_wh_def.ScWH = go_area_def.WHCode " +
                        "INNER JOIN go_locator_def ON go_area_def.ID = go_locator_def.ID_STORAGE_AREA " +
                        "INNER JOIN go_article_storage_prop ON go_locator_def.ID = go_article_storage_prop.Key3DLoc " +
                        "INNER JOIN go_article_masterdata ON go_article_storage_prop.KeyArticle='"+mCriteria.Trim()+"' AND go_article_storage_prop.KeyArticle = go_article_masterdata.StockCode;"; 
                    }
                    else if (mOption == 2) //Descriere1
                    {
                        mq = "SELECT go_article_storage_prop.ID, go_article_storage_prop.IsDynamic, go_article_storage_prop.KeyArticle," +
                        "go_area_def.WHCode,go_area_def.AreaCode, go_locator_def.LocatorSymbol,go_article_storage_prop.QtyMIN,go_article_storage_prop.QtyMAX," +
                        "go_article_storage_prop.OnStack," +
                        "go_article_storage_prop.OnRow, go_article_storage_prop.Status, go_article_storage_prop.mUser, go_article_storage_prop.InDate," +
                        "go_article_storage_prop.UpToDate " +
                        "FROM go_main_wh_def " +
                        "INNER JOIN go_area_def ON go_main_wh_def.ScWH = go_area_def.WHCode " +
                        "INNER JOIN go_locator_def ON go_area_def.ID = go_locator_def.ID_STORAGE_AREA " +
                        "INNER JOIN go_article_storage_prop ON go_locator_def.ID = go_article_storage_prop.Key3DLoc " +
                        "INNER JOIN go_article_masterdata ON go_article_storage_prop.KeyArticle = go_article_masterdata.StockCode and go_article_masterdata.Description1 LIKE '"+mCriteria.Trim()+"%';"; 
                    }
                    else if (mOption == 3) //Gruoup
                    {
                        mq = "SELECT go_article_storage_prop.ID, go_article_storage_prop.IsDynamic, go_article_storage_prop.KeyArticle," +
                        "go_area_def.WHCode,go_area_def.AreaCode, go_locator_def.LocatorSymbol,go_article_storage_prop.QtyMIN,go_article_storage_prop.QtyMAX," +
                        "go_article_storage_prop.OnStack," +
                        "go_article_storage_prop.OnRow, go_article_storage_prop.Status, go_article_storage_prop.mUser, go_article_storage_prop.InDate," +
                        "go_article_storage_prop.UpToDate " +
                        "FROM go_main_wh_def " +
                        "INNER JOIN go_area_def ON go_main_wh_def.ScWH = go_area_def.WHCode " +
                        "INNER JOIN go_locator_def ON go_area_def.ID = go_locator_def.ID_STORAGE_AREA " +
                        "INNER JOIN go_article_storage_prop ON go_locator_def.ID = go_article_storage_prop.Key3DLoc " +
                        "INNER JOIN go_article_masterdata ON go_article_storage_prop.KeyArticle = go_article_masterdata.StockCode and go_article_masterdata.ProductGroup='" + mCriteria.Trim() + "';"; 
                    }
                    else if (mOption == 4) //Gruoup Extended
                    {
                        mq = "SELECT go_article_storage_prop.ID, go_article_storage_prop.IsDynamic, go_article_storage_prop.KeyArticle," +
                        "go_area_def.WHCode,go_area_def.AreaCode, go_locator_def.LocatorSymbol,go_article_storage_prop.QtyMIN,go_article_storage_prop.QtyMAX," +
                        "go_article_storage_prop.OnStack," +
                        "go_article_storage_prop.OnRow, go_article_storage_prop.Status, go_article_storage_prop.mUser, go_article_storage_prop.InDate," +
                        "go_article_storage_prop.UpToDate " +
                        "FROM go_main_wh_def " +
                        "INNER JOIN go_area_def ON go_main_wh_def.ScWH = go_area_def.WHCode " +
                        "INNER JOIN go_locator_def ON go_area_def.ID = go_locator_def.ID_STORAGE_AREA " +
                        "INNER JOIN go_article_storage_prop ON go_locator_def.ID = go_article_storage_prop.Key3DLoc " +
                        "INNER JOIN go_article_masterdata ON go_article_storage_prop.KeyArticle = go_article_masterdata.StockCode and go_article_masterdata.ExtProdGroup='" + mCriteria.Trim() + "';"; 
                    }
                    else if (mOption == 5) //Clasificare GoWH
                    {
                        mq = "SELECT go_article_storage_prop.ID, go_article_storage_prop.IsDynamic, go_article_storage_prop.KeyArticle," +
                        "go_area_def.WHCode,go_area_def.AreaCode, go_locator_def.LocatorSymbol,go_article_storage_prop.QtyMIN,go_article_storage_prop.QtyMAX," +
                        "go_article_storage_prop.OnStack," +
                        "go_article_storage_prop.OnRow, go_article_storage_prop.Status, go_article_storage_prop.mUser, go_article_storage_prop.InDate," +
                        "go_article_storage_prop.UpToDate " +
                        "FROM go_main_wh_def " +
                        "INNER JOIN go_area_def ON go_main_wh_def.ScWH = go_area_def.WHCode " +
                        "INNER JOIN go_locator_def ON go_area_def.ID = go_locator_def.ID_STORAGE_AREA " +
                        "INNER JOIN go_article_storage_prop ON go_locator_def.ID = go_article_storage_prop.Key3DLoc " +
                        "INNER JOIN go_article_masterdata ON go_article_storage_prop.KeyArticle = go_article_masterdata.StockCode and go_article_masterdata.GoWHClass='" + mCriteria.Trim() + "';"; 
                    }
                }
            }
            else
            {
                if (mCriteria.Trim() == "")
                {
                    mq = "SELECT go_article_storage_prop.ID, go_article_storage_prop.IsDynamic, go_article_storage_prop.KeyClass,"+ 
                    "go_main_wh_def.ScWH, go_area_def.AreaCode,"+
                    "go_locator_def.LocatorSymbol,go_article_storage_prop.QtyMIN,go_article_storage_prop.QtyMAX, go_article_storage_prop.OnStack,go_article_storage_prop.OnRow,go_article_storage_prop.Status, go_article_storage_prop.mUser," + 
                    "go_article_storage_prop.InDate, go_article_storage_prop.UpToDate "+
                    "FROM go_main_wh_def INNER JOIN "+
                    "go_area_def ON go_main_wh_def.ScWH = go_area_def.WHCode INNER JOIN "+
                    "go_locator_def ON go_area_def.ID = go_locator_def.ID_STORAGE_AREA INNER JOIN "+
                    "go_article_storage_prop ON go_locator_def.ID = go_article_storage_prop.Key3DLoc "+
                    "and go_article_storage_prop.KeyArticle IS NULL;";
                }
                else
                {
                    if (mOption == 5) //Clasificare GoWH
                    {
                        mq = mq = "SELECT go_article_storage_prop.ID, go_article_storage_prop.IsDynamic, go_article_storage_prop.KeyClass," +
                        "go_main_wh_def.ScWH, go_area_def.AreaCode," +
                        "go_locator_def.LocatorSymbol,go_article_storage_prop.QtyMIN,go_article_storage_prop.QtyMAX, go_article_storage_prop.OnStack,go_article_storage_prop.OnRow,go_article_storage_prop.Status, go_article_storage_prop.mUser," +
                        "go_article_storage_prop.InDate, go_article_storage_prop.UpToDate " +
                        "FROM go_main_wh_def INNER JOIN " +
                        "go_area_def ON go_main_wh_def.ScWH = go_area_def.WHCode INNER JOIN " +
                        "go_locator_def ON go_area_def.ID = go_locator_def.ID_STORAGE_AREA INNER JOIN " +
                        "go_article_storage_prop ON go_locator_def.ID = go_article_storage_prop.Key3DLoc " +
                        "and go_article_storage_prop.KeyClass='" + mCriteria.Trim() + "' order by go_article_storage_prop.KeyClass;"; 
                    }
                    else
                    {
                        return;
                    }
                }
            }
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            System.Data.SqlClient.SqlDataReader dataread = null;
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
            this.MyListStore.BeginUpdate();
            while (dataread.Read())
            {

                if (MY_CANCEL == true)
                {
                    goto MYEND;
                }
                k = new ListViewItem(MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"));
                if(MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'")=="False")
                {
                    k.SubItems.Add("Static");    
                }
                else
                {
                    k.SubItems.Add("Dinamic");        
                }
                
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[5].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[8].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[9].ToString().Trim(), "'"));
                if (MyGlobal.Srch2Escape(dataread[10].ToString().Trim(), "'") == "0")
                {
                    k.SubItems.Add("LIBER");
                }
                else
                {
                    k.SubItems.Add("BLOCAT");
                }
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[11].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[12].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[13].ToString().Trim(), "'"));

                this.MyListStore.Items.Add(k);
                
                Application.DoEvents();
                x++;

            }
        MYEND:
            this.MyListStore.EndUpdate();
            this.MyListStore.Refresh();
            MY_CANCEL = false;
            
            try
            {
                dataread.Close();
            }
            catch { };
            mcmd = null;
            this.Cursor = Cursors.Default;
        }
        private void SetColStorage4Static()
        {
            ColumnHeader colHead;
            this.MyListStore.Clear();
            this.MyListStore.Columns.Clear();

            colHead = new ColumnHeader();
            colHead.Text = "ID";
            colHead.Width = 60;
            this.MyListStore.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "D/S";
            colHead.Width = 80;
            this.MyListStore.Columns.Add(colHead);
            if (rbStatic.Checked == true)
            {
                colHead = new ColumnHeader();
                colHead.Text = "Articol";
                colHead.Width = 180;
                this.MyListStore.Columns.Add(colHead);
            }
            else
            {
                colHead = new ColumnHeader();
                colHead.Text = "Clasificare";
                colHead.Width = 180;
                this.MyListStore.Columns.Add(colHead);
            }
            colHead = new ColumnHeader();
            colHead.Text = "Depozit";
            colHead.Width = 120;
            this.MyListStore.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Zona Stocare";
            colHead.Width = 120;
            this.MyListStore.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Locator";
            colHead.Width = 120;
            this.MyListStore.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "QtyMIN";
            colHead.Width = 80;
            this.MyListStore.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "QtyMAX";
            colHead.Width = 80;
            this.MyListStore.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Stivuire";
            colHead.Width = 80;
            this.MyListStore.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Randuri";
            colHead.Width = 80;
            this.MyListStore.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Status";
            colHead.Width = 80;
            this.MyListStore.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "User";
            colHead.Width = 120;
            this.MyListStore.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Inserare";
            colHead.Width = 120;
            this.MyListStore.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Modificare";
            colHead.Width = 120;
            this.MyListStore.Columns.Add(colHead);

            this.MyListStore.GridLines = true;
            this.MyListStore.FullRowSelect = true;
            this.MyListStore.View = View.Details;
        }
        private void MyListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                MY_CANCEL = true;
                ResetCtrl();
                
            }
        }
        private void LoadMyClass(int mOption,string mCriteria)
        {
            string mq = "";
            long x = 0;
            ListViewItem k = null;
            SetColumns4Clasify();
            this.Cursor = Cursors.WaitCursor;
            this.MyListView.Items.Clear();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            System.Data.SqlClient.SqlDataReader dataread = null;
            if (mCriteria.Trim() == "")
            {
                mq = "SELECT CASE WHEN go_article_category.IDCategory IS NULL THEN go_article_class.IDCLASS "+
                    "WHEN go_article_group.IDGROUP IS NULL THEN go_article_class.IDCLASS+go_article_category.IDCategory "+
                    "WHEN go_article_type.IDTYPE IS NULL THEN go_article_class.IDCLASS+go_article_category.IDCategory+go_article_group.IDGROUP "+
                    "ELSE go_article_class.IDCLASS+go_article_category.IDCategory+go_article_group.IDGROUP+go_article_type.IDTYPE "+
                    "END as CodClasa,"+
                    "CASE WHEN go_article_category.IDCategory IS NULL THEN 'CLASA' "+
                    "WHEN go_article_group.IDGROUP IS NULL THEN 'CATEGORIE' "+
                    "WHEN go_article_type.IDTYPE IS NULL THEN 'GRUPA' "+
                    "ELSE 'TIP' "+
                    "END as NivelClasificare,"+
                    "go_article_class.Description,"+
                    "go_article_category.Description,"+
                    "go_article_group.Description,"+
                    "go_article_type.Description "+
                    "FROM go_article_class "+
                    "LEFT JOIN go_article_category ON go_article_category.CLASSRef=go_article_class.IDCLASS "+
                    "LEFT JOIN go_article_group ON go_article_group.CATEGORYRef=go_article_category.IDCategory "+
                    "LEFT JOIN go_article_type ON go_article_type.GROUPRef=go_article_group.IDGROUP "+
                    "order by CodClasa;";
            }
            else
            {
                if (mOption == 0)
                {
                    mq = "SELECT " +
                     "CASE WHEN go_article_category.IDCategory IS NULL THEN go_article_class.IDCLASS " +
                     "WHEN go_article_group.IDGROUP IS NULL THEN go_article_class.IDCLASS+go_article_category.IDCategory " +
                     "WHEN go_article_type.IDTYPE IS NULL THEN go_article_class.IDCLASS+go_article_category.IDCategory+go_article_group.IDGROUP " +
                     "ELSE go_article_class.IDCLASS+go_article_category.IDCategory+go_article_group.IDGROUP+go_article_type.IDTYPE " +
                     "END as CodClasa," +
                     "CASE WHEN go_article_category.IDCategory IS NULL THEN 'CLASA' " +
                     "WHEN go_article_group.IDGROUP IS NULL THEN 'CATEGORIE' " +
                     "WHEN go_article_type.IDTYPE IS NULL THEN 'GRUPA' " +
                     "ELSE 'TIP' " +
                     "END as NivelClasificare," +
                     "go_article_class.Description," +
                     "go_article_category.Description," +
                     "go_article_group.Description," +
                     "go_article_type.Description " +
                     "FROM go_article_class " +
                     "LEFT JOIN go_article_category ON go_article_category.CLASSRef=go_article_class.IDCLASS " +
                     "LEFT JOIN go_article_group ON go_article_group.CATEGORYRef=go_article_category.IDCategory " +
                     "LEFT JOIN go_article_type ON go_article_type.GROUPRef=go_article_group.IDGROUP " +
                     "where " +
                     "CASE WHEN go_article_category.IDCategory IS NULL THEN go_article_class.IDCLASS " +
                     "WHEN go_article_group.IDGROUP IS NULL THEN go_article_class.IDCLASS+go_article_category.IDCategory " +
                     "WHEN go_article_type.IDTYPE IS NULL THEN go_article_class.IDCLASS+go_article_category.IDCategory+go_article_group.IDGROUP " +
                     "ELSE go_article_class.IDCLASS+go_article_category.IDCategory+go_article_group.IDGROUP+go_article_type.IDTYPE " +
                     "END like '" + mCriteria.Trim() + "%' order by CodClasa;";
                }
                else
                {
                    mq = "SELECT " +
                     "CASE WHEN go_article_category.IDCategory IS NULL THEN go_article_class.IDCLASS " +
                     "WHEN go_article_group.IDGROUP IS NULL THEN go_article_class.IDCLASS+go_article_category.IDCategory " +
                     "WHEN go_article_type.IDTYPE IS NULL THEN go_article_class.IDCLASS+go_article_category.IDCategory+go_article_group.IDGROUP " +
                     "ELSE go_article_class.IDCLASS+go_article_category.IDCategory+go_article_group.IDGROUP+go_article_type.IDTYPE " +
                     "END as CodClasa," +
                     "CASE WHEN go_article_category.IDCategory IS NULL THEN 'CLASA' " +
                     "WHEN go_article_group.IDGROUP IS NULL THEN 'CATEGORIE' " +
                     "WHEN go_article_type.IDTYPE IS NULL THEN 'GRUPA' " +
                     "ELSE 'TIP' " +
                     "END as NivelClasificare," +
                     "go_article_class.Description," +
                     "go_article_category.Description," +
                     "go_article_group.Description," +
                     "go_article_type.Description " +
                     "FROM go_article_class " +
                     "LEFT JOIN go_article_category ON go_article_category.CLASSRef=go_article_class.IDCLASS " +
                     "LEFT JOIN go_article_group ON go_article_group.CATEGORYRef=go_article_category.IDCategory " +
                     "LEFT JOIN go_article_type ON go_article_type.GROUPRef=go_article_group.IDGROUP " +
                     "where " +
                     "CASE WHEN go_article_category.IDCategory IS NULL THEN go_article_class.IDCLASS " +
                     "WHEN go_article_group.IDGROUP IS NULL THEN go_article_class.IDCLASS+go_article_category.IDCategory " +
                     "WHEN go_article_type.IDTYPE IS NULL THEN go_article_class.IDCLASS+go_article_category.IDCategory+go_article_group.IDGROUP " +
                     "ELSE go_article_class.IDCLASS+go_article_category.IDCategory+go_article_group.IDGROUP+go_article_type.IDTYPE " +
                     "END='" + mCriteria.Trim() + "' order by CodClasa;";
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
            while (dataread.Read())
            {

                if (MY_CANCEL == true)
                {
                    goto MYEND;
                }
                k = new ListViewItem(MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[5].ToString().Trim(), "'"));
                
                this.MyListView.Items.Add(k);
                
                Application.DoEvents();
                x++;

            }
        MYEND:
            this.MyListView.Refresh();
            MY_CANCEL = false;
            LblTotalInList.Text = x.ToString().Trim();
            LblTotalInList.Refresh();
            try
            {
                dataread.Close();
            }
            catch { };
            mcmd = null;
            this.Cursor = Cursors.Default;
        }

        private void rbDynamic_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rbStatic_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void CmdCauta_Click(object sender, EventArgs e)
        {
            if (rbStatic.Checked == true)
            {
                if (txtCauta.Text.Trim() == "")
                {
                    LoadFromMasterData(0, "");
                }
                else
                {

                    if (rbArticol.Checked == true)
                    {
                        LoadFromMasterData(1, txtCauta.Text.Trim());
                    }
                    else if (rbDenumireArticol.Checked == true)
                    {
                        LoadFromMasterData(2, txtCauta.Text.Trim());
                    }
                    else if (rbGroup.Checked == true)
                    {
                        LoadFromMasterData(3, txtCauta.Text.Trim());
                    }
                    else if (rbExtendGroup.Checked == true)
                    {
                        LoadFromMasterData(4, txtCauta.Text.Trim());
                    }
                    else if (rbClasificare.Checked == true)
                    {
                        LoadFromMasterData(5, txtCauta.Text.Trim());
                    }

                }
            }
            else
            {
                if (txtCauta.Text.Trim() == "")
                {
                    this.LoadMyClass(0,"");
                }
                else
                {
                    this.LoadMyClass(0,this.txtCauta.Text.Trim());
                }
            }
        }

        private void rbStatic_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbStatic.Checked == true)
            {
                
                rbArticol.Enabled = true;
                rbDenumireArticol.Enabled = true;
                rbExtendGroup.Enabled = true;
                rbGroup.Enabled = true;
                rbClasificare.Enabled = true;
                this.LoadFromMasterData(0, "");
                LoadFromStorageProp(0, "");
                ResetCtrl();
            }
        }

        private void rbDynamic_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbDynamic.Checked == true)
            {
                rbArticol.Enabled = false;
                rbDenumireArticol.Enabled = false;
                rbExtendGroup.Enabled = false;
                rbGroup.Enabled = false;
                rbClasificare.Enabled = false;
                LoadMyClass(0,"");
                LoadFromStorageProp(0, "");
                ResetCtrl();
            }
        }

        private void MyListStore_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                ID_STORAGE = long.Parse(this.MyListStore.SelectedItems[0].Text.Trim());
            }
            catch
            {
                MessageBox.Show("CRITIC_ERR ! Invalid ID_3DLOCATOR");
                return;
            }
            
            //LoadWH(MyListStore.SelectedItems[0].SubItems[3].Text.Trim());
            CmbWH.Text = MyListStore.SelectedItems[0].SubItems[3].Text.Trim();
            CmbWH.Refresh();
            LoadStorageAreDef(CmbWH.Text.Trim(), MyListStore.SelectedItems[0].SubItems[4].Text.Trim());
            int i = 0;
            for (i = 0; i < MyListLocator.Items.Count; i++)
            {
                if (MyListLocator.Items[i].SubItems[1].Text.Trim() == MyListStore.SelectedItems[0].SubItems[5].Text.Trim())
                {
                    try
                    {
                        MyListLocator.Items[i].Selected = true;
                    }
                    catch { }
                    MouseEventArgs erg = new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);
                    MyListLocator_MouseDoubleClick(MyListLocator, erg);
                    erg = null;
                    break;
                }
            }
            MyListLocator.Refresh();
            MyListLocator.Focus();


            double qmin = 0;
            double qmax = 0;
            try
            {
                qmin = double.Parse(MyListStore.SelectedItems[0].SubItems[6].Text.Trim());
            }
            catch
            {
            }
            txtQtyMIN.Text=qmin.ToString().Trim();
            try
            {
                qmax = double.Parse(MyListStore.SelectedItems[0].SubItems[7].Text.Trim());
            }
            catch { }
            txtQtyMAX.Text = qmax.ToString().Trim();
            txtStack.Text = MyListStore.SelectedItems[0].SubItems[8].Text.Trim();
            txtByRow.Text = MyListStore.SelectedItems[0].SubItems[9].Text.Trim();
            if (MyListStore.SelectedItems[0].SubItems[10].Text.Trim() == "LIBER")
            {
                CkLock.Checked = false;
            }
            else
            {
                CkLock.Checked = true;
            }
            
            if (rbStatic.Checked == true)
            {
                ID_ARTICLE = MyListStore.SelectedItems[0].SubItems[2].Text.Trim();
                if (CkShowMeProduct.Checked == true)
                {
                    LoadFromMasterData(6, ID_3D_LOCATOR.ToString().Trim());
                }
            }
            else
            {
                ID_CLASSIFY = MyListStore.SelectedItems[0].SubItems[2].Text.Trim();
                if (CkShowMeProduct.Checked == true)
                {
                    LoadMyClass(1, MyListStore.SelectedItems[0].SubItems[2].Text.Trim());
                }
           }
            
            //LoadMyClass
        }
        private void MyListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string mSelect="";
            if (rbStatic.Checked == true)
            {
                ID_ARTICLE = this.MyListView.SelectedItems[0].Text.Trim();
                mSelect=ID_ARTICLE;
                
            }
            else
            {
                ID_CLASSIFY = this.MyListView.SelectedItems[0].Text.Trim();
                mSelect=ID_CLASSIFY;
            }
            MessageBox.Show("Ai selectat item " +mSelect);
            
        }

        private void frmStorageProperties_Activated(object sender, EventArgs e)
        {
            
        }

        private void MyListLocator_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue==27)
            {

                ResetCtrl(); 
            }
        }
        private void ResetCtrl()
        {
            CmbSTArea.Text = "";
            this.LblSelectLocator.Text = "";
            ID_3D_LOCATOR = 0;
            AREA_STORAGE = "";
            ID_ARTICLE = "";
            ID_CLASSIFY = "";
            ID_STORAGE = 0;
            txtByRow.Text = "0";
            txtStack.Text = "0";
            txtQtyMAX.Text = "0";
            txtQtyMIN.Text = "0";
            MyListLocator.Items.Clear();
            MyListLocator.Refresh();
            LOAD_FROM_INIT = false;
            LoadWH("");
            LOAD_FROM_INIT = true;
        }

        private void copiazaInClipBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = 0;
            int z = 0;
            string s = "";

            ListView mList = null;
            if (MyListView.ContainsFocus == true)
            {
                mList = this.MyListView;
            }
            else 
            {
                mList = this.MyListStore;
            }


            i = mList.SelectedIndices.Count;
            
            this.Cursor = Cursors.WaitCursor;
            Clipboard.Clear();
            for (i = 0; i < mList.Items.Count; i++)
            {
                if (mList.Items[i].Selected == true)
                {
                    s += mList.Items[i].Text.Trim() + "\t";
                    for (z = 1; z < mList.Columns.Count ; z++)
                    {
                        if (mList.Items[i].SubItems[z].Text.Trim() != "" || mList.Items[i].SubItems[z].Text.Trim() != null)
                        {
                            s += mList.Items[i].SubItems[z].Text.Trim() + "\t";
                        }
                    }
                    s += "\r\n";
                }
            }
            Clipboard.SetDataObject(s);
            this.Cursor = Cursors.Default;
            GC.Collect();
        }

        private void MyListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                LVMenu.Show(MyListView, new Point(e.X + 15, e.Y));
                if (rbDynamic.Checked == true)
                {
                    LVMenu.Items[1].Visible = true;
                    LVMenu.Items[1].Text = "Arata-mi Articolele din Clasa " + this.MyListView.SelectedItems[0].Text.Trim();
                }
                else
                {
                    LVMenu.Items[1].Visible = false;
                }
            }
        }

        private void MyListStore_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                LVMenu.Show(MyListStore, new Point(e.X + 15, e.Y));
                LVMenu.Items[1].Visible = false;
            }
        }

        private void aratamiArticoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            LoadFromMasterData(5, this.MyListView.SelectedItems[0].Text.Trim());
            
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

        private void txtStack_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {

                ResetCtrl();
            }
        }

        private void txtByRow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {

                ResetCtrl();
            }
        }

        private void CkLock_KeyDown(object sender, KeyEventArgs e)
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

        private void rbStatic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {

                ResetCtrl();
            }
        }

        private void rbDynamic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {

                ResetCtrl();
            }
        }

        private void CkShowMeProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {

                ResetCtrl();
            }
        }

        private void rbArticol_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {

                ResetCtrl();
            }
        }

        private void rbDenumireArticol_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {

                ResetCtrl();
            }
        }

        private void rbGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {

                ResetCtrl();
            }
        }

        private void frmStorageProperties_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == 27)
            {

                ResetCtrl();
            }
        }

        private void MyListStore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {

                ResetCtrl();
            }
        }

    }
}