using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoWHMgmAdmin
{
    public partial class ImportSupplierAndCustomer : Form
    {
        private ListViewItem k = null;
        private string[] MY_CONDITIONAL_UPDATE_SETTINGS=new string[2];
        private bool MY_CANCEL = false;
        public ImportSupplierAndCustomer()
        {
            InitializeComponent();
        }

        private void ImportSupplierAndCustomer_Load(object sender, EventArgs e)
        {
            MY_CONDITIONAL_UPDATE_SETTINGS[0] = " ";
            MY_CONDITIONAL_UPDATE_SETTINGS[1] = " ";
            LblObservatii.Visible = false;
            CkPartType.Checked = false;
            rbCodPartener.Checked = true;
            SetComboBoxConditionat(true);
            LoadFromPartner(true, 1, "");
            
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

        private void ImportSupplierAndCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            try
            {
                k = null;
                MY_CONDITIONAL_UPDATE_SETTINGS = null;
                MyGlobal.mFrmSupplCutom = null;
            }
            finally
            {
                GC.Collect();
            }
        }

        private void CmdImport_Click(object sender, EventArgs e)
        {
            MyListView.Focus();
            LblTotalInList.Text = "0";
            ImportCustomer();
            ImportSupplier();
            MY_CANCEL = false;
            MY_CONDITIONAL_UPDATE_SETTINGS[0]=" ";
            MY_CONDITIONAL_UPDATE_SETTINGS[1] = " ";
            CmbConditieUpdate.Text = "";
            CmbConditieUpdate.Refresh();
            txtCriteria.Text = "";
            txtCriteria.Refresh();
            LblDescriere.Text = "";
            if (LblObservatii.Visible == true)
            {
                LblObservatii.Visible = false;
                LblObservatii.Text = "";
            }
        }
        private int ImportCustomer()
        {
            
            long x = 0;
            int z = 0;
            string mq = "";
            int mret = 0;
            string[] mres = new string[13];
            System.Data.SqlClient.SqlDataReader dataread = null;
            
            bool mreturn = false;
            long xinsert = 0;
            long xupdate = 0;
            long xtotal = 0;
            long xlock = 0;
            this.LblTInsert.Text = "0";
            this.LblTLock.Text = "0";
            this.LblTUpdate.Text = "0";
            this.LblTR.Text = "0";
            SetColumnsCustomer();

            try
            {
                MyGlobal.MY_SCALA_CON.Open();

            }
            catch
            {
                MessageBox.Show("Nu ma pot conecta la " + MyGlobal.MY_ISCALA_IP, "GoWHManagementAdmin");
                return -1;
            }
            this.Cursor = Cursors.WaitCursor;
            this.MyListView.Items.Clear();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SCALA_CON;
            if (MY_CONDITIONAL_UPDATE_SETTINGS[0].Trim() == "")
            {
                mq = "SELECT SL01001,SL01002,SL01003,SL01004,SL01005,SL01006,SL01007,SL01008,SL01009" +
                    ",SL01010,SL01092,SL01098,SL01099 " +
                    "FROM dbo.SL010100;";
            }
            else
            {
                mq = "SELECT SL01001,SL01002,SL01003,SL01004,SL01005,SL01006,SL01007,SL01008,SL01009" +
                    ",SL01010,SL01092,SL01098,SL01099 " +
                    "FROM dbo.SL010100 where "+MY_CONDITIONAL_UPDATE_SETTINGS[0].Trim()+";";
            }
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            try
            {
                dataread = mcmd.ExecuteReader();
            }
            catch (Exception erx)
            {
                MessageBox.Show("IMPORT_CUSTOMER : EROARE MSSQL!!!\r\n" + erx.Message.Trim());
                goto MYEND; 
            }
            this.MyListView.BeginUpdate();
            while (dataread.Read())
            {

                if (MY_CANCEL == true)
                {
                    MY_CANCEL = false;
                    DialogResult m=MessageBox.Show("Esti sigur ca vrei sa intrerupi procedura de import ?","",MessageBoxButtons.YesNo);
                    if (m == DialogResult.Yes)
                    {
                        goto MYEND;
                    }
                }
                mres[0] = MyGlobal.Srch2Escape(dataread[0].ToString().Trim(),"'");
                mres[1] = MyGlobal.Srch2Escape(dataread[1].ToString().Trim(),"'");
                mres[2] = MyGlobal.Srch2Escape(dataread[2].ToString().Trim(),"'");
                mres[3] = MyGlobal.Srch2Escape(dataread[3].ToString().Trim(),"'");
                mres[4] = MyGlobal.Srch2Escape(dataread[4].ToString().Trim(),"'");
                mres[5] = MyGlobal.Srch2Escape(dataread[5].ToString().Trim(),"'");
                mres[6] = MyGlobal.Srch2Escape(dataread[6].ToString().Trim(),"'");
                mres[7] = MyGlobal.Srch2Escape(dataread[7].ToString().Trim(),"'");
                mres[8] = MyGlobal.Srch2Escape(dataread[8].ToString().Trim(),"'");
                mres[9] = MyGlobal.Srch2Escape(dataread[9].ToString().Trim(),"'");
                mres[10] = MyGlobal.Srch2Escape(dataread[10].ToString().Trim(),"'");
                mres[11] = MyGlobal.Srch2Escape(dataread[11].ToString().Trim(),"'");
                mres[12] = MyGlobal.Srch2Escape(dataread[12].ToString().Trim(), "'");
                string[] mfunc = null;
                string mcc = "SELECT "+
                            "(select go_users_def.RealName from go_users_def where ID=go_sys_lock.IDUser),"+
                            "(select go_users_def.RealSurname from go_users_def where ID=go_sys_lock.IDUser) "+
                            "FROM go_customer_def "+
                            "LEFT JOIN "+
                            "go_sys_lock ON go_sys_lock.CustomCode = go_customer_def.CustomerCode "+
                            "where go_customer_def.CustomerCode='" + mres[0].Trim() + "';";
                mreturn = MyGlobal.IsForUpdate(mcc,2,ref mfunc);
                
                if (mfunc[0].Trim() == "")
                {
                    if (mreturn == false)
                    {

                        if (ImportInCustomerDef(mres, false) < 0)
                        {
                            mret = -1;
                            goto MYEND;
                        }
                        else
                        {
                            xinsert++;
                            this.LblTInsert.Text = xinsert.ToString().Trim();
                            this.LblTInsert.Refresh();
                        }
                    }
                    else
                    {

                        if (ImportInCustomerDef(mres, true) < 0)
                        {
                            mret = -1;
                            goto MYEND;
                        }
                        else
                        {
                            xupdate++;
                            this.LblTUpdate.Text = xupdate.ToString().Trim();
                            this.LblTUpdate.Refresh();
                        }
                    }
                    

                    k = new ListViewItem("Customer");
                    k.SubItems.Add(mres[0].Trim());
                    k.SubItems.Add(mres[1].Trim());
                    k.SubItems.Add(mres[2].Trim());
                    k.SubItems.Add(mres[3].Trim());
                    k.SubItems.Add(mres[4].Trim());
                    k.SubItems.Add(mres[5].Trim());
                    k.SubItems.Add(mres[6].Trim());
                    k.SubItems.Add(mres[7].Trim());
                    k.SubItems.Add(mres[8].Trim());
                    k.SubItems.Add(mres[9].Trim());
                    k.SubItems.Add(mres[10].Trim());
                    k.SubItems.Add(mres[11].Trim());
                    k.SubItems.Add(mres[12].Trim());

                    x++;
                }
                else
                {
                    k = new ListViewItem("Customer");
                    k.BackColor = Color.Tomato;
                    k.SubItems.Add(mres[0].Trim());
                    k.SubItems.Add("IS_LOCK");
                    k.SubItems.Add(MyGlobal.MyUserInfo.MyUser.Trim());
                    k.SubItems.Add(mfunc[0].Trim()+ " " + mfunc[1].Trim());
                    k.SubItems.Add("");
                    k.SubItems.Add("");
                    k.SubItems.Add("");
                    k.SubItems.Add("");
                    k.SubItems.Add("");
                    k.SubItems.Add("");
                    k.SubItems.Add("");
                    k.SubItems.Add("");
                    k.SubItems.Add("");

                    
                    xlock++;
                    LblTLock.Text = xlock.ToString().Trim();
                    LblTLock.Refresh();
                }
                this.MyListView.Items.Add(k);
                
                Application.DoEvents();
                mfunc = null;
                for (z = 0; z < 13; z++)
                {
                    mres[z] = "";
                }
                xtotal++;
                //LblTotalRecords.Text = xtotal.ToString().Trim();
                this.LblTR.Text = xtotal.ToString().Trim();
                this.LblTR.Refresh();
            }

        MYEND:
            this.MyListView.EndUpdate();
            this.MyListView.Refresh();
            
            MY_CANCEL = false;    
            try
            {
                dataread.Close();
                mcmd = null;
            }
            catch{}
            try
            {
                MyGlobal.MY_SCALA_CON.Close();
                
            }
            finally
            {
                GC.Collect();
            }
            this.Cursor = Cursors.Default;
            return mret;
        }
        private int ImportSupplier()
        {
            //ListViewItem k = null;
            long x = 0;
            int z = 0;
            string mq = "";
            int mret = 0;
            string[] mres = new string[13];
            System.Data.SqlClient.SqlDataReader dataread = null;

            bool mreturn = false;
            long xinsert = 0;
            long xupdate = 0;
            long xtotal = 0;
            long xlock = 0;

            this.LblTotalInsert.Text = "0";
            this.LblTotalUpdate.Text = "0";
            this.LblTotalLock.Text = "0";
            this.LblTotalRecords.Text = "0";

            try
            {
                MyGlobal.MY_SCALA_CON.Open();

            }
            catch
            {
                MessageBox.Show("Nu ma pot conecta la " + MyGlobal.MY_ISCALA_IP, "GoWHManagementAdmin");
                return -1;
            }
            this.Cursor = Cursors.WaitCursor;
            
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SCALA_CON;
            if (MY_CONDITIONAL_UPDATE_SETTINGS[1].Trim() == "")
            {
                mq = "SELECT PL01001,PL01002,PL01003,PL01004,PL01005,PL01006,PL01007,PL01048,PL01050" +
                 " FROM dbo.PL010100;";
            }
            else
            {
                mq = "SELECT PL01001,PL01002,PL01003,PL01004,PL01005,PL01006,PL01007,PL01048,PL01050" +
                 " FROM dbo.PL010100 where " + MY_CONDITIONAL_UPDATE_SETTINGS[1].Trim() + ";";
            }
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            try
            {
                dataread = mcmd.ExecuteReader();
            }
            catch (Exception erx)
            {
                MessageBox.Show("IMPORT_SUPPLIER : EROARE MSSQL!!!\r\n"+erx.Message.Trim());
                goto MYEND; 
            }
            this.MyListView.BeginUpdate();
            while (dataread.Read())
            {

                if(MY_CANCEL==true)
                {
                    MY_CANCEL = false;
                    DialogResult m=MessageBox.Show("Esti sigur ca vrei sa intrerupi procedura de import?","",MessageBoxButtons.YesNo);
                    if (m == DialogResult.Yes)
                    {
                        goto MYEND;
                    }
                }
                mres[0] = MyGlobal.Srch2Escape(dataread[0].ToString().Trim(),"'");
                mres[1] = MyGlobal.Srch2Escape(dataread[1].ToString().Trim(),"'");
                mres[2] = MyGlobal.Srch2Escape(dataread[2].ToString().Trim(),"'");
                mres[3] = MyGlobal.Srch2Escape(dataread[3].ToString().Trim(),"'");
                mres[4] = MyGlobal.Srch2Escape(dataread[4].ToString().Trim(),"'");
                mres[5] = MyGlobal.Srch2Escape(dataread[5].ToString().Trim(),"'");
                mres[6] = MyGlobal.Srch2Escape(dataread[6].ToString().Trim(),"'");
                mres[7] = MyGlobal.Srch2Escape(dataread[7].ToString().Trim(),"'");
                mres[8] = MyGlobal.Srch2Escape(dataread[8].ToString().Trim(), "'");

                string[] mfunc = new string[1];
                string mcc = "SELECT " +
                            "(select go_users_def.RealName from go_users_def where ID=go_sys_lock.IDUser)," +
                            "(select go_users_def.RealSurname from go_users_def where ID=go_sys_lock.IDUser) " +
                            "FROM go_supplier_def " +
                            "LEFT JOIN " +
                            "go_sys_lock ON go_sys_lock.SuppllCode = go_supplier_def.SupplierCode " +
                            "where go_supplier_def.SupplierCode='" + mres[0].Trim() + "';";
                mreturn = MyGlobal.IsForUpdate(mcc,2,ref mfunc);
                
                //mfunc = null;
                if (mfunc[0].Trim() == "")
                {
                    if (mreturn == false)
                    {

                        if (ImportInSupplierDef(mres, false) < 0)
                        {
                            mret = -1;
                            goto MYEND;
                        }
                        else
                        {
                            xinsert++;
                            this.LblTotalInsert.Text = xinsert.ToString().Trim();
                            this.LblTotalInsert.Refresh();
                            //LblTInsert.Text = xinsert.ToString().Trim();
                            //LblTInsert.Refresh();
                        }
                    }
                    else
                    {
                        if (ImportInSupplierDef(mres, true) < 0)
                        {
                            mret = -1;
                            goto MYEND;
                        }
                        else
                        {
                            xupdate++;
                            this.LblTotalUpdate.Text = xupdate.ToString().Trim();
                            this.LblTotalUpdate.Refresh();
                            //LblTUpdate.Text = xupdate.ToString().Trim();
                            //LblTUpdate.Refresh();
                        }
                    }
                    
                    k = new ListViewItem("Supplier");
                    k.SubItems.Add(mres[0].Trim());
                    k.SubItems.Add(mres[1].Trim());
                    k.SubItems.Add(mres[2].Trim());
                    k.SubItems.Add(mres[3].Trim());
                    k.SubItems.Add(mres[4].Trim());
                    k.SubItems.Add(mres[5].Trim());
                    k.SubItems.Add("");
                    k.SubItems.Add("");
                    k.SubItems.Add("");
                    k.SubItems.Add(mres[6].Trim());
                    k.SubItems.Add(mres[7].Trim());
                    k.SubItems.Add(mres[8].Trim());
                    k.SubItems.Add("");

                }
                else
                {
                    k = new ListViewItem("Supplier");
                    k.BackColor = Color.Tomato;
                    k.SubItems.Add(mres[0].Trim());
                    k.SubItems.Add("IS_LOCK");
                    k.SubItems.Add(MyGlobal.MyUserInfo.MyUser.Trim());
                    k.SubItems.Add(mfunc[0].Trim() + " " + mfunc[1].Trim());
                    k.SubItems.Add("");
                    k.SubItems.Add("");
                    k.SubItems.Add("");
                    k.SubItems.Add("");
                    k.SubItems.Add("");
                    k.SubItems.Add("");
                    k.SubItems.Add("");
                    k.SubItems.Add("");
                    k.SubItems.Add("");

                    
                    xlock++;
                    LblTotalLock.Text = xlock.ToString().Trim();
                    LblTotalLock.Refresh();

                }
                this.MyListView.Items.Add(k);
                
                Application.DoEvents();
                mfunc = null;
                xtotal++;
                this.LblTotalRecords.Text = xtotal.ToString().Trim();
                this.LblTotalRecords.Refresh();
                x++;
                for (z = 0; z < 13; z++)
                {
                    mres[z] = "";
                }
                
            }

        MYEND:
            this.MyListView.EndUpdate();
            this.MyListView.Refresh();
            
            try
            {
                dataread.Close();
                mcmd = null;
            }
            catch { }

            try
            {
                MyGlobal.MY_SCALA_CON.Close();
                
            }
            finally
            {
                GC.Collect();
            }
            MY_CANCEL = false; 
            this.Cursor = Cursors.Default;
            return mret;
        }
        int ImportInCustomerDef(string[] mData, bool IsUpdate)
        {
            string mq = "";
            int ret = 0;
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            if (IsUpdate == false)
            {
                mq = "INSERT INTO dbo.go_customer_def "+
		            "(CustomerCode"+
                    ",CustomerName"+
                    ",AddrLine1"+
                    ",AddrLine2"+
                    ",AddrLine3"+
                    ",Reference1"+
                    ",Reference2"+
                    ",Reference3"+
                    ",Reference4"+
                    ",Category"+
                    ",FiscalCode"+
                    ",DefaultWareHouse"+
                    ",AddrLine4"+
                    ",mUser"+
                    ",InDate"+
                    ",UpToDate) VALUES"+
                    "('"+mData[0].Trim()+"',"+
                    "'"+mData[1].Trim()+"',"+
                    "'"+mData[2].Trim()+"',"+
                    "'"+mData[3].Trim()+"',"+
                    "'"+mData[4].Trim()+"',"+
                    "'"+mData[5].Trim()+"',"+
                    "'"+mData[6].Trim()+"',"+
                    "'"+mData[7].Trim()+"',"+
                    "'"+mData[8].Trim()+"',"+
                    "'"+mData[9].Trim()+"',"+
                    "'"+mData[10].Trim()+"',"+
                    "'"+mData[11].Trim()+"',"+
                    "'"+mData[12].Trim()+"',"+
                    "'"+MyGlobal.MyUserInfo.MyUser.Trim()+"',"+
                    "getdate(),"+
                    "NULL);";

            }
            else
            {
                mq = "update dbo.go_customer_def set "+
		            "CustomerName='"+mData[1].Trim()+"'"+
                    ",AddrLine1='"+mData[2].Trim()+"'"+
                    ",AddrLine2='"+mData[3].Trim()+"'"+
                    ",AddrLine3='"+mData[4].Trim()+"'"+
                    ",Reference1='"+mData[5].Trim()+"'"+
                    ",Reference2='"+mData[6].Trim()+"'"+
                    ",Reference3='"+mData[7].Trim()+"'"+
                    ",Reference4='"+mData[8].Trim()+"'"+
                    ",Category='"+mData[9].Trim()+"'"+
                    ",FiscalCode='"+mData[10].Trim()+"'"+
                    ",DefaultWareHouse='"+mData[11].Trim()+"'"+
                    ",AddrLine4='"+mData[12].Trim()+"'"+
                    ",mUser='"+MyGlobal.MyUserInfo.MyUser.Trim()+"'"+
                    ",UpToDate=getdate()"+
                    " where CustomerCode='"+mData[0].Trim()+"';";

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
            }
            mcmd = null;
            return ret;
        }
        int ImportInSupplierDef(string[] mData, bool IsUpdate)
        {
            string mq = "";
            int ret = 0;
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            if (IsUpdate == false)
            {
                
                mq = "INSERT INTO dbo.go_supplier_def"+
                    "(SupplierCode"+
                    ",SupplierName"+
                    ",AddrLine1"+
                    ",AddrLine2"+
                    ",AddrLine3"+
                    ",Reference"+
                    ",Category"+
                    ",FiscalCode"+
                    ",OrganizationType"+
                    ",mUser"+
                    ",InDate"+
                    ",UpToDate) VALUES" +
                    "('" + mData[0].Trim() + "'," +
                    "'" + mData[1].Trim() + "'," +
                    "'" + mData[2].Trim() + "'," +
                    "'" + mData[3].Trim() + "'," +
                    "'" + mData[4].Trim() + "'," +
                    "'" + mData[5].Trim() + "'," +
                    "'" + mData[6].Trim() + "'," +
                    "'" + mData[7].Trim() + "'," +
                    "'" + mData[8].Trim() + "'," +
                    "'" + MyGlobal.MyUserInfo.MyUser.Trim() + "'," +
                    "getdate()," +
                    "NULL);";

            }
            else
            {
                mq = "update dbo.go_supplier_def set " +
                    "SupplierName='" + mData[1].Trim() + "'" +
                    ",AddrLine1='" + mData[2].Trim() + "'" +
                    ",AddrLine2='" + mData[3].Trim() + "'" +
                    ",AddrLine3='" + mData[4].Trim() + "'" +
                    ",Reference='" + mData[5].Trim() + "'" +
                    ",Category='" + mData[6].Trim() + "'" +
                    ",FiscalCode='" + mData[7].Trim() + "'" +
                    ",OrganizationType='" + mData[8].Trim() + "'" +
                    ",mUser='" + MyGlobal.MyUserInfo.MyUser.Trim() + "'" +
                    ",UpToDate=getdate()" +
                    " where SupplierCode='" + mData[0].Trim() + "';";

            }
            mcmd.CommandText =mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            try
            {
                mcmd.ExecuteNonQuery();
            }
            catch (Exception emsg)
            {
                MessageBox.Show("ERROR : " + emsg.Message.Trim(), "GoWHManagementAdmin");
                ret = -1;
            }
            mcmd = null;
            return ret;
        }

        private void CkPartType_CheckedChanged(object sender, EventArgs e)
        {
            int i = 0;
            if (LblObservatii.Visible == true)
            {
                LblObservatii.Visible = false;
                LblObservatii.Text = "";
            }
            if (CkPartType.Checked == false)
            {
                CkPartType.Text = "Client";
                LoadFromPartner(true, 1, "");
                SetComboBoxConditionat(true);
                i = MY_CONDITIONAL_UPDATE_SETTINGS[0].IndexOf(" ");
                if (i > 0)
                {
                    CmbConditieUpdate.Text = MY_CONDITIONAL_UPDATE_SETTINGS[0].Substring(0, i);
                   
                    txtCriteria.Text = MY_CONDITIONAL_UPDATE_SETTINGS[0].Trim().Substring(i + 1, MY_CONDITIONAL_UPDATE_SETTINGS[0].Length - (i + 1));
                }
            }
            else
            {
                CkPartType.Text = "Furnizor";
                LoadFromPartner(false, 1, "");
                SetComboBoxConditionat(false);
                i = MY_CONDITIONAL_UPDATE_SETTINGS[1].IndexOf(" ");
                if (i > 0)
                {
                    CmbConditieUpdate.Text = MY_CONDITIONAL_UPDATE_SETTINGS[1].Substring(0, i);
                    txtCriteria.Text = MY_CONDITIONAL_UPDATE_SETTINGS[1].Trim().Substring(i + 1, MY_CONDITIONAL_UPDATE_SETTINGS[1].Length - (i + 1));
                }
            }
            CmbConditieUpdate.Refresh();
            txtCriteria.Refresh();
        }
        private void LoadFromPartnerData(int mOption, string mCriteria)
        {
            string mq = "";
            ListViewItem k = null;
            
            this.LblTotalInsert.Text = "0";
            this.LblTotalLock.Text = "0";
            this.LblTotalRecords.Text = "0";
            this.LblTotalUpdate.Text = "0";
            this.LblTInsert.Text = "0";
            this.LblTotalUpdate.Text = "0";
            this.LblTUpdate.Text = "0";
            this.LblTLock.Text = "0";
            this.LblTR.Text = "0";
            this.Cursor = Cursors.WaitCursor;
            this.MyListView.Items.Clear();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            System.Data.SqlClient.SqlDataReader dataread = null;
            if (mCriteria.Trim() == "")
            {
                mq = "select * from go_article_masterdata order by StockCode;";
            }
            else
            {
                if (mOption == 1)   //Cod Articol
                {
                    mq = "select * from go_article_masterdata where StockCode like '" + mCriteria.Trim() + "%' order by StockCode;";
                }
                else if (mOption == 2) //Descriere1
                {
                    mq = "select * from go_article_masterdata where Description1 like '%" + mCriteria.Trim() + "%' order by StockCode;";
                }
                else if (mOption == 3) //Gruoup
                {
                    mq = "select * from go_article_masterdata where ProductGroup='" + mCriteria.Trim() + "' order by StockCode;";
                }
                else if (mOption == 4) //Gruoup Extended
                {
                    mq = "select * from go_article_masterdata where ExtProdGroup='" + mCriteria.Trim() + "' order by StockCode;";
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
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[14].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[15].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[16].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[17].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[18].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[19].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[20].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[21].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[22].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[23].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[24].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[25].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[26].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[27].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[28].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[29].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[30].ToString().Trim(), "'"));
                //k.SubItems.Add(MyGlobal.Srch2Escape(dataread[31].ToString().Trim(), "'"));

                this.MyListView.Items.Add(k);
                this.MyListView.Refresh();
            }
            dataread.Close();
            mcmd = null;
            this.Cursor = Cursors.Default;
        }
        private void SetColumnsCustomer()
        {
            ColumnHeader colHead;
            this.MyListView.Clear();
            this.MyListView.Columns.Clear();

            colHead = new ColumnHeader();
            colHead.Text = "PartType";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "PartCode";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "PartName";
            colHead.Width = 280;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "AddrLine1";
            colHead.Width = 180;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "AddrLine2";
            colHead.Width = 180;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "AddrLine3";
            colHead.Width = 180;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Reference1";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Reference2";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Reference3";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Reference4";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Category";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "FiscalCode";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "DefWareHouse";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "AddrLine4";
            colHead.Width = 180;
            this.MyListView.Columns.Add(colHead);

            this.MyListView.GridLines = true;
            this.MyListView.FullRowSelect = true;
            this.MyListView.View = View.Details;

        }

        private void CkLock_CheckedChanged(object sender, EventArgs e)
        {
            int i = 0;
            int x = 0;
            int z = 0;
            
            if (CkLock.Checked == true)
            {
                CkLock.Refresh();

                x = int.Parse(this.LblTotalLock.Text.Trim())+int.Parse(this.LblTLock.Text.Trim());
                if (x == 0)
                {
                    CkLock.Checked = false;
                    CkLock.Refresh();
                    return; //nu are nici un sens sa continui
                }
                for (z = 0; z < MyListView.Columns.Count; z++)
                {
                    MyListView.Columns[z].Text = "";
                }
                MyListView.Columns[0].Text = "TipPartener";
                MyListView.Columns[1].Text = "CodPartener";
                MyListView.Columns[2].Text = "Status";
                MyListView.Columns[3].Text = "User";
                MyListView.Columns[4].Text = "Nume";
                do
                {
                    if (CkLock.Checked == true)
                    {
                        for (i = 0; i < MyListView.Items.Count; i++)
                        {
                            if (MyListView.Items[i].SubItems[2].Text.Trim() != "IS_LOCK")
                            {
                                MyListView.Items[i].Remove();
                            }
                            MyListView.Refresh();
                        }

                    }
                } while (MyListView.Items.Count != x);
                CkLock.Checked = false;
                CkLock.Refresh();
            }
        }

        private void copiazaInClipBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = 0;
            int z = 0;
            string s = "";
            i = MyListView.SelectedIndices.Count;
            
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
        private void LoadFromPartner(bool IsCustomer,int mOption, string mCriteria)
        {
            string mq = "";
            long x = 0;
            ListViewItem k = null;
           
            this.LblTotalInsert.Text = "0";
            this.LblTotalLock.Text = "0";
            this.LblTotalRecords.Text = "0";
            this.LblTotalUpdate.Text = "0";
            this.Cursor = Cursors.WaitCursor;
            this.MyListView.Items.Clear();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            System.Data.SqlClient.SqlDataReader dataread = null;
            if (IsCustomer == true)
            {
                this.SetListColumns4ViewCustomer();
                if (mCriteria.Trim() == "")
                {
                    mq = "select * from go_customer_def;";
                }
                else
                {
                    if (mOption == 1)  //Code Partener
                    {
                        mq = "select * from go_customer_def where CustomerCode like '" + mCriteria.Trim() + "%' order by CustomerCode;";
                    }
                    else if (mOption == 2) //Denumire Partener
                    {
                        mq = "select * from go_customer_def where CustomerName like '%" + mCriteria.Trim() + "%' order by CustomerName;";
                    }
                }
            }
            else
            {
                this.SetListColumns4ViewSupplier();
                if (mCriteria.Trim() == "")
                {
                    mq = "select * from go_supplier_def;";
                }
                else
                {
                    if (mOption == 1)  //Code partener
                    {
                        mq = "select * from go_supplier_def where SupplierCode like '" + mCriteria.Trim() + "%' order by SupplierCode;";
                    }
                    else if(mOption==2) //Denumire Partener
                    {
                        mq = "select * from go_supplier_def where SupplierName like '%" + mCriteria.Trim() + "%' order by SupplierName;";
                    }
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
                if (IsCustomer == true)
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
                    k.SubItems.Add(MyGlobal.Srch2Escape(dataread[14].ToString().Trim(), "'"));
                    k.SubItems.Add(MyGlobal.Srch2Escape(dataread[15].ToString().Trim(), "'"));
                }
                else
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
                }
                this.MyListView.Items.Add(k);
               
                x++;
            }
            this.MyListView.EndUpdate();
            this.MyListView.Refresh();

            dataread.Close();
            mcmd = null;
            LblTotalInList.Text=x.ToString().Trim();
            this.Cursor = Cursors.Default;
        }
        private void SetListColumns4ViewCustomer()
        {
            ColumnHeader colHead;
            this.MyListView.Clear();
            this.MyListView.Columns.Clear();

            colHead = new ColumnHeader();
            colHead.Text = "CustomerCode";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "CustomerName";
            colHead.Width = 180;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "AddrLine1";
            colHead.Width = 180;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "AddrLine2";
            colHead.Width = 100;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "AddrLine3";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Reference1";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Reference2";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Reference3";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Reference4";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Category";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "FiscalCode";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "DefaultWareHouse";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "AddrLine4";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "mUser";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "InDate";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "UpToDate";
            colHead.Width = 60;
            this.MyListView.Columns.Add(colHead);

            this.MyListView.GridLines = true;
            this.MyListView.FullRowSelect = true;
            this.MyListView.View = View.Details;
        }
        private void SetListColumns4ViewSupplier()
        {
            ColumnHeader colHead;
            this.MyListView.Clear();
            this.MyListView.Columns.Clear();

            colHead = new ColumnHeader();
            colHead.Text = "SupplierCode";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "SupplierName";
            colHead.Width = 180;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "AddrLine1";
            colHead.Width = 180;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "AddrLine2";
            colHead.Width = 100;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "AddrLine3";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Reference";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Category";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "FiscalCode";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "OrganizationType";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);
                        
            colHead = new ColumnHeader();
            colHead.Text = "mUser";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "InDate";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "UpToDate";
            colHead.Width = 60;
            this.MyListView.Columns.Add(colHead);

            this.MyListView.GridLines = true;
            this.MyListView.FullRowSelect = true;
            this.MyListView.View = View.Details;
        }

        private void CmdCauta_Click(object sender, EventArgs e)
        {
            this.LblTInsert.Text = "0";
            this.LblTLock.Text = "0";
            this.LblTotalInsert.Text = "0";
            this.LblTotalLock.Text = "0";
            this.LblTotalRecords.Text = "0";
            this.LblTotalUpdate.Text = "0";
            this.LblTR.Text = "0";
            this.LblTUpdate.Text = "0";
            if (LblObservatii.Visible == true)
            {
                LblObservatii.Visible = false;
                LblObservatii.Text = "";
            }
            if (CkPartType.Checked == false)
            {
                if (txtCauta.Text.Trim() == "")
                {
                    LoadFromPartner(true, 1, "");
                }
                else
                {
                    if (this.rbCodPartener.Checked == true)
                    {
                        LoadFromPartner(true, 1, txtCauta.Text.Trim());
                    }
                    else
                    {
                        LoadFromPartner(true, 2, txtCauta.Text.Trim());
                    }
                }

            }
            else
            {
                if (txtCauta.Text.Trim() == "")
                {
                    LoadFromPartner(false, 1, "");
                }
                else
                {
                    if (this.rbCodPartener.Checked == true)
                    {
                        LoadFromPartner(false, 1, txtCauta.Text.Trim());
                    }
                    else
                    {
                        LoadFromPartner(false, 2, txtCauta.Text.Trim());
                    }
                }
            }
        }
        private void SetComboBoxConditionat(bool IsCustomer)
        {

            DataTable dataTable = new DataTable("Parteneri");
            dataTable.Columns.Add("Camp", typeof(String));
            dataTable.Columns.Add("Descriere", typeof(String));

            this.CmbConditieUpdate.Text = "";
            this.CmbConditieUpdate.DataSource = null;
            this.CmbConditieUpdate.Items.Clear();
            if (IsCustomer == true)
            {
                dataTable.Rows.Add(new String[] { "SL01001", "Cod Client" });
                dataTable.Rows.Add(new String[] { "SL01002", "Nume Client" });
                dataTable.Rows.Add(new String[] { "SL01003", "Adresa Linia 1" });
                dataTable.Rows.Add(new String[] { "SL01004", "Adresa Linia 2" });
                dataTable.Rows.Add(new String[] { "SL01005", "Adresa Linia 3" });
                dataTable.Rows.Add(new String[] { "SL01006", "Referinta 1" });
                dataTable.Rows.Add(new String[] { "SL01007", "Referinta 2" });
                dataTable.Rows.Add(new String[] { "SL01008", "Referinta 3" });
                dataTable.Rows.Add(new String[] { "SL01009", "Referinta 4" });
                dataTable.Rows.Add(new String[] { "SL01010", "Categorie" });
                dataTable.Rows.Add(new String[] { "SL01092", "Cod Fiscal" });
                dataTable.Rows.Add(new String[] { "SL01098", "Gestiune Implicita" });
                dataTable.Rows.Add(new String[] { "SL01099", "Adresa Linia 4" });
            }
            else
            {
                dataTable.Rows.Add(new String[] { "PL01001", "Cod Furnizor" });
                dataTable.Rows.Add(new String[] { "PL01002", "Nume Furnizor" });
                dataTable.Rows.Add(new String[] { "PL01003", "Adresa Linia 1" });
                dataTable.Rows.Add(new String[] { "PL01004", "Adresa Linia 2" });
                dataTable.Rows.Add(new String[] { "PL01005", "Adresa Linia 3" });
                dataTable.Rows.Add(new String[] { "PL01006", "Referinta" });
                dataTable.Rows.Add(new String[] { "PL01007", "Categorie" });
                dataTable.Rows.Add(new String[] { "PL01050", "Tip Organizatie" });
                dataTable.Rows.Add(new String[] { "PL01048", "Cod Fiscal" });
             }
            CmbConditieUpdate.DataSource = dataTable;
            CmbConditieUpdate.DisplayMember = "Camp";
            CmbConditieUpdate.ValueMember = "Descriere";
            LblDescriere.Text = ""; 
            CmbConditieUpdate.Text = "";
            this.Cursor = Cursors.Default;
        }

        private void CmbConditieUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ms = "";
            try
            {
                ms = ((DataRowView)CmbConditieUpdate.SelectedItem).Row.ItemArray[1].ToString();
                this.LblDescriere.ForeColor =System.Drawing.Color.DarkBlue; 
                this.LblDescriere.Text = ms.Trim();
            }
            catch { }
        }

        private void txtCriteria_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtCriteria_KeyDown(object sender, KeyEventArgs e)
        {
                        
            if(e.KeyValue==13)
            {

                if (CmbConditieUpdate.Text.Trim() == "" && this.txtSCriteria.Text.Trim() == "")
                {
                    MessageBox.Show("Ati ales o optiune de import conditionat dar nu ati completat nici un criteriu.");
                    return;
                }
                else if (this.CmbConditieUpdate.Text.Trim() == "" && this.txtSCriteria.Text.Trim() != "")
                {
                    MessageBox.Show("Este completat Criteria dar nu ati selectat nici o optiune.");
                    return;
                }
                else
                {
                    if (this.CkPartType.Checked == false)
                    {
                        MY_CONDITIONAL_UPDATE_SETTINGS[0] = this.CmbConditieUpdate.Text.Trim() + " " + this.txtCriteria.Text.Trim();
                        LblObservatii.Visible = true;
                        LblObservatii.Text="Validat : " + MY_CONDITIONAL_UPDATE_SETTINGS[0].Trim();
                    }
                    else
                    {
                        MY_CONDITIONAL_UPDATE_SETTINGS[1] = this.CmbConditieUpdate.Text.Trim() + " " + this.txtCriteria.Text.Trim();
                        LblObservatii.Visible = true;
                        LblObservatii.Text = "Validat : " + MY_CONDITIONAL_UPDATE_SETTINGS[1].Trim();
                    }
                    this.txtCriteria.Text = "";
                    this.CmbConditieUpdate.Text = "";
                    this.LblDescriere.Text = "";
                }
                
            }
        }

        private void MyListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                MY_CANCEL = true;    
            }
        }

    }
}