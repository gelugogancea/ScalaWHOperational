using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoWHMgmAdmin
{
    public partial class frmClassification : Form
    {
        
        private string ID_ARTICLE = "";
        private long COUNT_CLASS=0;
        private long COUNT_CATEGORY = 0;
        private long COUNT_GROUP = 0;
        private long COUNT_TYPE = 0;
        private bool MY_CANCEL = false;

        public frmClassification()
        {
            InitializeComponent();
        }

        private void frmClassification_Load(object sender, EventArgs e)
        {
            rbCodArticol.Checked = true;
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

            LoadMyClass();
            LoadFromMasterData(0, "");
            try
            {
                CmbCategory.SelectedIndex = 1;
            }
            catch { }
            
            ID_ARTICLE = "";
           
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

        private void frmClassification_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                MyGlobal.mFrmClassification = null;
            }
            finally
            {
                GC.Collect();
            }
        }

        private void CmbClass_KeyDown(object sender, KeyEventArgs e)
        {
            string mq = "";
            bool IfExist = false;
            if(e.KeyValue==13)
            {
                if(CmbClass.Text.Trim()=="")
                {
                    MessageBox.Show("Trebuie specificata Clasa");
                    return;
                }

                CmbClass.Text=FillZero(CmbClass.Text.Trim());
                string[] mres = new string[1];
                IfExist = MyGlobal.IsForUpdate("SELECT IDCLASS FROM go_article_class where IDCLASS like '" + CmbClass.Text.Trim() + "%' order by IDCLASS;", 1, ref mres);
                mres = null;
                if (IfExist == false)
                {
                    
                    if (IfExist == true)
                    {
                        MessageBox.Show("Deja exista cel putin o Clasa care contine " + CmbClass.Text.Trim() + " ");
                        return;
                    }
                    mq = "INSERT INTO go_article_class (IDCLASS,DispCaracteristic,ScRef,Description,mUser,InDate,UpToDate) " +
                        "VALUES ('" + CmbClass.Text.Trim().Substring(0, 5) + "',5,NULL,'" + this.txtClassDesc.Text.Trim() + "','" + MyGlobal.MyUserInfo.MyUser.Trim() + "',getdate(),NULL);";
                }
                else
                {
                    mq = "update go_article_class set DispCaracteristic=" + txtCharNr.Text.Trim() + ",ScRef=NULL,Description='" + txtClassDesc.Text.Trim() + "',mUser='" + MyGlobal.MyUserInfo.MyUser.Trim() + "',UpToDate=getdate() where IDCLASS='" + this.CmbClass.Text.Trim() + "';";
                }
                if (SaveData(mq) == 0)
                {
                    
                    MessageBox.Show("Datele au fost salvate cu succes.");
                    this.LoadMyCategory("");
                    this.LoadMyGroup("");
                    this.LoadMyType("");
                    CmbCategory.Text = "";
                    txtCategoryDesc.Text = "";
                    CmbGroup.Text = "";
                    txtGroupDesc.Text = "";
                    CmbType.Text = "";
                    txtTypeDesc.Text  = "";
                    LoadMyClass();
                }
                else
                {
                    MessageBox.Show("Nu pot salva date.");
                }
            }
            else if (e.KeyValue == 27)
            {
                
                this.CmbClass.Text = "";
                this.txtClassDesc.Text = "";
                this.LoadMyCategory("");
                this.LoadMyGroup("");
                this.LoadMyType("");
                LblClass.Text = "";
                
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
        private void LoadMyClass()
        {
            string mq = "";
            DataTable dataTable = new DataTable("MyClass");
            dataTable.Columns.Add("COD", typeof(String));
            dataTable.Columns.Add("Denumire", typeof(String));
            dataTable.Columns.Add("Cls.Caracteristic", typeof(String));
            
            this.Cursor = Cursors.WaitCursor;
            this.CmbClass.Text = "";
            this.CmbClass.DataSource = null;
            this.CmbClass.Items.Clear();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mq = "SELECT IDCLASS,Description,DispCaracteristic FROM go_article_class order by IDCLASS;";
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                dataTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"), MyGlobal.Srch2Escape("Display caracterisitic : "+dataread[2].ToString().Trim(), "'") });
            }
            CmbClass.DataSource = dataTable;
            CmbClass.DisplayMember = "COD";
            CmbClass.ValueMember = "Denumire";
            this.CmbClass.Text = "";
            this.txtClassDesc.Text = "";
            this.txtCharNr.Text = "";
            dataread.Close();
            mcmd = null;
            this.Cursor = Cursors.Default;
        }
        private void LoadMyCategory(string mClass)
        {
            string mq = "";
            if (mClass.Trim() == "")
            {
                goto MY_END;
            }
            DataTable dataTable = new DataTable("MyCategory");
            dataTable.Columns.Add("COD", typeof(String));
            dataTable.Columns.Add("Denumire", typeof(String));
           
            this.Cursor = Cursors.WaitCursor;
            this.CmbCategory.Text = "";
            CmbCategory.DataSource = null;
            this.CmbCategory.Items.Clear();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mq = "SELECT  go_article_category.IDCategory, go_article_category.Description "+
                "FROM go_article_category,go_article_class "+
                "where  go_article_category.CLASSRef='"+mClass.Trim()+"' "+ 
                "AND go_article_category.CLASSRef=go_article_class.IDCLASS "+
                "order by  go_article_category.IDCategory;";
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                dataTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'") });
            }
            CmbCategory.DataSource = dataTable;
            CmbCategory.DisplayMember = "COD";
            CmbCategory.ValueMember = "Denumire";
            dataread.Close();
            mcmd = null;
            MY_END:
            this.CmbCategory.Text = "";
            this.txtCategoryDesc.Text = "";
            
            
            this.Cursor = Cursors.Default;
        }
        private void LoadMyGroup(string mCategory)
        {
            string mq = "";
            if(mCategory.Trim()=="")
            {
                goto MY_END;
            }
            DataTable dataTable = new DataTable("MyGroup");
            dataTable.Columns.Add("COD", typeof(String));
            dataTable.Columns.Add("Denumire", typeof(String));

            this.Cursor = Cursors.WaitCursor;
            this.CmbGroup.Text = "";
            this.CmbGroup.DataSource = null;
            this.CmbGroup.Items.Clear();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mq = "SELECT  go_article_group.IDGROUP, go_article_group.Description " +
                 "FROM go_article_class,go_article_category,go_article_group " +
                 "where go_article_class.IDCLASS='"+CmbClass.Text.Trim()+"' and go_article_category.CLASSRef=go_article_class.IDCLASS "+
                 "AND go_article_category.IDCategory='" + mCategory.Trim() + "' AND go_article_group.CATEGORYRef=go_article_category.IDCategory " +
                 "order by go_article_group.IDGROUP;";
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                dataTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'") });
            }
            this.CmbGroup.DataSource = dataTable;
            this.CmbGroup.DisplayMember = "COD";
            this.CmbGroup.ValueMember = "Denumire";
            
            dataread.Close();
            mcmd = null;
            this.Cursor = Cursors.Default;
            MY_END:
            this.CmbGroup.Text = "";
            this.txtGroupDesc.Text = "";
        }
        private void LoadMyType(string mGroup)
        {
            string mq = "";
            if(mGroup.Trim()=="")
            {
                goto MY_END;
            }
            DataTable dataTable = new DataTable("MyType");
            dataTable.Columns.Add("COD", typeof(String));
            dataTable.Columns.Add("Denumire", typeof(String));

            this.Cursor = Cursors.WaitCursor;
            this.CmbType.Text = "";
            this.CmbType.DataSource = null;
            this.CmbType.Items.Clear();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mq = "SELECT  go_article_type.IDTYPE, go_article_type.Description " +
                 "FROM go_article_class,go_article_category,go_article_type,go_article_group " +
                 "where go_article_class.IDCLASS='" + CmbClass.Text.Trim() + "' " +
                 "AND go_article_category.IDCategory='" + CmbCategory.Text.Trim() + "' AND go_article_category.CLASSRef=go_article_class.IDCLASS " +
                 "AND go_article_group.IDGROUP='"+CmbGroup.Text.Trim()+"' AND go_article_group.CATEGORYRef=go_article_category.IDCategory " +
                 "AND go_article_type.GROUPRef=go_article_group.IDGROUP order by go_article_type.IDTYPE;"; 
                 
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                dataTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'") });
            }
            this.CmbType.DataSource = dataTable;
            this.CmbType.DisplayMember = "COD";
            this.CmbType.ValueMember = "Denumire";
            dataread.Close();
            mcmd = null;
            this.Cursor = Cursors.Default;
            MY_END:
            this.CmbType.Text = "";
            this.txtTypeDesc.Text = "";
        }
        private void CmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
             
            try
            {
                if (COUNT_CLASS >0)
                {
                    this.CmbClass.Text = ((DataRowView)CmbClass.SelectedItem).Row.ItemArray[0].ToString();
                    this.txtClassDesc.Text = ((DataRowView)CmbClass.SelectedItem).Row.ItemArray[1].ToString();
                    this.txtCharNr.Text = ((DataRowView)CmbClass.SelectedItem).Row.ItemArray[2].ToString();
                    COUNT_CLASS = 0;
                    LblClass.Text = this.txtClassDesc.Text;
                    LoadMyGroup("");
                    LoadMyType("");
                    LoadMyCategory(this.CmbClass.Text.Trim());
                    
                }
            }
            catch { }
        }

        private void LblValidClass_MouseClick(object sender, MouseEventArgs e)
        {
            KeyEventArgs aa=new KeyEventArgs(Keys.Enter);
            this.CmbClass_KeyDown(CmbClass, aa);
            aa = null;
        }

        private void CmbCategory_KeyDown(object sender, KeyEventArgs e)
        {
            
            string mq = "";
            bool IfExist = false;
            if (e.KeyValue == 13)
            {
                if (this.CmbClass.Text.Trim() == "" || this.txtCharNr.Text.Trim()=="")
                {
                    MessageBox.Show("Nu este selectata nici o Clasa de Articole.");
                    return;
                }
                CmbCategory.Text = FillZero(CmbCategory.Text.Trim());
                string[] mres = new string[1];
                IfExist = MyGlobal.IsForUpdate("SELECT IDCategory FROM go_article_category where IDCategory='" + CmbCategory.Text.Trim() + "' AND CLASSRef='" + this.CmbClass.Text.Trim() + "' order by IDCategory;", 1, ref mres);
                mres = null;
                if (IfExist == false)
                {

                    mq = "INSERT INTO go_article_category(IDCategory,CLASSRef,ScRef,Description,mUser,InDate,UpToDate) " +
                        "VALUES ('" + this.CmbCategory.Text.Trim().Substring(0, 5) + "','" + this.CmbClass.Text.Trim() + "',NULL,'" + this.txtCategoryDesc.Text.Trim() + "'," +
                        "'" + MyGlobal.MyUserInfo.MyUser.Trim() + "',getdate(),NULL);";
                }
                else
                {
                    mq = "update go_article_category set ScRef=NULL,Description='" + this.txtCategoryDesc.Text.Trim() + "',mUser='" + MyGlobal.MyUserInfo.MyUser.Trim() + "',UpToDate=getdate() where IDCategory='" + this.CmbCategory.Text.Trim().Substring(0,5) + "' AND CLASSRef='" + this.CmbClass.Text.Trim().Substring(0,5) + "';";
                }
                if (SaveData(mq) == 0)
                {
                    MessageBox.Show("Datele au fost salvate cu succes.");
                    this.LoadMyCategory(this.CmbClass.Text.Trim());
                    this.LoadMyGroup("");
                    this.LoadMyType("");
                    CmbGroup.Text = "";
                    txtGroupDesc.Text = "";
                    CmbType.Text = "";
                    txtTypeDesc.Text = "";
                }
                else
                {
                    MessageBox.Show("Nu pot salva date.");
                }
            }
            else if (e.KeyValue == 27)
            {
                this.txtCategoryDesc.Text = "";
                this.CmbCategory.Text = "";
                this.LoadMyGroup("");
                this.LoadMyType("");
                LblClass.Text = "";
                
            }
        }

        private void txtClassDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                //this.CmbClass.KeyDown += new KeyEventHandler(CmbCategory_KeyDown(e));
                this.CmbClass_KeyDown(this.CmbClass, e);
            }
        }

        private void CmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                if (COUNT_CATEGORY > 0)
                {
                    COUNT_CATEGORY = 0;
                    this.CmbCategory.Text = ((DataRowView)CmbCategory.SelectedItem).Row.ItemArray[0].ToString();
                    this.txtCategoryDesc.Text = ((DataRowView)CmbCategory.SelectedItem).Row.ItemArray[1].ToString();
                    LblClass.Text = this.txtClassDesc.Text + " " + this.txtCategoryDesc.Text;
                    LoadMyType("");
                    LoadMyGroup(this.CmbCategory.Text.Trim());
                    
                }
            }
            catch { }
            
        }

        private void LblValidCategory_Click(object sender, EventArgs e)
        {
            KeyEventArgs aa = new KeyEventArgs(Keys.Enter);
            this.CmbCategory_KeyDown(CmbCategory,aa);
            aa = null;
        }

        private void txtCategoryDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue==13)
            {
                this.CmbCategory_KeyDown(this.CmbCategory, e);
            }

        }
        private void CmbClass_DropDown(object sender, EventArgs e)
        {
            COUNT_CLASS++;
        }

        private void CmbCategory_DropDown(object sender, EventArgs e)
        {
            COUNT_CATEGORY++;
        }

        private void CmbGroup_DropDown(object sender, EventArgs e)
        {
            COUNT_GROUP++;
        }

        private void CmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (COUNT_GROUP > 0)
                {
                    COUNT_GROUP = 0;
                    this.CmbGroup.Text = ((DataRowView)CmbGroup.SelectedItem).Row.ItemArray[0].ToString();
                    this.txtGroupDesc.Text = ((DataRowView)CmbGroup.SelectedItem).Row.ItemArray[1].ToString();
                    LblClass.Text = this.txtClassDesc.Text + " " + this.txtCategoryDesc.Text+" "+this.txtGroupDesc.Text;
                    LoadMyType(this.CmbGroup.Text.Trim());
                }
            }
            catch { }
        }

        private void CmbGroup_KeyDown(object sender, KeyEventArgs e)
        {
            
            string mq = "";
            bool IfExist = false;
            if (e.KeyValue == 13)
            {
                if (this.CmbCategory.Text.Trim() == "")
                {
                    MessageBox.Show("Nu este selectata nici o Categorie de Articole.");
                    return;
                }
                CmbGroup.Text = FillZero(CmbGroup.Text.Trim());
                string[] mres = new string[1];
                IfExist = MyGlobal.IsForUpdate("SELECT IDGROUP FROM go_article_group where CATEGORYRef='"+this.CmbCategory.Text.Trim()+"' AND IDGROUP='"+this.CmbGroup.Text.Trim()+"';", 1, ref mres);
                mres = null;
                if (IfExist == false)
                {
                    mq = "INSERT INTO go_article_group (IDGROUP,CATEGORYRef,ScRef,Description,mUser,InDate,UpToDate)"+
                         " VALUES ('" + CmbGroup.Text.Trim() + "','" + CmbCategory.Text.Trim() + "',NULL,'" + txtGroupDesc.Text.Trim() + "','" + MyGlobal.MyUserInfo.MyUser.Trim() + "',getdate(),NULL)";
                }
                else
                {
                    mq = "update go_article_group set Description='" + txtGroupDesc.Text.Trim() + "',mUser='" + MyGlobal.MyUserInfo.MyUser.Trim() + "',UpToDate=getdate() where IDGROUP='" + CmbGroup.Text.Trim() + "' AND CATEGORYRef='" + CmbCategory.Text.Trim() + "';";
                }
                if (SaveData(mq) == 0)
                {
                    MessageBox.Show("Datele au fost salvate cu succes.");
                    LoadMyGroup(this.CmbCategory.Text.Trim());
                    this.LoadMyType("");
                    CmbType.Text = "";
                    txtTypeDesc.Text  = "";
                }
                else
                {
                    MessageBox.Show("Nu pot salva date.");
                }
            }
            else if (e.KeyValue == 27)
            {
                this.txtGroupDesc.Text = "";
                this.CmbGroup.Text = "";
                this.LoadMyType("");
                this.LblClass.Text = "";
            }
        }
        private void txtGroupDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.CmbGroup_KeyDown(CmbGroup, e);
            }
        }
        private void LblValidGroup_MouseClick(object sender, MouseEventArgs e)
        {
            KeyEventArgs aa = new KeyEventArgs(Keys.Enter);
            this.CmbGroup_KeyDown(CmbGroup, aa);
            aa = null;
        }

        private void CmbType_KeyDown(object sender, KeyEventArgs e)
        {
            
            string mq = "";
            bool IfExist = false;
            if (e.KeyValue == 13)
            {
                if (this.CmbGroup.Text.Trim() == "")
                {
                    MessageBox.Show("Nu este selectata nici o Grupa de Articole.");
                    return;
                }
                CmbType.Text = FillZero(CmbType.Text.Trim());
                string[] mres = new string[1];
                IfExist = MyGlobal.IsForUpdate("SELECT IDTYPE FROM go_article_type where GROUPRef='" + this.CmbGroup.Text.Trim() + "' AND IDTYPE='" + this.CmbType.Text.Trim() + "';", 1, ref mres);
                mres = null;
                if (IfExist == false)
                {
                    mq = "INSERT INTO go_article_type (IDTYPE,GROUPRef,ScRef,Description,mUser,InDate,UpToDate)" +
                         " VALUES ('" + CmbType.Text.Trim() + "','" + CmbGroup.Text.Trim() + "',NULL,'" + txtTypeDesc.Text.Trim() + "','" + MyGlobal.MyUserInfo.MyUser.Trim() + "',getdate(),NULL)";
                }
                else
                {
                    mq = "update go_article_type set Description='" + txtTypeDesc.Text.Trim() + "',mUser='" + MyGlobal.MyUserInfo.MyUser.Trim() + "',UpToDate=getdate() where IDTYPE='" + CmbType.Text.Trim() + "' AND GROUPRef='" + CmbGroup.Text.Trim() + "';";
                }
                if (SaveData(mq) == 0)
                {
                    MessageBox.Show("Datele au fost salvate cu succes.");
                    LoadMyType(this.CmbGroup.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Nu pot salva date.");
                }
            }
            else if(e.KeyValue==27)
            {
                CmbType.Text = "";
                txtTypeDesc.Text = "";
            }

        }

        private void CmbType_DropDown(object sender, EventArgs e)
        {
            COUNT_TYPE++;
        }

        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (COUNT_TYPE > 0)
                {
                    COUNT_TYPE = 0;
                    this.CmbType.Text = ((DataRowView)CmbType.SelectedItem).Row.ItemArray[0].ToString();
                    this.txtTypeDesc.Text = ((DataRowView)CmbType.SelectedItem).Row.ItemArray[1].ToString();
                    LblClass.Text = this.txtClassDesc.Text + " " + this.txtCategoryDesc.Text + " " + this.txtGroupDesc.Text+" "+this.txtTypeDesc.Text;
                }
            }
            catch { }
        }

        private void txtTypeDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.CmbType_KeyDown(CmbGroup, e);
            }
        }

        private void LblValidType_MouseClick(object sender, MouseEventArgs e)
        {
            KeyEventArgs aa = new KeyEventArgs(Keys.Enter);
            this.CmbType_KeyDown(CmbType, aa);
            aa = null;
        }
        private void LoadFromMasterData(int mOption, string mCriteria)
        {
            string mq = "";
            long x = 0;
            ListViewItem k = null;
            
            this.Cursor = Cursors.WaitCursor;
            this.MyListView.Items.Clear();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            System.Data.SqlClient.SqlDataReader dataread = null;
            if (mCriteria.Trim() == "")
            {
                mq = "select StockCode,Description1,Description2,ExtProdGroup,ProductGroup,GoWHClass,"+
                    "(select go_article_class.Description from go_article_class where go_article_class.IDCLASS = substring(go_article_masterdata.GoWHClass, 1, 5)),"+
                    "(select go_article_category.Description from go_article_category,go_article_class where go_article_class.IDCLASS=substring(go_article_masterdata.GoWHClass,1, 5) AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) AND go_article_category.CLASSRef=go_article_class.IDCLASS)," +
                    "(select go_article_group.Description from go_article_group,go_article_class,go_article_category where go_article_class.IDCLASS=substring(go_article_masterdata.GoWHClass, 1, 5) " +
                    "AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) " +
                    "AND go_article_category.CLASSRef=go_article_class.IDCLASS "+
                    "AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) "+
                    "AND go_article_category.CLASSRef=go_article_class.IDCLASS "+
                    "AND go_article_group.IDGROUP = substring(go_article_masterdata.GoWHClass, 11, 5) "+
                    "AND go_article_group.CATEGORYRef=go_article_category.IDCategory)," +
                    "(select go_article_type.Description from go_article_class,go_article_category,go_article_group,go_article_type where go_article_class.IDCLASS=substring(go_article_masterdata.GoWHClass, 1, 5) " +
                    "AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) " +
                    "AND go_article_category.CLASSRef=go_article_class.IDCLASS "+
                    "AND go_article_group.IDGROUP = substring(go_article_masterdata.GoWHClass, 11, 5) " +
                    "AND go_article_group.CATEGORYRef=go_article_category.IDCategory "+
                    "AND go_article_type.IDTYPE = substring(go_article_masterdata.GoWHClass, 16, 5) " + 
                    "AND go_article_type.GROUPRef=go_article_group.IDGROUP)," +
                    "mUser,InDate,UpToDate from go_article_masterdata order by StockCode;";
            }
            else
            {
                if (mOption == 1)   //Cod Articol
                {
                    mq = "select StockCode,Description1,Description2,ExtProdGroup,ProductGroup,GoWHClass,"+
                        "(select go_article_class.Description from go_article_class where go_article_class.IDCLASS = substring(go_article_masterdata.GoWHClass, 1, 5))," +
                        "(select go_article_category.Description from go_article_category,go_article_class where go_article_class.IDCLASS=substring(go_article_masterdata.GoWHClass,1, 5) AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) AND go_article_category.CLASSRef=go_article_class.IDCLASS)," +
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
                    mq = "select StockCode,Description1,Description2,ExtProdGroup,ProductGroup,GoWHClass,"+
                        "(select go_article_class.Description from go_article_class where go_article_class.IDCLASS = substring(go_article_masterdata.GoWHClass, 1, 5))," +
                        "(select go_article_category.Description from go_article_category,go_article_class where go_article_class.IDCLASS=substring(go_article_masterdata.GoWHClass,1, 5) AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) AND go_article_category.CLASSRef=go_article_class.IDCLASS)," +
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
                    mq = "select StockCode,Description1,Description2,ExtProdGroup,ProductGroup,GoWHClass,"+
                        "(select go_article_class.Description from go_article_class where go_article_class.IDCLASS = substring(go_article_masterdata.GoWHClass, 1, 5))," +
                        "(select go_article_category.Description from go_article_category,go_article_class where go_article_class.IDCLASS=substring(go_article_masterdata.GoWHClass,1, 5) AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) AND go_article_category.CLASSRef=go_article_class.IDCLASS)," +
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
                    mq = "select StockCode,Description1,Description2,ExtProdGroup,ProductGroup,GoWHClass,"+
                        "(select go_article_class.Description from go_article_class where go_article_class.IDCLASS = substring(go_article_masterdata.GoWHClass, 1, 5))," +
                        "(select go_article_category.Description from go_article_category,go_article_class where go_article_class.IDCLASS=substring(go_article_masterdata.GoWHClass,1, 5) AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) AND go_article_category.CLASSRef=go_article_class.IDCLASS)," +
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
                        "(select go_article_category.Description from go_article_category,go_article_class where go_article_class.IDCLASS=substring(go_article_masterdata.GoWHClass,1, 5) AND go_article_category.IDCategory = substring(go_article_masterdata.GoWHClass, 6, 5) AND go_article_category.CLASSRef=go_article_class.IDCLASS)," +
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
            this.MyListView.EndUpdate();
            this.MyListView.Refresh();
        MYEND:
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

        private void MyListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                MY_CANCEL = true;
                ID_ARTICLE = "";
                LblClass.Text = "";
                this.CmbClass.Text = "";
                this.txtClassDesc.Text = "";
                this.txtCategoryDesc.Text = "";
                this.CmbCategory.Text = "";
                this.CmbGroup.Text = "";
                this.txtGroupDesc.Text = "";
                this.CmbType.Text = "";
                this.txtTypeDesc.Text = "";

            }
        }

        private void CmdCauta_Click(object sender, EventArgs e)
        {
            if (txtCauta.Text.Trim() == "")
            {
                LoadFromMasterData(0, "");
            }
            else
            {

                if (rbCodArticol.Checked == true)
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

        private void MyListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                ID_ARTICLE = MyListView.SelectedItems[0].Text.Trim();
            }
            catch
            {
                MessageBox.Show("CRITIC_ERR ! Invalid ID_ARTICLE");
                return;
            }
            MessageBox.Show("Ai selectat "+ID_ARTICLE.ToString()+" "+MyListView.SelectedItems[0].SubItems[1].Text.Trim());
            if (MyListView.SelectedItems[0].SubItems[5].Text.Trim() == "0" || MyListView.SelectedItems[0].SubItems[5].Text.Trim() == "")
            {
                LblClass.Text = "";
                try
                {
                    txtClassDesc.Text = "";
                    CmbClass.Text = MyListView.SelectedItems[0].SubItems[5].Text.Trim().Substring(0, 5);
                    
                }
                catch { CmbClass.Text = ""; }
                try
                {
                    txtCategoryDesc.Text = "";
                    CmbCategory.Text = MyListView.SelectedItems[0].SubItems[5].Text.Trim().Substring(5, 5);
                    
                }
                catch { CmbCategory.Text = ""; }
                try
                {
                    txtGroupDesc.Text = "";
                    CmbGroup.Text = MyListView.SelectedItems[0].SubItems[5].Text.Trim().Substring(10, 5);
                    
                }
                catch { CmbGroup.Text = ""; }
                try
                {
                    txtTypeDesc.Text = "";
                    CmbType.Text = MyListView.SelectedItems[0].SubItems[5].Text.Trim().Substring(15, 5);
                    
                }
                catch { CmbType.Text = ""; }
            }
            else
            {
                try
                {
                    CmbClass.Text = MyListView.SelectedItems[0].SubItems[5].Text.Trim().Substring(0,5);
                    txtClassDesc.Text = MyListView.SelectedItems[0].SubItems[6].Text.Trim();
                }
                catch { CmbClass.Text = ""; txtClassDesc.Text = ""; }
                try
                {
                    CmbCategory.Text = MyListView.SelectedItems[0].SubItems[5].Text.Trim().Substring(5, 5);
                    txtCategoryDesc.Text = MyListView.SelectedItems[0].SubItems[7].Text.Trim();
                }
                catch { CmbCategory.Text = ""; txtCategoryDesc.Text = ""; }
                try
                {
                    CmbGroup.Text = MyListView.SelectedItems[0].SubItems[5].Text.Trim().Substring(10, 5);
                    txtGroupDesc.Text = MyListView.SelectedItems[0].SubItems[8].Text.Trim();
                }
                catch { CmbGroup.Text = ""; txtGroupDesc.Text = ""; }
                try
                {
                    CmbType.Text = MyListView.SelectedItems[0].SubItems[5].Text.Trim().Substring(15, 5);
                    txtTypeDesc.Text = MyListView.SelectedItems[0].SubItems[9].Text.Trim();
                }
                catch { CmbType.Text = ""; txtTypeDesc.Text = ""; }
                LblClass.Text = txtClassDesc.Text + txtCategoryDesc.Text + txtGroupDesc.Text + txtTypeDesc.Text;
            }
        }

        private void CmdSave_Click(object sender, EventArgs e)
        {
            string mq = "";
            string mc=CmbClass.Text.Trim()+CmbCategory.Text.Trim()+CmbGroup.Text.Trim()+CmbType.Text.Trim();
            if (ID_ARTICLE.Trim() == "")
            {
                MessageBox.Show("Nu este selectat nici un articol.");
                return;
            }
            if (mc.Trim() == "")
            {
                MessageBox.Show("Trebuie specificat cel putin o Clasa");
                return;
            }
            mq = "update go_article_masterdata set GoWHClass='"+mc+"' where StockCode='"+ID_ARTICLE.Trim()+"'";
            if (SaveData(mq) == 0)
            {

                MessageBox.Show("Datele au fost salvate cu succes.");
                LoadFromMasterData(0, "");
            }
            else
            {
                MessageBox.Show("Nu pot salva date.");
            }

        }
        private string FillZero(string mBuff)
        {
            int i = 0;
            string tmp = "";
            
            if (mBuff.Length > 5)
            {
                tmp = mBuff.ToUpper();    
                return tmp.Substring(1, 5);
            }
            else
            {
                mBuff = mBuff.ToUpper();
                for (i = 0; i < (5 - mBuff.Length); i++)
                {
                    tmp += "0";
                }
                return tmp + mBuff;
            }
        }

        private void CmbClass_Leave(object sender, EventArgs e)
        {
            CmbClass.Text = FillZero(CmbClass.Text.Trim());
        }

        private void CmbCategory_Leave(object sender, EventArgs e)
        {
            CmbCategory.Text = FillZero(CmbCategory.Text.Trim());
        }

        private void CmbGroup_Leave(object sender, EventArgs e)
        {
            CmbGroup.Text = FillZero(CmbGroup.Text.Trim());
        }

        private void CmbType_Leave(object sender, EventArgs e)
        {
            CmbType.Text = FillZero(CmbType.Text.Trim());
        }

        private void MyListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void copiazaInClipBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = 0;
            int z = 0;
            string s = "";
            i = MyListView.SelectedIndices.Count;
            //if (MessageBox.Show("Vrei sa copiezi ce este selectat ?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            this.Cursor = Cursors.WaitCursor;
            Clipboard.Clear();
            for (i = 0; i < MyListView.Items.Count; i++)
            {
                if (MyListView.Items[i].Selected == true)
                {
                    s += MyListView.Items[i].Text.Trim() + "\t";
                    for (z = 1; z < MyListView.Columns.Count - 1; z++)
                    {
                        if (MyListView.Items[i].SubItems[z].Text.Trim() != "" || MyListView.Items[i].SubItems[z].Text.Trim() != null)
                        {
                            s += MyListView.Items[i].SubItems[z].Text.Trim() + "\t";
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
            }
        }

    }
}